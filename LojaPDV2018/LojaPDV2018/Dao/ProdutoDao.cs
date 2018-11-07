using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LojaPDV2018Cliente.Model;
using MySql.Data.MySqlClient;

namespace LojaPDV2018Cliente.Dao
{
    public class ProdutoDao

    {   // Revisado
        public void Adicionar(Produto produto)
        {
            long id_produto = -1;
            try
            {
                MySqlConnection conn = new ConnectionFactory().getConnection();
                String query = "INSERT INTO produto (Codigo_produto, Ean_produto, Nome_produto, Descricao_produto, Valor_produto,Categoria_produto ) VALUES (@Codigo_produto, @Ean_produto, @Nome_produto, @Descricao_produto, @Valor_produto,@Categoria_produto ); ";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.Add(new MySqlParameter("Codigo_produto", produto.Codigo_produto));
                cmd.Parameters.Add(new MySqlParameter("Ean_produto", produto.Ean_produto));
                cmd.Parameters.Add(new MySqlParameter("Nome_produto", produto.Nome_produto));
                cmd.Parameters.Add(new MySqlParameter("Descricao_produto", produto.Descricao_produto));
                cmd.Parameters.Add(new MySqlParameter("Valor_produto", produto.Valor_produto));
                cmd.Parameters.Add(new MySqlParameter("Categoria_produto", produto.Categoria_produto));
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                id_produto = cmd.LastInsertedId;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
        }
        public void Atualizar(Produto produto)
        {
            try
            {
                MySqlConnection conn = new ConnectionFactory().getConnection();
                String query = "UPDATE produto SET Codigo_produto=@Codigo_produto,Ean_produto=@Ean_produto,Nome_produto=@Nome_produto,Descricao_produto=@Descricao_produto,ValorProd=@ValorProd,Categoria_produto=@Categoria_produto WHERE id_produto=@id_produto";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.Add(new MySqlParameter("Codigo_produto", produto.Codigo_produto));
                cmd.Parameters.Add(new MySqlParameter("Ean_produto", produto.Ean_produto));
                cmd.Parameters.Add(new MySqlParameter("Nome_produto", produto.Nome_produto));
                cmd.Parameters.Add(new MySqlParameter("Descricao_produto", produto.Descricao_produto));
                cmd.Parameters.Add(new MySqlParameter("Valor_produto", produto.Valor_produto));
                cmd.Parameters.Add(new MySqlParameter("Categoria_produto", produto.Categoria_produto));
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Produto Atualizado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
        }
        private void Delete(int id_produto)
        {
            MySqlConnection conn = new ConnectionFactory().getConnection();
            string query = "DELETE FROM produto WHERE id_produto = @id_produto";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.Add(new MySqlParameter("id_produto", id_produto));
            MySqlDataAdapter adapter;
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.DeleteCommand = conn.CreateCommand();
                adapter.DeleteCommand.CommandText = query;
                if (MessageBox.Show("Sure ??", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    if (cmd.ExecuteNonQuery() > 0)
                    {

                        MessageBox.Show("Sucessfully deleted");
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.ToString());
            }

        }
        public void ApagaPro(Produto produto)
        {
            try
            {
                MySqlConnection conn = new ConnectionFactory().getConnection();
                String query = "DELETE FROM produto WHERE id_produto =  id_produto + ";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Prepare();
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Produto removido com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.ToString());
            }

        }
        public void Remover(Produto produto)
        {

           


         
        

        } 
        public void ApagaPro(int Codigo_produto)
        {
            try
            {
                MySqlConnection conn = new ConnectionFactory().getConnection();
                String query = "DELETE FROM produto WHERE id_produto=@id_produto;";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.Add(new MySqlParameter("Codigo_produto",Codigo_produto));
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
        }
        // Metodo exibri grade funcionando nao mexer mais
        public List<Produto> CarregarGrade()
            {
                List<Produto> prod = new List<Produto>();
            try
            {
                MySqlConnection conn = new ConnectionFactory().getConnection();
                String query = "SELECT * FROM produto";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
              
                cmd.Prepare();
                MySqlDataReader leitor = cmd.ExecuteReader();

                while (leitor.Read())
                {
                        Produto p = new Produto()
                        {

                            id_produto = Convert.ToInt16(leitor["id_produto"]),
                            Ean_produto = Convert.ToString(leitor["Ean_produto"]),
                            Codigo_produto = Convert.ToString(leitor["Codigo_produto"]),
                            Nome_produto = Convert.ToString(leitor["Nome_produto"]),
                            Descricao_produto = Convert.ToString(leitor["Descricao_produto"]),
                            Valor_produto = Convert.ToInt16(leitor["Valor_produto"]),
                            Categoria_produto = Convert.ToString(leitor["Categoria_produto"])




                        };
                        prod.Add(p);
                    }
                    conn.Close();
                    return prod;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.ToString());
            }
                return prod;
            }        
        // metodo revisado e funcionando nao mexer mais
        public List<Produto> BuscarPorNome(String Nome_produto)
        {
            List<Produto> produtos = new List<Produto>();
            MySqlConnection conn = new ConnectionFactory().getConnection();
            String query = "SELECT id_produto,Codigo_produto,Ean_produto, Nome_produto, Descricao_produto, Valor_produto,Categoria_produto FROM produto WHERE Nome_produto LIKE @Nome_produto;";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.Add(new MySqlParameter("Nome_produto", Nome_produto));
            cmd.Prepare();
            MySqlDataReader leitor = cmd.ExecuteReader();
            while (leitor.Read())
            {
                Produto p = new Produto()
                {

                    id_produto = Convert.ToInt16(leitor["id_produto"]),
                    Ean_produto = Convert.ToString(leitor["Ean_produto"]),
                    Codigo_produto = Convert.ToString(leitor["Codigo_produto"]),
                    Nome_produto = Convert.ToString(leitor["Nome_produto"]),
                    Descricao_produto = Convert.ToString(leitor["Descricao_produto"]),
                    Valor_produto = Convert.ToInt16(leitor["Valor_produto"]),
                    Categoria_produto = Convert.ToString(leitor["Categoria_produto"])
                };
                produtos.Add(p);
            }
            conn.Close();
            return produtos;
        } 
        //Metodo revisado e ok
        public List<Produto> BuscarPorEan(String Ean_produto)
        {
            List<Produto> produtos = new List<Produto>();
            MySqlConnection conn = new ConnectionFactory().getConnection();
            String query = "SELECT id_produto,Codigo_produto,Ean_produto, Nome_produto, Descricao_produto, Valor_produto,Categoria_produto FROM produto WHERE Ean_produto = @Ean_produto;";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.Add(new MySqlParameter("Ean_Produto", Ean_produto));
            cmd.Prepare();
            MySqlDataReader leitor = cmd.ExecuteReader();
            while (leitor.Read())
            {
                Produto p = new Produto()
                {   id_produto = Convert.ToInt16(leitor["id_produto"]),
                    Ean_produto = Convert.ToString(leitor["Ean_produto"]),
                    Codigo_produto = Convert.ToString(leitor["Codigo_produto"]),
                    Nome_produto = Convert.ToString(leitor["Nome_produto"]),
                    Descricao_produto = Convert.ToString(leitor["Descricao_produto"]),
                    Valor_produto = Convert.ToInt16(leitor["Valor_produto"]),
                    Categoria_produto = Convert.ToString(leitor["Categoria_produto"])
                };
                produtos.Add(p);
            }
            conn.Close();
            return produtos;
        }
    }

}
     
    



 





