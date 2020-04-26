using Microsoft.EntityFrameworkCore;
using ProjectIvy.Media.Core.Business.Interfaces;
using ProjectIvy.Media.Core.Models.Database;
using System.Threading.Tasks;

namespace ProjectIvy.Media.Core.Business.Implementations
{
    public class NameHandler : INameHandler
    {
        public async Task<Models.View.Name> Get(string id)
        {
            using (var context = new MediaInfoContext())
            {
                var name = await context.Name.SingleOrDefaultAsync(x => x.ValueId == id);

                return new Models.View.Name(name);
            }
        }
    }
}
