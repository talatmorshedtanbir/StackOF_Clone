using FluentNHibernate.Mapping;
using StackOF_Clone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOF_Clone.Core.Database.Mappings
{
    public class QuestionVoteMapping : ClassMap<QuestionVote>
    {
        public QuestionVoteMapping()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.UpVote);
            References(x => x.ApplicationUser);
            References(x => x.Question);
        }
    }
}
