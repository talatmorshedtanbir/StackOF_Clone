using FluentNHibernate.Mapping;
using StackOF_Clone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOF_Clone.Core.Database.Mappings
{
    public class QuestionMapping : ClassMap<Question>
    {
        public QuestionMapping()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Title);
            Map(x => x.Description);
            Map(x => x.VoteCount);
            Map(x => x.QuestionTime);
            References(x => x.ApplicationUser);
            HasMany(x => x.Comments).Cascade.AllDeleteOrphan();
        }
    }
}
