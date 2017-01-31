using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW_Relational_Backend.Abstraction.Services
{
    public interface IBindingService
    {
        IEnumerable<T> ResolveAll<T>();
        T ResolveSingle<T>();
        T ResolveSingle<T>(object serviceKey);
    }
}
