using Microsoft.AspNet.Identity;
using NHibernate.AspNet.Identity;
using StackOF_Clone.Core.Database.Contexts;
using StackOF_Clone.Core.Entities;
using StackOF_Clone.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StackOF_Clone.Web.Areas.Admin.Models
{
    public class MemberViewModel
    {
        private readonly IMemberAccountService _memberAccountService;
        public MemberViewModel()
        {
            _memberAccountService = DependencyResolver.Current.GetService<IMemberAccountService>();
        }

        public string UserName { get; set; }
        public string PhoneNumber { get; set; }

        internal object GetMemberList()
        {
            var users = _memberAccountService.GetMembersList();

            return new
            {
                 data = (from user in users
                 select new string[]
                 {
                           user.Email,
                           user.PhoneNumber,
                           user.Id.ToString()
                 }
                 ).ToArray()
            };
        }
    }
}