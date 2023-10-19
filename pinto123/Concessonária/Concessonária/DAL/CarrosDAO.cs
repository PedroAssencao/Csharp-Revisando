using Concessonária.Models;
using Dapper;
using System.Data.SqlClient;

namespace Concessonária.DAL
{
    public class CarrosDAO
    {
        public SqlConnection _conexao;

        public CarrosDAO()
        {
            _conexao = ConexaoBD.getconexao(); //Serve para estanciar a conexão para todos os métodos
        }
        
       public List<Carros> getTodososCarros()
        {
            var sql = "select * from Carros";
            var dados = (List<Carros>)_conexao.Query<Carros>(sql);
            return dados;
        }  

       public bool InserirCarros(Carros carro)
        {

            try
            {
                var sql = "insert Carros(car_modelo,car_ano,car_cor) values (@car_modelo, @car_ano,@car_cor)";
                var dados = _conexao.Execute(sql, carro);
                return dados > 0;
            }
            catch (Exception)
            {

               return false;
            }
     

        }  
       
        public void Apagar(Carros carro)
        {
            var sql = "delete from Carros where car_id = @car_id";
            var dados = _conexao.Execute(sql, carro);
           

        }

        public bool UpdateCarros(Carros carro)
        {

            try
            {
                var sql = "update Carros set car_modelo  = (@car_modelo),  car_ano = (@car_ano), car_cor = (@car_cor) where car_id = @car_id";
                var dados = _conexao.Execute(sql, carro);
                return dados > 0;
            }
            catch (Exception)
            {

                return false;
            }


        }

    }
}
