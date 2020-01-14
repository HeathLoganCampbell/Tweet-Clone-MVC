using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TweetCloneMVC.Models;
using TweetCloneMVC.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace TweetCloneMVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TweetController : ControllerBase
    {
        private readonly TweetContext _context;

        public TweetController(TweetContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tweet>>> GetTweets()
        {
            return await _context.Tweets.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tweet>> GetTweet(long id)
        {
            var tweet = await _context.Tweets.FindAsync(id);

            if (tweet == null)
            {
                return NotFound();
            }

            return tweet;
        }

        [HttpPost]
        public async Task<ActionResult<Tweet>> PostTweet([FromBody] Tweet tweet)
        {
            tweet.Date = DateTime.Now;

            _context.Tweets.Add(tweet);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTweet), new { id = tweet.Id }, tweet);
        }
    }
}
