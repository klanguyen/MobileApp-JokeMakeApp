using System;
using SQLite;

namespace JokeMakerApp
{
    public class JokeMakerItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Jokes { get; set; }
    }
}

