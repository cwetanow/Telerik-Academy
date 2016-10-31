using SocialNetwork.Data;

namespace SocialNetwork.ConsoleClient.Searcher
{
    using System;
    using System.Collections;
    using System.Linq;

    public class SocialNetworkService : ISocialNetworkService
    {
        private readonly SocialNetworkEntities context;

        public SocialNetworkService(SocialNetworkEntities db)
        {
            this.context = db;
        }

        public IEnumerable GetUsersAfterCertainDate(int year)
        {
            var users = this.context.Users
                .Where(x => x.RegisteredOn.Value.Year > year)
                .Select(x => new
                {
                    Username = x.Username,
                    Firstname = x.Firstname,
                    Lastname = x.Lastname,
                    Posts = x.Posts.Count(),
                    Messages = x.Messages.Count()
                })
                .ToList();

            return users;
        }

        public IEnumerable GetPostsByUser(string username)
        {
            var posts = this.context.Posts
                .Where(x => x.TaggedUsers.Any(u => u.Username == username))
                .Select(p => new
                {
                    Content = p.Content,
                    DatePosted = p.PostedOn,
                    TaggedUsers = p.TaggedUsers.Select(x => x.Username)
                })
                .ToList();

            return posts;
        }

        public IEnumerable GetFriendships(int page = 1, int pageSize = 25)
        {
            var skip = (page - 1) * pageSize;

            var friendships = this.context.Friendships
                .Where(fr => fr.Approved)
                .OrderBy(f => f.FriendsSince)
                .Skip(skip)
                .Take(pageSize)
                .Select(f => new
                {
                    FirstUser = f.FirstUser.Username,
                    SecondUser = f.SecondUser.Username,
                    Messages = f.Messages.Count(),
                })
                .ToList();

            return friendships;
        }

        public IEnumerable GetChatUsers(string username)
        {
            var messages = this.context.Messages
                   .Where(m => m.Friendship.FirstUser.Username == username)
                   .Select(m => m.Friendship.SecondUser.Username)
                   .Union(
                       this.context.Messages
                       .Where(m => m.Friendship.SecondUser.Username == username)
                       .Select(m => m.Friendship.FirstUser.Username))
                   .Where(u => u != username)
                   .Distinct()
                   .OrderBy(u => u)
                   .ToList();

            return messages;
        }
    }
}
