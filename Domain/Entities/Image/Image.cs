using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Image : BaseEntity, ITrackableEntity
    {
        public string Url  { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        public bool Inactive { get; set; }

        [JsonIgnore]
        public ICollection<Product> Products { get; set; }

    }
}
