using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TanulmanyiRendszerDemo.BLL.DataTransferObjects;
using TanulmanyiRendszerDemo.BLL.Filter;
using TanulmanyiRendszerDemo.BLL.ViewModels;
using TanulmanyiRendszerDemo.DAL;
using TanulmanyiRendszerDemo.DAL.Entities;

namespace TanulmanyiRendszerDemo.BLL.Services
{
    public class DefaultSzemeszterService : ISzemeszterService
    {
        private readonly TanulmanyiRendszerDbContext _dbContext;

        public DefaultSzemeszterService(TanulmanyiRendszerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SzemeszterViewModel> CreateAsync(SzemeszterDto dto, CancellationToken cancellationToken)
        {
            var szemeszter = new Szemeszter {
                Kezdet = dto.Kezdet,
                Megnevezes = dto.Megnevezes,
                TargyjelentkezesKezdet = dto.TargyjelentkezesKezdet,
                TargyJelentkezesVeg = dto.TargyJelentkezesVeg,
                Veg = dto.Veg,
                VizsgajelentkezesKezdet = dto.VizsgajelentkezesKezdet,
                VizsgajelentkezesVeg = dto.VizsgajelentkezesVeg
            };

            _dbContext.Szemeszterek.Add(szemeszter);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return await FindByIdAsync(szemeszter.Id, cancellationToken);

        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var szemeszter = await _dbContext.Szemeszterek.FindAsync(id);
            if (szemeszter == null) {
                return;
            }
            _dbContext.Szemeszterek.Remove(szemeszter);
            await _dbContext.SaveChangesAsync(cancellationToken);

        }

        public async Task<SzemeszterViewModel> FindByIdAsync(int id, CancellationToken cancellationToken)
        {
            var szemeszter = await _dbContext.Szemeszterek.Include(x => x.Kurzusok).Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
            if (szemeszter == default) {
                return null;
            }
            return new SzemeszterViewModel {
                Id = szemeszter.Id,
                Kezdet = szemeszter.Kezdet,
                Megnevezes = szemeszter.Megnevezes,
                TargyjelentkezesKezdet = szemeszter.TargyjelentkezesKezdet,
                TargyJelentkezesVeg = szemeszter.TargyJelentkezesVeg,
                Veg = szemeszter.Veg,
                VizsgajelentkezesKezdet = szemeszter.VizsgajelentkezesKezdet,
                VizsgajelentkezesVeg = szemeszter.VizsgajelentkezesVeg,
                Kurzusok = szemeszter.Kurzusok.Select(x => new SzemeszterKurzusViewModel {
                    Id = x.Id,
                    Megnevezes = x.Megnevezes,
                    OktatoNev = x.OktatoNev,
                })
            };
        }

        public async Task<ItemsViewModel<SzemeszterRowViewModel>> ListAsync(PagedFilter filter, CancellationToken cancellationToken)
        {
            if (filter == null) {
                throw new ArgumentNullException(nameof(filter));
            }

            var totalCount = await _dbContext.Szemeszterek.CountAsync(cancellationToken);

            var szemeszterek = await _dbContext.Szemeszterek
                .Skip(filter.Skip)
                .Take(filter.Take)
                .Select(x => new SzemeszterRowViewModel {
                    Megnevezes = x.Megnevezes,
                    Kezdet = x.Kezdet,
                    TargyjelentkezesKezdet = x.TargyjelentkezesKezdet,
                    TargyJelentkezesVeg = x.TargyJelentkezesVeg,
                    Veg = x.Veg,
                    VizsgajelentkezesKezdet = x.VizsgajelentkezesKezdet,
                    VizsgajelentkezesVeg = x.VizsgajelentkezesVeg,
                    KurzusokSzama = x.Kurzusok.Count
                })
                .ToListAsync(cancellationToken);

            return new ItemsViewModel<SzemeszterRowViewModel> {
                Items = szemeszterek,
                TotalCount = totalCount
            };
        }

        public async Task UpdateAsync(int id, SzemeszterDto dto, CancellationToken cancellationToken)
        {
            var szemeszter = await _dbContext.Szemeszterek.FindAsync(id);
            if (szemeszter == null) {
                throw new Exception("Szemeszter nem található.");
            }
            szemeszter.Kezdet = dto.Kezdet;
            szemeszter.Megnevezes = dto.Megnevezes;
            szemeszter.TargyjelentkezesKezdet = dto.TargyjelentkezesKezdet;
            szemeszter.TargyJelentkezesVeg = dto.TargyJelentkezesVeg;
            szemeszter.Veg = dto.Veg;
            szemeszter.VizsgajelentkezesKezdet = dto.VizsgajelentkezesKezdet;
            szemeszter.VizsgajelentkezesVeg = dto.VizsgajelentkezesVeg;
            await _dbContext.SaveChangesAsync(cancellationToken);

        }
    }
}
