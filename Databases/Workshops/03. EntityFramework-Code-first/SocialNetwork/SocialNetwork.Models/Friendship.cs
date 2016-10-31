using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Models
{
    public class Friendship
    {
        public Friendship()
        {
            this.Messages = new HashSet<Message>();
        }

        [Key]
        public int Id { get; set; }

        public User FirstUser { get; set; }

        public User SeconduUser { get; set; }

        [Index]
        public bool Approved { get; set; }

        public DateTime? FriendsSince { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}
