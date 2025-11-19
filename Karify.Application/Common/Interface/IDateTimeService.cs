using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Common.Interface
{
    public interface IDateTimeService
    {
        public DateTime HoraLocal();
        public DateTime HoraActual();
    }
}
