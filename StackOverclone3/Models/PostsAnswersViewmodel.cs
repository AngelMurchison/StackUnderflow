using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackOverclone3.Models
{
    public class PostsAnswersViewmodel
    {
        public Posts post { get; set; }
        public List<Answers> answers { get; set; }
    }
}