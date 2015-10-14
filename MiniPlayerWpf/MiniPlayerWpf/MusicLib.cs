using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniPlayerWpf
{
    class MusicLib
    {
        // Public read-only properties
        private DataSet musicDataSet;

        // The constructor reads the music.xsd and music.xml files into the DataSet
        public MusicLib()
        {

        }

        // Adds a song to the music library and returns the song's ID. The song  
        // parameter's ID is also set to the auto‐generated ID.
        public int AddSong(Song s)
        {
            DataTable table = musicDataSet.Tables["song"];
            DataRow row = table.NewRow();
            row["title"] = s.Title;
            row["artist"] = s.Artist;
            row["album"] = s.Album;
            row["filename"] = s.Filename;
            row["length"] = s.Length;
            row["genre"] = s.Genre;
            table.Rows.Add(row);
            // Update this song's ID
            s.Id = Convert.ToInt32(row["id"]);
            return s.Id;
        }

        // Return a Song for the given song ID or null if no song was not found.
        public Song GetSong(int songId)
        {
            return new Song();
        }

        // Update the given song with the given song ID.  Returns true if the song
        // was updated, false if it could not because the song ID was not found.
        public bool UpdateSong(int songId, Song song)
        {
            return true;
        }

        // Delete a song given the song's ID. Return true if the song was  
        // successfully deleted, false if the song ID was not found.
        public bool DeleteSong(int songId)
        {
            return true;
        }

        // Save the song database to the music.xml file
        public void Save()
        {

        }

        // Returns ObservableCollection of strings representing Song Ids
        public EnumerableRowCollection<string> SongIds
        {
            get
            {
                var ids = from row in musicDataSet.Tables["song"].AsEnumerable()
                          orderby row["id"]
                          select row["id"].ToString();
                return ids;
            }
        }

        private void PrintAllTables()
        {
            foreach (DataTable table in musicDataSet.Tables)
            {
                Console.WriteLine("Table name = " + table.TableName);
                foreach (DataRow row in table.Rows)
                {
                    Console.WriteLine("Row:");
                    int i = 0;
                    foreach (Object item in row.ItemArray)
                    {
                        Console.WriteLine(" " + table.Columns[i].Caption + "=" + item);
                        i++;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
