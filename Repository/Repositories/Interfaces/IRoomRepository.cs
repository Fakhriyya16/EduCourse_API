using Domain.Entities;


namespace Repository.Repositories.Interfaces
{
    public interface IRoomRepository : IBaseRepository<Room>
    {
        Task<IEnumerable<Room>> GetByName(string name);
        Task<IEnumerable<Room>> SortBySeatCount(string count);
        Task<IEnumerable<Room>> SortByName(string name);
    }
}
