using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TrialBookStoreWebApi.Modal;

namespace TrialBookStoreWebApi.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<UserModal> _userManager;

        public AccountRepository(UserManager<UserModal> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModal signUpModal)
        {
            var user = new UserModal()
            {
                FirstName = signUpModal.FirstName,
                LastName = signUpModal.LastName,
                Email = signUpModal.Email,
                UserName = signUpModal.Email
            };

            return await _userManager.CreateAsync(user, signUpModal.Password);
        }
    }
}