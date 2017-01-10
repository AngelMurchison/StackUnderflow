using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using StackOverclone3.Models;
using Microsoft.AspNet.Identity;

namespace StackOverclone3.Controllers
{
    // TODO: debug VoteController
    [Authorize]
    [RoutePrefix("api/votes")]
    public class VotesController : ApiController
    {
        [Route("{postId}/up")]
        public IHttpActionResult UpVote([FromUri] int postId)
        {
            var db = new ApplicationDbContext();
            var post = db.Posts.FirstOrDefault(f => f.ID == postId);
            Votes userVote;
            if (post != null)
            {
                var userId = User.Identity.GetUserId();
                // get the vote
                userVote = post.Votes.FirstOrDefault(f => f.UserId == userId);
                if (userVote != null)
                {
                    // if different, change the value
                    if (userVote.Weight == VoteWeight.downvote)
                    {
                        userVote.Weight = VoteWeight.upvote;
                    }
                    else if (userVote.Weight == VoteWeight.upvote)
                    {
                        post.Votes.Remove(userVote);
                        userVote = null;
                    }
                }
                else
                {
                    //add vote to vote list
                    var newVote = new Votes
                    {
                        PostId = post.ID,
                        Weight = VoteWeight.upvote,
                        UserId = userId
                    };
                    post.Votes.Add(newVote);
                    userVote = newVote;
                }
                db.SaveChanges();
                var weightRv = 0;
                if (userVote != null)
                {
                    weightRv = (int)userVote.Weight;
                }
                return Ok(new VoteResponseViewModel { NewCount = post.VoteSum, Vote = weightRv });
            }
            return NotFound();
        }


        [Route("{postId}/down")]
        public IHttpActionResult DownVote([FromUri] int postId)
        {
            var db = new ApplicationDbContext();
            var post = db.Posts.FirstOrDefault(f => f.ID == postId);
            Votes userVote;
            if (post != null)
            {
                var userId = User.Identity.GetUserId();
                // get the vote
                userVote = post.Votes.SingleOrDefault(f => f.UserId == userId);
                if (userVote != null)
                {
                    // if different, change the value
                    if (userVote.Weight == VoteWeight.upvote)
                    {
                        userVote.Weight = VoteWeight.downvote;
                    }
                    else if (userVote.Weight == VoteWeight.downvote)
                    {
                        post.Votes.Remove(userVote);
                        userVote = null;
                    }
                }
                else
                {
                    //add vote to vote list
                    var newVote = new Votes
                    {
                        PostId = post.ID,
                        Weight = VoteWeight.downvote,
                        UserId = userId
                    };
                    userVote = newVote;
                    post.Votes.Add(newVote);

                }
                db.SaveChanges();
                var weightRv = 0;
                if (userVote != null)
                {
                    weightRv = (int)userVote.Weight;
                }
                return Ok(new VoteResponseViewModel { NewCount = post.VoteSum, Vote = weightRv });
            }
            return NotFound();
        }
    }
}