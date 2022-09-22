using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TrialBookStoreWebApi.Modal
{
    public class UserModal : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}