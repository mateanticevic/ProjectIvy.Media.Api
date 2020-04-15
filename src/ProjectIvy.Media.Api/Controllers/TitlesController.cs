using Microsoft.AspNetCore.Mvc;
using ProjectIvy.Media.Core.Business.Interfaces;
using ProjectIvy.Media.Core.Models.View;
using System.Threading.Tasks;

namespace ProjectIvy.Media.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TitlesController : ControllerBase
    {
        private readonly ITitleHandler _titleHandler;

        public TitlesController(ITitleHandler titleHandler)
        {
            _titleHandler = titleHandler;
        }

        [HttpGet("{id}")]
        public async Task<Title> Get(string id) => await _titleHandler.Get(id);
    }
}
