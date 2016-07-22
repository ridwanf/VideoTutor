using System;
using Core;

namespace VideoTutor.Data.Domain
{
    public abstract class BaseClass<T> : BaseEntity<T>
    {
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}