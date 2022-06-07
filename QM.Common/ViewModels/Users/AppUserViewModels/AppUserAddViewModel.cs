using System;
using System.ComponentModel.DataAnnotations;

namespace QM.Common.ViewModels.Users.AppUserViewModels
{
    public class AppUserAddViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Picture { get; set; }
        public string Gender { get; set; }
        public string DepartmentName { get; set; }//Kullanıcının departmanı - Foreign Key.
        [Required]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
