using DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDeviceUpdateEventRepositroy DeviceUpdateEvent { get; set; }

        public IDHT11ReadingRepository DHT11Reading { get; set; }

        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            DeviceUpdateEvent = new DeviceUpdateEventRepository(_db);
            DHT11Reading= new DHT11ReadingRepository(_db);
        }
    }
}
