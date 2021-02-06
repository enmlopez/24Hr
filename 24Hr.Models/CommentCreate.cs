using _24Hr.Data;
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
        [MaxLength(100)]
        public string Text { get; set; }
        [Required]
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
