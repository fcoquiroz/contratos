using Microsoft.IdentityModel.Tokens;
using Repository.Persistence;
using scontracts.Shared.DTO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace scontracts.Api.Helpers
{
    /// <summary>
    /// CtoTokens
    /// </summary>
    public class CtoTokens
    
    {
        /// <summary>
        /// ValidateRefreshToken
        /// </summary>
        /// <param name="user"></param>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        public async Task<bool> ValidateRefreshToken(UserDTO user, string refreshToken)
        {
            RefreshTokenDTO refreshTokenUser;
            using (var unitofwork = new UnitOfWork(new DataContext()))
                refreshTokenUser = unitofwork.Cat_UsuarioRoutines.ValidateRefreshToken(refreshToken);


            if (refreshTokenUser != null && refreshTokenUser.UserId == user.UserId
                && refreshTokenUser.ExpiryDate > DateTime.UtcNow)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// GetUserFromAccessToken
        /// </summary>
        /// <param name="secret"></param>
        /// <param name="accessToken"></param>
        /// <param name="aud"></param>
        /// <param name="iss"></param>
        /// <returns></returns>
        public async Task<UserDTO> GetUserFromAccessToken(string secret, string accessToken, string aud, string iss)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(secret);

                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = iss,
                    ValidAudience = aud
                };

                SecurityToken securityToken;
                var principle = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out securityToken);

                JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;

                if (jwtSecurityToken != null && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    var userId = principle.FindFirst(ClaimTypes.Name)?.Value;
                    using (var unitofwork = new UnitOfWork(new DataContext()))
                    return unitofwork.Cat_UsuarioRoutines.GetUser(Convert.ToInt32(userId));
                    
                }
            }
            catch (Exception ex)
            {
                string exs = ex.Message;
                return new UserDTO {UserId=-1 } ;
            }

            return new UserDTO();
        }
        /// <summary>
        /// GenerateRefreshToken
        /// </summary>
        /// <returns></returns>
        public RefreshTokenDTO GenerateRefreshToken()
        {
            RefreshTokenDTO refreshToken = new RefreshTokenDTO();

            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                refreshToken.Token = Convert.ToBase64String(randomNumber);
            }
            refreshToken.ExpiryDate = DateTime.UtcNow.AddMinutes(1);

            return refreshToken;
        }

        /// <summary>
        /// GenerateAccessToken
        /// </summary>
        /// <param name="secret"></param>
        /// <param name="userId"></param>
        /// <param name="aud"></param>
        /// <param name="iss"></param>
        /// <returns></returns>
        public string GenerateAccessToken(string secret, int userId, string aud, string iss)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, Convert.ToString(userId))
                }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                Issuer= iss,
                Audience = aud,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }



    }

}
