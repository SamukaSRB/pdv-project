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
using LojaPDV2018Cliente.Dao;
using LojaPDV2018Cliente.Model;
using MySql.Data.MySqlClient;
using System.IO;

namespace LojaPDV2018Cliente
{

    public partial class CadastroCliente : Form

    {
        private ProdutoDao produtoDao;

        public CadastroCliente()
        {
            InitializeComponent();


            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            produtoDao = new ProdutoDao();



        }
        private void CadastroProduto_Load(object sender, EventArgs e)
        {
            AtualizaTabela();

        }
        private void btnCadastrar_Click(object sender, EventArgs e)
        {


            Produto a = new Produto()
            {
               
                Codigo_produto = Convert.ToString(tbxCodigo.Text),
                Ean_produto = tbxEAN.Text,
                Nome_produto = tbxNome.Text,
                Descricao_produto = tbxDescricao.Text,
                Valor_produto = Convert.ToInt16(tbxValor.Text),
                Categoria_produto = tbxCategoria.Text


            };
            produtoDao.Adicionar(a);
            AtualizaTabela();

            MessageBox.Show("Produto adicionado com sucesso");


        }
        protected override void OnPaint(PaintEventArgs e)
        {



            GraphicsPath forma = new GraphicsPath();
            forma.AddEllipse(0, 0, btnCadastrar.Width, btnCadastrar.Height);

        }
        private void btnDeletar_Click(object sender, EventArgs e)
        {

            MySqlConnection conn = new ConnectionFactory().getConnection();
            string query = "DELETE FROM produto WHERE id_produto=@Id_produto";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Id_produto", tbxId_produto.Text);
            cmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    MessageBox.Show("Registro excluído com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
            finally
            {
                conn.Close();
            }


           

            AtualizaTabela();
        }        
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
          

            /* dataGridView1.DataSource = produtoDao.BuscarPorNome(tbxNome.Text)); */
            dataGridView1.DataSource = produtoDao.BuscarPorEan(tbxEAN.Text);

        }
        public void AtualizaTabela()
        {
            ProdutoDao carregar = new ProdutoDao();
            
            dataGridView1.DataSource = carregar.CarregarGrade();

        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {

            Produto alt = new Produto()
            {

                Codigo_produto = Convert.ToString(tbxCodigo.Text),
                Ean_produto = tbxEAN.Text,
                Nome_produto = tbxNome.Text,
                Descricao_produto = tbxDescricao.Text,
                Valor_produto = Convert.ToInt16(tbxValor.Text),
                Categoria_produto = tbxCategoria.Text


            };
            produtoDao.Atualizar(alt);
        

            MessageBox.Show("Produto alterado com sucesso");

        }      
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            tbxId_produto.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            tbxCodigo.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            tbxEAN.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            tbxNome.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            tbxDescricao.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            tbxValor.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            tbxCategoria.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

        }     

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            LojaPDV2018.WCorreios.AtendeClienteClient cliente = new LojaPDV2018.WCorreios.AtendeClienteClient();
            string[] lista = { tbxRastreamento.Text };

            string resultado = cliente.consultaSRO(lista, "L", "T", "ECT", "SRO");
            TextReader reader = new StringReader(resultado);

            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            Tabela.DataSource = ds.Tables[2];

          

        }

        private void button1_Click(object sender, EventArgs e)
        {
           /* using (var ws = new LojaPDV2018.WCorreios.AtendeClienteClient())
            {
                try
                {
                    var resultado = ws.consultaSRO(tbxRastreamento.Text);
                    tbxTipo.Text = resultado.codigo;
                    tbxStatus.Text = resultado.complemento2;
                    tbxData.Text = resultado.cidade;
                    tbxHora.Text = resultado.Length
                    tbxDesc.Text = resultado.bairro;
                    tbxDetalhe.Text = resultado.uf;
                    tbxLocal.Text = resultado.uf;
                    tbxCodigo.Text = resultado.uf;
                    tbxCidade.Text = resultado.uf;
                    tbxEstado.Text = resultado.uf;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }*/

            }
        }

}