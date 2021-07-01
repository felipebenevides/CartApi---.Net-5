﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductImage: BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid ImageId { get; set; }
        public Image Property { get; set; }
    }
}
