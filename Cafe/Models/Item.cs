namespace Cafe.Models
{
    internal class Item
    {
        public int ID { get; set; }
        public string? itemName { get; set; }
        public int Price { get; set; }
        List<Ingredients>? ingredients { get; set; }
    }
}
