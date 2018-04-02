using System;

namespace CAF_CUP.Repositories {

    public interface IEntity<TPrimaryKey> {
        TPrimaryKey Id { get; set; }

        bool IsTransient();
    }

    public interface IEntity : IEntity<Guid> {

    }
}
