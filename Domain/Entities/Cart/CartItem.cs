using System;


namespace Domain.Entities
{
    public class CartItem: BaseEntity, ITrackableEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
        public decimal TotalPriceItem { get; set; }

        public Guid CartId { get; set; }
        public Cart Cart { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        public bool Inactive { get; set; }
    }
}
