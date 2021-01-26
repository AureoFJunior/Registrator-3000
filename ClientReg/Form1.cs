using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientReg
{
    public partial class Form1 : Form
    {
        UsuarioRepositorio mUsuarioRepositorio = new UsuarioRepositorio();
        Int32 mId = 0;
        public Form1()
        {
            InitializeComponent();
            panel1.Hide();
            
            addItem.Click += AddItem_Click;
            editItem.Click += EditItem_Click;
            delItem.Click += DelItem_Click;
            gitItem.Click += GitItem_Click;


            atualizaLista();
        }

        private void GitItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Obrigado!", "HeLp", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            var a = new ProcessStartInfo(@"https://github.com/AureoFJunior");
            a.UseShellExecute = true;
            a.Verb = "open";
            Process.Start(a);

        }

        private void DelItem_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("Deseja mesmo excluir\neste item?", "Aviso!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            var model = mUsuarioRepositorio.GetQuery().Where(t => t.Id == mId).FirstOrDefault();

            if (msg == DialogResult.Yes)
            {
                model.Status = "I";
                mUsuarioRepositorio.Alterar(model);
                atualizaLista();
            }
            
        }

        private void atualizaLista()
        {
            listBox1.Items.Clear();
            var lista = mUsuarioRepositorio.GetQuery().Where(t => t.Status != "I").OrderBy(t => t.Id).ToList();
            listBox1.Items.AddRange(lista.Select(item => $"{item.Id}" + '-' + $" {item.Nome}").ToArray());

        }

        private void EditItem_Click(object sender, EventArgs e)
        {
            panel1.Show();
             
            var modelDB = mUsuarioRepositorio.GetQuery().Where(t => t.Id == mId).FirstOrDefault();
            //var modelDB2 = mUsuarioRepositorio.RetornarPorId(id);

            
            
            
           // model.Nome =  

            txtNome.Text = modelDB.Nome;
            txtEmail.Text = modelDB.Email;
            txtLogra.Text = modelDB.Logradouro;
            txtComp.Text = modelDB.Complemento;
            txtNum.Text = modelDB.Numero;
            txtCEP.Text = modelDB.CEP;
            txtBairro.Text = modelDB.Bairro;
            mktxtTel.Text = modelDB.Telefone;

        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            mId = 0;
            panel1.Show();
            /*var panel = this.Controls.OfType<Panel>().FirstOrDefault(p => p.Name == "panel1");
            if (panel != default(Panel)) panel.Visible = visible;*/
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var msgResult = MessageBox.Show("Deseja salvar mesmo?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (msgResult == DialogResult.Yes)
            {


                var model = setClie();
                var validModel = validaClie(model);

                if (validModel)
                {
                    mUsuarioRepositorio.InserirOuAtualizar(model);

                    MessageBox.Show("Inserido com êxito!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearPanel();
                    atualizaLista();
                }
                else
                {
                    MessageBox.Show("Campo não pode ser nulo\nou conter caracteres inválidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private Boolean validaClie(ClientesDet model)
        {
            if (String.IsNullOrWhiteSpace(model.Nome.ToString()))
            {
                MessageBox.Show("Campo não pode ser nulo\nou conter caracteres inválidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            else if (String.IsNullOrWhiteSpace(model.Logradouro.ToString()))
            {
                MessageBox.Show("Campo não pode ser nulo\nou conter caracteres inválidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (String.IsNullOrWhiteSpace(model.Numero.ToString()))
            {
                MessageBox.Show("Campo não pode ser nulo\nou conter caracteres inválidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (String.IsNullOrWhiteSpace(model.CEP.ToString()))
            {
                MessageBox.Show("Campo não pode ser nulo\nou conter caracteres inválidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else
            {
                return true;
            }
        }
        

        private ClientesDet setClie()
        {
            var model = new ClientesDet();


            model.Id = mId;
            model.Nome = txtNome.Text;
            model.Logradouro = txtLogra.Text;
            model.Numero = txtNum.Text;
            model.CEP = txtCEP.Text;
            txtCEP.MaxLength = 8;



            model.Email = txtEmail.Text;
            mktxtTel.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            model.Telefone = mktxtTel.Text;
            model.Bairro = txtBairro.Text;
            model.Complemento = txtComp.Text;
            model.Status = "A";

            return model;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            var msgResult = MessageBox.Show("Deseja cancelar mesmo?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            if (msgResult == DialogResult.Yes)
            {
                clearPanel();
            }
            
            

        }

        private void clearPanel()
        {
            txtNome.Clear();
            txtBairro.Clear();
            txtCEP.Clear();
            txtComp.Clear();
            txtEmail.Clear();
            txtLogra.Clear();
            txtNum.Clear();
            mktxtTel.Clear();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String codigo = listBox1.SelectedItem.ToString().Substring(0, listBox1.SelectedItem.ToString().IndexOf('-'));
            mId = Convert.ToInt32(codigo);
        }
    }
}
