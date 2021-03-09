﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CeeLearnAndDo.Models
{
    public class Article
    {
        public int Id { get; set; }
        public User User { get; set; }
        public List<ArticleReply> ArticleReplies { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
