using StackOF_Clone.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StackOF_Clone.Web.Areas.Member.Models
{
    public class ForumBaseModel : IDisposable
    {
        protected readonly IForumService _forumService;
        protected readonly IMemberAccountService _memberAccountService;
        protected readonly IVotingService _votingService;

        public ForumBaseModel(IForumService forumService)
        {
            _forumService = forumService;
        }

        public ForumBaseModel()
        {
            _forumService = DependencyResolver.Current.GetService<IForumService>();
            _memberAccountService = DependencyResolver.Current.GetService<IMemberAccountService>();
            _votingService = DependencyResolver.Current.GetService<IVotingService>();
        }

        public void Dispose()
        {
            _forumService?.Dispose();
        }
    }
}