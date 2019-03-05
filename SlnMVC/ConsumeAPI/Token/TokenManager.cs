using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ConsumeAPI.Token
{
    public class TokenManager
    {
        string secretKey = "asdwda1d8a4sd8w4das8d*w8d*asd@#";
        string audienceToken = "http"; 
        string issuerToken = "http";
        string expireTime = "30"; 

        public string GenerateTokenJwt(string username)
        {
            // appsetting for Token JWT
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // create a claimsIdentity 
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) });

            // create token to the user 
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audienceToken,
                issuer: issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)),
                signingCredentials: signingCredentials);

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;


            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            //var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //var token = new JwtSecurityToken(issuerToken,
            //  audienceToken,
            //  expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)),
            //  signingCredentials: creds);

            //return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
