using Microsoft.AspNetCore.Identity;
using QM.Common.ViewModels.Users.AppRoleViewModels;
using QM.Entities.Concrete.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QM.BussinessLogic.Interface.Users
{
    public interface IAppRoleService : IGenericService<AppRole>
    {
        Task<IdentityResult> AddAppRole(AppRoleAddViewModel model);

        void DeleteAppRole(AppRoleListViewModel model);

        AppRoleUpdateViewModel GetAppRoleInfoToUpdate(int roleId);

        List<AppRoleListViewModel> GetAllAppRoles();

        Task<IdentityResult> UpdateAppRole(AppRoleUpdateViewModel model);
    }
}
