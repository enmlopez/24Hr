using _24Hr.Data;
using _24Hr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr.Services
{
    public class CommentService
    {
        private readonly Guid _userId;
        private PostService postService;

        public CommentService(Guid userId)
        {
            _userId = userId;
            postService = new PostService(userId);
        }


         
        public bool CreateComment(CommentCreate model)
        {
            var post = postService.GetPostById(model.PostID);

            if (post is null)
                return false;

            var entity =
                new Comment()
                {
                    Author = _userId,
                    Text = model.Text,
                    PostId = model.PostID,
                    
                };
            using (var ctx = new ApplicationDbContext())
            {
                
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() >= 1;
            }
        }

        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.Author == _userId)
                        .Select(
                            e =>
                                new CommentListItem
                                {
                                    Id = e.Id,
                                    Text = e.Text
                                }
                        );
                return query.ToArray();
            }
        }

        public CommentDetail GetCommentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
               
                var entity =
                    ctx
                        .Comments
                        .SingleOrDefault(e => e.Id == id && e.Author == _userId);
                if (entity == null)
                    return null;



                return
                    new CommentDetail
                    {
                        Id = entity.Id,
                        Text = entity.Text,
                        Replies = entity.Reply
                    };
            }
        }


        public bool UpdateComment(CommentEdit comment,int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity =
                    ctx
                        .Comments
                        .SingleOrDefault(e => e.Id == id && e.Author == _userId);
                if (entity == null)
                    return false;


                entity.Text = comment.Text;

                return ctx.SaveChanges() >= 1;

            }

        }


        public bool DeleteComment(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {



                var entity =
                    ctx
                        .Comments
                        .SingleOrDefault(e => e.Id == id && e.Author == _userId);
                if (entity == null)
                    return false;



                //remove replies if any
                if (entity.Reply.Count > 0)
                {

                    ctx.Replies.RemoveRange(entity.Reply);
                    ctx.SaveChanges();
                }

                ctx.Comments.Remove(entity);
                return ctx.SaveChanges() >= 1;

            }
        }









    }
}
