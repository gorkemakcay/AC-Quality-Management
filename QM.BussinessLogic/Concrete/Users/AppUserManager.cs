using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using QM.BussinessLogic.Interface.Users;
using QM.Common.ViewModels.Users.AppUserViewModels;
using QM.DataAccess.UnitOfWorks.Interface;
using QM.Entities.Concrete.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM.BussinessLogic.Concrete.Users
{
    public class AppUserManager : GenericManager<AppUser>, IAppUserService
    {
        private readonly IUnitOfWork _Uow;
        private readonly IMapper _Mapper;
        private readonly UserManager<AppUser> _UserManager;
        private readonly SignInManager<AppUser> _SignInManager;
        private IPasswordHasher<AppUser> _PasswordHasher;

        public AppUserManager(IUnitOfWork uow, 
                              IMapper mapper, 
                              IPasswordHasher<AppUser> passwordHash, 
                              SignInManager<AppUser> signInManager, 
                              UserManager<AppUser> userManager) : base(uow)
        {
            _Uow = uow;
            _Mapper = mapper;
            _SignInManager = signInManager;
            _UserManager = userManager;
            _PasswordHasher = passwordHash;
        }
        public List<AppUserListViewModel> GetAllUser()
        {
            return _Mapper.Map<List<AppUserListViewModel>>(GetAll());
        }

        public AppUserUpdateViewModel GetUserInfo(int userId)
        {
            return _Mapper.Map<AppUserUpdateViewModel>(GetById(userId));
        }

        public async Task<string> LogIn(AppUserLogInViewModel model)
        {
            var user = await _UserManager.FindByNameAsync(model.UserName);
            if (user != null && String.Equals(user.UserName, model.UserName, StringComparison.CurrentCulture))
            {
                var signInResult = await _SignInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                if (signInResult.Succeeded)
                {
                    var roles = await _UserManager.GetRolesAsync(user);
                    return roles[0].ToString();
                }
            }
            return null;
        }

        public async Task<IdentityResult> Registration(AppUserAddViewModel model)
        {
            AppUser user = new AppUser();
            user = _Mapper.Map<AppUser>(model);

            var result = await _UserManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return await _UserManager.AddToRoleAsync(user, "Member");
            }
            else
                return null;
        }

        public async Task<IdentityResult> UpdateUser(AppUserUpdateViewModel model)
        {
            AppUser user = await _UserManager.FindByIdAsync(model.Id.ToString());
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Gender = model.Gender;
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.DepartmentName = model.DepartmentName;
            user.PasswordHash = _PasswordHasher.HashPassword(user, model.Password);

            var result = await _UserManager.UpdateAsync(user);
            return result;
        }

        public Task<AppUser> FindByIdAsync(int userId)
        {
            AppUser user = (AppUser)Activator.CreateInstance(typeof(AppUser));
            user.UserName = userId.ToString();
            user.PasswordHash = null;

            //I'm suppose to query the database with userId parameter here
            return Task.FromResult<AppUser>(user); //return as is
        }
    }
}