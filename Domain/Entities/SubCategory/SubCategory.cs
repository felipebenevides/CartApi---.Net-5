using System;

namespace Domain.Entities
{
    public class SubCategory : BaseEntity, ITrackableEntity
    {
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        public bool Inactive { get; set; }
    }
}
