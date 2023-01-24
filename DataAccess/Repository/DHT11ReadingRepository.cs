using DataAccess.Repository.IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class DHT11ReadingRepository : GenericRepository<DHT11Reading>, IDHT11ReadingRepository
    {
        private readonly ApplicationDbContext _db;

        public DHT11ReadingRepository(ApplicationDbContext db) : base(db) 
        { 
            _db = db;
        }
    }
}
