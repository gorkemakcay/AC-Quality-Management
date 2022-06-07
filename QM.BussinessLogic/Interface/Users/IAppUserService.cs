using Microsoft.AspNetCore.Identity;
using QM.Common.ViewModels.Users.AppUserViewModels;
using QM.Entities.Concrete.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QM.BussinessLogic.Interface.Users
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        Task<string> LogIn(AppUserLogInViewModel model);
        List<AppUserListViewModel> GetAllUser();

        Task<IdentityResult> Registration(AppUserAddViewModel model);

        AppUserUpdateViewModel GetUserInfo(int userId);

        Task<IdentityResult> UpdateUser(AppUserUpdateViewModel model);

        Task<AppUser> FindByIdAsync(int userId);


    }
}
