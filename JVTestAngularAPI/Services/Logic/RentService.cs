using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logic
{
    public class RentService
    {
        private readonly RentskiContext _db;
        private readonly Mapper _mapper;

        public RentService(RentskiContext db, Mapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RentModel>> GetAll()
        {
            var data = await _db.Rents.ToListAsync();

            return _mapper.Map<IEnumerable<RentModel>>(data);
        }

        public async Task<RentModel> Get(long id)
        {
            var rent = await _db.Rents.SingleOrDefaultAsync(x => x.Id == id);

            if (rent == null)
            {
                throw new NotFoundException("Not found");
            }

            return _mapper.Map<RentModel>(rent);
        }

        public async Task<long> Create(RentModelBase rent)
        {
            var ski = await _db.Skis.SingleOrDefaultAsync(x => x.Id == rent.SkiId);

            if (ski == null)
            {
                throw new NotFoundException("Ski not found");
            }
            else if (ski.Rented)
            {
                throw new NotFoundException("Ski rented");
            }

            ski.Rented = true;

            var rentDB = _mapper.Map<Data.Models.RentModel>(rent);

            rentDB.RentedAt = DateTime.UtcNow;
            rentDB.HourlyRate = ski.HourlyRate;

            await _db.Rents.AddAsync(rentDB);
            await _db.SaveChangesAsync();

            return rentDB.Id;
        }

        public async Task Return(long id)
        {
            var rent = await _db.Rents.SingleOrDefaultAsync(x => x.Id == id);

            if (rent == null)
            {
                throw new NotFoundException("Ski not found");
            }

            var ski = await _db.Skis.SingleOrDefaultAsync(x => x.Id == rent.SkiId);

            ski.Rented = false;

            rent.ReturnedAt = DateTime.UtcNow;
        }

        public async Task<bool> Delete(long id)
        {
            var rent = await _db.Rents.SingleOrDefaultAsync(x => x.Id == id);

            if (rent == null)
            {
                throw new NotFoundException("Rent not found");
            }

            _db.Rents.Remove(rent);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
