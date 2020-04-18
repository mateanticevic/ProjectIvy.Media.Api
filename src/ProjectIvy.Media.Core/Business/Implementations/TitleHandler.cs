using Microsoft.EntityFrameworkCore;
using ProjectIvy.Media.Core.Business.Interfaces;
using ProjectIvy.Media.Core.Models.Database;
using ProjectIvy.Media.Core.Models.Requests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIvy.Media.Core.Business.Implementations
{
    public class TitleHandler : ITitleHandler
    {
        public async Task<Models.View.Title> Get(string id)
        {
            using (var context = new MediaInfoContext())
            {
                var title = await context.Title.Include(x => x.TitleNames).Include("TitleNames.Role").Include("TitleNames.Name").SingleOrDefaultAsync(x => x.ValueId == id);
                return new Models.View.Title(title);
            }
        }

        public async Task<IEnumerable<Models.View.Title>> Get(string nameId, TitlesByNameFilter filter)
        {
            using (var context = new MediaInfoContext())
            {
                return (await context.Name.Include(x => x.TitleName).Include("TitleName.Title").Include("TitleName.Role")
                                         .SingleOrDefaultAsync(x => x.ValueId == nameId))
                                         .TitleName
                                         .Select(x => new Models.View.Title(x.Title));

            }
        }

        public async Task<IEnumerable<Models.View.Title>> GetEpisodesBySeason(string id, short season)
        {
            using (var context = new MediaInfoContext())
            {
                int titleId = context.Title.Single(x => x.ValueId == id).Id;

                return await context.Title.Where(x => x.ParentTitleId == titleId && x.SeasonNumber == season)
                    .OrderBy(x => x.EpisodeNumber)
                    .Select(x => new Models.View.Title(x))
                    .ToListAsync();

            }
        }
    }
}
