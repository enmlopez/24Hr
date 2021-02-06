using _24Hr.Data;
using _24Hr.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr.Services
{
   public class ReplyService
    {
        private readonly Guid _authorId;

        public  ReplyService(Guid authorId)
        {
            _authorId = authorId;
        }

        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {
                    Author = _authorId,
                    Text = model.Text,
                   
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReplyListItems> GetNotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Replies
                        .Where(e => e.Author == _authorId)
                        .Select(
                            e =>
                                new ReplyListItems
                                {
                                    Id = e.Id,
                                    Text = e.Text,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }

    }
    
}
