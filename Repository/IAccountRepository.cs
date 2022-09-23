using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TrialBookStoreWebApi.Model;

namespace TrialBookStoreWebApi.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel SignUpModel);
        Task<string> LoginAsync(SignInModel signIn);
    }
}