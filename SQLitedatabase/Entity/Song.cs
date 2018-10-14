using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLitedatabase.Entity
{
    class Song
    {
        private string _id;
        private string _name;
        private string _thumbnail;

        public string Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Thumbnail { get => _thumbnail; set => _thumbnail = value; }
    }
}
