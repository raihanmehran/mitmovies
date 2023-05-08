namespace Application.v1.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> SaveAllAsync();
    }
}