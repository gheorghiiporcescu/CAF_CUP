using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CAF_CUP.Repositories {
    [Serializable]
    public abstract class Entity : Entity<Guid>, IEntity {

    }

    [Serializable]
    public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        
        /// <summary>
        /// Unique identifier for this entity.
        /// </summary>
        [Key]
        public virtual TPrimaryKey Id { get; set; }

        /// <summary>
        /// Checks if this entity is transient (it has not an Id).
        /// </summary>
        /// <returns>True, if this entity is transient</returns>
        public virtual bool IsTransient() {
            if (EqualityComparer<TPrimaryKey>.Default.Equals(Id, default(TPrimaryKey))) {
                return true;
            }

            //Workaround for EF Core since it sets int/long to min value when attaching to dbcontext
            if (typeof(TPrimaryKey) == typeof(int)) {
                return Convert.ToInt32(Id) <= 0;
            }

            if (typeof(TPrimaryKey) == typeof(long)) {
                return Convert.ToInt64(Id) <= 0;
            }

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode() {
            return Id.GetHashCode();
        }

        /// <inheritdoc/>
        public static bool operator ==(Entity<TPrimaryKey> left, Entity<TPrimaryKey> right) {
            if (Equals(left, null)) {
                return Equals(right, null);
            }

            return left.Equals(right);
        }

        /// <inheritdoc/>
        public static bool operator !=(Entity<TPrimaryKey> left, Entity<TPrimaryKey> right) {
            return !(left == right);
        }

        /// <inheritdoc/>
        public override string ToString() {
            return $"[{GetType().Name} {Id}]";
        }
    }
}
