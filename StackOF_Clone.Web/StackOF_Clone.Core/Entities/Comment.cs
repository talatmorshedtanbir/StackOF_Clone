using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOF_Clone.Core.Entities
{
    public class Comment
    {
        public virtual int Id { get; set; }
        public virtual string CommentDescription { get; set; }
        public virtual int VoteCount { get; set; }
        public virtual bool IsApproved { get; set; }
        public virtual DateTime CommentTime { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Question Question { get; set; }
    }
}
