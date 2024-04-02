using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;

#nullable disable

namespace API.Models
{
    public partial class KUPFDbContext : DbContext
    {
        
        public KUPFDbContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<AccountHead> AccountHeads { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<ChequeBook> ChequeBooks { get; set; }
        public DbSet<Coa> Coas { get; set; }
        public DbSet<CostCenter> CostCenters { get; set; }
        public DbSet<CrupMst> CrupMsts { get; set; }
        public DbSet<Crupaudit> Crupaudits { get; set; }
        public DbSet<DeletedVoucher> DeletedVouchers { get; set; }
        public DbSet<DetailedEmployee> DetailedEmployees { get; set; }
        public DbSet<EmployeeDetailsWithHistory> EmployeeDetailsWithHistorys { get; set; }
        public DbSet<DetailedEmployeeImport> DetailedEmployeeImports { get; set; }
        public DbSet<DrCrTemplate> DrCrTemplates { get; set; }
        public DbSet<FaaccountGroup> FaaccountGroups { get; set; }
        public DbSet<FaactIntegSetup> FaactIntegSetups { get; set; }
        public DbSet<FaactPredGroup> FaactPredGroups { get; set; }
        public DbSet<FacashBankMaster> FacashBankMasters { get; set; }
        public DbSet<FachequeBook> FachequeBooks { get; set; }
        public DbSet<FacostCenter> FacostCenters { get; set; }
        public DbSet<Faglaccount> Faglaccounts { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Faslaccount> Faslaccounts { get; set; }
        public DbSet<FinancialPeriod> FinancialPeriods { get; set; }
        public DbSet<FormTitleDt> FormTitleDt { get; set; }
        public DbSet<FormTitleHd> FormTitleHd { get; set; }
        public DbSet<Iccatsubcat> Iccatsubcats { get; set; }
        public DbSet<LettersHd> LettersHds { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Mapping> Mappings { get; set; }
        public DbSet<MappingHead> MappingHeads { get; set; }
        public DbSet<Mycompanysetup> Mycompanysetups { get; set; }
        public DbSet<RefLabelMst> RefLabelMsts { get; set; }
        public DbSet<RefTableAdmin> RefTableAdmins { get; set; }
        public DbSet<Reftable> Reftables { get; set; }
        public DbSet<ServiceSetup> ServiceSetups { get; set; }
        public DbSet<SubHead> SubHeads { get; set; }
        public DbSet<SubSubHead> SubSubHeads { get; set; }
        public DbSet<TblAccountMst> TblAccountMsts { get; set; }
        public DbSet<TblActSlsetup> TblActSlsetups { get; set; }
        public DbSet<TblAudit> TblAudits { get; set; }
        public DbSet<TblCityStatesCounty> TblCityStatesCounties { get; set; }
        public DbSet<TblCountry> TblCountries { get; set; }
        public DbSet<TblDistrictStatesCounty> TblDistrictStatesCounties { get; set; }
        public DbSet<TblImportCoa> TblImportCoas { get; set; }
        public DbSet<TblImportCoav2> TblImportCoav2s { get; set; }
        public DbSet<TblImportVoucher> TblImportVouchers { get; set; }
        public DbSet<TblState> TblStates { get; set; }
        public DbSet<Tblcompanysetup> Tblcompanysetups { get; set; }
        public DbSet<TblcontactDelAdre> TblcontactDelAdres { get; set; }
        public DbSet<Tblperiod> Tblperiods { get; set; }
        public DbSet<Tbltranssubtype> Tbltranssubtypes { get; set; }
        public DbSet<Tbltranstype> Tbltranstypes { get; set; }
        public DbSet<TestTable> TestTables { get; set; }
        public DbSet<TotalJv> TotalJvs { get; set; }
        public DbSet<TransactionDt> TransactionDts { get; set; }
        public DbSet<TransactionHd> TransactionHds { get; set; }
        public DbSet<TransDTSubMonthly> TransDTSubMonthlies { get; set; }
        public DbSet<TransactionHddapprovalDetail> TransactionHddapprovalDetails { get; set; }
        public DbSet<TransactionHddm> TransactionHddms { get; set; }
        public DbSet<TreeFunction> TreeFunctions { get; set; }
        public DbSet<TreeNode> TreeNodes { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserDtl> UserDtls { get; set; }
        public DbSet<UserMst> UserMsts { get; set; }
        public DbSet<UserPage> UserPages { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<VoucherDetail> VoucherDetails { get; set; }
        public DbSet<VoucherDetailHistory> VoucherDetailHistories { get; set; }
        public DbSet<VoucherType> VoucherTypes { get; set; }
        public DbSet<VwAwstatusCatWise> VwAwstatusCatWises { get; set; }
        public DbSet<WebPage> WebPages { get; set; }
        public DbSet<WebPageUrl> WebPageUrls { get; set; }
        public DbSet<TestCompany> TestCompanies { get; set; }
        public DbSet<TestEmployee> TestEmployees { get; set; }
        public DbSet<FormTitleHDLanguage> FormTitleHDLanguage { get; set; }
        public DbSet<FormTitleDTLanguage> FormTitleDTLanguage { get; set; }
        public DbSet<FUNCTION_MST> FUNCTION_MST { get; set; }
        public DbSet<FUNCTION_USER> FUNCTION_USER { get; set; }
        public DbSet<ServiceSubscription> ServiceSubscription { get; set; } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AccountHead>(builder =>
               {
                   builder.HasNoKey();
                   builder.ToTable("AccountHead");
                   builder.Property(e => e.BalanceAmt)
                   .HasColumnType("decimal(18, 2)")
                   .HasDefaultValueSql("((0))");
               });

            // modelBuilder.Entity<FormTitleHDLanguage>()
            //     .HasMany(p=>p.FormTitleDTLanguage)
            //     .WithOne(c=>c.FormTitleHDLanguage)
            //     .HasPrincipalKey(p => new {p.FormId, p.FormTitleDTLanguage})
            //     .IsRequired();


                    // modelBuilder.Entity<AccountHead>(entity =>
            // {
            //     entity.HasKey(e => new { e.TenentId, e.LocationId, e.HeadId });

            //     entity.ToTable("AccountHead", "Accounts");

            //     entity.Property(e => e.TenentId)
            //         .HasColumnName("TenentID")
            //         .HasDefaultValueSql("((1))");

            //     entity.Property(e => e.LocationId).HasColumnName("LocationID");

            //     entity.Property(e => e.HeadId).HasColumnName("HeadID");

            //     entity.Property(e => e.ArabicHeadName).HasMaxLength(250);

            //     entity.Property(e => e.BalanceAmt)
            //         .HasColumnType("decimal(18, 2)")
            //         .HasDefaultValueSql("((0))");

            //     entity.Property(e => e.Crupid).HasColumnName("crupid");

            //     entity.Property(e => e.FamilyId).HasColumnName("Family_ID");

            //     entity.Property(e => e.HeadName).HasMaxLength(250);

            //     entity.Property(e => e.IsActive)
            //         .IsRequired()
            //         .HasDefaultValueSql("((1))");
            // });

            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.ToTable("AccountTypes", "Accounts");

                entity.Property(e => e.AccountTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("AccountTypeID");

                entity.Property(e => e.AccountTypeName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'Name')");

                entity.Property(e => e.ArabicAccountTypeName).HasMaxLength(200);
            });

            modelBuilder.Entity<ChequeBook>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.LocationId, e.ChequeBookId });

                entity.ToTable("ChequeBooks", "Accounts");

                entity.Property(e => e.TenentId).HasColumnName("TenentID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.ChequeBookId).HasColumnName("ChequeBookID");

                entity.Property(e => e.AccountId).HasColumnName("Account_ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EntryDate).HasColumnType("date");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Coa>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.LocationId, e.AccountId });

                entity.ToTable("COA", "Accounts");

                entity.Property(e => e.TenentId)
                    .HasColumnName("TenentID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LocationId).HasColumnName("locationID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.AccountName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.AccountTypeId).HasColumnName("AccountType_ID");

                entity.Property(e => e.ArabicAccountName).HasMaxLength(500);

                entity.Property(e => e.BankAccountNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Crupid).HasColumnName("crupid");

                entity.Property(e => e.FamilyId).HasColumnName("Family_ID");

                entity.Property(e => e.HeadId).HasColumnName("Head_ID");

                entity.Property(e => e.OtherAccountName).HasMaxLength(500);

                entity.Property(e => e.SubHeadId).HasColumnName("SubHead_ID");

                entity.Property(e => e.SubSubHeadId).HasColumnName("SubSubHead_ID");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CostCenter>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.LocationId, e.CostCenterId });

                entity.ToTable("CostCenters", "Accounts");

                entity.Property(e => e.TenentId)
                    .HasColumnName("TenentID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LocationId).HasColumnName("locationID");

                entity.Property(e => e.CostCenterId).HasColumnName("CostCenterID");

                entity.Property(e => e.ArabicCostCenterName).HasMaxLength(300);

                entity.Property(e => e.CostCenterName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Crupid).HasColumnName("crupid");

                entity.Property(e => e.OtherCostCenterName).HasMaxLength(300);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CrupMst>(entity =>
            {
                entity.HasKey(e => new { e.TenantId, e.LocationId, e.CrupId })
                    .HasName("PK_ERP_CREATEUPDATE_MST");

                entity.ToTable("CRUP_MST");

                entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.CrupId).HasColumnName("CRUP_ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedDt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_DT");

                entity.Property(e => e.MenuId).HasColumnName("MENU_ID");

                entity.Property(e => e.Physicallocid)
                    .HasMaxLength(100)
                    .HasColumnName("PHYSICALLOCID");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDt)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_DT");
            });

            modelBuilder.Entity<Crupaudit>(entity =>
            {
                entity.HasKey(e => new { e.TenantId, e.LocationId, e.CrupId, e.MySerial, e.AuditNo })
                    .HasName("PK_CRUPAuditAudit");

                entity.ToTable("CRUPAudit");

                entity.Property(e => e.TenantId)
                    .HasColumnName("TENANT_ID")
                    .HasDefaultValueSql("((18))");

                entity.Property(e => e.LocationId)
                    .HasColumnName("LocationID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CrupId).HasColumnName("CRUP_ID");

                entity.Property(e => e.AuditNo).ValueGeneratedOnAdd();

                entity.Property(e => e.AuditType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedUserName)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.FieldName)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateUserName)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DeletedVoucher>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.LocationId, e.VoucherId });

                entity.ToTable("DeletedVoucher", "Accounts");

                entity.Property(e => e.TenentId).HasColumnName("TenentID");

                entity.Property(e => e.LocationId).HasColumnName("locationID");

                entity.Property(e => e.VoucherId).HasColumnName("VoucherID");

                entity.Property(e => e.AccountId).HasColumnName("Account_ID");

                entity.Property(e => e.CostCenterId).HasColumnName("CostCenter_ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Crupid).HasColumnName("crupid");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.FperiodId).HasColumnName("FPeriod_ID");

                entity.Property(e => e.Narrations).HasMaxLength(500);

                entity.Property(e => e.ReceiverName).HasMaxLength(500);

                entity.Property(e => e.ReferenceNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.VoucherCode)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.VoucherDate).HasColumnType("date");

                entity.Property(e => e.VoucherTypeId).HasColumnName("VoucherType_ID");
            });

            modelBuilder.Entity<DetailedEmployee>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.LocationId, e.EmployeeId })
                    .HasName("PK_tbl_Employee");

                entity.ToTable("DetailedEmployee");

                entity.HasIndex(e => new { e.TenentId, e.Pfid }, "IX_DetailedEmployee");

                entity.Property(e => e.TenentId).HasColumnName("TenentID");

                entity.Property(e => e.LocationId)
                    .HasColumnName("LocationID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(20)
                    .HasColumnName("employeeID");

                entity.Property(e => e.ActiveDirectoryId)
                    .HasMaxLength(100)
                    .HasColumnName("ActiveDirectoryID");

                entity.Property(e => e.AgreedSubAmount).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.ArabicName).HasMaxLength(200);

                entity.Property(e => e.CityCode)
                    .HasMaxLength(50)
                    .HasColumnName("city_code")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ContractType).HasMaxLength(50);

                entity.Property(e => e.CounCode)
                    .HasColumnName("coun_code")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Department).HasComment("Coming from RefTable RefSubType='Department'");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(200)
                    .HasColumnName("Department_Name");

                entity.Property(e => e.DeviceId)
                    .HasMaxLength(50)
                    .HasColumnName("DeviceID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EmpBirthday)
                    .HasColumnType("datetime")
                    .HasColumnName("emp_birthday");

                entity.Property(e => e.EmpCidNum)
                    .HasMaxLength(100)
                    .HasColumnName("emp_cid_num")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EmpGender).HasColumnName("emp_gender");

                entity.Property(e => e.EmpMaritalStatus)
                    .HasMaxLength(20)
                    .HasColumnName("emp_marital_status");

                entity.Property(e => e.EmpOtherId)
                    .HasMaxLength(100)
                    .HasColumnName("emp_other_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EmpPaciNum)
                    .HasMaxLength(100)
                    .HasColumnName("emp_paci_num")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EmpStatus)
                    .HasColumnName("EmpStatus")
                    .HasColumnType("int");

                entity.Property(e => e.EmpStreet1)
                    .HasMaxLength(100)
                    .HasColumnName("emp_street1")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EmpStreet2)
                    .HasMaxLength(100)
                    .HasColumnName("emp_street2")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EmpWorkEmail)
                    .HasMaxLength(50)
                    .HasColumnName("emp_work_email")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EmpWorkTelephone)
                    .HasMaxLength(50)
                    .HasColumnName("emp_work_telephone")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EmployeeLoginId)
                    .HasMaxLength(100)
                    .HasColumnName("EmployeeLoginID");

                entity.Property(e => e.EmployeePassword).HasMaxLength(150);

                entity.Property(e => e.EmployeeType)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("(N'1')")
                    .HasComment("1= Employee, 2= Non Employee");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("End_date");

                entity.Property(e => e.EnglishName).HasMaxLength(200);

                entity.Property(e => e.HajjAct).HasMaxLength(50);

                entity.Property(e => e.JobTitleCode)
                    .HasColumnName("job_title_code")
                    .HasDefaultValueSql("((1))")
                    .HasComment("Coming from RefTable RefSubType='Role'");

                entity.Property(e => e.JobTitleName)
                    .HasMaxLength(200)
                    .HasColumnName("job_title_Name");

                entity.Property(e => e.JoinedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("joined_date");

                entity.Property(e => e.LoanAct).HasMaxLength(50);

                entity.Property(e => e.MainHrroleId)
                    .HasColumnName("MainHRRoleID")
                    .HasComment("Coming from RefTable RefSubType='Role'");

                entity.Property(e => e.MobileNumber).HasMaxLength(15);

                entity.Property(e => e.NationCode)
                    .HasColumnName("nation_code")
                    .HasDefaultValueSql("((126))")
                    .HasComment("Nationality Code from tblcountry");

                entity.Property(e => e.NationName)
                    .HasMaxLength(200)
                    .HasColumnName("nation_Name");

                entity.Property(e => e.Next2KinMobNumber).HasMaxLength(15);

                entity.Property(e => e.Next2KinName).HasMaxLength(200);

                entity.Property(e => e.OtherAct1)
                    .HasMaxLength(50)
                    .HasComment("contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account");

                entity.Property(e => e.OtherAct2)
                    .HasMaxLength(50)
                    .HasComment("contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account");

                entity.Property(e => e.OtherAct3)
                    .HasMaxLength(50)
                    .HasComment("contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account");

                entity.Property(e => e.OtherAct4)
                    .HasMaxLength(50)
                    .HasComment("contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account");

                entity.Property(e => e.OtherAct5)
                    .HasMaxLength(50)
                    .HasComment("contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account");

                entity.Property(e => e.PersLoanAct).HasMaxLength(50);

                entity.Property(e => e.Pfid)
                    .HasMaxLength(20)
                    .HasColumnName("PFID");

                entity.Property(e => e.ReSubscribed).HasColumnType("datetime");

                entity.Property(e => e.ReSubscripedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ReSubscriped_date");

                entity.Property(e => e.Remarks).HasMaxLength(500);

                entity.Property(e => e.Salary)
                    .HasColumnType("numeric(18, 3)")
                    .HasColumnName("salary");

                entity.Property(e => e.SubscribedDate).HasColumnType("datetime");

                entity.Property(e => e.SubscriptionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("subscription_date");

                entity.Property(e => e.SynId).HasColumnName("SynID");

                entity.Property(e => e.SyncDate).HasColumnType("datetime");

                entity.Property(e => e.Syncby).HasMaxLength(50);

                entity.Property(e => e.TerminationId)
                    .HasColumnName("termination_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UploadDate).HasColumnType("datetime");

                entity.Property(e => e.Uploadby).HasMaxLength(50);

                entity.Property(e => e.UserId)
                    .HasMaxLength(100)
                    .HasColumnName("userID");
            });

            modelBuilder.Entity<DetailedEmployeeImport>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.LocationId, e.EmployeeId });

                entity.ToTable("DetailedEmployee_Import");

                entity.Property(e => e.TenentId).HasColumnName("TenentID");

                entity.Property(e => e.LocationId)
                    .HasColumnName("LocationID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeID");

                entity.Property(e => e.ActiveDirectoryId)
                    .HasMaxLength(100)
                    .HasColumnName("ActiveDirectoryID");

                entity.Property(e => e.ArabicName).HasMaxLength(200);

                entity.Property(e => e.CityCode)
                    .HasMaxLength(50)
                    .HasColumnName("city_code")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CounCode)
                    .HasColumnName("coun_code")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Department).HasComment("Coming from RefTable RefSubType='Department'");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(200)
                    .HasColumnName("Department_Name");

                entity.Property(e => e.DeviceId)
                    .HasMaxLength(50)
                    .HasColumnName("DeviceID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EmpBirthday)
                    .HasColumnType("datetime")
                    .HasColumnName("emp_birthday");

                entity.Property(e => e.EmpCidNum)
                    .HasMaxLength(100)
                    .HasColumnName("emp_cid_num")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EmpGender).HasColumnName("emp_gender");

                entity.Property(e => e.EmpMaritalStatus)
                    .HasMaxLength(20)
                    .HasColumnName("emp_marital_status");

                entity.Property(e => e.EmpOtherId)
                    .HasColumnName("emp_other_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EmpPaciNum)
                    .HasMaxLength(100)
                    .HasColumnName("emp_paci_num")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EmpStatus)
                    .HasColumnName("EmpStatus")
                    .HasColumnType("int");

                entity.Property(e => e.EmpStreet1)
                    .HasMaxLength(100)
                    .HasColumnName("emp_street1")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EmpStreet2)
                    .HasMaxLength(100)
                    .HasColumnName("emp_street2")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EmpWorkEmail)
                    .HasMaxLength(50)
                    .HasColumnName("emp_work_email")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EmpWorkTelephone)
                    .HasMaxLength(50)
                    .HasColumnName("emp_work_telephone")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EmployeeType)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("(N'1')")
                    .HasComment("1= Employee, 2= Non Employee");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("End_date");

                entity.Property(e => e.EnglishName).HasMaxLength(200);

                entity.Property(e => e.HajjAct).HasMaxLength(50);

                entity.Property(e => e.Importdate)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("IMPORTDATE");

                entity.Property(e => e.JobTitleCode)
                    .HasColumnName("job_title_code")
                    .HasDefaultValueSql("((1))")
                    .HasComment("Coming from RefTable RefSubType='Role'");

                entity.Property(e => e.JobTitleName)
                    .HasMaxLength(200)
                    .HasColumnName("job_title_name");

                entity.Property(e => e.JoinedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("joined_date");

                entity.Property(e => e.LoanAct).HasMaxLength(50);

                entity.Property(e => e.MainHrroleId)
                    .HasColumnName("MainHRRoleID")
                    .HasComment("Coming from RefTable RefSubType='Role'");

                entity.Property(e => e.MobileNumber).HasMaxLength(15);

                entity.Property(e => e.NationCode)
                    .HasColumnName("nation_code")
                    .HasDefaultValueSql("((126))")
                    .HasComment("Nationality Code from tblcountry");

                entity.Property(e => e.Next2KinMobNumber).HasMaxLength(15);

                entity.Property(e => e.Next2KinName).HasMaxLength(200);

                entity.Property(e => e.OtherAct1)
                    .HasMaxLength(50)
                    .HasComment("contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account");

                entity.Property(e => e.OtherAct2)
                    .HasMaxLength(50)
                    .HasComment("contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account");

                entity.Property(e => e.OtherAct3)
                    .HasMaxLength(50)
                    .HasComment("contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account");

                entity.Property(e => e.OtherAct4)
                    .HasMaxLength(50)
                    .HasComment("contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account");

                entity.Property(e => e.OtherAct5)
                    .HasMaxLength(50)
                    .HasComment("contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account");

                entity.Property(e => e.Password)
                    .HasMaxLength(150)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.PersLoanAct).HasMaxLength(50);

                entity.Property(e => e.Pfid)
                    .HasMaxLength(20)
                    .HasColumnName("PFID");

                entity.Property(e => e.ReSubscripedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ReSubscriped_date");

                entity.Property(e => e.Remarks).HasMaxLength(500);

                entity.Property(e => e.Salary)
                    .HasColumnType("numeric(18, 3)")
                    .HasColumnName("salary");

                entity.Property(e => e.StudenLoginId)
                    .HasMaxLength(100)
                    .HasColumnName("Studen_LoginID");

                entity.Property(e => e.SubscriptionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("subscription_date");

                entity.Property(e => e.SynId).HasColumnName("SynID");

                entity.Property(e => e.SyncDate).HasColumnType("datetime");

                entity.Property(e => e.Syncby).HasMaxLength(50);

                entity.Property(e => e.TerminationId)
                    .HasColumnName("termination_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UploadDate).HasColumnType("datetime");

                entity.Property(e => e.Uploadby).HasMaxLength(50);

                entity.Property(e => e.UserId)
                    .HasMaxLength(100)
                    .HasColumnName("userID");
            });

            modelBuilder.Entity<DrCrTemplate>(entity =>
            {
                entity.HasKey(e => e.TemplateId)
                    .HasName("PK__DrCrTemp__F87ADD07FC51001D");

                entity.ToTable("DrCrTemplate", "Accounts");

                entity.Property(e => e.TemplateId).HasColumnName("TemplateID");

                entity.Property(e => e.AccountId).HasColumnName("Account_ID");

                entity.Property(e => e.ArabicTemplateName).HasMaxLength(500);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(1000);

                entity.Property(e => e.TemplateName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<FaaccountGroup>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.LocationId, e.ActGroupId })
                    .HasName("PK_AccountGroup");

                entity.ToTable("FAAccountGroup");

                entity.Property(e => e.TenentId).HasColumnName("TenentID");

                entity.Property(e => e.LocationId).HasDefaultValueSql("((1))");

                entity.Property(e => e.ActGroupId).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))")
                    .HasComment("1=Yes / 0=No");

                entity.Property(e => e.CrupId).HasColumnName("CRUP_ID");

                entity.Property(e => e.Cuserid)
                    .HasMaxLength(50)
                    .HasColumnName("CUSERID");

                entity.Property(e => e.DefaultCc)
                    .HasMaxLength(20)
                    .HasColumnName("DefaultCC");

                entity.Property(e => e.DisplayOrder)
                    .HasDefaultValueSql("((1))")
                    .HasComment("");

                entity.Property(e => e.EffectGrossProfit).HasComment("1=Yes/ 0=No");

                entity.Property(e => e.Glsl)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GLSL")
                    .HasComment("GL/SL");

                entity.Property(e => e.GroupDesc1)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.GroupDesc2).HasMaxLength(200);

                entity.Property(e => e.GroupDesc3).HasMaxLength(200);

                entity.Property(e => e.GroupNatureType)
                    .HasMaxLength(2)
                    .HasComment("1=Income, 2= Expenditure");

                entity.Property(e => e.GroupSubType).HasComment("REFID From the RefTable REFTYPE=AccountTyp REFSUBTYPE=SubType based upon above choosen Account Type this sub type will be displayed");

                entity.Property(e => e.GroupType).HasComment("REFID From the RefTable REFTYPE=AccountTyp REFSUBTYPE=Type (Assets, Liabilities, Equity, Revenue, Expenses)");

                entity.Property(e => e.GroupUnder)
                    .HasMaxLength(20)
                    .HasComment("The Main Group is from the same Table");

                entity.Property(e => e.InternalGroupId).HasComment("coming from REFID from RefType=ACT RefSubtype=Group");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<FaactIntegSetup>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.LocationId, e.Transid, e.Mysysname, e.Transsubid, e.ActIntegrationId, e.AccountId });

                entity.ToTable("FAActIntegSetup");

                entity.Property(e => e.TenentId).HasColumnName("TenentID");

                entity.Property(e => e.LocationId).HasDefaultValueSql("((1))");

                entity.Property(e => e.Transid)
                    .HasColumnName("transid")
                    .HasComment("tbltranssubtype.Transid for the Selected above System");

                entity.Property(e => e.Mysysname)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("MYSYSNAME")
                    .HasComment("tblsystems.mysysname for the exist unique tbltranssubtype.mysysname record in tbltranssubtype");

                entity.Property(e => e.Transsubid)
                    .HasColumnName("transsubid")
                    .HasComment("tbltranssubtype.Transsubid for the Selected above System");

                entity.Property(e => e.ActIntegrationId)
                    .HasMaxLength(2)
                    .HasColumnName("ActIntegrationID")
                    .HasDefaultValueSql("((0))")
                    .HasComment("1=CostOSales,2=Sales,3=Items Related Expenses");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(20)
                    .HasColumnName("AccountID")
                    .HasComment("From the FASLAccount.SLAccountID to be used here where the type of the account to be decided like expense etc");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Consolidation).HasComment("Cost Center yet no drop down available but for the future use");

                entity.Property(e => e.ConsolidationType)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasDefaultValueSql("((0))")
                    .IsFixedLength(true)
                    .HasComment("Consolidation MO=Monthly / WK=Weekly / DA=Daily / YR=Yearly / PR=Once in the Period");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))")
                    .HasComment("Consolidation 1=Yes / 0=No");

                entity.Property(e => e.CrupId).HasColumnName("CRUP_ID");

                entity.Property(e => e.DefaultCc)
                    .HasMaxLength(20)
                    .HasColumnName("DefaultCC")
                    .HasComment("Cost Center yet no drop down available but for the future use");

                entity.Property(e => e.FromCatSubId)
                    .HasColumnName("FromCatSubID")
                    .HasComment("tblCategory having self Join");

                entity.Property(e => e.FromItemId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasComment("From the MYPRODID.TBLPRODUCT incase of one Item than From & To remain Same");

                entity.Property(e => e.GroupId)
                    .HasMaxLength(20)
                    .HasColumnName("GroupID")
                    .HasComment("The  FAAcountGroup.ActGroupID to be used as default yet no action needed from this");

                entity.Property(e => e.IntegrationDesc1)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.IntegrationDesc2).HasMaxLength(200);

                entity.Property(e => e.IntegrationDesc3).HasMaxLength(200);

                entity.Property(e => e.ToCatSubId)
                    .HasColumnName("ToCatSubID")
                    .HasComment("tblCategory having self Join");

                entity.Property(e => e.ToItemId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasComment("From the MYPRODID.TBLPRODUCT incase of one Item than From & To remain Same");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<FaactPredGroup>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.LocationId, e.ActPredGroupId });

                entity.ToTable("FAActPredGroup");

                entity.Property(e => e.TenentId).HasColumnName("TenentID");

                entity.Property(e => e.ActPredGroupId)
                    .HasMaxLength(20)
                    .HasComment("User will enter and not allowed to change any predefined here it is fixed");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))")
                    .HasComment("1=Yes / 0=No");

                entity.Property(e => e.CrupId).HasColumnName("CRUP_ID");

                entity.Property(e => e.Cuserid)
                    .HasMaxLength(50)
                    .HasColumnName("CUSERID");

                entity.Property(e => e.DefaultCc)
                    .HasMaxLength(20)
                    .HasColumnName("DefaultCC");

                entity.Property(e => e.Description1).HasMaxLength(200);

                entity.Property(e => e.Description2).HasMaxLength(200);

                entity.Property(e => e.Description3).HasMaxLength(200);

                entity.Property(e => e.Glsl)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GLSL")
                    .HasComment("GL/SL");

                entity.Property(e => e.GroupNatureType).HasMaxLength(20);

                entity.Property(e => e.GroupSubType).HasComment("REFID From the RefTable REFTYPE=AccountTyp REFSUBTYPE=SubType based upon above choosen Account Type this sub type will be displayed");

                entity.Property(e => e.GroupType).HasComment("REFID From the RefTable REFTYPE=AccountTyp REFSUBTYPE=Type (Assets, Liabilities, Equity, Revenue, Expenses)");

                entity.Property(e => e.GroupUnder).HasMaxLength(100);

                entity.Property(e => e.InternalGroupId).HasComment("coming from REFID from RefType=ACT RefSubtype=Group");

                entity.Property(e => e.LeftRight)
                    .HasMaxLength(1)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<FacashBankMaster>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.LocationId, e.AcountId });

                entity.ToTable("FACashBankMaster");

                entity.Property(e => e.TenentId).HasColumnName("TenentID");

                entity.Property(e => e.AccountName1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AccountName2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AccountName3)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovedDate).HasColumnType("datetime");

                entity.Property(e => e.ChequeDate).HasColumnType("datetime");

                entity.Property(e => e.ChequeMiti)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ChequeNo).IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CurrentBalance)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fyid).HasColumnName("FYid");

                entity.Property(e => e.PreDefinedAccount)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Rate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks).IsUnicode(false);

                entity.Property(e => e.SortingOrder)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.VoucherDate).HasColumnType("datetime");

                entity.Property(e => e.VoucherMiti).IsUnicode(false);

                entity.Property(e => e.VoucherNo).IsUnicode(false);
            });

            modelBuilder.Entity<FachequeBook>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.ChequeId });

                entity.ToTable("FAChequeBook");

                entity.Property(e => e.TenentId).HasColumnName("TenentID");

                entity.Property(e => e.ChequeId).HasColumnName("ChequeID");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.BankId).HasColumnName("BankID");

                entity.Property(e => e.ChequeName1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ChequeName2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ChequeName3)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Compid).HasColumnName("COMPID");

                entity.Property(e => e.ContactMyId).HasColumnName("ContactMyID");

                entity.Property(e => e.CrupId).HasColumnName("CRUP_ID");

                entity.Property(e => e.DateOutFromBank).HasColumnType("datetime");

                entity.Property(e => e.Dated).HasColumnType("datetime");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Switch1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SWITCH1");

                entity.Property(e => e.SyncDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<FacostCenter>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.LocationId, e.CostCenterId });

                entity.ToTable("FACostCenter");

                entity.Property(e => e.TenentId).HasColumnName("TenentID");

                entity.Property(e => e.CostCenterId)
                    .HasMaxLength(20)
                    .HasColumnName("CostCenterID")
                    .HasComment("User will enter and not allowed to change any predefined here it is fixed");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CostCenterName1).HasMaxLength(200);

                entity.Property(e => e.CostCenterName2).HasMaxLength(200);

                entity.Property(e => e.CostCenterName3).HasMaxLength(200);

                entity.Property(e => e.CrupId).HasColumnName("CRUP_ID");

                entity.Property(e => e.Cuserid)
                    .HasMaxLength(50)
                    .HasColumnName("CUSERID");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("DepartmentID")
                    .HasComment("HRMSDepartment.DepartmentID where active=Y");

                entity.Property(e => e.GlcontrolAccountId)
                    .HasMaxLength(20)
                    .HasColumnName("GLControlAccountID")
                    .HasDefaultValueSql("((0))")
                    .HasComment("Status of this CC will be reported here in the GL to know actually how this CC");

                entity.Property(e => e.GroupUnder)
                    .HasMaxLength(100)
                    .HasComment("Stock or Investment in the Hand will be reported in this Account here");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("ProjectID")
                    .HasComment("tblProject.ProjectID where active=Y");

                entity.Property(e => e.SlexpenseAccountId)
                    .HasMaxLength(20)
                    .HasColumnName("SLExpenseAccountID")
                    .HasDefaultValueSql("((0))")
                    .HasComment("all the expenses of this CC will be reported here");

                entity.Property(e => e.SlrevenueAccountId)
                    .HasMaxLength(20)
                    .HasColumnName("SLRevenueAccountID")
                    .HasDefaultValueSql("((0))")
                    .HasComment("all the Revenue of this CC will be reported here");

                entity.Property(e => e.SlstockInHandAccountId)
                    .HasMaxLength(20)
                    .HasColumnName("SLStockInHandAccountID")
                    .HasDefaultValueSql("((0))")
                    .HasComment("all the expenses of this CC will be reported here");
            });

            modelBuilder.Entity<Faglaccount>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.LocationId, e.GlaccountId })
                    .HasName("PK_FAAccountLedger")
                    .IsClustered(false);

                entity.ToTable("FAGLAccount");

                entity.Property(e => e.TenentId).HasColumnName("TenentID");

                entity.Property(e => e.LocationId).HasDefaultValueSql("((1))");

                entity.Property(e => e.GlaccountId)
                    .HasMaxLength(20)
                    .HasColumnName("GLAccountID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ActGroupId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("FAAcountGroup.ActGroupID where GLSL=GL");

                entity.Property(e => e.ActPredGroupId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasComment("FAActPredGroup.ActPredGroupId ");

                entity.Property(e => e.ActSubType).HasComment("REFID From the RefTable REFTYPE=AccountTyp REFSUBTYPE=SubType based upon above choosen Account Type this sub type will be displayed");

                entity.Property(e => e.ActType).HasComment("REFID From the RefTable REFTYPE=AccountTyp REFSUBTYPE=Type (Assets, Liabilities, Equity, Revenue, Expenses)");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.AnalysisType).HasComment("REFID From the RefTable REFTYPE=AccountTyp REFSUBTYPE=AnalysisType Purchase / Sales / Stock / Cost of the Stock");

                entity.Property(e => e.Compid)
                    .HasColumnName("COMPID")
                    .HasComment("if this has relation with tblcompanysetup than take if this has relation with tblcompanysetup.compid default=99999(Not Found in the table)");

                entity.Property(e => e.ConsolidationType)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasDefaultValueSql("((0))")
                    .IsFixedLength(true)
                    .HasComment("Consolidation MO=Monthly / WK=Weekly / DA=Daily / YR=Yearly / PR=Once in the Period");

                entity.Property(e => e.ContactMyId)
                    .HasColumnName("ContactMyID")
                    .HasComment("if this has relation with tblcontact than take if this has relation with tblcontact.contactid default=99999(Not Found in the table)");

                entity.Property(e => e.CrupId).HasColumnName("CRUP_ID");

                entity.Property(e => e.DefaultCc)
                    .HasMaxLength(20)
                    .HasColumnName("DefaultCC");

                entity.Property(e => e.GlaccountName1)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("GLAccountName1");

                entity.Property(e => e.GlaccountName2)
                    .HasMaxLength(200)
                    .HasColumnName("GLAccountName2");

                entity.Property(e => e.GlaccountName3)
                    .HasMaxLength(200)
                    .HasColumnName("GLAccountName3");

                entity.Property(e => e.Glsltype)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GLSLType")
                    .HasComment("GL=General Ledger Always by default GL");

                entity.Property(e => e.Header).HasComment("Header Yes than this account can be used than many below will be bypassed");

                entity.Property(e => e.InternalGroupId).HasComment("coming from REFID from RefType=ACT RefSubtype=Group");

                entity.Property(e => e.MasterAccountId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("MasterAccountID")
                    .HasDefaultValueSql("((0))")
                    .HasComment("Incase this falls into another Accounts Group than within GL or SL we will choose account");

                entity.Property(e => e.Opamount).HasColumnName("OPAmount");

                entity.Property(e => e.OpdrCr).HasColumnName("OPDrCr");

                entity.Property(e => e.OpperiodCode)
                    .HasColumnName("OPPERIOD_CODE")
                    .HasComment("from TblPeriod where SystemName=Finance/ACT");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("Same as used in the tblcontact");

                entity.Property(e => e.Remarks).HasMaxLength(500);

                entity.Property(e => e.Switch1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SWITCH1");

                entity.Property(e => e.Switch2)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SWITCH2");

                entity.Property(e => e.Switch3)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SWITCH3");

                entity.Property(e => e.SyncDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Family>(entity =>
            {
                entity.ToTable("Families", "Accounts");

                entity.Property(e => e.FamilyId)
                    .ValueGeneratedNever()
                    .HasColumnName("FamilyID");

                entity.Property(e => e.ArabicName).HasMaxLength(200);

                entity.Property(e => e.Crupid).HasColumnName("crupid");

                entity.Property(e => e.FamilyName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.OtherName).HasMaxLength(200);
            });

            modelBuilder.Entity<Faslaccount>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.LocationId, e.GlaccountId, e.SlaccountId })
                    .IsClustered(false);

                entity.ToTable("FASLAccount");

                entity.Property(e => e.TenentId).HasColumnName("TenentID");

                entity.Property(e => e.LocationId).HasDefaultValueSql("((1))");

                entity.Property(e => e.GlaccountId)
                    .HasMaxLength(20)
                    .HasColumnName("GLAccountID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SlaccountId)
                    .HasMaxLength(20)
                    .HasColumnName("SLAccountID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ActGroupId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("FAAcountGroup.ActGroupID where GLSL=SL");

                entity.Property(e => e.ActSubType).HasComment("REFID From the RefTable REFTYPE=AccountTyp REFSUBTYPE=SubType based upon above choosen Account Type this sub type will be displayed");

                entity.Property(e => e.ActType).HasComment("REFID From the RefTable REFTYPE=AccountTyp REFSUBTYPE=Type (Assets, Liabilities, Equity, Revenue, Expenses)");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.AnalysisType).HasComment("REFID From the RefTable REFTYPE=AccountTyp REFSUBTYPE=AnalysisType Purchase / Sales / Stock / Cost of the Stock");

                entity.Property(e => e.Compid)
                    .HasColumnName("COMPID")
                    .HasComment("if this has relation with tblcompanysetup than take if this has relation with tblcompanysetup.compid default=99999(Not Found in the table)");

                entity.Property(e => e.ConsolidationType)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasDefaultValueSql("((0))")
                    .IsFixedLength(true)
                    .HasComment("Consolidation MO=Monthly / WK=Weekly / DA=Daily / YR=Yearly / PR=Once in the Period");

                entity.Property(e => e.ContactMyId)
                    .HasColumnName("ContactMyID")
                    .HasComment("if this has relation with tblcontact than take if this has relation with tblcontact.contactid default=99999(Not Found in the table)");

                entity.Property(e => e.CrupId).HasColumnName("CRUP_ID");

                entity.Property(e => e.DefaultCc)
                    .HasMaxLength(20)
                    .HasColumnName("DefaultCC");

                entity.Property(e => e.Glsltype)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GLSLType")
                    .HasComment("GL=General Ledger Always by default SL");

                entity.Property(e => e.Header).HasComment("Header Yes than this account can be used than many below will be bypassed");

                entity.Property(e => e.InternalGroupId).HasComment("coming from REFID from RefType=ACT RefSubtype=Group");

                entity.Property(e => e.MasterAccountId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("MasterAccountID")
                    .HasComment("Incase this falls into another Accounts Group than within SL we will choose account If Header=Yes than this cant be used\r\n");

                entity.Property(e => e.Opamount).HasColumnName("OPAmount");

                entity.Property(e => e.OpdrCr).HasColumnName("OPDrCr");

                entity.Property(e => e.OpperiodCode)
                    .HasColumnName("OPPERIOD_CODE")
                    .HasComment("from TblPeriod where SystemName=Finance/ACT");

                entity.Property(e => e.PredAccountId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("PredAccountID")
                    .HasComment("Comming from FAAPredGroup");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("Same as used in the tblcontact");

                entity.Property(e => e.Remarks).HasMaxLength(500);

                entity.Property(e => e.SlaccountName1)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("SLAccountName1");

                entity.Property(e => e.SlaccountName2)
                    .HasMaxLength(200)
                    .HasColumnName("SLAccountName2");

                entity.Property(e => e.SlaccountName3)
                    .HasMaxLength(200)
                    .HasColumnName("SLAccountName3");

                entity.Property(e => e.Switch1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SWITCH1");

                entity.Property(e => e.Switch2)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SWITCH2");

                entity.Property(e => e.Switch3)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SWITCH3");

                entity.Property(e => e.SyncDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<FinancialPeriod>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.LocationId, e.FperiodId });

                entity.ToTable("FinancialPeriod", "Accounts");

                entity.Property(e => e.TenentId)
                    .HasColumnName("TenentID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.FperiodId).HasColumnName("FPeriodID");

                entity.Property(e => e.Crupid).HasColumnName("crupid");

                entity.Property(e => e.DescripitonArabic).HasMaxLength(50);

                entity.Property(e => e.DescripitonEng).HasMaxLength(50);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.YearCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            // modelBuilder.Entity<FormTitleDt>(entity =>
            // {
            //     entity.HasKey(e => new { e.TenentId, e.FormTitleHdId, e.Language, e.LabelId })
            //         .HasName("PK_FormTitleDT_1");

            //     entity.ToTable("FormTitleDT");

            //     entity.Property(e => e.TenentId).HasColumnName("TenentID");

            //     entity.Property(e => e.FormTitleHdId)
            //         .HasMaxLength(40)
            //         .HasColumnName("FormID")
            //         .HasComment("Make sure you are not using any special character here");

            //     entity.Property(e => e.Language).HasComment("1= English 2=Arabic you can take from reftable refsubtype='Language'");

            //     entity.Property(e => e.LabelId)
            //         .HasMaxLength(40)
            //         .HasColumnName("LabelID");

            //     entity.Property(e => e.ArabicTitle)
            //         .HasMaxLength(150)
            //         .HasComment("English or Arabic Text");

            //     entity.Property(e => e.Attiribute)
            //         .HasMaxLength(100)
            //         .HasComment("incase color or any special effect u want to apply thru this");

            //     entity.Property(e => e.Remarks).HasMaxLength(50);

            //     entity.Property(e => e.Rl)
            //         .HasMaxLength(5)
            //         .HasColumnName("RL")
            //         .HasComment(" RL=Right to left or LR=Left to Right");

            //     entity.Property(e => e.Status).HasMaxLength(10);

            //     entity.Property(e => e.Title)
            //         .HasMaxLength(150)
            //         .HasComment("English or Arabic Text");
            // });

            // modelBuilder.Entity<FormTitleHd>(entity =>
            // {
            //     entity.HasKey(e => new { e.TenentId, e.FormId, e.Language });

            //     entity.ToTable("FormTitleHD");

            //     entity.Property(e => e.TenentId).HasColumnName("TenentID");

            //     entity.Property(e => e.FormId)
            //         .HasMaxLength(40)
            //         .HasColumnName("FormID")
            //         .HasComment("Make sure you are not using any special character here");

            //     entity.Property(e => e.Language).HasComment("1= English 2=Arabic you can take from reftable refsubtype='Language'");

            //     entity.Property(e => e.FormName).HasMaxLength(50);

            //     entity.Property(e => e.HeaderName).HasMaxLength(150);

            //     entity.Property(e => e.Navigation).HasMaxLength(150);

            //     entity.Property(e => e.Remarks).HasMaxLength(250);

            //     entity.Property(e => e.Status).HasMaxLength(10);

            //     entity.Property(e => e.SubHeader).HasMaxLength(100);
            // });

            modelBuilder.Entity<Iccatsubcat>(entity =>
            {
                entity.HasKey(e => new { e.Companyid, e.Mycatsubid });

                entity.ToTable("ICCATSUBCAT");

                entity.Property(e => e.Companyid)
                    .HasColumnName("COMPANYID")
                    .HasDefaultValueSql("((1))")
                    .HasComment("Company ID");

                entity.Property(e => e.Mycatsubid).HasColumnName("MYCATSUBID");

                entity.Property(e => e.Catid)
                    .HasColumnName("CATID")
                    .HasDefaultValueSql("((9999))");

                entity.Property(e => e.Cattype)
                    .HasMaxLength(10)
                    .HasColumnName("CATTYPE")
                    .HasDefaultValueSql("('NONE')");

                entity.Property(e => e.CrupId).HasColumnName("CRUP_ID");

                entity.Property(e => e.Itemid)
                    .HasMaxLength(50)
                    .HasColumnName("ITEMID");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(200)
                    .HasColumnName("REMARKS");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Subcatid)
                    .HasColumnName("SUBCATID")
                    .HasDefaultValueSql("((9999))");

                entity.Property(e => e.Subcattype)
                    .HasMaxLength(10)
                    .HasColumnName("SUBCATTYPE")
                    .HasDefaultValueSql("('ZZZ')");
            });

            modelBuilder.Entity<LettersHd>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.Mytransid, e.LetterType })
                    .IsClustered(false);

                entity.ToTable("LettersHD");

                entity.Property(e => e.TenentId)
                    .HasColumnName("TenentID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Mytransid).HasColumnName("MYTRANSID");

                entity.Property(e => e.LetterType).HasComment("from RefTable RefSubType='LetterType'");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.CrupId).HasColumnName("CRUP_ID");

                entity.Property(e => e.Description).HasDefaultValueSql("('0')");

                entity.Property(e => e.Dmsid)
                    .HasColumnName("DMSID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeID")
                    .HasComment("Received or Sent / Sign by ");

                entity.Property(e => e.Entrydate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYDATE");

                entity.Property(e => e.Entrytime)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYTIME");

                entity.Property(e => e.FilledAt).HasComment("Where this Letter is Filled at the Folder it is coming from RefTable RefSubType='FilingPlace'");

                entity.Property(e => e.LetterDated).HasColumnType("date");

                entity.Property(e => e.LocationId)
                    .HasColumnName("locationID")
                    .HasDefaultValueSql("((0))")
                    .HasComment("from DMS generated ID to fetch that Letter from there");

                entity.Property(e => e.ReceivedSentDate)
                    .HasColumnType("date")
                    .HasColumnName("Received_SentDate")
                    .HasComment("If there is Master Service id than unique of the ServiceSetup.ServiceID except this raw ServiceID will be in the drop Down\r\nIf this service ID Does not have any master or consecutive than it will be same as ServiceID");

                entity.Property(e => e.Representative).HasMaxLength(100);

                entity.Property(e => e.SearchTag)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('0')")
                    .HasComment("SearchTagwill be stored here with Comma Seperated coming from RefTable RefSubType='FilingTag'");

                entity.Property(e => e.SenderReceiverParty).HasComment("Where this Letter is Filled at the Folder it is coming from RefTable RefSubType='Party'");

                entity.Property(e => e.Status).HasMaxLength(25);

                entity.Property(e => e.Updttime)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDTTIME");

                entity.Property(e => e.Userid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USERID");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.LocationName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.LocationNameArabic)
                    .HasMaxLength(150)
                    .HasColumnName("LocationName_Arabic");

                entity.Property(e => e.TenentId).HasColumnName("TenentID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<Mapping>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.LocationId, e.MappingId });

                entity.ToTable("Mapping", "Accounts");

                entity.Property(e => e.TenentId)
                    .HasColumnName("TenentID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LocationId).HasColumnName("locationID");

                entity.Property(e => e.MappingId).HasColumnName("MappingID");

                entity.Property(e => e.AccountId).HasColumnName("Account_ID");

                entity.Property(e => e.ArabicDescription).HasMaxLength(400);

                entity.Property(e => e.Crupid).HasColumnName("crupid");

                entity.Property(e => e.EnglishDescription)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.OtherDescription).HasMaxLength(400);
            });

            modelBuilder.Entity<MappingHead>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MappingHeads", "Accounts");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MappingId).HasColumnName("MappingID");
            });

            modelBuilder.Entity<Mycompanysetup>(entity =>
            {
                entity.HasKey(e => e.TenentId)
                    .IsClustered(false);

                entity.ToTable("MYCOMPANYSETUP");

                entity.Property(e => e.TenentId)
                    .HasColumnName("TenentID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Actdatabasename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ACTDATABASENAME");

                entity.Property(e => e.Activetenent).HasColumnName("ACTIVETENENT");

                entity.Property(e => e.Addr1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADDR1");

                entity.Property(e => e.Addr2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADDR2");

                entity.Property(e => e.Arabic)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ARABIC")
                    .HasDefaultValueSql("('2')")
                    .IsFixedLength(true);

                entity.Property(e => e.Backupdirectory)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BACKUPDIRECTORY");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CITY");

                entity.Property(e => e.Companyid).HasColumnName("COMPANYID");

                entity.Property(e => e.Compname)
                    .HasMaxLength(50)
                    .HasColumnName("COMPNAME");

                entity.Property(e => e.Compname1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("COMPNAME1");

                entity.Property(e => e.Compname2)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("COMPNAME2");

                entity.Property(e => e.Compname3)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("COMPNAME3");

                entity.Property(e => e.Compnamech)
                    .HasMaxLength(50)
                    .HasColumnName("COMPNAMECH");

                entity.Property(e => e.Compnameo)
                    .HasMaxLength(50)
                    .HasColumnName("COMPNAMEO");

                entity.Property(e => e.Countryid).HasColumnName("COUNTRYID");

                entity.Property(e => e.CrupId).HasColumnName("CRUP_ID");

                entity.Property(e => e.Datadirectory)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DATADIRECTORY");

                entity.Property(e => e.Decimalcurrency)
                    .HasColumnType("numeric(9, 3)")
                    .HasColumnName("DECIMALCURRENCY")
                    .HasDefaultValueSql("((3))");

                entity.Property(e => e.Entrydate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYDATE");

                entity.Property(e => e.Entrytime)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYTIME");

                entity.Property(e => e.Executabledirectory)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EXECUTABLEDIRECTORY");

                entity.Property(e => e.Fax)
                    .IsRequired()
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("FAX");

                entity.Property(e => e.Invdatabasename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("INVDATABASENAME");

                entity.Property(e => e.Language1).HasMaxLength(10);

                entity.Property(e => e.Language2).HasMaxLength(10);

                entity.Property(e => e.Language3).HasMaxLength(10);

                entity.Property(e => e.Logo3).HasMaxLength(100);

                entity.Property(e => e.LogotoDisplay).HasMaxLength(100);

                entity.Property(e => e.LogotoPrint).HasMaxLength(100);

                entity.Property(e => e.Msrp)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("msrp");

                entity.Property(e => e.PeriodEndDate).HasMaxLength(150);

                entity.Property(e => e.PeriodId)
                    .HasMaxLength(150)
                    .HasColumnName("PeriodID");

                entity.Property(e => e.PeriodStartDate).HasMaxLength(150);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.Physicallocid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PHYSICALLOCID")
                    .HasDefaultValueSql("('HLY')");

                entity.Property(e => e.Postalcode)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("POSTALCODE");

                entity.Property(e => e.RecRunningSrl).HasColumnName("REC_RUNNING_SRL");

                entity.Property(e => e.Reportdefault)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("REPORTDEFAULT")
                    .HasDefaultValueSql("('0')")
                    .IsFixedLength(true);

                entity.Property(e => e.Reportdirectory)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REPORTDIRECTORY");

                entity.Property(e => e.SalePrice1).HasColumnType("numeric(3, 0)");

                entity.Property(e => e.SalePrice2).HasColumnType("numeric(3, 0)");

                entity.Property(e => e.SalePrice3).HasColumnType("numeric(3, 0)");

                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STATE");

                entity.Property(e => e.StockTaking).HasDefaultValueSql("((0))");

                entity.Property(e => e.Sysname)
                    .HasMaxLength(150)
                    .HasColumnName("sysname");

                entity.Property(e => e.TenantGroupId)
                    .HasColumnName("TenantGroupID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Tenentdate)
                    .HasColumnType("date")
                    .HasColumnName("TENENTDATE");

                entity.Property(e => e.Updttime)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDTTIME");

                entity.Property(e => e.Userid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USERID");

                entity.Property(e => e.Zipcode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ZIPCODE");
            });

            modelBuilder.Entity<RefLabelMst>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.RefLabelId, e.RefType, e.RefSubType });

                entity.ToTable("RefLabelMST");

                entity.Property(e => e.TenentId).HasColumnName("TenentID");

                entity.Property(e => e.RefLabelId).HasColumnName("RefLabelID");

                entity.Property(e => e.RefType).HasMaxLength(10);

                entity.Property(e => e.RefSubType).HasMaxLength(20);

                entity.Property(e => e.La1)
                    .HasMaxLength(50)
                    .HasColumnName("LA1");

                entity.Property(e => e.La10)
                    .HasMaxLength(50)
                    .HasColumnName("LA10");

                entity.Property(e => e.La2)
                    .HasMaxLength(50)
                    .HasColumnName("LA2");

                entity.Property(e => e.La3)
                    .HasMaxLength(50)
                    .HasColumnName("LA3");

                entity.Property(e => e.La4)
                    .HasMaxLength(50)
                    .HasColumnName("LA4");

                entity.Property(e => e.La5)
                    .HasMaxLength(50)
                    .HasColumnName("LA5");

                entity.Property(e => e.La6)
                    .HasMaxLength(50)
                    .HasColumnName("LA6");

                entity.Property(e => e.La7)
                    .HasMaxLength(50)
                    .HasColumnName("LA7");

                entity.Property(e => e.La8)
                    .HasMaxLength(50)
                    .HasColumnName("LA8");

                entity.Property(e => e.La9)
                    .HasMaxLength(50)
                    .HasColumnName("LA9");

                entity.Property(e => e.Le1)
                    .HasMaxLength(50)
                    .HasColumnName("LE1");

                entity.Property(e => e.Le10)
                    .HasMaxLength(50)
                    .HasColumnName("LE10");

                entity.Property(e => e.Le2)
                    .HasMaxLength(50)
                    .HasColumnName("LE2");

                entity.Property(e => e.Le3)
                    .HasMaxLength(50)
                    .HasColumnName("LE3");

                entity.Property(e => e.Le4)
                    .HasMaxLength(50)
                    .HasColumnName("LE4");

                entity.Property(e => e.Le5)
                    .HasMaxLength(50)
                    .HasColumnName("LE5");

                entity.Property(e => e.Le6)
                    .HasMaxLength(50)
                    .HasColumnName("LE6");

                entity.Property(e => e.Le7)
                    .HasMaxLength(50)
                    .HasColumnName("LE7");

                entity.Property(e => e.Le8)
                    .HasMaxLength(50)
                    .HasColumnName("LE8");

                entity.Property(e => e.Le9)
                    .HasMaxLength(50)
                    .HasColumnName("LE9");

                entity.Property(e => e.Lf1)
                    .HasMaxLength(50)
                    .HasColumnName("LF1");

                entity.Property(e => e.Lf10)
                    .HasMaxLength(50)
                    .HasColumnName("LF10");

                entity.Property(e => e.Lf2)
                    .HasMaxLength(50)
                    .HasColumnName("LF2");

                entity.Property(e => e.Lf3)
                    .HasMaxLength(50)
                    .HasColumnName("LF3");

                entity.Property(e => e.Lf4)
                    .HasMaxLength(50)
                    .HasColumnName("LF4");

                entity.Property(e => e.Lf5)
                    .HasMaxLength(50)
                    .HasColumnName("LF5");

                entity.Property(e => e.Lf6)
                    .HasMaxLength(50)
                    .HasColumnName("LF6");

                entity.Property(e => e.Lf7)
                    .HasMaxLength(50)
                    .HasColumnName("LF7");

                entity.Property(e => e.Lf8)
                    .HasMaxLength(50)
                    .HasColumnName("LF8");

                entity.Property(e => e.Lf9)
                    .HasMaxLength(50)
                    .HasColumnName("LF9");
            });

            modelBuilder.Entity<RefTableAdmin>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.RefAdminId, e.RefType, e.RefSubType });

                entity.ToTable("RefTableAdmin");

                entity.Property(e => e.TenentId).HasColumnName("TenentID");

                entity.Property(e => e.RefType).HasMaxLength(10);

                entity.Property(e => e.RefSubType).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Admin)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CrupId).HasColumnName("CRUP_ID");

                entity.Property(e => e.Descrip)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Infrastructure).HasMaxLength(1);

                entity.Property(e => e.MySysName)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.NormalUser)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks).HasMaxLength(500);

                entity.Property(e => e.Switch1)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("switch1");

                entity.Property(e => e.SyncDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Reftable>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.Refid, e.Reftype, e.Refsubtype });

                entity.ToTable("REFTABLE");

                entity.Property(e => e.TenentId)
                    .HasColumnName("TenentID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Refid)
                    .HasColumnType("int")
                    .HasColumnName("REFID");

                entity.Property(e => e.Reftype)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("REFTYPE")
                    .HasDefaultValueSql("('OTH')");

                entity.Property(e => e.Refsubtype)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("REFSUBTYPE")
                    .HasDefaultValueSql("('OTH')");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.CrupId).HasColumnName("CRUP_ID");

                entity.Property(e => e.Infrastructure).HasMaxLength(1);

                entity.Property(e => e.RefImage)
                    .HasMaxLength(500)
                    .HasColumnName("REF_Image");

                entity.Property(e => e.Refname1)
                    .HasMaxLength(100)
                    .HasColumnName("REFNAME1");

                entity.Property(e => e.Refname2)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("REFNAME2");

                entity.Property(e => e.Refname3)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("REFNAME3");

                entity.Property(e => e.Remarks).HasMaxLength(500);

                entity.Property(e => e.Shortname)
                    .HasMaxLength(50)
                    .HasColumnName("SHORTNAME");

                entity.Property(e => e.Switch1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SWITCH1");

                entity.Property(e => e.Switch2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SWITCH2");

                entity.Property(e => e.Switch3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SWITCH3");

                entity.Property(e => e.Switch4).HasColumnName("SWITCH4");

                entity.Property(e => e.SynId).HasColumnName("SynID");

                entity.Property(e => e.SyncDate).HasColumnType("datetime");

                entity.Property(e => e.Syncby).HasMaxLength(50);

                entity.Property(e => e.UploadDate).HasColumnType("datetime");

                entity.Property(e => e.Uploadby).HasMaxLength(50);
            });

            modelBuilder.Entity<ServiceSetup>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.ServiceId })
                    .HasName("PK_Service");

                entity.ToTable("ServiceSetup");

                entity.Property(e => e.TenentId).HasColumnName("TenentID");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AllowSponser).HasComment("Allow Sponser for this Services or no");

                entity.Property(e => e.AllowedNonEmployes)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("((1))")
                    .HasComment("Allowed Non Employee in this Service Y/N");

                entity.Property(e => e.ConsumerLoanAct)
                    .HasMaxLength(50)
                    .HasComment("contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account");

                entity.Property(e => e.CrupId).HasColumnName("CRUP_ID");

                entity.Property(e => e.Entrydate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYDATE");

                entity.Property(e => e.Entrytime)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYTIME");

                entity.Property(e => e.FinalApproval)
                    .HasMaxLength(1)
                    .HasComment("Here you will place which SerApproval# is the last for example 1,2,3,4,5");

                entity.Property(e => e.Frozen)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("((1))")
                    .HasComment("Allowed to be Frozen");

                entity.Property(e => e.HajjAct).HasMaxLength(50);

                entity.Property(e => e.Keyword).HasMaxLength(255);

                entity.Property(e => e.LoanAct).HasMaxLength(50);

                entity.Property(e => e.MasterServiceId)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MasterServiceID")
                    .HasComment("Accept Comma Seperated ID from Drop Down ..\r\nIf there is Master Service id than unique of the ServiceSetup.ServiceID except this raw ServiceID will be in the drop Down\r\nIf this service ID Does not have any master or consecutive than it will be same as ServiceID");

                entity.Property(e => e.MaxInstallment).HasDefaultValueSql("((8))");

                entity.Property(e => e.MinInstallment)
                    .HasDefaultValueSql("((0))")
                    .HasComment("Incase Min is remain 0 than max must be zero too if Min is other than Zero than Max must be equallant or greater than Zero");

                entity.Property(e => e.MinMonthsService).HasDefaultValueSql("((3))");

                entity.Property(e => e.OtherAct1)
                    .HasMaxLength(50)
                    .HasComment("contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account");

                entity.Property(e => e.OtherAct2)
                    .HasMaxLength(50)
                    .HasComment("contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account");

                entity.Property(e => e.OtherAct3)
                    .HasMaxLength(50)
                    .HasComment("contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account");

                entity.Property(e => e.OtherAct4)
                    .HasMaxLength(50)
                    .HasComment("contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account");

                entity.Property(e => e.PersLoanAct).HasMaxLength(50);

                entity.Property(e => e.PreviousEmployees)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("((1))")
                    .HasComment("Allowed by Previous Employees");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(255)
                    .HasColumnName("REMARKS");

                entity.Property(e => e.SerApproval1)
                    .HasMaxLength(50)
                    .HasComment("Coming from RefTable RefSubType='Role' and\r\n Which AprovalEmployeeRole will be allowed to be approved else it is to be left NULL");

                entity.Property(e => e.SerApproval2)
                    .HasMaxLength(50)
                    .HasComment("Which AprovalEmployeeRole will be allowed to be approved else it is to be left NULL");

                entity.Property(e => e.SerApproval3)
                    .HasMaxLength(50)
                    .HasComment("Which AprovalEmployeeRole will be allowed to be approved else it is to be left NULL");

                entity.Property(e => e.SerApproval4)
                    .HasMaxLength(50)
                    .HasComment("Which AprovalEmployeeRole will be allowed to be approved else it is to be left NULL");

                entity.Property(e => e.SerApproval5)
                    .HasMaxLength(50)
                    .HasComment("Which AprovalEmployeeRole will be allowed to be approved else it is to be left NULL");

                entity.Property(e => e.SerIdbyUser).HasColumnName("SerIDByUser");

                entity.Property(e => e.ServiceName1).HasMaxLength(150);

                entity.Property(e => e.ServiceName2).HasMaxLength(150);

                entity.Property(e => e.ServiceSubType).HasComment("Coming from RefTable RefType='KUPF' and RefSubtype='ConsumerLoanType' and Switch3=ServiceSetup.ServiceID");

                entity.Property(e => e.ServiceType).HasComment("Coming from RefTable RefType='KUPF' and RefSubtype='ServiceType'");

                entity.Property(e => e.SynId).HasColumnName("SynID");

                entity.Property(e => e.SyncDate).HasColumnType("datetime");

                entity.Property(e => e.Syncby).HasMaxLength(50);

                entity.Property(e => e.Updttime)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDTTIME");

                entity.Property(e => e.UploadDate).HasColumnType("datetime");

                entity.Property(e => e.Uploadby).HasMaxLength(50);

                entity.Property(e => e.Userid)
                    .HasMaxLength(50)
                    .HasColumnName("USERID");
            });

            modelBuilder.Entity<SubHead>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.LocationId, e.SubHeadId });

                entity.ToTable("SubHead", "Accounts");

                entity.Property(e => e.TenentId)
                    .HasColumnName("TenentID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.SubHeadId).HasColumnName("SubHeadID");

                entity.Property(e => e.ArabicSubHeadName).HasMaxLength(200);

                entity.Property(e => e.BalanceAmt)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Crupid).HasColumnName("crupid");

                entity.Property(e => e.HeadId).HasColumnName("Head_ID");

                entity.Property(e => e.Remarks)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.SubHeadName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<SubSubHead>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.LocationId, e.SubSubHeadId })
                    .HasName("PK__SubSubHe__5298A9220DD76A00");

                entity.ToTable("SubSubHead", "Accounts");

                entity.Property(e => e.TenentId).HasColumnName("TenentID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.SubSubHeadId).HasColumnName("SubSubHeadID");

                entity.Property(e => e.ArabicSubSubHeadName).HasMaxLength(500);

                entity.Property(e => e.BalanceAmt)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Crupid).HasColumnName("crupid");

                entity.Property(e => e.HeadId).HasColumnName("Head_ID");

                entity.Property(e => e.SubHeadId).HasColumnName("SubHead_ID");

                entity.Property(e => e.SubSubHeadName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblAccountMst>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.Id })
                    .HasName("PK_CRM_tbl_Account_Mst");

                entity.ToTable("tbl_Account_Mst");

                entity.Property(e => e.TenentId).HasColumnName("TenentID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AnnualRevenue)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Annual_Revenue");

                entity.Property(e => e.AssignedToName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Assigned_to_Name");

                entity.Property(e => e.BillingAddressCity)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Billing_Address_City");

                entity.Property(e => e.BillingAddressCountry)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Billing_Address_Country");

                entity.Property(e => e.BillingAddressPostalcode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Billing_Address_Postalcode");

                entity.Property(e => e.BillingAddressState)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Billing_Address_State");

                entity.Property(e => e.BillingAddressStreet)
                    .IsUnicode(false)
                    .HasColumnName("Billing_Address_Street");

                entity.Property(e => e.ContactName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CrupId).HasColumnName("CRUP_ID");

                entity.Property(e => e.DateEntered).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Email1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Employee)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IndustryId).HasColumnName("IndustryID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ownership)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ParentName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneAlternate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Phone_Alternate");

                entity.Property(e => e.PhoneFax)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Phone_Fax");

                entity.Property(e => e.PhoneOffice)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Phone_Office");

                entity.Property(e => e.Rating)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingAddressCity)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Shipping_Address_City");

                entity.Property(e => e.ShippingAddressCountry)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Shipping_Address_Country");

                entity.Property(e => e.ShippingAddressPostalcode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Shipping_Address_Postalcode");

                entity.Property(e => e.ShippingAddressState)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Shipping_Address_State");

                entity.Property(e => e.ShippingAddressStreet)
                    .IsUnicode(false)
                    .HasColumnName("Shipping_Address_Street");

                entity.Property(e => e.SicCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TickerSymbol)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblActSlsetup>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.LocationId, e.Transid, e.Transsubid });

                entity.ToTable("tblActSLSetup");

                entity.Property(e => e.TenentId).HasColumnName("TenentID");

                entity.Property(e => e.LocationId).HasColumnName("locationID");

                entity.Property(e => e.Transid).HasColumnName("transid");

                entity.Property(e => e.Transsubid).HasColumnName("transsubid");

                entity.Property(e => e.BottomTagLine).HasMaxLength(100);

                entity.Property(e => e.CompniId).HasColumnName("CompniID");

                entity.Property(e => e.Countryid).HasColumnName("COUNTRYID");

                entity.Property(e => e.HeaderLine).HasMaxLength(500);

                entity.Property(e => e.Module).HasColumnName("module");

                entity.Property(e => e.SalesAdminId).HasColumnName("SalesAdminID");

                entity.Property(e => e.TagLine).HasMaxLength(500);

                entity.Property(e => e.Tcquotation).HasColumnName("TCQuotation");
            });

            modelBuilder.Entity<TblAudit>(entity =>
            {
                entity.HasKey(e => new { e.TenantId, e.CrupId, e.MySerial, e.AuditNo })
                    .HasName("PK_Audit");

                entity.ToTable("tblAudit");

                entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");

                entity.Property(e => e.CrupId).HasColumnName("CRUP_ID");

                entity.Property(e => e.AuditNo).ValueGeneratedOnAdd();

                entity.Property(e => e.AuditType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedUserName)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.FieldName)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateUserName)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblCityStatesCounty>(entity =>
            {
                entity.HasKey(e => new { e.TenantId, e.CityId, e.StateId, e.Countryid })
                    .HasName("PK_tblCityStatesCounty1");

                entity.ToTable("tblCityStatesCounty");

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.Property(e => e.Countryid).HasColumnName("COUNTRYID");

                entity.Property(e => e.Active1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVE1")
                    .IsFixedLength(true);

                entity.Property(e => e.Active2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVE2")
                    .IsFixedLength(true);

                entity.Property(e => e.AssignedRoute).HasMaxLength(50);

                entity.Property(e => e.CityArabic).HasMaxLength(250);

                entity.Property(e => e.CityEnglish)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CityOther).HasMaxLength(250);

                entity.Property(e => e.CrupId).HasColumnName("CRUP_ID");

                entity.Property(e => e.DistrictId).HasColumnName("DistrictID");

                entity.Property(e => e.DistrictName).HasMaxLength(250);

                entity.Property(e => e.LandLine).HasMaxLength(20);

                entity.Property(e => e.Shortcode)
                    .HasMaxLength(50)
                    .HasColumnName("SHORTCODE");

                entity.Property(e => e.SynId).HasColumnName("SynID");

                entity.Property(e => e.SyncDate).HasColumnType("datetime");

                entity.Property(e => e.Syncby).HasMaxLength(50);

                entity.Property(e => e.UploadDate).HasColumnType("datetime");

                entity.Property(e => e.Uploadby).HasMaxLength(50);

                entity.Property(e => e.Zone)
                    .HasMaxLength(50)
                    .HasColumnName("ZONE");
            });

            modelBuilder.Entity<TblCountry>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.Countryid })
                    .HasName("PK_tblCOUNTRY_1");

                entity.ToTable("tblCOUNTRY");

                entity.Property(e => e.TenentId).HasColumnName("TenentID");

                entity.Property(e => e.Countryid).HasColumnName("COUNTRYID");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Capital)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("CAPITAL");

                entity.Property(e => e.Couname1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("COUNAME1");

                entity.Property(e => e.Couname2)
                    .HasMaxLength(50)
                    .HasColumnName("COUNAME2");

                entity.Property(e => e.Couname3)
                    .HasMaxLength(50)
                    .HasColumnName("COUNAME3");

                entity.Property(e => e.CountryTsubType)
                    .HasMaxLength(50)
                    .HasColumnName("CountryTSubType");

                entity.Property(e => e.CountryType).HasMaxLength(30);

                entity.Property(e => e.CrupId).HasColumnName("CRUP_ID");

                entity.Property(e => e.Currencyname1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("CURRENCYNAME1");

                entity.Property(e => e.Currencyname2)
                    .HasMaxLength(50)
                    .HasColumnName("CURRENCYNAME2");

                entity.Property(e => e.Currencyname3)
                    .HasMaxLength(50)
                    .HasColumnName("CURRENCYNAME3");

                entity.Property(e => e.Currencyshortname1)
                    .HasMaxLength(50)
                    .HasColumnName("CURRENCYSHORTNAME1");

                entity.Property(e => e.Currencyshortname2)
                    .HasMaxLength(50)
                    .HasColumnName("CURRENCYSHORTNAME2");

                entity.Property(e => e.Currencyshortname3)
                    .HasMaxLength(50)
                    .HasColumnName("CURRENCYSHORTNAME3");

                entity.Property(e => e.Currentconvrate)
                    .HasColumnType("numeric(8, 5)")
                    .HasColumnName("CURRENTCONVRATE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IanacountryCodeTld)
                    .HasMaxLength(50)
                    .HasColumnName("IANACountryCodeTLD");

                entity.Property(e => e.Iso316612letterCode)
                    .HasMaxLength(50)
                    .HasColumnName("ISO3166_1_2LetterCode");

                entity.Property(e => e.Iso316613letterCode)
                    .HasMaxLength(10)
                    .HasColumnName("ISO3166_1_3LetterCode");

                entity.Property(e => e.Iso31661number)
                    .HasMaxLength(50)
                    .HasColumnName("ISO3166_1Number");

                entity.Property(e => e.Iso4217curCode)
                    .HasMaxLength(30)
                    .HasColumnName("ISO4217CurCode");

                entity.Property(e => e.Iso4217curName)
                    .HasMaxLength(50)
                    .HasColumnName("ISO4217CurName");

                entity.Property(e => e.ItuttelephoneCode)
                    .HasMaxLength(10)
                    .HasColumnName("ITUTTelephoneCode");

                entity.Property(e => e.Nationality1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("NATIONALITY1");

                entity.Property(e => e.Nationality2)
                    .HasMaxLength(50)
                    .HasColumnName("NATIONALITY2");

                entity.Property(e => e.Nationality3)
                    .HasMaxLength(50)
                    .HasColumnName("NATIONALITY3");

                entity.Property(e => e.Region1)
                    .HasMaxLength(50)
                    .HasColumnName("REGION1");

                entity.Property(e => e.Sovereignty).HasMaxLength(50);

                entity.Property(e => e.SynId).HasColumnName("SynID");

                entity.Property(e => e.SyncDate).HasColumnType("datetime");

                entity.Property(e => e.Syncby).HasColumnType("text");

                entity.Property(e => e.UploadDate).HasColumnType("datetime");

                entity.Property(e => e.Uploadby).HasColumnType("text");

                entity.Property(e => e.Zone1)
                    .HasMaxLength(3)
                    .HasColumnName("zone1")
                    .IsFixedLength(true);

                entity.Property(e => e.Zone2)
                    .HasMaxLength(3)
                    .HasColumnName("zone2")
                    .IsFixedLength(true);

                entity.Property(e => e.Zone3)
                    .HasMaxLength(3)
                    .HasColumnName("zone3")
                    .IsFixedLength(true);

                entity.Property(e => e.Zone4)
                    .HasMaxLength(3)
                    .HasColumnName("zone4")
                    .IsFixedLength(true);

                entity.Property(e => e.Zone5)
                    .HasMaxLength(3)
                    .HasColumnName("zone5")
                    .IsFixedLength(true);

                entity.Property(e => e.Zone6)
                    .HasMaxLength(3)
                    .HasColumnName("zone6")
                    .IsFixedLength(true);

                entity.Property(e => e.Zone7)
                    .HasMaxLength(3)
                    .HasColumnName("zone7")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TblDistrictStatesCounty>(entity =>
            {
                entity.HasKey(e => new { e.TenantId, e.Countryid, e.StateId, e.DistrictId });

                entity.ToTable("tblDistrictStatesCounty");

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.Property(e => e.Countryid).HasColumnName("COUNTRYID");

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.Property(e => e.DistrictId).HasColumnName("DistrictID");

                entity.Property(e => e.Active1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVE1")
                    .IsFixedLength(true);

                entity.Property(e => e.Active2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVE2")
                    .IsFixedLength(true);

                entity.Property(e => e.AssignedRoute).HasMaxLength(50);

                entity.Property(e => e.CrupId).HasColumnName("CRUP_ID");

                entity.Property(e => e.DistrictArabic).HasMaxLength(250);

                entity.Property(e => e.DistrictEnglish).HasMaxLength(250);

                entity.Property(e => e.DistrictOther).HasMaxLength(250);

                entity.Property(e => e.LandLine).HasMaxLength(20);

                entity.Property(e => e.Shortcode)
                    .HasMaxLength(50)
                    .HasColumnName("SHORTCODE");

                entity.Property(e => e.SynId).HasColumnName("SynID");

                entity.Property(e => e.SyncDate).HasColumnType("datetime");

                entity.Property(e => e.Syncby).HasMaxLength(50);

                entity.Property(e => e.UploadDate).HasColumnType("datetime");

                entity.Property(e => e.Uploadby).HasMaxLength(50);

                entity.Property(e => e.Zone)
                    .HasMaxLength(50)
                    .HasColumnName("ZONE");
            });

            modelBuilder.Entity<TblImportCoa>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblImportCOA");

                entity.Property(e => e.AccountName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.AccountTypeName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ActivityDateTime).HasColumnType("datetime");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ArabicAccountName).HasMaxLength(500);

                entity.Property(e => e.ArabicHeadName).HasMaxLength(500);

                entity.Property(e => e.ArabicSubHeadName).HasMaxLength(500);

                entity.Property(e => e.BankAccountNo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FamilyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HeadCode)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.HeadName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.SubHeadCode)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SubHeadName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SubSubHeadCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SubSubHeadName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SubSubHeadNameArabic).HasMaxLength(500);

                entity.Property(e => e.TanentId).HasColumnName("TanentID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<TblImportCoav2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblImportCOAV2");

                entity.Property(e => e.AccountId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AccountID");

                entity.Property(e => e.AccountName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.AccountTypeName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ActivityDateTime).HasColumnType("datetime");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ArabicAccountName).HasMaxLength(500);

                entity.Property(e => e.ArabicHeadName).HasMaxLength(500);

                entity.Property(e => e.ArabicSubHeadName).HasMaxLength(500);

                entity.Property(e => e.BankAccountNo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FamilyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HeadCode)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.HeadName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.SubHeadCode)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SubHeadName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SubSubHeadCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SubSubHeadName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SubSubHeadNameArabic).HasMaxLength(500);

                entity.Property(e => e.TanentId).HasColumnName("TanentID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<TblImportVoucher>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblImportVoucher");

                entity.Property(e => e.AccountName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ChequeDate).HasColumnType("date");

                entity.Property(e => e.ChequeNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TanentId).HasColumnName("TanentID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.VoucherDate).HasColumnType("date");

                entity.Property(e => e.VoucherTypeId).HasColumnName("VoucherType_ID");
            });

            modelBuilder.Entity<TblState>(entity =>
            {
                entity.HasKey(e => new { e.Countryid, e.StateId });

                entity.ToTable("tblStates");

                entity.Property(e => e.Countryid).HasColumnName("COUNTRYID");

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.Property(e => e.Active1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVE1")
                    .IsFixedLength(true);

                entity.Property(e => e.Active2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVE2")
                    .IsFixedLength(true);

                entity.Property(e => e.CrupId).HasColumnName("CRUP_ID");

                entity.Property(e => e.Myname1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("MYNAME1");

                entity.Property(e => e.Myname2)
                    .HasMaxLength(50)
                    .HasColumnName("MYNAME2");

                entity.Property(e => e.Myname3)
                    .HasMaxLength(50)
                    .HasColumnName("MYNAME3");

                entity.Property(e => e.Statezipcode)
                    .HasMaxLength(50)
                    .HasColumnName("STATEZIPCODE");

                entity.Property(e => e.SynId).HasColumnName("SynID");

                entity.Property(e => e.SyncDate).HasColumnType("datetime");

                entity.Property(e => e.Syncby).HasMaxLength(50);

                entity.Property(e => e.UploadDate).HasColumnType("datetime");

                entity.Property(e => e.Uploadby).HasMaxLength(50);
            });

            modelBuilder.Entity<Tblcompanysetup>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.Compid });

                entity.ToTable("TBLCOMPANYSETUP");

                entity.HasComment("Company Data");

                entity.HasIndex(e => new { e.TenentId, e.Myconlocid, e.Compname1, e.Compname2, e.Compname3 }, "IX_TBLCOMPANYSETUPCompName");

                entity.HasIndex(e => new { e.TenentId, e.Myconlocid, e.Countryid, e.State, e.City }, "IX_TBLCOMPANYSETUPCountStatCity");

                entity.HasIndex(e => new { e.TenentId, e.Myconlocid, e.Altmobphone }, "IX_TBLCOMPANYSETUP_Mob");

                entity.HasIndex(e => new { e.TenentId, e.Myconlocid, e.Compname1, e.Altmobphone, e.Compid }, "TBLCOMPANYSETUP")
                    .IsUnique();

                entity.Property(e => e.TenentId).HasColumnName("TenentID");

                entity.Property(e => e.Compid).HasColumnName("COMPID");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((1))")
                    .IsFixedLength(true);

                entity.Property(e => e.Addr1).HasColumnName("ADDR1");

                entity.Property(e => e.Addr2)
                    .HasMaxLength(100)
                    .HasColumnName("ADDR2");

                entity.Property(e => e.Altmobphone)
                    .HasMaxLength(50)
                    .HasColumnName("ALTMOBPHONE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Approved).HasDefaultValueSql("((1))");

                entity.Property(e => e.Avtar).HasDefaultValueSql("((0))");

                entity.Property(e => e.Barcode)
                    .HasMaxLength(50)
                    .HasColumnName("BARCODE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Busid)
                    .HasColumnName("BUSID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Busphone1)
                    .HasMaxLength(50)
                    .HasColumnName("BUSPHONE1")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Busphone2)
                    .HasMaxLength(50)
                    .HasColumnName("BUSPHONE2")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Busphone3)
                    .HasMaxLength(50)
                    .HasColumnName("BUSPHONE3")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Busphone4)
                    .HasMaxLength(24)
                    .HasColumnName("BUSPHONE4")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Buyer)
                    .HasColumnName("BUYER")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("CITY")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CivilId)
                    .HasMaxLength(30)
                    .HasColumnName("CivilID")
                    .IsFixedLength(true);

                entity.Property(e => e.CompanyType)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CompanyTypeRef)
                    .HasColumnName("CompanyType_Ref")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Companyid)
                    .HasColumnName("COMPANYID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Compname)
                    .HasMaxLength(50)
                    .HasColumnName("COMPNAME")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Compname1)
                    .HasMaxLength(100)
                    .HasColumnName("COMPNAME1");

                entity.Property(e => e.Compname2)
                    .HasMaxLength(100)
                    .HasColumnName("COMPNAME2");

                entity.Property(e => e.Compname3)
                    .HasMaxLength(100)
                    .HasColumnName("COMPNAME3");

                entity.Property(e => e.Compnamech)
                    .HasMaxLength(255)
                    .HasColumnName("COMPNAMECH")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Compnameo)
                    .HasMaxLength(50)
                    .HasColumnName("COMPNAMEO")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Countryid)
                    .HasColumnName("COUNTRYID")
                    .HasDefaultValueSql("((126))");

                entity.Property(e => e.Cpasswrd)
                    .HasMaxLength(50)
                    .HasColumnName("CPASSWRD")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrupId)
                    .HasColumnName("CRUP_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Cuserid)
                    .HasMaxLength(50)
                    .HasColumnName("CUSERID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Datasource).HasColumnName("datasource");

                entity.Property(e => e.DefaultAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DistrictId).HasColumnName("DistrictID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Email1)
                    .HasMaxLength(50)
                    .HasColumnName("EMAIL1");

                entity.Property(e => e.Email2)
                    .HasMaxLength(240)
                    .HasColumnName("EMAIL2");

                entity.Property(e => e.Emailsubdate)
                    .HasColumnType("datetime")
                    .HasColumnName("EMAILSUBDATE");

                entity.Property(e => e.Emaisub)
                    .HasColumnName("EMAISUB")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Entrydate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYDATE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Entrytime)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYTIME")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Fax)
                    .HasMaxLength(50)
                    .HasColumnName("FAX")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Fax1)
                    .HasMaxLength(24)
                    .HasColumnName("FAX1")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Fax2)
                    .HasMaxLength(24)
                    .HasColumnName("FAX2")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Images).HasColumnType("image");

                entity.Property(e => e.Inhawally)
                    .HasColumnName("INHAWALLY")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Iscorporate)
                    .HasColumnName("ISCORPORATE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Isministry)
                    .HasColumnName("ISMINISTRY")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Issmb)
                    .HasColumnName("ISSMB")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Itmanager)
                    .HasMaxLength(255)
                    .HasColumnName("ITMANAGER")
                    .HasComment("Employee ID incase he is an Employee of the Company incase this field is Null than will considered to be a temporary Driver");

                entity.Property(e => e.Keyword)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Marketting).HasMaxLength(500);

                entity.Property(e => e.Mobphone)
                    .HasMaxLength(50)
                    .HasColumnName("MOBPHONE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Mycatsubid)
                    .HasColumnName("MYCATSUBID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Myconlocid)
                    .HasColumnName("MYCONLOCID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Myprodid).HasColumnName("MYPRODID");

                entity.Property(e => e.Nationality)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OldCompid).HasColumnName("OldCOMPid");

                entity.Property(e => e.Paci)
                    .HasMaxLength(50)
                    .HasColumnName("PACI");

                entity.Property(e => e.Physicallocid)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("PHYSICALLOCID");

                entity.Property(e => e.Postalcode)
                    .HasMaxLength(50)
                    .HasColumnName("POSTALCODE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Primlanguge)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PRIMLANGUGE")
                    .HasDefaultValueSql("('E')")
                    .IsFixedLength(true);

                entity.Property(e => e.Productdealin)
                    .HasMaxLength(255)
                    .HasColumnName("PRODUCTDEALIN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProfitPercDuringSale)
                    .HasColumnType("decimal(8, 2)")
                    .HasComment("During Sales the percentage it is 8,2 like 99.99 only");

                entity.Property(e => e.Reload).HasDefaultValueSql("((0))");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(255)
                    .HasColumnName("REMARKS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Saledeprod)
                    .HasColumnName("SALEDEPROD")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Saler)
                    .HasColumnName("SALER")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .HasColumnName("STATE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SynId).HasColumnName("SynID");

                entity.Property(e => e.SyncDate).HasColumnType("datetime");

                entity.Property(e => e.Syncby).HasMaxLength(50);

                entity.Property(e => e.Updttime)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDTTIME")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UploadDate).HasColumnType("datetime");

                entity.Property(e => e.Uploadby).HasMaxLength(50);

                entity.Property(e => e.Userid)
                    .HasMaxLength(50)
                    .HasColumnName("USERID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Webpage)
                    .HasMaxLength(150)
                    .HasColumnName("WEBPAGE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Zipcode)
                    .HasMaxLength(50)
                    .HasColumnName("ZIPCODE")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblcontactDelAdre>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.ContactMyId, e.DeliveryAdressId });

                entity.ToTable("TBLCONTACT_DEL_ADRES");

                entity.Property(e => e.TenentId).HasColumnName("TenentID");

                entity.Property(e => e.ContactMyId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("ContactMyID");

                entity.Property(e => e.DeliveryAdressId)
                    .HasColumnName("DeliveryAdressID")
                    .HasComment("select * from reftable where tenentID=18 and reftype = 'COURIER' and REFSUBTYPE= 'AdresLocation' order by 5 ");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Addr1).HasColumnName("ADDR1");

                entity.Property(e => e.Addr2).HasColumnName("ADDR2");

                entity.Property(e => e.Addr3).HasColumnName("ADDR3");

                entity.Property(e => e.Address3)
                    .HasMaxLength(250)
                    .IsFixedLength(true);

                entity.Property(e => e.AdressName1).HasMaxLength(50);

                entity.Property(e => e.AdressShortName1).HasMaxLength(50);

                entity.Property(e => e.Block).HasMaxLength(100);

                entity.Property(e => e.Building).HasMaxLength(150);

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .HasColumnName("CITY")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CompId).HasColumnName("CompID");

                entity.Property(e => e.ContactId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("ContactID");

                entity.Property(e => e.Countryid).HasColumnName("COUNTRYID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.CrupId).HasColumnName("CRUP_ID");

                entity.Property(e => e.Cuserid)
                    .HasMaxLength(50)
                    .HasColumnName("CUSERID");

                entity.Property(e => e.DistrictId).HasColumnName("DistrictID");

                entity.Property(e => e.Entrydate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYDATE");

                entity.Property(e => e.Entrytime)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYTIME");

                entity.Property(e => e.FloorNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ForFlat).HasMaxLength(50);

                entity.Property(e => e.Lane).HasMaxLength(150);

                entity.Property(e => e.Latitute).HasMaxLength(50);

                entity.Property(e => e.Longitute).HasMaxLength(50);

                entity.Property(e => e.Pacinumber)
                    .HasMaxLength(20)
                    .HasColumnName("PACINumber");

                entity.Property(e => e.PostCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(255)
                    .HasColumnName("REMARKS");

                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .HasColumnName("STATE");

                entity.Property(e => e.Street).HasMaxLength(150);

                entity.Property(e => e.SynId).HasColumnName("SynID");

                entity.Property(e => e.SyncDate).HasColumnType("datetime");

                entity.Property(e => e.SyncStatus)
                    .HasMaxLength(50)
                    .HasColumnName("syncStatus");

                entity.Property(e => e.Syncby).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Updttime)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDTTIME");

                entity.Property(e => e.UploadDate).HasColumnType("datetime");

                entity.Property(e => e.Uploadby).HasMaxLength(50);
            });

            modelBuilder.Entity<Tblperiod>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.PeriodCode, e.Mysysname })
                    .IsClustered(false);

                entity.ToTable("TBLPERIODS");

                entity.Property(e => e.TenentId)
                    .HasColumnName("TenentID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PeriodCode).HasColumnName("PERIOD_CODE");

                entity.Property(e => e.Mysysname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MYSYSNAME");

                entity.Property(e => e.CrupId).HasColumnName("CRUP_ID");

                entity.Property(e => e.Glpost)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GLPOST")
                    .HasDefaultValueSql("('2')")
                    .IsFixedLength(true);

                entity.Property(e => e.Glpostref)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GLPOSTREF");

                entity.Property(e => e.Icpost)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ICPOST")
                    .HasDefaultValueSql("('2')")
                    .IsFixedLength(true);

                entity.Property(e => e.Icpostref)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ICPOSTREF");

                entity.Property(e => e.PrdEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("PRD_END_DATE");

                entity.Property(e => e.PrdMonth)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PRD_MONTH");

                entity.Property(e => e.PrdPeriod)
                    .HasMaxLength(10)
                    .HasColumnName("PRD_PERIOD");

                entity.Property(e => e.PrdPeriod1)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PRD_PERIOD1");

                entity.Property(e => e.PrdPeriod2)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PRD_PERIOD2");

                entity.Property(e => e.PrdPeriod3)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PRD_PERIOD3");

                entity.Property(e => e.PrdStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("PRD_START_DATE");

                entity.Property(e => e.PrdYear).HasColumnName("PRD_YEAR");

                entity.Property(e => e.Status1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS1")
                    .HasDefaultValueSql("('2')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Tbltranssubtype>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.Transsubid, e.Transid, e.Mysysname })
                    .HasName("PK_TBLTRANSSUBTYPE");

                entity.ToTable("tbltranssubtype");

                entity.Property(e => e.TenentId)
                    .HasColumnName("TenentID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Transsubid).HasColumnName("transsubid");

                entity.Property(e => e.Transid).HasColumnName("transid");

                entity.Property(e => e.Mysysname)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("MYSYSNAME");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('1')")
                    .IsFixedLength(true);

                entity.Property(e => e.CashBeh)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CrupId).HasColumnName("CRUP_ID");

                entity.Property(e => e.OnHandBeh)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')")
                    .IsFixedLength(true);

                entity.Property(e => e.OpQtyBeh)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')")
                    .IsFixedLength(true);

                entity.Property(e => e.QtyAtDestination)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.QtyAtSource)
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.QtyConsumedBeh)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')")
                    .IsFixedLength(true);

                entity.Property(e => e.QtyOutBeh)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')")
                    .IsFixedLength(true);

                entity.Property(e => e.QtyReceivedBeh)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.QtyReservedBeh)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')")
                    .IsFixedLength(true);

                entity.Property(e => e.Serialno)
                    .HasMaxLength(100)
                    .HasColumnName("serialno");

                entity.Property(e => e.Transsubtype)
                    .HasMaxLength(100)
                    .HasColumnName("transsubtype");

                entity.Property(e => e.Transsubtype1)
                    .HasMaxLength(100)
                    .HasColumnName("transsubtype1");

                entity.Property(e => e.Transsubtype2)
                    .HasMaxLength(100)
                    .HasColumnName("transsubtype2");

                entity.Property(e => e.Transsubtype3)
                    .HasMaxLength(100)
                    .HasColumnName("transsubtype3");

                entity.Property(e => e.Years)
                    .HasMaxLength(5)
                    .HasColumnName("years");
            });

            modelBuilder.Entity<Tbltranstype>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.Transid, e.Mysysname })
                    .HasName("PK_TBLTRANSTYPE");

                entity.ToTable("tbltranstype");

                entity.Property(e => e.TenentId)
                    .HasColumnName("TenentID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Transid).HasColumnName("transid");

                entity.Property(e => e.Mysysname)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("MYSYSNAME")
                    .HasDefaultValueSql("('IC')");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('1')")
                    .IsFixedLength(true);

                entity.Property(e => e.CrupId).HasColumnName("CRUP_ID");

                entity.Property(e => e.InoutSwitch)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("inoutSwitch")
                    .HasDefaultValueSql("('I')")
                    .IsFixedLength(true)
                    .HasComment("I=In O=Out C=Consume (case Sensitive)");

                entity.Property(e => e.Serialno)
                    .HasMaxLength(100)
                    .HasColumnName("serialno")
                    .HasDefaultValueSql("((1001))")
                    .HasComment("The Serial number running for this type of the Transaction is stored here in the terms of the main transaction type. This number can be reset by every year as year is mentioned below so when-ever u make transaction id printed use year as preprinted two digita");

                entity.Property(e => e.Switch1)
                    .HasMaxLength(1)
                    .HasColumnName("switch1")
                    .IsFixedLength(true);

                entity.Property(e => e.Transtype)
                    .HasMaxLength(100)
                    .HasColumnName("transtype");

                entity.Property(e => e.Transtype1)
                    .HasMaxLength(100)
                    .HasColumnName("transtype1");

                entity.Property(e => e.Transtype2)
                    .HasMaxLength(100)
                    .HasColumnName("transtype2");

                entity.Property(e => e.Transtype3)
                    .HasMaxLength(100)
                    .HasColumnName("transtype3");

                entity.Property(e => e.Years)
                    .HasMaxLength(5)
                    .HasColumnName("years")
                    .HasDefaultValueSql("((2014))")
                    .HasComment("Year of the transaction");
            });

            modelBuilder.Entity<TestTable>(entity =>
            {
                entity.ToTable("TestTable");
            });

            modelBuilder.Entity<TotalJv>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("'Total JV$'");

                entity.Property(e => e.AccountHead)
                    .HasMaxLength(255)
                    .HasColumnName("Account Head");

                entity.Property(e => e.Month).HasMaxLength(255);

                entity.Property(e => e.Remarks).HasMaxLength(255);

                entity.Property(e => e.SlNo).HasColumnName("Sl No");

                entity.Property(e => e.SubAccountExpenses)
                    .HasMaxLength(255)
                    .HasColumnName("Sub Account / Expenses");

                entity.Property(e => e.VoucherNo).HasColumnName("Voucher No");
            });

            modelBuilder.Entity<TransactionDt>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.Mytransid, e.LocationId, e.Myid })
                    .HasName("PK_ICTR_DT")
                    .IsClustered(false);

                entity.ToTable("TransactionDT");

                entity.Property(e => e.TenentId)
                    .HasColumnName("TenentID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Mytransid).HasColumnName("MYTRANSID");

                entity.Property(e => e.LocationId).HasColumnName("locationID");

                entity.Property(e => e.Myid).HasColumnName("MYID");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.Activityid)
                    .HasColumnName("ACTIVITYID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AttachId)
                    .HasColumnName("AttachId")
                    .HasColumnType("int")
                    .HasComment("TransactionHDDMS.AttachId");

                entity.Property(e => e.CrupId).HasColumnName("CRUP_ID");

                entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DiscountReference).HasMaxLength(50);

                entity.Property(e => e.EffectedAccount)
                    .HasMaxLength(50)
                    .HasComment("contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeID");

                entity.Property(e => e.Glpost)
                    .HasColumnName("GLPOST");

                entity.Property(e => e.Glpost1)
                    .HasColumnName("GLPOST1");

                entity.Property(e => e.Glpostref)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GLPOSTREF");

                entity.Property(e => e.Glpostref1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GLPOSTREF1")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InstallmentAmount)
                    .HasColumnType("decimal(18, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InstallmentNumber)
                    .HasColumnType("int")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OtherReference)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PendingAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.PeriodCode)
                    .HasColumnName("PERIOD_CODE")
                    .HasComment("TransactionHDDMS.AttachID");

                entity.Property(e => e.ReceivedAmount)
                    .HasColumnType("decimal(18, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceivedDate).HasColumnType("date");

                entity.Property(e => e.Switch1)
                    .HasMaxLength(20)
                    .HasColumnName("SWITCH1");

                entity.Property(e => e.UniversityBatchNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TransDTSubMonthly>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.Mytransid, e.LocationId, e.Myid, e.SeqId })
                    .HasName("PK_ICTR_DT")
                    .IsClustered(false);

                entity.ToTable("TransDTSubMonthly");

                entity.Property(e => e.TenentId)
                    .HasColumnName("TenentID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Mytransid).HasColumnName("MYTRANSID");

                entity.Property(e => e.LocationId).HasColumnName("locationID");

                entity.Property(e => e.Myid).HasColumnName("MYID");

                entity.Property(e => e.SeqId).HasColumnName("SEQID");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.Activityid)
                    .HasColumnName("ACTIVITYID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrupId).HasColumnName("CRUP_ID");

                entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DiscountReference).HasMaxLength(50);

                entity.Property(e => e.EffectedAccount)
                    .HasMaxLength(50)
                    .HasComment("contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeID");

                entity.Property(e => e.Glpost)
                    .HasColumnName("GLPOST");

                entity.Property(e => e.Glpost1)
                    .HasColumnName("GLPOST1");

                entity.Property(e => e.Glpostref)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GLPOSTREF");

                entity.Property(e => e.Glpostref1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GLPOSTREF1")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InstallmentAmount)
                    .HasColumnType("decimal(18, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InstallmentNumber)
                    .HasColumnType("int")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OtherReference)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PendingAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.PeriodCode)
                    .HasColumnName("PERIOD_CODE")
                    .HasComment("TransactionHDDMS.AttachID");

                entity.Property(e => e.ReceivedAmount)
                    .HasColumnType("decimal(18, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceivedDate).HasColumnType("date");

                entity.Property(e => e.Switch1)
                    .HasMaxLength(20)
                    .HasColumnName("SWITCH1");

                entity.Property(e => e.UniversityBatchNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.TotRecAmount)
                    .HasColumnType("decimal(18, 3)")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TransactionHd>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.Mytransid })
                    .IsClustered(false);

                entity.ToTable("TransactionHD");

                entity.Property(e => e.TenentId)
                    .HasColumnName("TenentID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Mytransid).HasColumnName("MYTRANSID");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.Activitycode)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVITYCODE");

                entity.Property(e => e.AmtPaid)
                    .HasColumnType("decimal(18, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AttachId)
                .HasColumnName("AttachId")
                .HasColumnType("int");

                entity.Property(e => e.BankId).HasColumnName("BankID");

                entity.Property(e => e.ChequeAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.ChequeDate).HasColumnType("date");

                entity.Property(e => e.ChequeNumber).HasMaxLength(20);

                entity.Property(e => e.Companyid).HasColumnName("COMPANYID");

                entity.Property(e => e.ConsumerLoanAct)
                    .HasMaxLength(50)
                    .HasComment("contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account");

                entity.Property(e => e.CrupId).HasColumnName("CRUP_ID");

                entity.Property(e => e.Discount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeID");

                entity.Property(e => e.Entrydate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYDATE");

                entity.Property(e => e.Entrytime)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYTIME");

                entity.Property(e => e.ExtraSwitch1).HasMaxLength(5);

                entity.Property(e => e.ExtraSwitch2).HasMaxLength(5);

                entity.Property(e => e.Glpostref)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GLPOSTREF")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Glpostref1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GLPOSTREF1")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.HajjAct).HasMaxLength(50);

                entity.Property(e => e.LoanAct).HasMaxLength(50);

                entity.Property(e => e.LocationId)
                    .HasColumnName("locationID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MasterServiceId)
                    .HasColumnName("MasterServiceID")
                    .HasComment("If there is Master Service id than unique of the ServiceSetup.ServiceID except this raw ServiceID will be in the drop Down\r\nIf this service ID Does not have any master or consecutive than it will be same as ServiceID");

                entity.Property(e => e.Mydocno)
                    .HasColumnType("int")
                    .HasColumnName("MYDOCNO")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OtherAct1)
                    .HasMaxLength(50)
                    .HasComment("contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account");

                entity.Property(e => e.OtherAct2)
                    .HasMaxLength(50)
                    .HasComment("contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account");

                entity.Property(e => e.OtherAct3)
                    .HasMaxLength(50)
                    .HasComment("contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account");

                entity.Property(e => e.OtherAct4)
                    .HasMaxLength(50)
                    .HasComment("contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account");

                entity.Property(e => e.PersLoanAct).HasMaxLength(50);

                entity.Property(e => e.Projectno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PROJECTNO")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.RefTransId).HasColumnName("RefTransID");

                entity.Property(e => e.Reference)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("REFERENCE")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.ServiceSubType)
                    .HasColumnType("nvarchar(100)")
                    .HasComment("Coming from RefTable RefType='KUPF' and RefSubtype='ConsumerLoanType' and Switch3=ServiceSetup.ServiceID");

                entity.Property(e => e.ServiceType)
                    .HasColumnType("nvarchar(100)")
                    .HasComment("Coming from RefTable RefType='KUPF' and RefSubtype='ServiceType'");

                entity.Property(e => e.Signatures)
                    .HasMaxLength(100)
                    .HasColumnName("signatures");

                entity.Property(e => e.Source)
                    .HasMaxLength(10)
                    .IsFixedLength(true)
                    .HasComment("Online / Local");

                entity.Property(e => e.Status).HasMaxLength(25);

                entity.Property(e => e.Totamt)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("TOTAMT")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Totinstallments)
                    .HasColumnType("decimal(4, 0)")
                    .HasColumnName("TOTInstallments")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TransDocNo)
                    .HasMaxLength(100)
                    .HasComment("TransactionHDDMS.AttachID");

                entity.Property(e => e.Transdate)
                    .HasColumnType("datetime")
                    .HasColumnName("TRANSDATE");

                entity.Property(e => e.Updttime)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDTTIME");

                entity.Property(e => e.Userbatchno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USERBATCHNO");

                entity.Property(e => e.Userid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USERID");
            });

            modelBuilder.Entity<TransactionHddapprovalDetail>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.Mytransid, e.LocationId, e.SerApprovalId })
                    .HasName("PK_TransactionHDDApprovalDetails  _1");

                entity.ToTable("TransactionHDDApprovalDetails  ");

                entity.Property(e => e.TenentId)
                    .HasColumnName("TenentID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Mytransid).HasColumnName("MYTRANSID");

                entity.Property(e => e.LocationId).HasColumnName("locationID");

                entity.Property(e => e.SerApprovalId)
                    .HasColumnType("int")
                    .HasColumnName("SerApprovalID")
                    .HasComment("REFID Coming from RefTable RefSubType='Role' and\r\n Which AprovalEmployeeRole will be allowed to be approved else it is to be left NULL");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.ApprovalDate).HasColumnType("date");

                entity.Property(e => e.AttachId).HasColumnName("AttachID");

                entity.Property(e => e.CrupId).HasColumnName("CRUP_ID");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeID")
                    .HasComment("Person who approved this his Id");

                entity.Property(e => e.Entrydate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYDATE");

                entity.Property(e => e.Entrytime)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYTIME");

                entity.Property(e => e.MasterServiceId)
                    .HasColumnName("MasterServiceID")
                    .HasComment("If there is Master Service id than unique of the ServiceSetup.ServiceID except this raw ServiceID will be in the drop Down\r\nIf this service ID Does not have any master or consecutive than it will be same as ServiceID");

                entity.Property(e => e.RejectionRemarks).HasMaxLength(250);

                entity.Property(e => e.RejectionType)
                    .HasColumnType("numeric(18, 0)")
                    .HasComment("Coming from RefTable RefType='KUPF' and  RefSubtype='LoanRefusedType'");

                entity.Property(e => e.SerApproval)
                    .HasMaxLength(50)
                    .HasComment("RefName1 having Role Coming from RefTable RefSubType='Role' and\r\n Which AprovalEmployeeRole will be allowed to be approved else it is to be left NULL");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.Status).HasMaxLength(25);

                entity.Property(e => e.Updttime)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDTTIME");

                entity.Property(e => e.Userid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USERID");
            });

            modelBuilder.Entity<TransactionHddm>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.Mytransid, e.AttachId, e.Serialno });

                entity.ToTable("TransactionHDDMS ");

                entity.Property(e => e.TenentId).HasColumnName("TenentID");

                entity.Property(e => e.Mytransid).HasColumnName("MYTRANSID");

                entity.Property(e => e.AttachId)
                    .HasColumnName("AttachID")
                    .HasComment("Continues Serial Number for This TenentID and this TransactionID");

                entity.Property(e => e.Serialno).HasComment("1,2,3,4 Continues Serial Number for This TenentID, this TransactionID and This AttachmentID ");

                entity.Property(e => e.Action).HasMaxLength(50);

                entity.Property(e => e.AttachmentByName).HasMaxLength(50);

                entity.Property(e => e.AttachmentPath)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.AttachmentsDetail)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Catid).HasColumnName("CATID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CrupId).HasColumnName("CRUP_ID");

                entity.Property(e => e.DocumentType)
                    .HasColumnType("numeric(18, 0)")
                    .HasComment("from  Reftable where refsubtype=’ DocType’");

                entity.Property(e => e.RoutId).HasColumnName("RoutID");

                entity.Property(e => e.ShareId).HasColumnName("ShareID");

                entity.Property(e => e.Subject).HasMaxLength(50);
            });

            modelBuilder.Entity<TreeFunction>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.NodeId, e.TenentId });

                entity.ToTable("TreeFunction");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.NodeId).HasColumnName("NodeID");

                entity.Property(e => e.TenentId)
                    .HasColumnName("TenentID")
                    .HasDefaultValueSql("((21))");

                entity.Property(e => e.DashBoardImage)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeleteAllow)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsGraph).HasDefaultValueSql("((0))");

                entity.Property(e => e.NodeImageUrl)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NodeNavUrl)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Other1Allow)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Other2Allow)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Other3Allow)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Other4Allow)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Other5Allow)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PagePath)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PageTitle).HasMaxLength(150);

                entity.Property(e => e.PageTitle1).HasMaxLength(150);

                entity.Property(e => e.PageTitle2).HasMaxLength(150);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.PrintAllow)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.ReadAllow)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.WriteAllow)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Y')");
            });

            modelBuilder.Entity<TreeNode>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.NodeId });

                entity.ToTable("TreeNode");

                entity.Property(e => e.TenentId).HasColumnName("TenentID");

                entity.Property(e => e.NodeId).HasColumnName("NodeID");

                entity.Property(e => e.CommandName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.DashBoardImage)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeleteAllow)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("(N'N')")
                    .IsFixedLength(true);

                entity.Property(e => e.IsGraph).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsSubParent).HasDefaultValueSql("((0))");

                entity.Property(e => e.LocationId)
                    .HasColumnName("LocationID")
                    .HasDefaultValueSql("((1))")
                    .HasComment("Branch / Location / Supplier / Customer");

                entity.Property(e => e.NodeImageUrl)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NodeNavUrl)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NodeValue)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Other1)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("(N'N')")
                    .IsFixedLength(true);

                entity.Property(e => e.Other2)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("(N'N')")
                    .IsFixedLength(true);

                entity.Property(e => e.Other3)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("(N'N')")
                    .IsFixedLength(true);

                entity.Property(e => e.Other4)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("(N'N')")
                    .IsFixedLength(true);

                entity.Property(e => e.Other5)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("(N'N')")
                    .IsFixedLength(true);

                entity.Property(e => e.PagePath)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PageTitle).HasMaxLength(150);

                entity.Property(e => e.PageTitle1).HasMaxLength(150);

                entity.Property(e => e.PageTitle2).HasMaxLength(150);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.PrintAllow)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("(N'Y')")
                    .IsFixedLength(true);

                entity.Property(e => e.ReadAllow)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("(N'Y')")
                    .IsFixedLength(true);

                entity.Property(e => e.SubParentId)
                    .HasColumnName("SubParentID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WriteAllow)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("(N'Y')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<University>(entity =>
            {
                entity.HasKey(e => e.TenentId)
                    .HasName("PK_University_1");

                entity.ToTable("University");

                entity.HasComment("Company Data");

                entity.HasIndex(e => new { e.TenentId, e.Myconlocid, e.Countryid, e.State, e.City }, "IX_UniversityCountStatCity");

                entity.HasIndex(e => new { e.TenentId, e.Myconlocid, e.UnivName1, e.UnivName2, e.UnivName3 }, "IX_UniversityUnivName");

                entity.HasIndex(e => new { e.TenentId, e.Myconlocid, e.Altmobphone }, "IX_University_Mob");

                entity.HasIndex(e => new { e.TenentId, e.Myconlocid, e.UnivName1, e.Altmobphone, e.UnivIdbyUser }, "University")
                    .IsUnique();

                entity.Property(e => e.TenentId)
                    .HasColumnName("TenentID")
                    .HasDefaultValueSql("((21))");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((1))")
                    .IsFixedLength(true);

                entity.Property(e => e.Addr1).HasColumnName("ADDR1");

                entity.Property(e => e.Addr2)
                    .HasMaxLength(100)
                    .HasColumnName("ADDR2");

                entity.Property(e => e.Altmobphone)
                    .HasMaxLength(50)
                    .HasColumnName("ALTMOBPHONE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BeginDate).HasColumnType("date");

                entity.Property(e => e.Busphone1)
                    .HasMaxLength(50)
                    .HasColumnName("BUSPHONE1")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("CITY")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CivilId)
                    .HasMaxLength(30)
                    .HasColumnName("CivilID")
                    .IsFixedLength(true);

                entity.Property(e => e.Countryid)
                    .HasColumnName("COUNTRYID")
                    .HasDefaultValueSql("((126))");

                entity.Property(e => e.CrupId)
                    .HasColumnName("CRUP_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Email1)
                    .HasMaxLength(50)
                    .HasColumnName("EMAIL1");

                entity.Property(e => e.Email2)
                    .HasMaxLength(240)
                    .HasColumnName("EMAIL2");

                entity.Property(e => e.Entrydate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYDATE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Entrytime)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYTIME")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Fax)
                    .HasMaxLength(50)
                    .HasColumnName("FAX")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Fax1)
                    .HasMaxLength(24)
                    .HasColumnName("FAX1")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Fax2)
                    .HasMaxLength(24)
                    .HasColumnName("FAX2")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HajjAct).HasMaxLength(50);

                entity.Property(e => e.Keyword)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LoanAct).HasMaxLength(50);

                entity.Property(e => e.Mobphone)
                    .HasMaxLength(50)
                    .HasColumnName("MOBPHONE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Myconlocid)
                    .HasColumnName("MYCONLOCID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OtherAct1).HasMaxLength(50);

                entity.Property(e => e.OtherAct2).HasMaxLength(50);

                entity.Property(e => e.OtherAct3).HasMaxLength(50);

                entity.Property(e => e.OtherAct4).HasMaxLength(50);

                entity.Property(e => e.OtherAct5).HasMaxLength(50);

                entity.Property(e => e.Paciid)
                    .HasMaxLength(30)
                    .HasColumnName("PACIID")
                    .IsFixedLength(true);

                entity.Property(e => e.PersLoanAct).HasMaxLength(50);

                entity.Property(e => e.Physicallocid)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("PHYSICALLOCID");

                entity.Property(e => e.Primlanguge)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PRIMLANGUGE")
                    .HasDefaultValueSql("('E')")
                    .IsFixedLength(true);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(255)
                    .HasColumnName("REMARKS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SerApproval1)
                    .HasMaxLength(50)
                    .HasComment("Coming from RefTable RefSubType='Role' and\r\n Which AprovalEmployeeRole will be allowed to be approved else it is to be left NULL");

                entity.Property(e => e.SerApproval2)
                    .HasMaxLength(50)
                    .HasComment("Which AprovalEmployeeRole will be allowed to be approved else it is to be left NULL");

                entity.Property(e => e.SerApproval3)
                    .HasMaxLength(50)
                    .HasComment("Which AprovalEmployeeRole will be allowed to be approved else it is to be left NULL");

                entity.Property(e => e.SerApproval4)
                    .HasMaxLength(50)
                    .HasComment("Which AprovalEmployeeRole will be allowed to be approved else it is to be left NULL");

                entity.Property(e => e.SerApproval5)
                    .HasMaxLength(50)
                    .HasComment("Which AprovalEmployeeRole will be allowed to be approved else it is to be left NULL");

                entity.Property(e => e.ServiceTypeCustom).HasComment("From RefTable REFSubtype='ServiceType'");

                entity.Property(e => e.ServiceTypeInfrastructure).HasComment("From RefTable REFSubtype='ServiceType'");

                entity.Property(e => e.ServiceTypeRegular).HasComment("From RefTable REFSubtype='ServiceType'");

                entity.Property(e => e.ServiceTypeReimbursement).HasComment("From RefTable REFSubtype='ServiceType'");

                entity.Property(e => e.ServiceTypeTermination).HasComment("From RefTable REFSubtype='ServiceType'");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .HasColumnName("STATE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SynId).HasColumnName("SynID");

                entity.Property(e => e.SyncDate).HasColumnType("datetime");

                entity.Property(e => e.Syncby).HasMaxLength(50);

                entity.Property(e => e.UnivIdbyUser).HasColumnName("UnivIDByUser");

                entity.Property(e => e.UnivName1).HasMaxLength(100);

                entity.Property(e => e.UnivName2).HasMaxLength(100);

                entity.Property(e => e.UnivName3).HasMaxLength(100);

                entity.Property(e => e.Updttime)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDTTIME")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UploadDate).HasColumnType("datetime");

                entity.Property(e => e.Uploadby).HasMaxLength(50);

                entity.Property(e => e.Userid)
                    .HasMaxLength(50)
                    .HasColumnName("USERID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Webpage)
                    .HasMaxLength(150)
                    .HasColumnName("WEBPAGE")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users", "Membership");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LocationId).HasColumnName("Location_ID");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TanentId).HasColumnName("Tanent_ID");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserDtl>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.UserDetailId, e.LocationId })
                    .HasName("PK_ACM_USER_DTL_1");

                entity.ToTable("USER_DTL");

                entity.Property(e => e.TenentId).HasColumnName("TenentID");

                entity.Property(e => e.UserDetailId).HasColumnName("USER_DETAIL_ID");

                entity.Property(e => e.LocationId).HasColumnName("LOCATION_ID");

                entity.Property(e => e.Address1)
                    .HasMaxLength(50)
                    .HasColumnName("ADDRESS1");

                entity.Property(e => e.Address2)
                    .HasMaxLength(50)
                    .HasColumnName("ADDRESS2");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("CITY");

                entity.Property(e => e.Country).HasColumnName("COUNTRY");

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(50)
                    .HasColumnName("COUNTRY_CODE");

                entity.Property(e => e.CrupId).HasColumnName("CRUP_ID");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(150)
                    .HasColumnName("EMAIL_ADDRESS");

                entity.Property(e => e.FaxNo)
                    .HasMaxLength(50)
                    .HasColumnName("FAX_NO");

                entity.Property(e => e.FromRegDt)
                    .HasMaxLength(50)
                    .HasColumnName("FROM_REG_DT");

                entity.Property(e => e.HouseNo)
                    .HasMaxLength(50)
                    .HasColumnName("HOUSE_NO");

                entity.Property(e => e.MobileNum)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("MOBILE_NUM");

                entity.Property(e => e.PanNo)
                    .HasMaxLength(50)
                    .HasColumnName("PAN_NO");

                entity.Property(e => e.PhNo)
                    .HasMaxLength(50)
                    .HasColumnName("PH_NO");

                entity.Property(e => e.PincodeNo)
                    .HasMaxLength(50)
                    .HasColumnName("PINCODE_NO");

                entity.Property(e => e.PostOffice)
                    .HasMaxLength(50)
                    .HasColumnName("POST_OFFICE");

                entity.Property(e => e.SecAns)
                    .HasMaxLength(100)
                    .HasColumnName("SEC_ANS");

                entity.Property(e => e.SecQues)
                    .HasMaxLength(150)
                    .HasColumnName("SEC_QUES");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .HasColumnName("STATE");

                entity.Property(e => e.Street)
                    .HasMaxLength(50)
                    .HasColumnName("STREET");

                entity.Property(e => e.Tehsil)
                    .HasMaxLength(50)
                    .HasColumnName("TEHSIL");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("TITLE");

                entity.Property(e => e.VillageTownCity)
                    .HasMaxLength(50)
                    .HasColumnName("VILLAGE_TOWN_CITY");

                entity.Property(e => e.Zip)
                    .HasMaxLength(50)
                    .HasColumnName("ZIP");
            });

            modelBuilder.Entity<UserMst>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.UserId, e.LocationId });

                entity.ToTable("USER_MST");

                entity.Property(e => e.TenentId).HasColumnName("TenentID");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.Property(e => e.LocationId).HasColumnName("LOCATION_ID");

                entity.Property(e => e.AccLock)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACC_LOCK");

                entity.Property(e => e.ActiveFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVE_FLAG");

                entity.Property(e => e.Activeuser).HasColumnName("ACTIVEUSER");

                entity.Property(e => e.ApprovalDt)
                    .HasColumnType("datetime")
                    .HasColumnName("APPROVAL_DT");

                entity.Property(e => e.Avtar)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.CrupId).HasColumnName("CRUP_ID");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.DateOfJoining).HasColumnType("datetime");

                entity.Property(e => e.EmailAddress).HasMaxLength(50);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.EmployeePosition).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.FirstName1)
                    .HasMaxLength(50)
                    .HasColumnName("FIRST_NAME1");

                entity.Property(e => e.FirstName2)
                    .HasMaxLength(50)
                    .HasColumnName("FIRST_NAME2");

                entity.Property(e => e.FirstTime)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_TIME");

                entity.Property(e => e.Language1).HasMaxLength(50);

                entity.Property(e => e.Language2).HasMaxLength(50);

                entity.Property(e => e.Language3).HasMaxLength(50);

                entity.Property(e => e.LastLoginDt)
                    .HasColumnType("datetime")
                    .HasColumnName("LAST_LOGIN_DT");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.LastName1)
                    .HasMaxLength(50)
                    .HasColumnName("LAST_NAME1");

                entity.Property(e => e.LastName2)
                    .HasMaxLength(50)
                    .HasColumnName("LAST_NAME2");

                entity.Property(e => e.LoginId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("LOGIN_ID");

                entity.Property(e => e.Password)
                    .HasMaxLength(150)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.PasswordChng)
                    .HasMaxLength(150)
                    .HasColumnName("PASSWORD_CHNG");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(500)
                    .HasColumnName("REMARKS");

                entity.Property(e => e.Salary)
                    .HasMaxLength(50)
                    .HasColumnName("salary");

                entity.Property(e => e.SignatureImage)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ThemeName)
                    .HasMaxLength(50)
                    .HasColumnName("THEME_NAME");

                entity.Property(e => e.TillDt)
                    .HasColumnType("datetime")
                    .HasColumnName("Till_DT")
                    .HasComment("Ayo Till date");

                entity.Property(e => e.UserDetailId).HasColumnName("USER_DETAIL_ID");

                entity.Property(e => e.UserType).HasColumnName("USER_TYPE");

                entity.Property(e => e.Userdate)
                    .HasColumnType("datetime")
                    .HasColumnName("USERDATE");

                entity.Property(e => e.VerificationCd)
                    .HasMaxLength(40)
                    .HasColumnName("VERIFICATION_CD");
            });

            modelBuilder.Entity<UserPage>(entity =>
            {
                entity.HasKey(e => e.UserWebPageId)
                    .HasName("PK__UserPage__D6CACE438595FAC8");

                entity.ToTable("UserPages", "Membership");

                entity.Property(e => e.UserWebPageId).HasColumnName("UserWebPageID");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.Property(e => e.WebPageId).HasColumnName("WebPage_ID");
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.LocationId, e.VoucherId });

                entity.ToTable("Voucher", "Accounts");

                entity.Property(e => e.TenentId)
                    .HasColumnName("TenentID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.VoucherId).HasColumnName("VoucherID");

                entity.Property(e => e.AccountId).HasColumnName("Account_ID");

                entity.Property(e => e.CostCenterId).HasColumnName("CostCenter_ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Crupid).HasColumnName("crupid");

                entity.Property(e => e.FileContentType)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FileExtension)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FilePath)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FperiodId).HasColumnName("FPeriod_ID");

                entity.Property(e => e.IsSingleEntry).HasDefaultValueSql("((0))");

                entity.Property(e => e.Narrations).HasMaxLength(500);

                entity.Property(e => e.OriginalFileName).HasMaxLength(1000);

                entity.Property(e => e.ReceiverName).HasMaxLength(500);

                entity.Property(e => e.ReferenceNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.VoucherCode)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.VoucherDate).HasColumnType("date");

                entity.Property(e => e.VoucherTypeId).HasColumnName("VoucherType_ID");
            });

            modelBuilder.Entity<VoucherDetail>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.LocationId, e.VoucherDetailId });

                entity.ToTable("VoucherDetail", "Accounts");

                entity.Property(e => e.TenentId)
                    .HasColumnName("TenentID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.VoucherDetailId).HasColumnName("VoucherDetailID");

                entity.Property(e => e.AccountId).HasColumnName("Account_ID");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.ChequeDate).HasColumnType("datetime");

                entity.Property(e => e.ChequeNo)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ClearedDate).HasColumnType("date");

                entity.Property(e => e.ClearedDateTime).HasColumnType("datetime");

                entity.Property(e => e.CostCenterId).HasColumnName("CostCenter_ID");

                entity.Property(e => e.Cr).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Dr).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Particular)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.VoucherId).HasColumnName("Voucher_ID");
            });

            modelBuilder.Entity<VoucherDetailHistory>(entity =>
            {
                entity.HasKey(e => new { e.TenentId, e.LocationId, e.VoucherDetailHistoryId });

                entity.ToTable("VoucherDetail_History", "Accounts");

                entity.Property(e => e.TenentId)
                    .HasColumnName("TenentID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.VoucherDetailHistoryId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("VoucherDetailHistoryID");

                entity.Property(e => e.AccountId).HasColumnName("Account_ID");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ChequeDate).HasColumnType("datetime");

                entity.Property(e => e.ChequeNo)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ClearedDate).HasColumnType("date");

                entity.Property(e => e.ClearedDateTime).HasColumnType("datetime");

                entity.Property(e => e.CostCenterId).HasColumnName("CostCenter_ID");

                entity.Property(e => e.Cr).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Crupid).HasColumnName("crupid");

                entity.Property(e => e.Dr).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FilePath)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.HistoryDate).HasColumnType("datetime");

                entity.Property(e => e.Particular)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.Property(e => e.VoucherDetailId).HasColumnName("VoucherDetail_ID");

                entity.Property(e => e.VoucherId).HasColumnName("Voucher_ID");
            });

            modelBuilder.Entity<VoucherType>(entity =>
            {
                entity.ToTable("VoucherTypes", "Accounts");

                entity.Property(e => e.VoucherTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("VoucherTypeID");

                entity.Property(e => e.ArabicVoucherName).HasMaxLength(50);

                entity.Property(e => e.CodePrefix)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VoucherName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwAwstatusCatWise>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwAWStatusCatWise");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVE");

                entity.Property(e => e.Awstatus)
                    .HasMaxLength(100)
                    .HasColumnName("AWStatus");

                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Department).HasMaxLength(100);

                entity.Property(e => e.DepartmentId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DepartmentID");

                entity.Property(e => e.Refsubtype)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("REFSUBTYPE");

                entity.Property(e => e.Reftype)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("REFTYPE");

                entity.Property(e => e.Sorting)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TenentId).HasColumnName("TenentID");
            });

            modelBuilder.Entity<WebPage>(entity =>
            {
                entity.ToTable("WebPages", "Membership");

                entity.Property(e => e.WebPageId).HasColumnName("WebPageID");

                entity.Property(e => e.ArabicPageTitle).HasMaxLength(500);

                entity.Property(e => e.ControllerName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PageIcon)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PageTitle)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId).HasColumnName("Parent_ID");

                entity.Property(e => e.ViewName)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WebPageUrl>(entity =>
            {
                entity.ToTable("WebPageUrls", "Membership");

                entity.Property(e => e.WebPageUrlId).HasColumnName("WebPageUrlID");

                entity.Property(e => e.Url)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WebPageId).HasColumnName("WebPage_ID");
            });


            //-----------------

            modelBuilder.Entity<DetailedEmployee>(entity =>
            {
                entity.Property(e => e.HoldQty)
                    .HasColumnType("decimal(18, 2)"); // Example precision and scale
                entity.Property(e => e.LoanOPAmount)
                    .HasColumnType("decimal(18, 2)");
                // Specify the store type for other decimal properties as well
            });

            modelBuilder.Entity<FUNCTION_MST>(entity =>
            {
                entity.Property(e => e.MENU_ORDER)
                    .HasColumnType("decimal(18, 2)"); // Example precision and scale
                                                      // Specify the store type for other decimal properties as well
            });

            modelBuilder.Entity<FUNCTION_USER>(entity =>
            {
                entity.Property(e => e.MENU_ORDER)
                    .HasColumnType("decimal(18, 2)"); // Example precision and scale
                                                      // Specify the store type for other decimal properties as well
            });

            modelBuilder.Entity<ServiceSetup>(entity =>
            {
                entity.Property(e => e.AllowDiscountAmount)
                    .HasColumnType("decimal(18, 2)"); // Example precision and scale
                                                      // Specify the store type for other decimal properties as well
            });

            modelBuilder.Entity<TransactionHd>(entity =>
            {
                entity.Property(e => e.AdjustmentAmount)
                    .HasColumnType("decimal(18, 2)"); // Example precision and scale
                                                      // Specify the store type for other decimal properties as well
            });
            modelBuilder.Entity<TransactionHd>(entity =>
            {
                entity.Property(e => e.AmountMinus)
                    .HasColumnType("decimal(18, 2)");
                entity.Property(e => e.AmountPlus)
                    .HasColumnType("decimal(18, 2)");
                entity.Property(e => e.CalculatedAmount)
                    .HasColumnType("decimal(18, 2)");
                entity.Property(e => e.DiscountedGiftAmount)
                    .HasColumnType("decimal(18, 2)");
                entity.Property(e => e.DownPayment)
                    .HasColumnType("decimal(18, 2)");
                entity.Property(e => e.DraftAmount1)
                    .HasColumnType("decimal(18, 2)");
                entity.Property(e => e.DraftAmount2)
                    .HasColumnType("decimal(18, 2)");
                entity.Property(e => e.EachInstallmentsAmt)
                    .HasColumnType("decimal(18, 2)");
                entity.Property(e => e.EntireLoanAmount)
                    .HasColumnType("decimal(18, 2)");
                entity.Property(e => e.FinancialAid)
                    .HasColumnType("decimal(18, 2)");
                entity.Property(e => e.FinancialAmount)
                    .HasColumnType("decimal(18, 2)");
                entity.Property(e => e.InstallmentAmount)
                    .HasColumnType("decimal(18, 2)");
                entity.Property(e => e.LoanAmountBalance)
                    .HasColumnType("decimal(18, 2)");
                entity.Property(e => e.PFFundRevenue)
                    .HasColumnType("decimal(18, 2)");
                entity.Property(e => e.PFFundRevenuePercentage)
                    .HasColumnType("decimal(18, 2)");
                entity.Property(e => e.PaidSubscriptionAmount)
                    .HasColumnType("decimal(18, 2)");
                entity.Property(e => e.PayPer1)
                    .HasColumnType("decimal(18, 2)");
                entity.Property(e => e.PayPer2)
                    .HasColumnType("decimal(18, 2)");
                entity.Property(e => e.SponsorDueAmount)
                    .HasColumnType("decimal(18, 2)");
                entity.Property(e => e.SubscriptionDueAmount)
                    .HasColumnType("decimal(18, 2)");
                entity.Property(e => e.TotalAmount)
                    .HasColumnType("decimal(18, 2)");

                // Add similar configurations for other decimal properties in the TransactionHd entity
            });


            modelBuilder.Entity<DetailedEmployee>(entity =>
            {
                entity.Property(e => e.LoanOPNotPaidAmount)
                    .HasColumnType("decimal(18, 2)");
                entity.Property(e => e.NextSetlementPayAmount)
                    .HasColumnType("decimal(18, 2)");
                entity.Property(e => e.SettlementAmount)
                    .HasColumnType("decimal(18, 2)");
                entity.Property(e => e.SubOPAmount)
                    .HasColumnType("decimal(18, 2)");
                entity.Property(e => e.SubOPNotPaidAmount)
                    .HasColumnType("decimal(18, 2)");

                // Add similar configurations for other decimal properties in the DetailedEmployee entity
            });

            modelBuilder.Entity<ServiceSetup>(entity =>
            {
                entity.Property(e => e.DocumentsCount)
                    .HasColumnType("decimal(18, 2)");
                entity.Property(e => e.OfferAmount)
                    .HasColumnType("decimal(18, 2)");

                // Add similar configurations for other decimal properties in the ServiceSetup entity
            });

            modelBuilder.Entity<EmployeeDetailsWithHistory>(entity =>
            {
                entity.HasKey(e => new { e.DETenentID, e.DELocationID, e.DEemployeeID }).IsClustered(false);
                entity.ToView("View_EmployeeDetailsWithHistory");

                entity.Property(e => e.DETenentID).HasColumnName("DETenentID").HasDefaultValueSql("((1))");
                entity.Property(e => e.DELocationID).HasColumnName("DELocationID").HasDefaultValueSql("((1))");
                entity.Property(e => e.DEemployeeID)
                    .HasMaxLength(20)
                    .HasColumnName("DEemployeeID");
                entity.Property(e => e.Department).HasColumnName("Department");
                entity.Property(e => e.Department_Name).HasColumnName("Department_Name");
                entity.Property(e => e.DEPFID).HasColumnName("DEPFID");
                entity.Property(e => e.ContractType).HasColumnName("ContractType");
                entity.Property(e => e.SubscribedDate).HasColumnType("datetime");
                entity.Property(e => e.AgreedSubAmount).HasColumnName("AgreedSubAmount");
                entity.Property(e => e.KUEmployee).HasColumnName("KUEmployee");
                entity.Property(e => e.OnSickLeave).HasColumnName("OnSickLeave");
                entity.Property(e => e.MemberOfFund).HasColumnName("MemberOfFund");
                entity.Property(e => e.ReSubscribed).HasColumnName("ReSubscribed");
                entity.Property(e => e.LoanAmount).HasColumnName("LoanAmount");
                /*entity.Property(e => e.ServiceSubTypeEnglish)
                    .HasMaxLength(50)
                    .HasColumnName("ServiceSubTypeEnglish");
                entity.Property(e => e.ServiceSubTypeArabic)
                    .HasMaxLength(50)
                    .HasColumnName("ServiceSubTypeArabic");
                entity.Property(e => e.ServiceSubTypeSorting)
                    .HasMaxLength(50)
                    .HasColumnName("ServiceSubTypeSorting");
                entity.Property(e => e.ServiceTypeEnglish)
                    .HasMaxLength(50)
                    .HasColumnName("ServiceTypeEnglish");
                entity.Property(e => e.ServiceTypeArabic)
                    .HasMaxLength(50)
                    .HasColumnName("ServiceTypeArabic");
                entity.Property(e => e.ServiceTypeSorting)
                    .HasMaxLength(50)
                    .HasColumnName("ServiceTypeSorting");
                entity.Property(e => e.ContractTypeID)
                    .HasMaxLength(50)
                    .HasColumnName("ContractTypeID");
                entity.Property(e => e.ContractTypeEnglish)
                    .HasMaxLength(50)
                    .HasColumnName("ContractTypeEnglish");
                entity.Property(e => e.ContractTypeArabic)
                    .HasMaxLength(50)
                    .HasColumnName("ContractTypeArabic");
                entity.Property(e => e.ContractTypeFullName)
                    .HasMaxLength(50)
                    .HasColumnName("ContractTypeFullName");
                entity.Property(e => e.ContractTypeSorting)
                    .HasMaxLength(50)
                    .HasColumnName("ContractTypeSorting");
                entity.Property(e => e.TerminationEnglish)
                    .HasMaxLength(50)
                    .HasColumnName("TerminationEnglish");
                entity.Property(e => e.TerminationArabic)
                    .HasMaxLength(50)
                    .HasColumnName("TerminationArabic");
                entity.Property(e => e.TerminationSorting)
                    .HasMaxLength(50)
                    .HasColumnName("TerminationSorting");
                entity.Property(e => e.COUNTRYID)
                    .HasMaxLength(50)
                    .HasColumnName("COUNTRYID");
                entity.Property(e => e.COUNAME1)
                    .HasMaxLength(50)
                    .HasColumnName("COUNAME1");
                entity.Property(e => e.COUNAME2)
                    .HasMaxLength(50)
                    .HasColumnName("COUNAME2");
                entity.Property(e => e.REFIDUniversityID)
                    .HasMaxLength(50)
                    .HasColumnName("REFIDUniversityID");
                entity.Property(e => e.UniversityEnglish)
                    .HasMaxLength(50)
                    .HasColumnName("UniversityEnglish");
                entity.Property(e => e.UniversityArabic)
                    .HasMaxLength(50)
                    .HasColumnName("UniversityArabic");
                entity.Property(e => e.UniversitySorting)
                    .HasMaxLength(50)
                    .HasColumnName("UniversitySorting");
                entity.Property(e => e.TransactionHDTenentID)
                    .HasMaxLength(50)
                    .HasColumnName("TransactionHDTenentID");
                entity.Property(e => e.TransactionHDTenentID)
                    .HasMaxLength(50)
                    .HasColumnName("TransactionHDTenentID");
                entity.Property(e => e.TransactionHDMYTRANSID)
                    .HasMaxLength(50)
                    .HasColumnName("TransactionHDMYTRANSID");
                entity.Property(e => e.TransactionHDlocationID)
                    .HasMaxLength(50)
                    .HasColumnName("TransactionHDlocationID");
                entity.Property(e => e.TransactionHDemployeeID)
                    .HasMaxLength(50)
                    .HasColumnName("TransactionHDemployeeID");
                entity.Property(e => e.TransactionHDSponserProvidentID)
                    .HasMaxLength(50)
                    .HasColumnName("TransactionHDSponserProvidentID");
                entity.Property(e => e.TransactionHDServieID)
                    .HasMaxLength(50)
                    .HasColumnName("TransactionHDServieID");
                entity.Property(e => e.TransactionHDMasterServiceID)
                    .HasMaxLength(50)
                    .HasColumnName("TransactionHDMasterServiceID");
                entity.Property(e => e.TransactionHDServiceTypeId)
                    .HasMaxLength(50)
                    .HasColumnName("TransactionHDServiceTypeId");
                entity.Property(e => e.TransactionHDServiceSubTypeId)
                    .HasMaxLength(50)
                    .HasColumnName("TransactionHDServiceSubTypeId");
                entity.Property(e => e.TransactionHDServiceType)
                    .HasMaxLength(50)
                    .HasColumnName("TransactionHDServiceType");
                entity.Property(e => e.TransactionHDServiceSubType)
                    .HasMaxLength(50)
                    .HasColumnName("TransactionHDServiceSubType");
                entity.Property(e => e.Source)
                    .HasMaxLength(50)
                    .HasColumnName("Source");
                entity.Property(e => e.AttachID)
                    .HasMaxLength(50)
                    .HasColumnName("AttachID");
                entity.Property(e => e.UserDefinedNumber)
                    .HasMaxLength(50)
                    .HasColumnName("UserDefinedNumber");
                entity.Property(e => e.TransDocNo)
                    .HasMaxLength(50)
                    .HasColumnName("TransDocNo");
                entity.Property(e => e.BankID)
                    .HasMaxLength(50)
                    .HasColumnName("BankID");
                entity.Property(e => e.VoucherNumber)
                    .HasMaxLength(50)
                    .HasColumnName("VoucherNumber");
                entity.Property(e => e.VoucherDate)
                    .HasMaxLength(50)
                    .HasColumnName("VoucherDate");
                entity.Property(e => e.AccountantID)
                    .HasMaxLength(50)
                    .HasColumnName("AccountantID");
                entity.Property(e => e.BenefeciaryName)
                    .HasMaxLength(50)
                    .HasColumnName("BenefeciaryName");
                entity.Property(e => e.ChequeNumber)
                    .HasMaxLength(50)
                    .HasColumnName("ChequeNumber");
                entity.Property(e => e.ChequeDate)
                    .HasMaxLength(50)
                    .HasColumnName("ChequeDate");
                entity.Property(e => e.ChequeAmount)
                    .HasMaxLength(50)
                    .HasColumnName("ChequeAmount");
                entity.Property(e => e.CollectedDate)
                    .HasMaxLength(50)
                    .HasColumnName("CollectedDate");
                entity.Property(e => e.CollectedBy)
                    .HasMaxLength(50)
                    .HasColumnName("CollectedBy");
                entity.Property(e => e.Relationship)
                    .HasMaxLength(50)
                    .HasColumnName("Relationship");
                entity.Property(e => e.CollectedPersonCID)
                    .HasMaxLength(50)
                    .HasColumnName("CollectedPersonCID");
                entity.Property(e => e.InstallmentsBegDate)
                    .HasMaxLength(50)
                    .HasColumnName("InstallmentsBegDate");
                entity.Property(e => e.PeriodBegin)
                    .HasMaxLength(50)
                    .HasColumnName("PeriodBegin");
                entity.Property(e => e.EachInstallmentsAmt)
                    .HasMaxLength(50)
                    .HasColumnName("EachInstallmentsAmt");
                entity.Property(e => e.TOTInstallments)
                    .HasMaxLength(50)
                    .HasColumnName("TOTInstallments");
                entity.Property(e => e.AllowDiscountDefault)
                    .HasMaxLength(50)
                    .HasColumnName("AllowDiscountDefault");
                entity.Property(e => e.DiscountType)
                    .HasMaxLength(50)
                    .HasColumnName("DiscountType");
                entity.Property(e => e.Discount)
                    .HasMaxLength(50)
                    .HasColumnName("Discount");
                entity.Property(e => e.DiscountedGiftAmount)
                    .HasMaxLength(50)
                    .HasColumnName("DiscountedGiftAmount");
                entity.Property(e => e.AmtPaid)
                    .HasMaxLength(50)
                    .HasColumnName("AmtPaid");
                entity.Property(e => e.TOTAMT)
                    .HasMaxLength(50)
                    .HasColumnName("TOTAMT");
                entity.Property(e => e.LoanAct)
                    .HasMaxLength(50)
                    .HasColumnName("LoanAct");
                entity.Property(e => e.HajjAct)
                    .HasMaxLength(50)
                    .HasColumnName("HajjAct");
                entity.Property(e => e.PersLoanAct)
                    .HasMaxLength(50)
                    .HasColumnName("PersLoanAct");
                entity.Property(e => e.ConsumerLoanAct)
                    .HasMaxLength(50)
                    .HasColumnName("ConsumerLoanAct");
                entity.Property(e => e.OtherAct1)
                    .HasMaxLength(50)
                    .HasColumnName("OtherAct1");
                entity.Property(e => e.OtherAct2)
                    .HasMaxLength(50)
                    .HasColumnName("OtherAct2");
                entity.Property(e => e.OtherAct3)
                    .HasMaxLength(50)
                    .HasColumnName("OtherAct3");
                entity.Property(e => e.DiscountType)
                    .HasMaxLength(50)
                    .HasColumnName("DiscountType");
                entity.Property(e => e.OtherAct4)
                    .HasMaxLength(50)
                    .HasColumnName("OtherAct4");
                entity.Property(e => e.OtherAct5)
                    .HasMaxLength(50)
                    .HasColumnName("OtherAct5");
                entity.Property(e => e.SerApproval1)
                    .HasMaxLength(50)
                    .HasColumnName("SerApproval1");
                entity.Property(e => e.ApprovalBy1)
                    .HasMaxLength(50)
                    .HasColumnName("ApprovalBy1");
                entity.Property(e => e.SerApproval2)
                    .HasMaxLength(50)
                    .HasColumnName("SerApproval2");
                entity.Property(e => e.ApprovalBy2)
                    .HasMaxLength(50)
                    .HasColumnName("ApprovalBy2");
                entity.Property(e => e.ApprovedDate2)
                    .HasMaxLength(50)
                    .HasColumnName("ApprovedDate2");
                entity.Property(e => e.SerApproval3)
                    .HasMaxLength(50)
                    .HasColumnName("SerApproval3");
                entity.Property(e => e.ApprovalBy3)
                    .HasMaxLength(50)
                    .HasColumnName("AmtPaid");
                entity.Property(e => e.ApprovedDate3)
                    .HasMaxLength(50)
                    .HasColumnName("ApprovedDate3");
                entity.Property(e => e.SerApproval4)
                    .HasMaxLength(50)
                    .HasColumnName("SerApproval4");
                entity.Property(e => e.ApprovalBy4)
                    .HasMaxLength(50)
                    .HasColumnName("ApprovalBy4");
                entity.Property(e => e.SerApproval5)
                    .HasMaxLength(50)
                    .HasColumnName("SerApproval5");
                entity.Property(e => e.ApprovalBy5)
                    .HasMaxLength(50)
                    .HasColumnName("ApprovalBy5");
                entity.Property(e => e.ApprovedDate5)
                    .HasMaxLength(50)
                    .HasColumnName("ApprovedDate5");
                entity.Property(e => e.SerApproval6)
                    .HasMaxLength(50)
                    .HasColumnName("SerApproval6");
                entity.Property(e => e.ApprovalBy6)
                    .HasMaxLength(50)
                    .HasColumnName("ApprovalBy6");
                entity.Property(e => e.ApprovedDate6)
                    .HasMaxLength(50)
                    .HasColumnName("ApprovedDate6");
                entity.Property(e => e.PFID)
                    .HasMaxLength(50)
                    .HasColumnName("PFID");
                entity.Property(e => e.InstallmentAmount)
                    .HasMaxLength(50)
                    .HasColumnName("InstallmentAmount");
                entity.Property(e => e.UntilMonth)
                    .HasMaxLength(50)
                    .HasColumnName("UntilMonth");
                entity.Property(e => e.DownPayment)
                    .HasMaxLength(50)
                    .HasColumnName("DownPayment");
                entity.Property(e => e.YearOfService)
                    .HasMaxLength(50)
                    .HasColumnName("YearOfService");
                entity.Property(e => e.NoOfTransactions)
                    .HasMaxLength(50)
                    .HasColumnName("NoOfTransactions");
                entity.Property(e => e.PaidSubscriptionAmount)
                    .HasMaxLength(50)
                    .HasColumnName("PaidSubscriptionAmount");
                entity.Property(e => e.SubscriptionDueAmount)
                    .HasMaxLength(50)
                    .HasColumnName("SubscriptionDueAmount");
                entity.Property(e => e.LoanAmountBalance)
                    .HasMaxLength(50)
                    .HasColumnName("LoanAmountBalance");
                entity.Property(e => e.FinancialAid)
                    .HasMaxLength(50)
                    .HasColumnName("FinancialAid");
                entity.Property(e => e.PFFundRevenuePercentage)
                    .HasMaxLength(50)
                    .HasColumnName("PFFundRevenuePercentage");
                entity.Property(e => e.AdjustmentAmount)
                    .HasMaxLength(50)
                    .HasColumnName("AdjustmentAmount");
                entity.Property(e => e.AdjustmentAmountRemarks)
                    .HasMaxLength(50)
                    .HasColumnName("AdjustmentAmountRemarks");
                entity.Property(e => e.FinancialAmount)
                    .HasMaxLength(50)
                    .HasColumnName("FinancialAmount");
                entity.Property(e => e.FinancialAmountRemarks)
                    .HasMaxLength(50)
                    .HasColumnName("FinancialAmountRemarks");
                entity.Property(e => e.NoOfSponsor)
                    .HasMaxLength(50)
                    .HasColumnName("NoOfSponsor");
                entity.Property(e => e.SponsorDueAmount)
                    .HasMaxLength(50)
                    .HasColumnName("SponsorDueAmount");
                entity.Property(e => e.TotalAmount)
                    .HasMaxLength(50)
                    .HasColumnName("TotalAmount");
                entity.Property(e => e.FinancialAidPercentage)
                    .HasMaxLength(50)
                    .HasColumnName("FinancialAidPercentage");
                entity.Property(e => e.PFFundRevenue)
                    .HasMaxLength(50)
                    .HasColumnName("PFFundRevenue");
                entity.Property(e => e.EntireLoanAmount)
                    .HasMaxLength(50)
                    .HasColumnName("EntireLoanAmount");
                entity.Property(e => e.PayPer1)
                    .HasMaxLength(50)
                    .HasColumnName("PayPer1");
                entity.Property(e => e.DraftNumber1)
                    .HasMaxLength(50)
                    .HasColumnName("DraftNumber1");
                entity.Property(e => e.DraftDate1)
                    .HasMaxLength(50)
                    .HasColumnName("DraftDate1");
                entity.Property(e => e.DraftAmount1)
                    .HasMaxLength(50)
                    .HasColumnName("DraftAmount1");
                entity.Property(e => e.BankAccount1)
                    .HasMaxLength(50)
                    .HasColumnName("BankAccount1");
                entity.Property(e => e.DeliveryDate1)
                    .HasMaxLength(50)
                    .HasColumnName("DeliveryDate1");
                entity.Property(e => e.ReceivedBy1)
                    .HasMaxLength(50)
                    .HasColumnName("ReceivedBy1");
                entity.Property(e => e.DeliveredBy1)
                    .HasMaxLength(50)
                    .HasColumnName("DeliveredBy1");
                entity.Property(e => e.DraftNumber2)
                    .HasMaxLength(50)
                    .HasColumnName("DraftNumber2");
                entity.Property(e => e.PayPer2)
                    .HasMaxLength(50)
                    .HasColumnName("PayPer2");
                entity.Property(e => e.DraftDate2)
                    .HasMaxLength(50)
                    .HasColumnName("DraftDate2");
                entity.Property(e => e.DraftAmount2)
                    .HasMaxLength(50)
                    .HasColumnName("DraftAmount2");
                entity.Property(e => e.BankAccount2)
                    .HasMaxLength(50)
                    .HasColumnName("BankAccount2");
                entity.Property(e => e.DeliveryDate2)
                    .HasMaxLength(50)
                    .HasColumnName("DeliveryDate2");
                entity.Property(e => e.ReceivedBy2)
                    .HasMaxLength(50)
                    .HasColumnName("ReceivedBy2");
                entity.Property(e => e.DeliveredBy2)
                    .HasMaxLength(50)
                    .HasColumnName("DeliveredBy2");
                entity.Property(e => e.ACTIVITYCODE)
                   .HasMaxLength(50)
                   .HasColumnName("ACTIVITYCODE");
                entity.Property(e => e.MYDOCNO)
                    .HasMaxLength(50)
                    .HasColumnName("MYDOCNO");
                entity.Property(e => e.USERBATCHNO)
                    .HasMaxLength(50)
                    .HasColumnName("USERBATCHNO");
                entity.Property(e => e.PROJECTNO)
                    .HasMaxLength(50)
                    .HasColumnName("PROJECTNO");
                entity.Property(e => e.TRANSDATE)
                    .HasMaxLength(50)
                    .HasColumnName("TRANSDATE");
                entity.Property(e => e.REFERENCE)
                    .HasMaxLength(50)
                    .HasColumnName("REFERENCE");
                entity.Property(e => e.NOTES)
                    .HasMaxLength(50)
                    .HasColumnName("NOTES");
                entity.Property(e => e.GLPOSTREF)
                    .HasMaxLength(50)
                    .HasColumnName("GLPOSTREF");
                entity.Property(e => e.GLPOSTREF1)
                    .HasMaxLength(50)
                    .HasColumnName("GLPOSTREF1");
                entity.Property(e => e.COMPANYID)
                    .HasMaxLength(50)
                    .HasColumnName("COMPANYID");
                entity.Property(e => e.Terms)
                    .HasMaxLength(50)
                    .HasColumnName("Terms");
                entity.Property(e => e.RefTransID)
                    .HasMaxLength(50)
                    .HasColumnName("RefTransID");
                entity.Property(e => e.signatures)
                    .HasMaxLength(50)
                    .HasColumnName("signatures");
                entity.Property(e => e.ExtraSwitch1)
                    .HasMaxLength(50)
                    .HasColumnName("ExtraSwitch1");
                entity.Property(e => e.ExtraSwitch2)
                    .HasMaxLength(50)
                    .HasColumnName("ExtraSwitch2");
                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasColumnName("Status");
                entity.Property(e => e.USERID)
                    .HasMaxLength(50)
                    .HasColumnName("USERID");
                entity.Property(e => e.ACTIVE)
                    .HasMaxLength(50)
                    .HasColumnName("ACTIVE");
                entity.Property(e => e.ReceivedDate1)
                    .HasMaxLength(50)
                    .HasColumnName("ReceivedDate1");
                entity.Property(e => e.ReceivedDate2)
                    .HasMaxLength(50)
                    .HasColumnName("ReceivedDate2");
                entity.Property(e => e.AmountMinus)
                    .HasMaxLength(50)
                    .HasColumnName("AmountMinus");
                entity.Property(e => e.AmountPlus)
                    .HasMaxLength(50)
                    .HasColumnName("AmountPlus");
                entity.Property(e => e.SystemRemarks)
                    .HasMaxLength(50)
                    .HasColumnName("SystemRemarks");
                entity.Property(e => e.IsDraftCreated)
                    .HasMaxLength(50)
                    .HasColumnName("IsDraftCreated");
                entity.Property(e => e.CalculatedAmount)
                    .HasMaxLength(50)
                    .HasColumnName("CalculatedAmount");
                entity.Property(e => e.PendingAmount)
                    .HasMaxLength(50)
                    .HasColumnName("PendingAmount");*/
                // Add similar configurations for other decimal properties in the ServiceSetup entity
            });

            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
