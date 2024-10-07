namespace Cafe.Models
{
    class UserCart
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public double ItemPrice { get; set; }
        public int Qty { get; set; }
    }
}
