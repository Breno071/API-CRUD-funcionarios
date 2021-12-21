using Microsoft.AspNetCore.Mvc;
using Dapper;

namespace CRUD_funcionarios.repository
{
  public class Repository : IRepository
  {
    private readonly DataBaseSession _Dbsession;
    private readonly IConfiguration _configuration;

    public Repository(IConfiguration configuration, DataBaseSession Dbsession)
    {
      _configuration = configuration;
      _Dbsession = Dbsession;
    }

    public async Task<int> AddAsync([FromBody] Funcionario funcionario)
    {
      using (var connection = _Dbsession.Connection)
      {
        string sql = $"INSERT into funcionarios (nome, sobrenome, email, genero, cidade, pais, empresa, salario) VALUES (@nome, @sobrenome, @email, @genero, @cidade, @pais, @empresa, @salario)";

        return await connection.ExecuteAsync(sql, new { nome = funcionario.nome, sobrenome = funcionario.sobrenome, email = funcionario.email, genero = funcionario.genero, cidade = funcionario.cidade, pais = funcionario.pais, empresa = funcionario.empresa, salario = funcionario.salario });
      }
    }

    public async Task<int> DeleteAsync(long id)
    {
      using (var connection = _Dbsession.Connection)
      {
        string sql = $"DELETE FROM funcionarios WHERE id = @id";

        return await connection.ExecuteAsync(sql, new { id = id });
      }
    }

    public async Task<Funcionario> GetAsync(long id)
    {
      using (var connection = _Dbsession.Connection)
      {
        string sql = $"SELECT * FROM funcionarios WHERE id = {id}";

        return await connection.QueryFirstOrDefaultAsync<Funcionario>(sql);
      }
    }

    public async Task<IEnumerable<Funcionario>> GetAllAsync()
    {
      using (var connection = _Dbsession.Connection)
      {
        string sql = $"SELECT * from funcionarios";
        return await connection.QueryAsync<Funcionario>(sql);
      }
    }

    public async Task UpdateAsync(long id, [FromBody] Funcionario funcionario)
    {
      using (var connection = _Dbsession.Connection)
      {
        string sql = $"UPDATE funcionarios SET nome = @nome, sobrenome = @sobrenome, email = @email, genero = @genero, cidade = @cidade, pais = @pais, empresa = @empresa, salario = @salario WHERE id = {id}";

        await connection.ExecuteAsync(sql, new { nome = funcionario.nome, sobrenome = funcionario.sobrenome, email = funcionario.email, genero = funcionario.genero, cidade = funcionario.cidade, pais = funcionario.pais, empresa = funcionario.empresa, salario = funcionario.salario });
      }
    }
  }
}