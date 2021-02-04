using _24Hr.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr.Models
{
    public class PostDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        //[ForeignKey(nameof(Comment))]
        //public int CommentId { get; set; }
        public List<Comment> Comment { get; set; }
    }
}
