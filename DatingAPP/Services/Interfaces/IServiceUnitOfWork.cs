using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IServiceUnitOfWork:IDisposable
    {
        Lazy<IUserService> user { get; }


    }
}
