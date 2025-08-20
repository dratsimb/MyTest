using System;

namespace Safran.Data.Flowers
{
    public class Flower
    {
        public int Id {  get; set; }

        public string Name { get; set; }

        public int PicturesCount { get; set; }

        public DateTime CreationDate { get; set; }

        public string AddedBy {  get; set; } 

        public string Description { get; set; }
    }
}
