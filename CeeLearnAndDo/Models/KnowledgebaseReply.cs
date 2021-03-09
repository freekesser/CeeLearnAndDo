﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CeeLearnAndDo.Models
{
    public class KnowledgebaseReply
    {
        public int Id { get; set; }
        public Knowledgebase Knowledgebase { get; set; }
        public User User { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
