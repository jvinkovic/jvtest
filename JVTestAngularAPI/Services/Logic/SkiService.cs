using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Logic
{
    public class SkiService
    {
        private readonly RentskiContext _db;
        private readonly Mapper _mapper;

        public SkiService(RentskiContext db, Mapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SkiModel>> GetAll()
        {
            var data = await _db.Skis.ToListAsync();

            return _mapper.Map<IEnumerable<SkiModel>>(data);
        }

        public async Task<SkiModel> Get(long id)
        {
            var ski = await _db.Skis.SingleOrDefaultAsync(x => x.Id == id);

            if (ski == null)
            {
                throw new NotFoundException("Not found");
            }

            return _mapper.Map<SkiModel>(ski);
        }

        public async Task<long> Create(SkiModel Ski)
        {
            var SkiDB = _mapper.Map<Data.Models.SkiModel>(Ski);

            await _db.Skis.AddAsync(SkiDB);
            await _db.SaveChangesAsync();

            return SkiDB.Id;
        }

        public async Task<SkiModel> Edit(SkiModel Ski, long id)
        {
            var SkiDB = await _db.Skis.SingleOrDefaultAsync(x => x.Id == id);

            _mapper.Map(Ski, SkiDB);

            await _db.SaveChangesAsync();

            SkiDB = await _db.Skis.SingleOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<SkiModel>(SkiDB);
        }

        public async Task<bool> Delete(long id)
        {
            var Ski = await _db.Skis.SingleOrDefaultAsync(x => x.Id == id);

            _db.Skis.Remove(Ski);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
