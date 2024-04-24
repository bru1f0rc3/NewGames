using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace App5
{
    public class DB
    {
        private readonly SQLiteConnection conn;

        public DB(string path)
        {
            conn = new SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), path));
            conn.CreateTable<Points>();
        }

        public int SavePoints(Points point)
        {
            return conn.Insert(point);
        }

        public List<Points> GetPoints()
        {
            return conn.Table<Points>().ToList();
        }
    }
}
