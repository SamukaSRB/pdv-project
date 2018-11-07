using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LojaPDV2018.Model;
using LojaPDV2018Cliente.Dao;
using MySql.Data.MySqlClient;

namespace LojaPDV2018.Dao
{
    public class ClienteDao
    {
            
        public void Adicionar(cliente cliente)
        {
            long id_cliente = -1;
            try
            {
                MySqlConnection conn = new ConnectionFactory().getConnection();
                String query = "INSERT INTO cliente (Nome_cliente,Logradouro_cliente,Numero_cliente,Bairro_cliente,Cep_cliente,Cidade_cliente,Estado_cliente,Cpf_cliente,Ddd_Cliente,Contato_cliente,Email_cliente) VALUES (@Nome_cliente,@Logradouro_cliente,@Numero_cliente,@Bairro_cliente,@Cep_cliente,@Cidade_cliente,@Estado_cliente,@Cpf_cliente,@Ddd_Cliente,@Contato_cliente,@Email_cliente); ";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.Add(new MySqlParameter("Nome_cliente", cliente.Nome_cliente));
                cmd.Parameters.Add(new MySqlParameter("Logradouro_cliente", cliente.Logradouro_cliente));
                cmd.Parameters.Add(new MySqlParameter("Numero_cliente", cliente.Numero_cliente));
                cmd.Parameters.Add(new MySqlParameter("Bairro_cliente", cliente.Bairro_cliente));
                cmd.Parameters.Add(new MySqlParameter("Cep_cliente", cliente.Cep_cliente));
                cmd.Parameters.Add(new MySqlParameter("Cidade_cliente", cliente.Cidade_cliente));
                cmd.Parameters.Add(new MySqlParameter("Estado_cliente", cliente.Estado_cliente));
                cmd.Parameters.Add(new MySqlParameter("Cpf_cliente", cliente.Cpf_cliente));
                cmd.Parameters.Add(new MySqlParameter("Ddd_cliente", cliente.Ddd_cliente));
                cmd.Parameters.Add(new MySqlParameter("Contato_cliente", cliente.Contato_cliente));
                cmd.Parameters.Add(new MySqlParameter("Email_cliente", cliente.Email_cliente));
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                id_cliente = cmd.LastInsertedId;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
        }
    }
}
