using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Product : BaseEntity, ITrackableEntity
    {
        public string Title { get; set; }
        public string Mark { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public int Evaluation { get; set; }
        public decimal Price { get; set; }
        public Guid SubCategoryId { get; set; }
        public SubCategory Category { get; set; }
        public ICollection<Image> Images { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        public bool Inactive { get; set; }
    }
}
