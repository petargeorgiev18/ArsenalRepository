using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luxor.Data.Models.Enums
{
    public enum Status
    {
        Pending=1,
        Reserved,
        Deposit,
        Paid,
        Cancelled,
        None
    }
}
