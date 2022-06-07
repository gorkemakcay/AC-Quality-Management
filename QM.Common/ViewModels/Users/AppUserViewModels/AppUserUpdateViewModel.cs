using System;

namespace QM.Common.ViewModels.Users.AppUserViewModels
{
    public class AppUserUpdateViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Picture { get; set; }
        public string Gender { get; set; }
        public string DepartmentName { get; set; }//Kullanıcının departmanı - Foreign Key.
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
