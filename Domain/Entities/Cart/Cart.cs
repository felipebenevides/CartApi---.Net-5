using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Cart : BaseEntity, ITrackableEntity
    {

        public List<CartItem> Items { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        public bool Inactive { get; set; }
    }
}
