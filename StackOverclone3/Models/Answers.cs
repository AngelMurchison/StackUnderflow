using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StackOverclone3.Models
{
    public class Answers
    {
        public Answers() //TODO: is this correct? every answer should be born false.
        {
            this.isAnswer = false;
        }
        [Key]
        [Required]
        public int ID { get; set; }
        public string body { get; set; }
        public int upvotes { get; set; }
        public int downvotes { get; set; }
        public bool isAnswer { get; set; }
        public string userId { get; set; }
        public int postId { get; set; }


        [ForeignKey("postId")]
        public Posts post { get; set; }
        [ForeignKey("userId")]
        public virtual ApplicationUser user { get; set; }
    }
}