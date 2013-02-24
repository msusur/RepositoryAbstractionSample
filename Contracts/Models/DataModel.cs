using System;

namespace Contracts.Models
{
    public class DataModel
    {
        public virtual UserModel Owner { get; set; }

        public virtual string DataDescription { get; set; }

        public virtual Guid Id { get; set; }

        public virtual int OwnerId { get; set; }
    }
}