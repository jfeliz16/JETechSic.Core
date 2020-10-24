﻿using JETech.SIC.Core.Data.Entities;
using JETech.SIC.Core.Exceptions;
using JETech.SIC.Core.Global;
using JETech.SIC.Core.User.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JETech.SIC.Core.User.Helper
{
    public class UsersManager 
    {
        private readonly UserManager<Data.Entities.User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<Data.Entities.User> _signInManager;
        private readonly MailHelper _mailHelper;

        public UsersManager(
            UserManager<Data.Entities.User> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<Data.Entities.User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public UsersManager(
            UserManager<Data.Entities.User> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<Data.Entities.User> signInManager,
            MailHelper mailHelper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _mailHelper = mailHelper;
        }

        public async Task<IdentityResult> CreateAsync(UserModel user)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(user.FirstName)) 
                {
                    throw new JETechException(Global.Messages.NullField, "Nombres"); 
                }
                if (string.IsNullOrWhiteSpace(user.LastName)) 
                {
                    throw new JETechException(Global.Messages.NullField, "Apellidos"); 
                }
                if (string.IsNullOrWhiteSpace(user.UserName)) 
                { 
                    throw new JETechException(Global.Messages.NullField, "Usuario");
                }
                if (string.IsNullOrWhiteSpace(user.Password)) 
                { 
                    throw new JETechException(Global.Messages.NullField, "Contraseña");
                }
                if (user.Password != user.PasswordConfirm) 
                { 
                    throw new JETechException(Global.Messages.NullField, "Contraseña"); 
                }

                var userFinded = await GetUserByEmailAsync(user.UserName);

                if (userFinded != null) throw new JETechException(Global.Messages.NullField); 

                var userEntity = UserConverter.ToUser(user);

                return await _userManager.CreateAsync(userEntity, user.Password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddUserToRoleAsync(Data.Entities.User user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }
        }

        public async Task<Data.Entities.User> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;
        }

        public async Task<bool> IsUserInRoleAsync(Data.Entities.User user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        public async Task<SignInResult> LoginAsync(LoginModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Username)) throw new JETechException("Usuario no pueder nulo.");
                if (string.IsNullOrEmpty(model.Password)) throw new JETechException("Contraseña no puede ser nulo.");

                return await _signInManager.PasswordSignInAsync(
                    model.Username,
                    model.Password,
                    model.RememberMe,
                    false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> DeleteUserAsync(string email)
        {
            var user = await GetUserByEmailAsync(email);
            if (user == null)
            {
                return true;
            }

            var response = await _userManager.DeleteAsync(user);
            return response.Succeeded;
        }

        public async Task<IdentityResult> UpdateUserAsync(Data.Entities.User user)
        {
            return await _userManager.UpdateAsync(user);
        }

        public async Task<IdentityResult> RecoverPassword(UserModel user)
        {
            try
            {
                return await _userManager.UpdateAsync(new Data.Entities.User());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
