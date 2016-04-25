namespace Store.Models
{
    using Contracts;
    using SQLite.Net.Attributes;

    public class FoodItem : ISellable
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public byte[] Image { get; set; }

        public string Tempimage { get; set; } = "http://simpleicon.com/wp-content/uploads/mobile-1.png";
    }
}
