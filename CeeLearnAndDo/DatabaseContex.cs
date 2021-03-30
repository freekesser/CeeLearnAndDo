using CeeLearnAndDo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CeeLearnAndDo
{
    public class DatabaseContex : DbContext
    {
        public DatabaseContex(DbContextOptions<DatabaseContex> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleReply> ArticleReplies { get; set; }
        public DbSet<Knowledgebase> Knowledgebases { get; set; }
        public DbSet<KnowledgebaseReply> KnowledgebaseReplies { get; set; }
        public DbSet<Question> Questions { get; set; }
    }
}
