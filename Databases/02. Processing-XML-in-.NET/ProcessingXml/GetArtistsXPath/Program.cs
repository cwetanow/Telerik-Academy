using System;
using System.Collections;
using System.Xml;

namespace GetArtistsXPath
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "../../../../catalogue.xml";

            var doc = new XmlDocument();
            doc.Load(path);

            var uniqueArtists = ExtractArtists(doc);

            foreach (var artist in uniqueArtists.Keys)
            {
                var oneOrMany = (int)uniqueArtists[artist] > 1 ? "albums" : "album";
                var artistAndAlbums = $"{artist}: {uniqueArtists[artist]} {oneOrMany}";
                Console.WriteLine(artistAndAlbums);
            }
        }

        public static Hashtable ExtractArtists(XmlDocument document)
        {
            var artistsPath = "catalogue/album/artist";
            var allArtists = document.SelectNodes(artistsPath);

            var artists = new Hashtable();

            foreach (XmlNode artist in allArtists)
            {
                var currentArtist = artist.InnerText;

                if (artists.ContainsKey(currentArtist))
                {
                    artists[currentArtist] = (int)artists[currentArtist] + 1;
                }
                else
                {
                    artists[currentArtist] = 1;
                }
            }

            return artists;
        }
    }
}
