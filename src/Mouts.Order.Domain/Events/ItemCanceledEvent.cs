namespace MoutsOrder.Domain.Events
{
    public class ItemCanceledEvent
    {
        public string ItemId { get; set; }

        public ItemCanceledEvent(string ItemId)
        {
            ItemId = ItemId;
        }
    }
}
