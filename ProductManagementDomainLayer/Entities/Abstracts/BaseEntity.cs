using System;

namespace ProductManagementDomainLayer.Entities.Abstracts
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public BaseEntity() { this.CreatedAt = DateTime.Now; }
    }
}
