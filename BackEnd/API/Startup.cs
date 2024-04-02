using API.Helpers;
using API.Middleware;
using API.Models;
using API.Servivces;
using API.Servivces.Implementation;
using API.Servivces.Implementation.DetailedEmployee;
using API.Servivces.Implementation.Localization;
using API.Servivces.Interfaces;
using API.Servivces.Interfaces.DetailedEmployee;
using API.Servivces.Interfaces.FinancialServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using API.Middleware;
using Microsoft.Extensions.Options;
using DinkToPdf.Contracts;
using DinkToPdf;

namespace API
{
    public class Startup
    {
        private static string _coreOriginPolicyName = "CoreAllowPolicy";
        public IConfiguration _config { get; }
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<IISServerOptions>(Options =>
            {
                Options.MaxRequestBodySize = int.MaxValue;
            });
            //
             services.AddScoped<ITokenService, TokenService>();
            //
            services.AddScoped<ILocalizationService, LocalizationService>();
            //
            services.AddScoped<IDetailedEmployeeService, DetailedEmployeeService>();
            //
            services.AddScoped<IFunctionMstService, FunctionMstService>();
            //
            services.AddScoped<IUserMstService, UserMstService>();
            //
            services.AddScoped<IRefTableService, RefTableService>();
            //
            services.AddScoped<IFunctionUserService, FunctionUserService>();
            //
            services.AddScoped<ICrupMstServivce, CrupMstService>();
            //
            services.AddScoped<ICrupAuditService, CrupAuditService>();
            //
            services.AddScoped<ILoginService, LoginService>();
            //
            services.AddScoped<ICommonService, CommonService>();
            //
            services.AddScoped<IServiceSetupService, ServiceSetupService>();
            //
            services.AddScoped<IFinancialService, FinancialService>();
            //
            services.AddScoped<IFinancialTransactionService, FinancialTransactionService>();
            //
            services.AddScoped<IOfferService, OfferService>();
            //
            services.AddScoped<IDisplayCrupAuditService, DisplayCrupAuditService>();
            //
            services.AddScoped<ICommunicationService, CommunicationService>();

            //
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            //
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IFormHeaderService, FormHeaderService>();
            services.AddScoped<IDashBoardService, DashBoardService>();
            services.AddScoped<IReportsService, ReportsService>();
            //
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

            services.AddDbContext<KUPFDbContext>(options =>
            {
                options.UseSqlServer(_config.GetConnectionString("MsSqlConnection"));
            });
            //Enable CORS    
            //services.AddCors(c =>    
            //{    
            //    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod()    
            //     .AllowAnyHeader());    
            //});   
            //services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            //{
            //    builder.WithOrigins("http://localhost:4200", "https://kupf.erp53.com", "https://localhost:44336")
            //           .AllowAnyMethod()
            //           .AllowAnyHeader();
            //}));
            services.AddControllers();            
            services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
            services.AddCors(options =>
            {
                options.AddPolicy(_coreOriginPolicyName,
                    builder =>
                    {
                        builder
                        .WithOrigins("http://localhost:4200","https://kupf.erp53.com", "http://kupfweb.erp53.com", "https://kupfapi.erp53.com")
                        .AllowAnyMethod()
                        .AllowAnyHeader().AllowAnyOrigin();
                    });
            });
            services.AddSwaggerGen(c =>
            {
                //c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                   
                    Title = "KUPF API",
                    Version = "v1",
                    Description = "An API to perform KUPF operations",             
                    
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            services.AddCors();
            services.AddTokenAuthentication(_config);
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuerSigningKey = true,
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["TokenKey"])),
            //            ValidateIssuer = false,
            //            ValidateAudience = false
            //        };
            //    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //app.UseCors(options=> 
            //options.WithOrigins("http://localhost:4200", "https://kupf.erp53.com", "https://localhost:44336")
            //.AllowAnyMethod()
            //.AllowAnyHeader());
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            app.UseMiddleware<ExceptionMiddleware>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            if (env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(_coreOriginPolicyName);
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
