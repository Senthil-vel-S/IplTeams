using IplTeams.API.Data;
using IplTeams.API.Models;
using IplTeams.API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace IplTeams.API.Repository
{
    public class TeamsRepository :GenericRepository<team>, ITeamsRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        public TeamsRepository(ApplicationDbContext dbcontext):base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
       
        public async Task Update(team entity)
        {
            _dbcontext.Teams.Update(entity);
            await Save();
        }
    }
}
