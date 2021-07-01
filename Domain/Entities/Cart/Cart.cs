using System;


namespace Domain.Entities
{
    public class Cart : BaseEntity, ITrackableEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        public bool Inactive { get; set; }
    }
}
