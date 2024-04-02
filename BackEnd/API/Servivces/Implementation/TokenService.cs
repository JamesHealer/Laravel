using API.Common;
using API.DTOs;
using API.Models;
using API.Servivces.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Servivces.Implementation
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly string _issuer;  
        private readonly double _tokenValidity;
        public TokenService(IConfiguration _config)
        {
            var secret = _config.GetSection("JwtConfig").GetSection("secret").Value;
            _key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
           // _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["TokenKey"]));
              _issuer = _config.GetSection("JwtConfig").GetSection("ValidIssuer").Value;
            _tokenValidity =Convert.ToDouble(_config.GetSection("JwtConfig").GetSection("TokenValidity").Value);
        }

        public string CreateToken(string userName)
        {

            //var claims = new[] {
            //    new Claim(JwtRegisteredClaimNames.NameId, userName.ToString()),
            //    new Claim(JwtRegisteredClaimNames.Email, userEmail),
            //   };
             

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, userName)
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(_issuer, _issuer, claims,
                        expires: DateTime.Now.AddDays(_tokenValidity),
                        signingCredentials: creds);

            ///////////  save token in database
            var tokenValue= new JwtSecurityTokenHandler().WriteToken(token);
            var data = new TokenAuthorizationModel();
            Hashtable hashTable = new Hashtable();
            hashTable.Add("userName", userName);
            hashTable.Add("tokenValue", tokenValue);
            hashTable.Add("tokenValidity", _tokenValidity);
            DataSet objDataset = CommonMethods.GetDataSet("[dbo].[spCreateTokenValue]", CommandType.StoredProcedure, hashTable);
            data = this.AutoMapToObject<TokenAuthorizationModel>(objDataset.Tables[0]).FirstOrDefault();

            return tokenValue;
        }

        public bool IsTokenValid(string token)
        {
            
           // var mySecret = Encoding.UTF8.GetBytes(key);
           // var mySecurityKey = new SymmetricSecurityKey(mySecret);
            var mySecurityKey = _key;
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _issuer,
                    ValidAudience = _issuer,
                    IssuerSigningKey = mySecurityKey,
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public string GetTokenValueByUserName(string userName)
        {
            try
            {
                var data = new TokenAuthorizationModel();
                Hashtable hashTable = new Hashtable();
                hashTable.Add("userName", userName);
                DataSet objDataset = CommonMethods.GetDataSet("[dbo].[spGetTockenNo]", CommandType.StoredProcedure, hashTable);
                data = this.AutoMapToObject<TokenAuthorizationModel>(objDataset.Tables[0]).FirstOrDefault();
               if(data != null)
                return data.TokenNo;
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        private   string GenerateTokenValueByUserName(string userName)
        {
            try
            {
                var data = new TokenAuthorizationModel();
                Hashtable hashTable = new Hashtable();
                hashTable.Add("userName", userName);
                DataSet objDataset = CommonMethods.GetDataSet("[dbo].[spCreateTokenValue]", CommandType.StoredProcedure, hashTable);
                data = this.AutoMapToObject<TokenAuthorizationModel>(objDataset.Tables[0]).FirstOrDefault();
                if (data != null)
                    return data.TokenNo;
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        public int UpdateTokenDetailsByUserName(string userName)
        {
            int result = 0;
            try
            {
                var data = new TokenAuthorizationModel();
                Hashtable hashTable = new Hashtable();
                hashTable.Add("userName", userName);
                DataSet objDataset = CommonMethods.GetDataSet("[dbo].[spUpdateTokenDetails]", CommandType.StoredProcedure, hashTable);
                result = (int)objDataset.Tables[0].Rows[0][0];
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
            
        }
    }
}
