using System;

namespace CAF_CUP.Common {
    public interface IBaseDto<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
        byte[] Version { get; set; }

        string InsertUser { get; set; }
        string ModifyUser { get; set; }
        DateTime InsertDate { get; set; }
        DateTime? ModifyDate { get; set; }
    }
}
