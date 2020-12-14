using Microsoft.AspNet.Identity;
using StackOF_Clone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOF_Clone.Core.Services
{
    public interface IMemberAccountService
    {
        Task<IdentityResult> Delete(ApplicationUser user);
        IList<ApplicationUser> GetMembersList();
        Task<ApplicationUser> FindById(string id);
        Task<ApplicationUser> FindByEmail(string email);
        Task<IList<string>> GetRoles(ApplicationUser user);
        Task<IdentityResult> RemoveRoles(ApplicationUser user, List<string> roles);
        Task<IdentityResult> AddRoles(ApplicationUser user, List<string> roles);
        Task<IdentityResult> Update(ApplicationUser user);
    }
}
