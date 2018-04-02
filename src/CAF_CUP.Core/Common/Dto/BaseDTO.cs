using System;
using System.ComponentModel.DataAnnotations;

namespace CAF_CUP.Common {
    public class BaseDto<TPrimaryKey> : IBaseDto<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
        public byte[] Version { get; set; }

        [Display(Name = "General_InsertUser")]
        public string InsertUser { get; set; }
        [Display(Name = "General_ModifyUser")]
        public string ModifyUser { get; set; }
        [Display(Name = "General_InsertDate")]
        public DateTime InsertDate { get; set; }
        [Display(Name = "General_ModifyDate")]
        public DateTime? ModifyDate { get; set; }
    }
}
