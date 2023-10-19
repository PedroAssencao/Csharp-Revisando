using Concessonária.Models;
using Dapper;
using System.Data.SqlClient;

namespace Concessonária.DAL
{
    public class MotosDAO
    {
        public SqlConnection _conexao;

        public MotosDAO()
        {
            _conexao = ConexaoBD.getconexao();
        }

        public List<Motos> getTodasasMotos()
        {
            var sql = "select * from Motos";
            var dados = (List<Motos>)_conexao.Query<Motos>(sql);
            return dados;
        }
        public bool InserirMotos(Motos motos)
        {

            try
            {
                var sql = "insert Motos(mot_modelo,mot_ano,mot_cor) values (@mot_modelo, @mot_ano,@mot_cor)";
                var dados = _conexao.Execute(sql, motos);
                return dados > 0;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public void Apagar(Motos motos)
        {
            var sql = "delete from Motos where mot_id = @mot_id";
            var dados = _conexao.Execute(sql, motos);
        }

        public bool UpdateMotos(Motos motos)
        {

            try
            {

                var sql = "update Motos set mot_modelo  = (@mot_modelo),  mot_ano = (@mot_ano), mot_cor = (@mot_cor) where mot_id = @mot_id";
                var dados = _conexao.Execute(sql, motos);
                return dados > 0;
            }
            catch (Exception)
            {

                return false;
            }


        }
    }
}
