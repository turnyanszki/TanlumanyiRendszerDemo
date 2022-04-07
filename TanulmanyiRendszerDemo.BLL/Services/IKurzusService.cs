using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TanulmanyiRendszerDemo.BLL.DataTransferObjects;

namespace TanulmanyiRendszerDemo.BLL.Services
{
    public interface IKurzusService
    {
        Task AddToSzemeszter(int szemeszterId, KurzusDto dto, CancellationToken cancellationToken);
    }
}
