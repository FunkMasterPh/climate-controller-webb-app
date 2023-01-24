using DataAccess.Repository.IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class DeviceUpdateEventRepository : GenericRepository<C2DUpdateEvent>, IDeviceUpdateEventRepositroy
    {
        private readonly ApplicationDbContext _db;

        public DeviceUpdateEventRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }   
    }
}
