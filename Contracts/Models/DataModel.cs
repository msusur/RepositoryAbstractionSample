using System;

namespace Contracts.Models
{
    public class DataModel
    {
        public UserModel Owner { get; set; }

        public string DataDescription { get; set; }

        public Guid Id { get; set; }
    }
}