using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CeeLearnAndDo.Models
{
    public class ArticleReply
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Content { get; set; }
        public DateTime CheckedAt { get; set; }
    }
}
