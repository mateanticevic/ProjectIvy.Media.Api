using Microsoft.AspNetCore.Mvc;
using ProjectIvy.Media.Core.Business.Interfaces;
using ProjectIvy.Media.Core.Models.View;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectIvy.Media.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NamesController : ControllerBase
    {
        private readonly ITitleHandler _titleHandler;

        public NamesController(ITitleHandler titleHandler)
        {
            _titleHandler = titleHandler;
        }

        [HttpGet("{nameId}/titles")]
        public async Task<IEnumerable<Title>> Get(string nameId) => await _titleHandler.Get(nameId, null);
    }
}
