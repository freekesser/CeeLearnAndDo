using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CeeLearnAndDo.Models
{
    public class Knowledgebase
    {
        public int Id { get; set; }
        public User User { get; set; }
        public List<KnowledgebaseReply> KnowledgebaseReplies { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? PublishedAt { get; set; }
    }
}
