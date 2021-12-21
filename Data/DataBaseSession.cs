using System.Data;
using System.Data.SqlClient;

namespace CRUD_funcionarios
{
  public class DataBaseSession : IDisposable
  {
    public IDbConnection Connection { get; }

    public DataBaseSession(IConfiguration configuration)
    {
      Connection = new SqlConnection(configuration.GetConnectionString("funcionariosDb"));
      Connection.Open();
    }

    public void Dispose() => Connection.Dispose();

  }
}