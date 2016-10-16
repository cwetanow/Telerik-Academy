using System;
using System.Collections;
using System.Xml;

namespace GetArtistsDom
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "../../../../catalogue.xml";

            var doc = new XmlDocument();
            doc.Load(path);

            var catalog = doc.DocumentElement;

            var uniqueArtists = ExtractArtists(catalog);

            foreach (var artist in uniqueArtists.Keys)
            {
                var oneOrMany = (int)uniqueArtists[artist] > 1 ? "albums" : "album";
                var artistAndAlbums = $"{artist}: {uniqueArtists[artist]} {oneOrMany}";
                Console.WriteLine(artistAndAlbums);
            }
        }

        public static Hashtable ExtractArtists(XmlElement node)
        {
            var tagName = "album";
            var artists = new Hashtable();

            var albums = node.GetElementsByTagName(tagName);

            foreach (XmlNode album in albums)
            {
                var currentArtistName = album["artist"].InnerText;

                if (artists.ContainsKey(currentArtistName))
                {
                    artists[currentArtistName] = (int)artists[currentArtistName] + 1;
                }
                else
                {
                    artists[currentArtistName] = 1;
                }
            }

            return artists;
        }
    }
}
