using System;
using System.ComponentModel.DataAnnotations;

namespace TweetCloneMVC.Models
{
    public class Tweet
    {
        public long Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public String Username { get; set; }

        public string Message { get; set; }
    }
}
