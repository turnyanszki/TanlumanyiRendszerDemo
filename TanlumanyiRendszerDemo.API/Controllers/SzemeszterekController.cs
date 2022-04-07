using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TanulmanyiRendszerDemo.BLL.DataTransferObjects;
using TanulmanyiRendszerDemo.BLL.Filter;
using TanulmanyiRendszerDemo.BLL.Services;
using TanulmanyiRendszerDemo.BLL.ViewModels;

namespace TanlumanyiRendszerDemo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SzemeszterekController : ControllerBase
    {
        private readonly ISzemeszterService _szemeszterService;

        public SzemeszterekController(ISzemeszterService szemeszterService)
        {
            _szemeszterService = szemeszterService;
        }

        [HttpGet]
        public async Task<ItemsViewModel<SzemeszterRowViewModel>> Get([FromQuery] PagedFilter filter, CancellationToken cancellationToken)
        {
            return await _szemeszterService.ListAsync(filter, cancellationToken);
        }

        [HttpPost]
        public Task<SzemeszterViewModel> Post([FromBody] SzemeszterDto dto, CancellationToken cancellationToken)
        {
            return _szemeszterService.CreateAsync(dto, cancellationToken);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SzemeszterDto dto, CancellationToken cancellationToken)
        {
            await _szemeszterService.UpdateAsync(id, dto, cancellationToken);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _szemeszterService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
