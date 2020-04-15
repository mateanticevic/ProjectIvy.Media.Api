using System.Threading.Tasks;
using ProjectIvy.Media.Core.Models.View;

namespace ProjectIvy.Media.Core.Business.Interfaces
{
    public interface ITitleHandler
    {
        Task<Title> Get(string id);
    }
}