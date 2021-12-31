using System;
using BookStore.API.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStore.API.Repositories
{
	public interface IAccountRepository
	{
		Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
		Task<string> LoginAsync(SignInModel signInModel);

	}
}

