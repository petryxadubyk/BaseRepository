namespace KRS.Model
{
    public class Delivery
    {
        //Primary key, and one-to-many relation with Customer
        public int DeliveryId { get; set; }
        public virtual int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        //Properties for the delivery
        public string Description { get; set; }
        public bool IsDelivered { get; set; }
    }
}
