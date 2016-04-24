namespace Store.Models
{
    using SQLite.Net.Attributes;

    public class DrinkItem
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public byte[] Image { get; set; }
    }
}
