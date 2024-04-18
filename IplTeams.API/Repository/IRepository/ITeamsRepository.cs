using IplTeams.API.Models;

namespace IplTeams.API.Repository.IRepository
{
    public interface ITeamsRepository:IGenericRepository<team>
    {
        Task Update(team entity);
    }
}
