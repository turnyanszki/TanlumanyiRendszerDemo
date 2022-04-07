using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TanulmanyiRendszerDemo.BLL.DataTransferObjects;
using TanulmanyiRendszerDemo.BLL.Services;

namespace TanlumanyiRendszerDemo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KurzusokController : ControllerBase
    {
        private readonly IKurzusService _kurzusService;

        public KurzusokController(IKurzusService kurzusService)
        {
            _kurzusService = kurzusService;
        }

        [HttpPost("{szemeszterId}")]
        public async Task<IActionResult> Post(int szemeszterId, [FromBody] KurzusDto dto, CancellationToken cancellationToken)
        {
            await _kurzusService.AddToSzemeszter(szemeszterId, dto, cancellationToken);
            return Ok();
        }
    }
}
