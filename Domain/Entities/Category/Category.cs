using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Category : BaseEntity , ITrackableEntity
    {
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public List<SubCategory> SubCategories { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        public bool Inactive { get; set; }
    }
}
