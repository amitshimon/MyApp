using System;

namespace Models.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime ModifyOn { get; set; }
        bool IsDeleted { get; set; }
        Guid CreatedBy { get; set; }
        Guid ModifyBy { get; set; }
    }
}
