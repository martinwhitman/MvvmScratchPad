using SQLite;
using System;

namespace MvvmTestApp.Models
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
    }
}