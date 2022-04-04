//using Microsoft.aspnetcore.authentication;
//using Microsoft.aspnetcore.authentication.jwtbearer;
//using Microsoft.identitymodel.tokens;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using IntelPro.Helpers;

namespace intelpro
{
    public class JwtHelper : IJwtHelper
    {
        //private readonly SymmetricSecurityKey symmetricsecuritykey;
        private readonly string _key;

        public JwtHelper(string key)
        {
            _key = key;
        }

        public string GetToken(string username) 
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            byte[] tokenKey = Encoding.ASCII.GetBytes(_key);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name , username) } ),
                Expires = DateTime.Now.AddMinutes(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey) , SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        //public string GetToken(string username, string role)
        //{
        //    Claim claimbyusername = new Claim(ClaimTypes.Name,username);
        //    Claim claimbyrole = new Claim(ClaimTypes.Role, role);
        //    List<Claim> claims = new List<Claim> { claimbyusername, claimbyrole };
        //    ClaimsIdentity claimsidentity = new ClaimsIdentity(claims);

        //    SigningCredentials signingcredentials = new SigningCredentials(symmetricsecuritykey, SecurityAlgorithms.HmacSha512Signature);

        //    SecurityTokenDescriptor securitytokendescriptor = new SecurityTokenDescriptor();
        //    securitytokendescriptor.Subject = claimsidentity;
        //    securitytokendescriptor.SigningCredentials = signingcredentials;
        //    securitytokendescriptor.Expires = DateTime.UtcNow.AddHours(1);


        //    JwtSecurityTokenHandler jwtsecuritytokenhandler = new JwtSecurityTokenHandler();
        //    SecurityToken securitytoken = jwtsecuritytokenhandler.CreateToken(securitytokendescriptor);
        //    string token = jwtsecuritytokenhandler.WriteToken(securitytoken);

        //    return token;

        //}

        //public void setauthenticationoptions(AuthenticationOptions options)
        //{
        //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
           
        //}

        //public void setbeareroptions(JwtBearerOptions options)
        //{
        //    TokenValidationParameters tokenvalidationparameters = new TokenValidationParameters();
        //    tokenvalidationparameters.IssuerSigningKey = symmetricsecuritykey;
        //    tokenvalidationparameters.ValidateIssuer = false;
        //    tokenvalidationparameters.ValidateAudience = false;
        //    tokenvalidationparameters.ClockSkew = TimeSpan.Zero;
        //    options.TokenValidationParameters = tokenvalidationparameters;


        //}
    }
}
