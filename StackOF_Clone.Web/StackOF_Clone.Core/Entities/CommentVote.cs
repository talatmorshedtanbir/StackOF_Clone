using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOF_Clone.Core.Entities
{
    public class CommentVote
    {
        public virtual int Id { get; set; }
        public virtual bool UpVote { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
