﻿using _24Hr.Models;
using _24Hr.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _24Hr.Controllers
{
    [Authorize]
    public class PostController : ApiController
    {
        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var postService = new PostService(userId);
            return postService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            PostService postService = CreatePostService();
            var posts = postService.GetPosts();
            return Ok(posts);
        }
        [HttpPost]
        public IHttpActionResult Post(PostCreate post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreatePostService();
            if (!service.CreatePost(post))
            {
                return InternalServerError();
            }
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            PostService postService = CreatePostService();
            var post = postService.GetPostById(id);
            return Ok(post);
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreatePostService();
            if (!service.DeletePost(id))
            {
                return InternalServerError();
            }
            return Ok();
        }
    }
}

