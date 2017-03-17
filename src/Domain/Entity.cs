using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Entity
    {
        public int Id { get; set; }
        public Guid Idx { get; set; }
    }
}
