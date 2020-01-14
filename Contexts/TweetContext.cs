using Microsoft.EntityFrameworkCore;
using TweetCloneMVC.Models;

namespace TweetCloneMVC.Contexts
{
    public class TweetContext : DbContext
    {
        public TweetContext(DbContextOptions<TweetContext> options)
            : base(options)
        {
        }

        public DbSet<Tweet> Tweets { get; set; }
    }
}