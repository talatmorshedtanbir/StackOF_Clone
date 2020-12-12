using Microsoft.AspNet.Identity;
using StackOF_Clone.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StackOF_Clone.Web.Areas.Admin.Models
{
    public class MemberUpdateModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsModerator { get; set; }
        public bool IsMember { get; set; }

        private readonly IMemberAccountService _memberAccountService;
        public MemberUpdateModel()
        {
            _memberAccountService = DependencyResolver.Current.GetService<IMemberAccountService>();
        }

        public async Task Delete(string id)
        {
            var user = await _memberAccountService.FindById(id);

            await _memberAccountService.Delete(user);
        }

        public async Task GetMemberRolesById(string id)
        {
            var user = await _memberAccountService.FindById(id);

            if (user == null)
                throw new InvalidOperationException("User is missing");

            var roles = await _memberAccountService.GetRoles(user);

            Id = user.Id;
            IsAdmin = roles.Any(x => x.Contains("Admin")) ? true : false;
            IsMember = roles.Any(x => x.Contains("Member")) ? true : false;
            IsModerator = roles.Any(x => x.Contains("Moderator")) ? true : false;
        }

        public async Task UpdateMemberRoles()
        {
            var user = await _memberAccountService.FindById(Id);

            if (user == null)
                throw new InvalidOperationException("User is missing");

            var roles = await _memberAccountService.GetRoles(user);
            var newRoles = new List<string>();

            if (IsModerator)
                newRoles.Add("Moderator");
            if (IsMember)
                newRoles.Add("Member");
            if (IsAdmin)
                newRoles.Add("Admin");

            await _memberAccountService.RemoveRoles(user, roles.ToList());
            await _memberAccountService.AddRoles(user, newRoles);

        }

        public async Task Load(string id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                throw new NullReferenceException();
            }

            var user = await _memberAccountService.FindById(id);

            if(user != null)
            {
                UserName = user.UserName;
                PhoneNumber = user.PhoneNumber;
            }
        }

        public async Task<IdentityResult> UpdateMember()
        {
            var userList = _memberAccountService.GetMembersList();
            var user = await _memberAccountService.FindById(Id);

            if (userList.Any(x => x.UserName == UserName && x.UserName != user.UserName))
                throw new InvalidOperationException("Username already exists");

            user.UserName = UserName;
            user.PhoneNumber = PhoneNumber;

            var result = await _memberAccountService.Update(user);

            return result;
        }
    }
}