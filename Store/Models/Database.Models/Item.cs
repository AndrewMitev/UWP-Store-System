namespace Store.Models
{
    using Contracts;
    using SQLite.Net.Attributes;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Item : ISellable
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; } = 100;

        public string Measurement { get; set; } = "Kg.";

        public byte[] Image { get; set; }

        public string Tempimage { get; set; } = "http://simpleicon.com/wp-content/uploads/mobile-1.png";

        public int CategoryId { get; set; }
    }
}
