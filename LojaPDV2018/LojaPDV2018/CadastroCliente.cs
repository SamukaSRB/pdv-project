using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LojaPDV2018.Dao;
using LojaPDV2018.Model;
using LojaPDV2018Cliente.Dao;
using MySql.Data.MySqlClient;
using System.IO;



namespace LojaPDV2018
{
    public partial class CadastroCliente : Form
    {
        private ClienteDao clienteDao;
        public CadastroCliente()
        {
            InitializeComponent();
            clienteDao = new ClienteDao();

        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {

            cliente a = new cliente()
            {

                Nome_cliente = Convert.ToString(tbxNome.Text),
                Logradouro_cliente = tbxEndereco.Text,
                Numero_cliente = Convert.ToInt32(tbxNumero.Text),
                Bairro_cliente = tbxBairro.Text,
                Cep_cliente = tbxCep.Text,
                Cidade_cliente = tbxCidade.Text,
                Estado_cliente = tbxEstado.Text,
                Cpf_cliente = tbxCpf.Text,
                Ddd_cliente = Convert.ToInt16(tbxDdd.Text),
                Contato_cliente = tbxContato.Text,
                Email_cliente = tbxEmail.Text
            };
            clienteDao.Adicionar(a);
            MessageBox.Show("Produto adicionado com sucesso");
        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }     

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            using (var ws = new WCorreios.AtendeClienteClient())
            {
                try
                {
                    var resultado = ws.consultaCEP(tbxCep.Text);
                    tbxEndereco.Text = resultado.end;
                    tbxNumero.Text = resultado.complemento2;
                    tbxCidade.Text = resultado.cidade;
                    tbxBairro.Text = resultado.bairro;
                    tbxEstado.Text = resultado.uf;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

    }
 }