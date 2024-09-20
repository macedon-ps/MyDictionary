using Microsoft.EntityFrameworkCore;
using MyDictionary.Models;

namespace MyDictionary.DBContext
{
    public class WordsDbContext: DbContext
    {
        public WordsDbContext() { }

        public WordsDbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Word> Words { get; set; } = null!;
        public virtual DbSet<Sentence> Sentences { get; set; } = null!;
    }
}
