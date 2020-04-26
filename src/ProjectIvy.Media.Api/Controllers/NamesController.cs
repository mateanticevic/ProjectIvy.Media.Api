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
        private readonly INameHandler _nameHandler;
        private readonly ITitleHandler _titleHandler;

        public NamesController(INameHandler nameHandler, ITitleHandler titleHandler)
        {
            _nameHandler = nameHandler;
            _titleHandler = titleHandler;
        }

        [HttpGet("{nameId}")]
        public async Task<Name> Get(string nameId) => await _nameHandler.Get(nameId);

        [HttpGet("{nameId}/titles")]
        public async Task<IEnumerable<Title>> GetTitles(string nameId) => await _titleHandler.Get(nameId, null);
    }
}
