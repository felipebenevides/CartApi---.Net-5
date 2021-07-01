using System;

namespace Domain.Entities
{
    public class Image : BaseEntity, ITrackableEntity
    {
        public string Url  { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        public bool Inactive { get; set; }
    }
}
