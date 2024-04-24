using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App5
{
    public class Points
    {
        [PrimaryKey, AutoIncrement]
        public int Answer { get; set; }
        public int Verity { get; set; }
        public int No_verity { get; set; }
        public int Score { get; set; }
    }
}
