using CAF_CUP.Repositories;
using System;
using System.ComponentModel.DataAnnotations;

namespace CAF_CUP.Common.Domain {
    public class DomainBase<TPrimaryKey> : Entity<TPrimaryKey> where TPrimaryKey : IComparable {
        [Timestamp]
        public byte[] Version { get; set; }

        public DateTime InsertDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        [MaxLength(150)]
        public virtual string InsertUser { get; set; }

        [MaxLength(150)]
        public virtual string ModifyUser { get; set; }
    }
}
