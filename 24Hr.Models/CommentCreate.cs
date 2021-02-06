using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr.Models
{
    public class CommentCreate
    {
        public int PostID { get; set; }

        [MaxLength(500)]
        public string Text { get; set; }
    }
}
