using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StackOverclone3.Models
{
    public class Posts
    {
        [Key]
        [Required]
        public int ID { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public string topicTag { get; set; }
        public string userId { get; set; }
        public virtual ICollection<Answers> postAnswers { get; set; }
        public virtual ICollection<Votes> Votes { get; set; }

        [ForeignKey("userId")]
        public virtual ApplicationUser User { get; set; }

        public int UpVote
        {
            get
            {
                return Votes.Count(w => w.Weight == VoteWeight.upvote);
            }
        }

        public int DownVote
        {
            get
            {
                return Votes.Count(w => w.Weight == VoteWeight.downvote);
            }
        }
        public int VoteSum
        {
            get
            {
                return this.UpVote - this.DownVote;
            }
        }

    }
}