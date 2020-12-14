using FluentNHibernate.Mapping;
using StackOF_Clone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOF_Clone.Core.Database.Mappings
{
    public class CommentMapping : ClassMap<Comment>
    {
        public CommentMapping()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.CommentDescription);
            Map(x => x.IsApproved);
            Map(x => x.VoteCount);
            Map(x => x.CommentTime);
            References(x => x.ApplicationUser);
            References(x => x.Question);
            HasMany(x => x.CommentVotes).Cascade.AllDeleteOrphan();
        }
    }
}
