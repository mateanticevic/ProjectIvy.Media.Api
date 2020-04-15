using Microsoft.EntityFrameworkCore;
using ProjectIvy.Media.Core.Business.Interfaces;
using ProjectIvy.Media.Core.Models.Database;
using System.Threading.Tasks;

namespace ProjectIvy.Media.Core.Business.Implementations
{
    public class TitleHandler : ITitleHandler
    {
        public TitleHandler()
        {

        }

        public async Task<Models.View.Title> Get(string id)
        {
            using (var context = new MediaInfoContext())
            {
                var title = await context.Title.SingleOrDefaultAsync(x => x.ValueId == id);
                return new Models.View.Title(title);
            }
        }
    }
}
