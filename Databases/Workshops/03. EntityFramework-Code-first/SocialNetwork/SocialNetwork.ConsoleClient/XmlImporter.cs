using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using SocialNetwork.ConsoleClient.Models;
using SocialNetwork.Data;
using SocialNetwork.Models;

namespace SocialNetwork.ConsoleClient
{
    public class XmlImporter
    {
        private readonly SocialNetworkEntities context;
        public XmlImporter(SocialNetworkEntities db)
        {
            this.context = db;
        }

        public void Import()
        {
            var friendshipsLocation = "XmlFiles/Friendships-Test.xml";
            var friendships = this.Deserialize<FriendshipXmlModel>(friendshipsLocation, "Friendships");
            this.ProcessFriendships(friendships);

            var postsLocation = "XmlFiles/Posts-Test.xml";
            var posts = this.Deserialize<PostXmlModel>(postsLocation, "Posts");
            this.ProcessPosts(posts);
        }

        private void ProcessFriendships(IEnumerable<FriendshipXmlModel> friendships)
        {
            var addedUsers = new HashSet<string>();

            foreach (var friendshipXmlModel in friendships)
            {
                var firstUser = this.GetUser(friendshipXmlModel.FirstUser, addedUsers);
                var secondUser = this.GetUser(friendshipXmlModel.SecondUser, addedUsers);

                var friendship = new Friendship
                {
                    Approved = friendshipXmlModel.Approved,
                    FriendsSince = friendshipXmlModel.FriendsSince,
                    FirstUser = firstUser,
                    SeconduUser = secondUser
                };

                foreach (var messageXmlModel in friendshipXmlModel.Messages)
                {
                    var message = new Message
                    {
                        Content = messageXmlModel.Content,
                        SeenOn = messageXmlModel.SeenOn,
                        SentOn = messageXmlModel.SentOn,
                        Friendship = friendship,
                        Author = messageXmlModel.Author == firstUser.Username ? firstUser : secondUser
                    };

                    this.context.Messages.Add(message);
                }

                this.context.SaveChanges();
            }
        }

        private User GetUser(UserXmlModel user, ICollection<string> addedUsers)
        {
            if (addedUsers.Contains(user.Username))
            {
                return this.context.Users
                    .FirstOrDefault(x => x.Username.Equals(user.Username));
            }
            else
            {
                addedUsers.Add(user.Username);

                var newUser = new User
                {
                    Username = user.Username,
                    Firstname = user.FirstName,
                    Lastname = user.LastName,
                    RegisteredOn = user.RegisteredOn
                };

                foreach (var image in user.Images)
                {
                    var img = new Image
                    {
                        FileExtension = image.FileExtension,
                        ImageUrl = image.ImageUrl
                    };

                    newUser.Images.Add(img);
                }

                this.context.Users.Add(newUser);
                this.context.SaveChanges();

                return newUser;
            }
        }

        private void ProcessPosts(IEnumerable<PostXmlModel> posts)
        {
            foreach (var postXmlModel in posts)
            {
                var post = new Post
                {
                    Content = postXmlModel.Content + "12345",
                    PostedOn = postXmlModel.PostedOn,
                };

                var usernames = postXmlModel.Users.Split(',');
                var users = this.context.Users
                    .Where(u => usernames.Contains(u.Username))
                    .ToList();

                foreach (var user in users)
                {
                    post.TaggedUsers.Add(user);
                }

                this.context.Posts.Add(post);
            }

            this.context.SaveChanges();
        }

        private IEnumerable<TModel> Deserialize<TModel>(string fileName, string rootElement)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException();
            }

            IEnumerable<TModel> result;

            using (var fileStream = new FileStream(fileName, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(List<TModel>), new XmlRootAttribute(rootElement));
                result = (IEnumerable<TModel>)serializer.Deserialize(fileStream);
            }

            return result;
        }

    }
}
