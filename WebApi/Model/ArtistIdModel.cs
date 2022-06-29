﻿namespace WebApi.Model
{
    public class ArtistIdModel
    {
        
       public Artists Artists { get; set; }     

    }
    public class Artists
    {
        public List<Item> Items { get; set; }
    }
    public class Image
    {

        public string Url { get; set; }

    }

    public class Item
    {

        public List<string> Genres { get; set; }

        public string Id { get; set; }
        public List<Image> Images { get; set; }
        public string Name { get; set; }

    }
}
