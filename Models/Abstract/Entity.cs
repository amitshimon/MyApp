using Models.Interfaces;
using System;

namespace Models.Abstract
{
    public class Entity : IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifyOn { get; set; }
        public bool IsDeleted { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifyBy { get; set; }
    }
}
