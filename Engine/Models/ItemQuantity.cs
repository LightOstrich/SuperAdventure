namespace Engine.Models
{
    public class ItemQuantity
    {
        public int ItemID { get; }
        public int Quantity { get; }
        public ItemQuantity(int itemId, int quantiy)
        {
            ItemID = itemId;
            Quantity = quantiy;
        }
    }
}
