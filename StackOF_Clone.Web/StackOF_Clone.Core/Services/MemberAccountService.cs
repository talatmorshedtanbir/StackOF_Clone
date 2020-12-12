using Microsoft.AspNet.Identity;
using NHibernate;
using NHibernate.AspNet.Identity;
using StackOF_Clone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOF_Clone.Core.Services
{
    public class MemberAccountService : IMemberAccountService
    {
        private readonly ISession _session;
        private readonly UserManager<ApplicationUser> userManager;
        public MemberAccountService(ISession session)
        {
            _session = session;
             userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_session));
        }

        public IList<ApplicationUser> GetMembersList()
        {
            var users = userManager.Users.ToList();

            return users;
        }

        public Task<IdentityResult> Delete(ApplicationUser user)
        {
            return userManager.DeleteAsync(user);
        }

        public Task<ApplicationUser> FindById(string id)
        {
            return userManager.FindByIdAsync(id);
        }

        public Task<IList<string>> GetRoles(ApplicationUser user)
        {
            return userManager.GetRolesAsync(user.Id);
        }

        public Task<IdentityResult> RemoveRoles(ApplicationUser user, List<string> roles)
        {
            return userManager.RemoveFromRolesAsync(user.Id, roles.ToArray());
        }

        public Task<IdentityResult> AddRoles(ApplicationUser user, List<string> roles)
        {
            return userManager.AddToRolesAsync(user.Id, roles.ToArray());
        }

        public Task<IdentityResult> Update(ApplicationUser user)
        {
            return userManager.UpdateAsync(user);
        }
    }
}
