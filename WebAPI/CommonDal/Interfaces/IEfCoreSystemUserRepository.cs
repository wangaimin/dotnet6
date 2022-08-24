using CommonDAL.Model;

namespace CommonDAL.Interfaces;

public interface IEfCoreSystemUserRepository
{
     Task<int> AddAsync(SystemUser systemUser);

     Task<bool> UpdateAsync(SystemUser systemUser);

     Task<List<SystemUser>> GetAllAsync();
}