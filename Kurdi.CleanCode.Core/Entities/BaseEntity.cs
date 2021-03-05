using System;
using System.Collections.Generic;
using System.Text;

namespace Kurdi.CleanCode.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now.ToUniversalTime();
    }
}
