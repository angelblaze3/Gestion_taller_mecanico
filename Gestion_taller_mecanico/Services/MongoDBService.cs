using MongoDB.Bson;
using MongoDB.Driver;

namespace Gestion_taller_mecanico.Services
{
    public class MongoDBService
    {
        private readonly IMongoDatabase _database;

        public MongoDBService(IConfiguration configuration)
        {
            string cadena = configuration["MongoDB:ConnectionString"];
            string nombreBD = configuration["MongoDB:DatabaseName"];

            MongoClient cliente = new MongoClient(cadena);
            _database = cliente.GetDatabase(nombreBD);
        }

        public bool ProbarConexion(out string error)
        {
            try
            {
                _database.Client.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
                error = "Conexion exitosa con Mongo";
                return true;
            }
            catch (Exception ex)
            {
                error = ex.ToString();
                return false;
            }
        }
    }
}