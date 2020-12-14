using Microsoft.AspNet.Identity;
using NHibernate;
using NHibernate.AspNet.Identity;
using StackOF_Clone.Core.Constants;
using StackOF_Clone.Core.Database.Contexts;
using StackOF_Clone.Core.Entities;
using StackOF_Clone.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackOF_Clone.Web.Data_Seeder
{
    public class AdminSeed
    {
        internal static void SeedIdentities(ISession session)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(session));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(session));

            if (!roleManager.RoleExists(Roles.AdminRole))
            {
                roleManager.Create(new IdentityRole(Roles.AdminRole));
            }
            if (!roleManager.RoleExists(Roles.MemberRole))
            {
                roleManager.Create(new IdentityRole(Roles.MemberRole));
            }
            if (!roleManager.RoleExists(Roles.ModeratorRole))
            {
                roleManager.Create(new IdentityRole(Roles.ModeratorRole));
            }

            string userName = "admin@onnorokom.com";
            string password = "P@ss1234";

            ApplicationUser user = userManager.FindByName(userName);
            if (user == null)
            {
                user = new ApplicationUser()
                {
                    UserName = userName,
                    Email = userName,
                    EmailConfirmed = true
                };
                IdentityResult userResult = userManager.Create(user, password);
                if (userResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, Roles.AdminRole);
                    userManager.AddToRole(user.Id, Roles.MemberRole);
                    userManager.AddToRole(user.Id, Roles.ModeratorRole);
                }
            }
        }
    }
}