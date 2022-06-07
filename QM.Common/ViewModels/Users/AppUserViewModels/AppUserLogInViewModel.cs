using System;
using System.ComponentModel.DataAnnotations;

namespace QM.Common.ViewModels.Users.AppUserViewModels
{
    public class AppUserLogInViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
