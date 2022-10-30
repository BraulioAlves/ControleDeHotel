using Correios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeHotel
{
    public partial class frmFuncionario : Form
    {
        public frmFuncionario()
        {
            InitializeComponent();
        }
        Funcionario novoFuncionario = new Funcionario();
        private void frmFuncionario_Load(object sender, EventArgs e)
        {
            ListarFuncionario();
        }

        private void ListarFuncionario()
        {
            try
            {
                dtgFuncionario.DataSource = novoFuncionario.Listar();
                Estilo();
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Estilo()
        {
            for (int i = 0; i < dtgFuncionario.Rows.Count; i++)
            {
                dtgFuncionario.Rows[i].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                i++;
            }
        }

        private void Ativar()
        {
            txtNome.Enabled = true;
            mtxtCPF.Enabled = true;
            txtEndereco.Enabled = true;
            txtBairro.Enabled = true;
            mtxtCEP.Enabled = true;
            txtNumero.Enabled = true;
            txtCidade.Enabled = true;
            txtEmail.Enabled = true;
            mtxtTelefone.Enabled = true;
            dtpDataNascimento.Enabled = true;
        }

        private void Limpar()
        {
            txtCodigo.Text = "0";
            txtNome.Clear();
            mtxtCPF.Clear();
            txtEndereco.Clear();
            txtNumero.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            mtxtCEP.Clear();
            mtxtTelefone.Clear();
            txtEmail.Clear();
        }

        private bool ValidarForm()
        {
            var FormValido = true;

            if (mtxtCPF.Text == "")
            {
                MessageBox.Show("Informe seu CPF");
                mtxtCPF.Focus();
                FormValido = false;
            }
            else if (txtNome.Text == "")
            {
                MessageBox.Show("Informe seu Nome");
                txtNome.Focus();
                FormValido = false;

            }
            else if (txtEndereco.Text == "")
            {
                MessageBox.Show("Informe seu Endereço");
                txtEndereco.Focus();
                FormValido = false;

            }
            else if (txtBairro.Text == "")
            {
                MessageBox.Show("Informe seu Bairro");
                txtBairro.Focus();
                FormValido = false;
            }
            else if (mtxtCEP.Text == "")
            {
                MessageBox.Show("Informe seu CEP");
                mtxtCEP.Focus();
                FormValido = false;
            }
            else if (txtNumero.Text == "")
            {
                MessageBox.Show("Informe seu Numero");
                txtNumero.Focus();
                FormValido = false;

            }
            else if (txtCidade.Text == "")
            {
                MessageBox.Show("Informe sua Cidade");
                txtCidade.Focus();
                FormValido = false;
            }
            else if (txtEmail.Text == "")
            {
                MessageBox.Show("Informe seu Email");
                txtEmail.Focus();
                FormValido = false;
            }
            else if (mtxtTelefone.Text == "")
            {
                MessageBox.Show("Informe seu Telefone");
                mtxtTelefone.Focus();
                FormValido = false;
            }
            else if (dtpDataNascimento.Text == "")
            {
                MessageBox.Show("Informe sua Data de Nascimento");
                dtpDataNascimento.Focus();
                FormValido = false;
            }

            return FormValido;

        }

        private void tsbSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarForm())
                {
                    MessageBox.Show("Preencha os campos obrigatorios!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    novoFuncionario = new Funcionario();
                    if (txtCodigo.Text == "0")
                    {
                        novoFuncionario.Salvar(txtNome.Text, mtxtCPF.Text, txtEndereco.Text, txtNumero.Text, txtBairro.Text, mtxtCEP.Text,
                            dtpDataNascimento.Value.Date, txtEmail.Text, txtCidade.Text, mtxtTelefone.Text);

                        MessageBox.Show("Funcionario salvo com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        novoFuncionario.Alterar(Convert.ToInt32(txtCodigo.Text), txtNome.Text, mtxtCPF.Text, txtEndereco.Text, txtNumero.Text, txtBairro.Text, mtxtCEP.Text,
                           dtpDataNascimento.Value.Date, txtEmail.Text, txtCidade.Text, mtxtTelefone.Text);
                    }
                    ListarFuncionario();

                }
                else { }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbNovo_Click(object sender, EventArgs e)
        {
            Ativar();
            Limpar();

        }

        private void dtgFuncionario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgFuncionario.Columns[e.ColumnIndex].Name == "btnEditar")
            {
                txtCodigo.Text = dtgFuncionario.Rows[e.RowIndex].Cells["CODIGO"].Value.ToString();
                txtNome.Text = dtgFuncionario.Rows[e.RowIndex].Cells["NOME"].Value.ToString();
                mtxtCPF.Text = dtgFuncionario.Rows[e.RowIndex].Cells["CPF"].Value.ToString();
                txtEndereco.Text = dtgFuncionario.Rows[e.RowIndex].Cells["ENDERECO"].Value.ToString();
                txtBairro.Text = dtgFuncionario.Rows[e.RowIndex].Cells["BAIRRO"].Value.ToString();
                mtxtCEP.Text = dtgFuncionario.Rows[e.RowIndex].Cells["CEP"].Value.ToString();
                txtCidade.Text = dtgFuncionario.Rows[e.RowIndex].Cells["CIDADE"].Value.ToString();
                txtEmail.Text = dtgFuncionario.Rows[e.RowIndex].Cells["EMAIL"].Value.ToString();
                mtxtTelefone.Text = dtgFuncionario.Rows[e.RowIndex].Cells["TELEFONE"].Value.ToString();
                dtpDataNascimento.Text = dtgFuncionario.Rows[e.RowIndex].Cells["DATA_NASCIMENTO"].Value.ToString();
            }
            else if (dtgFuncionario.Columns[e.ColumnIndex].Name == "btnExcluir" &&
                MessageBox.Show("Deseja realmente excluir?", "Deseja excluir?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                novoFuncionario.Excluir(Convert.ToInt32(dtgFuncionario.Rows[e.RowIndex].Cells["CODIGO"].Value));

                MessageBox.Show("Funcionario excluido com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListarFuncionario();
                Limpar();
            }
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            novoFuncionario = new Funcionario();
            try
            {
                if (rbNome.Checked)
                {
                    dtgFuncionario.DataSource = novoFuncionario.PesquisarNome(txtPesquisar.Text);
                }
                else
                {
                    dtgFuncionario.DataSource = novoFuncionario.PesquisarCPF(txtPesquisar.Text);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void btnBuscarCep_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(mtxtCEP.Text))
                {
                    MessageBox.Show("O campo de CEP esta vazio!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    CorreiosApi novoCorreio = new CorreiosApi();
                    var retornar = novoCorreio.consultaCEP(mtxtCEP.Text);

                    txtEndereco.Text = retornar.end;
                    txtBairro.Text = retornar.bairro;
                    txtCidade.Text = retornar.cidade;


                }
            }
            catch (Exception)
            {

                MessageBox.Show("CEP não encontrado!");
            }
        }
    }
}
