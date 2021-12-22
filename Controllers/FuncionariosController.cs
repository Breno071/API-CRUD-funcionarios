using Microsoft.AspNetCore.Mvc;
using CRUD_funcionarios.repository;

namespace CRUD_funcionarios.Controllers
{
  [ApiController]
  [Route("api/v1/[controller]")]
  public class FuncionariosController : ControllerBase
  {
    private readonly IRepository _repository;
    public FuncionariosController(IRepository repository)
    {
      _repository = repository;
    }

    [HttpGet]
    public async Task<dynamic> GetAllAsync()
    {
      return await _repository.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<Funcionario> GetAsync(long id)
    {
      return await _repository.GetAsync(id);
    }

    [HttpPost]
    public async Task<int> AddAsync([FromBody] Funcionario funcionario)
    {
      return await _repository.AddAsync(funcionario);
    }

    [HttpPut("{id}")]
    public async Task UpdateAsync(long id, [FromBody] Funcionario funcionario)
    {
      await _repository.UpdateAsync(id, funcionario);
    }

    [HttpDelete("{id}")]
    public async Task DeleteAsync(long id)
    {
      await _repository.DeleteAsync(id);
    }

  }
}