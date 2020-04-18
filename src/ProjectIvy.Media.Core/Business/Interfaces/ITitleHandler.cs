using ProjectIvy.Media.Core.Models.Requests;
using ProjectIvy.Media.Core.Models.View;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectIvy.Media.Core.Business.Interfaces
{
    public interface ITitleHandler
    {
        Task<Title> Get(string id);

        Task<IEnumerable<Title>> Get(string nameId, TitlesByNameFilter request);

        Task<IEnumerable<Models.View.Title>> GetEpisodesBySeason(string id, short season);
    }
}