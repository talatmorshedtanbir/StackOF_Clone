using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using NHibernate;
using NHibernate.AspNet.Identity;
using StackOF_Clone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;

namespace StackOF_Clone.Core.Services
{
    public class MemberAccountService : IMemberAccountService
    {
        private readonly ISession _session;
        private readonly ApplicationUserManager _applicationUserManager;
        public MemberAccountService(ISession session, ApplicationUserManager applicationUserManager)
        {
            _session = session;
            _applicationUserManager = applicationUserManager;
        }

        public MemberAccountService(ISession session)
        {
            _session = session;
            _applicationUserManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }
        public IList<ApplicationUser> GetMembersList()
        {
            var users = _applicationUserManager.Users.ToList();

            return users;
        }

        public Task<IdentityResult> Delete(ApplicationUser user)
        {
            return _applicationUserManager.DeleteAsync(user);
        }

        public Task<ApplicationUser> FindById(string id)
        {
            return _applicationUserManager.FindByIdAsync(id);
        }

        public Task<IList<string>> GetRoles(ApplicationUser user)
        {
            return _applicationUserManager.GetRolesAsync(user.Id);
        }

        public Task<IdentityResult> RemoveRoles(ApplicationUser user, List<string> roles)
        {
            return _applicationUserManager.RemoveFromRolesAsync(user.Id, roles.ToArray());
        }

        public Task<IdentityResult> AddRoles(ApplicationUser user, List<string> roles)
        {
            return _applicationUserManager.AddToRolesAsync(user.Id, roles.ToArray());
        }

        public Task<IdentityResult> Update(ApplicationUser user)
        {
            return _applicationUserManager.UpdateAsync(user);
        }
    }
}
