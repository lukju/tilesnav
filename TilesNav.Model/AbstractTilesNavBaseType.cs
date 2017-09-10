using System;
using System.Collections.Generic;
using System.Text;

namespace TilesNav.Model
{
    public abstract class AbstractTilesNavBaseType<TKey>
    {
        private TKey _id;
        public TKey Id {
            get { return _id; }
            set
            {
                if(HasAssignedId)
                {
                    throw new NotSupportedException("Not allowed to change ID!");
                }
                _id = value;
            }
        }
        protected abstract bool HasAssignedId { get; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public User CreatedBy { get; set; }
        public User ModifiedBy { get; set; }
    }
}
