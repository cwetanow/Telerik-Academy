namespace SocialNetwork.ConsoleClient.Searcher
{
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;

    public class DataSearcher
    {
        public static void Search(ISocialNetworkService searcher)
        {
            var users = searcher.GetUsersAfterCertainDate(2013);
            var postsByUsers = searcher.GetPostsByUser("ZtlKYHVN7h8SwMmaJs");
            var friendships = searcher.GetFriendships(2, 10);
            var chatUsers = searcher.GetChatUsers("ZtlKYHVN7h8SwMmaJs");

            var json = new List<string>
            {
                JsonConvert.SerializeObject(users,Formatting.Indented),
                JsonConvert.SerializeObject(postsByUsers,Formatting.Indented),
                JsonConvert.SerializeObject(friendships,Formatting.Indented),
                JsonConvert.SerializeObject(chatUsers,Formatting.Indented)
            };

            for (var i = 0; i < json.Count; i++)
            {
                using (var writer = new StreamWriter($"Jsons{i + 1}.json"))
                {
                    writer.WriteLine(json[i]);
                }
            }
        }
    }
}
