using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr.Data
{
    public class Reply
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public Guid Author { get; set; }

        [ForeignKey(nameof(Comment))]
        public int? CommentId { get; set; }
         
        [JsonIgnore]
        public virtual Comment Comment { get; set; }
    }
}
