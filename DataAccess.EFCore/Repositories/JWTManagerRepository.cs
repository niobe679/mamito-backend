using Domain.Interfaces;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace DataAccess.EFCore.Repositories
{
    public class JWTManagerRepository : GenericRepository<Tokens>, IJWTManagerRepository
	{


		private readonly IConfiguration iconfiguration;
		private readonly IAccountRepository _accountRepository;

		public JWTManagerRepository(ApplicationContext context, IConfiguration iconfiguration, IAccountRepository accountRepository) : base(context)
		{
			this.iconfiguration = iconfiguration;
			_accountRepository = accountRepository;
		}
		public Tokens Authenticate(string email, string password)
		{
			List<Account> UsersRecords = _accountRepository.GetAll().ToList();
			if (!UsersRecords.Any(x => x.Email == email && x.Password == password))
			{
				return null;
			}

			// Else we generate JSON Web Token
			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
			  {
			 new Claim(ClaimTypes.Email, email)
			  }),
				Expires = DateTime.UtcNow.AddMinutes(10),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return new Tokens { Token = tokenHandler.WriteToken(token) };

		}
	}
}
