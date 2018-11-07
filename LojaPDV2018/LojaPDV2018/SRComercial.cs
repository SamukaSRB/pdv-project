using LojaPDV2018;
using LojaPDV2018.Dao;
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

namespace LojaPDV2018Cliente
{
    public partial class SRComercialPrincipal : Form
    {    
        public SRComercialPrincipal()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath forma = new GraphicsPath();
            forma.AddEllipse(0, 0, btnProduto.Width, btnProduto.Height);
            btnProduto.Region = new Region(forma);
            btnCliente.Region = new Region(forma);
            btnFornecedor.Region = new Region(forma);
            btnRelatorio.Region = new Region(forma);
            btnVendas.Region = new Region(forma);
           
       
        }
        private void btnProduto_Click(object sender, EventArgs e)
        {
            CadastroCliente rf = new CadastroCliente();
            rf.ShowDialog();
        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCliente_Click(object sender, EventArgs e)
        {


            LojaPDV2018.CadastroCliente cc = new LojaPDV2018.CadastroCliente();
            cc.ShowDialog();           
        }
    }
}
