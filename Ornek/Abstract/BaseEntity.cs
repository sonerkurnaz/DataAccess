using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ornek.Abstract
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        private DateTime _CreateDate;

        public DateTime MyProperty
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }

    }
}
