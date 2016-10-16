using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            var catalog = doc.DocumentElement;

            var uniqueArtists = ExtractArtists(catalog);

            foreach (var artist in uniqueArtists.Keys)
            {
                var oneOrMany = (int)uniqueArtists[artist] > 1 ? "albums" : "album";
                var artistAndAlbums = $"{artist}: {uniqueArtists[artist]} {oneOrMany}";
                Console.WriteLine(artistAndAlbums);
            }
        }

        public static Hashtable ExtractArtists(XmlElement catalog)
        {
            var artistsPath = "catalogue/album/artist";

            var artists = new Hashtable();

            return artists;
        }
    }
}
