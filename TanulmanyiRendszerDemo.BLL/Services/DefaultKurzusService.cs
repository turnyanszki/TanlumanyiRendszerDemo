using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TanulmanyiRendszerDemo.BLL.DataTransferObjects;
using TanulmanyiRendszerDemo.DAL;
using TanulmanyiRendszerDemo.DAL.Entities;

namespace TanulmanyiRendszerDemo.BLL.Services
{
    public class DefaultKurzusService : IKurzusService
    {
        private readonly TanulmanyiRendszerDbContext _dbContext;

        public DefaultKurzusService(TanulmanyiRendszerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddToSzemeszter(int szemeszterId, KurzusDto dto, CancellationToken cancellationToken)
        {
            var kurzus = new Kurzus {
                Megnevezes = dto.Megnevezes,
                OktatoNev = dto.OktatoNev,
            };

            var szemeszter = await _dbContext.Szemeszterek.FindAsync(szemeszterId);

            if (szemeszter == null) {
                throw new Exception("Szemeszter is not existing.");
            }

            kurzus.Szemeszter = szemeszter;
            _dbContext.Kurzusok.Add(kurzus);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
