using Microsoft.AspNetCore.Mvc;

namespace CRUD_funcionarios
{
  public interface IRepository
  {
    Task<int> AddAsync(Funcionario funcionario);
    Task UpdateAsync(long id, Funcionario funcionario);
    Task<int> DeleteAsync(long id);
    Task<Funcionario> GetAsync(long id);
    Task<IEnumerable<Funcionario>> GetAllAsync();
  }
}