﻿using Microsoft.IdentityModel.Tokens;
using ProfitFlowBackend.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProfitFlowBackend.Services
{
    public class TokenService
    {

        private IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(Usuario usuario)
        {
            Claim[] claims = new Claim[]
            {
            new Claim("username", usuario.UserName),
            new Claim("id", usuario.Id),
            };
            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SymmetricSecurityKey"]));
            var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(expires: DateTime.Now.AddDays(1), claims: claims, signingCredentials: signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}