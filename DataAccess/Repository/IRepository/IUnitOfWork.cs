using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IDeviceUpdateEventRepositroy DeviceUpdateEvent { get; }
        IDHT11ReadingRepository DHT11Reading { get; }
    }
}
