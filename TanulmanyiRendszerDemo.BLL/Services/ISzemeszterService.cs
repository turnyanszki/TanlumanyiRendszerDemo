using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TanulmanyiRendszerDemo.BLL.DataTransferObjects;
using TanulmanyiRendszerDemo.BLL.Filter;
using TanulmanyiRendszerDemo.BLL.ViewModels;

namespace TanulmanyiRendszerDemo.BLL.Services
{
    public interface ISzemeszterService
    {
        Task<ItemsViewModel<SzemeszterRowViewModel>> ListAsync(PagedFilter filter, CancellationToken cancellationToken);
        Task<SzemeszterViewModel> FindByIdAsync(int id, CancellationToken cancellationToken);
        Task<SzemeszterViewModel> CreateAsync(SzemeszterDto dto, CancellationToken cancellationToken);
        Task UpdateAsync(int id, SzemeszterDto dto, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);

    }
}
