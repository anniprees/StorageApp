using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model
{
    public class Item
    {
        public int Id { get; set; }

        public int StorageLocationId { get; set; }

        public string Image { get; set; }

        public string Name { get; set; }

        public string SerialNumber { get; set; }

        public string Comment { get; set; }

        public string Color { get; set; }

        public int Price { get; set; }
    }
}
