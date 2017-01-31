using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW_Relational_Backend.Abstraction.DTL
{
    public interface IEntity<TId>
        where TId : struct
    {
        TId Id { get; set; }
    }
}
