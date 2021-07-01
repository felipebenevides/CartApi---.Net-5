using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public interface ITrackableEntity
    {
        DateTime CreateDate { get; set; }
        DateTime? ModifyDate { get; set; }
        bool Inactive { get; set; }
    }
}
