using Correios;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ControleDeHotel
{
    public partial class frmHospede : Form
    {
        public frmHospede()
        {
            InitializeComponent();
        }

        Hospede hospede = new Hospede();

        private void hospedeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.hospedeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hotel_UirapuruDataSet);

        }

        private void Hospede_Load(object sender, EventArgs e)
        {
            listarHospede();
        }

        private void tsbSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarForm())
                {
                    MessageBox.Show("Preencha os campos obrigatorio!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    hospede = new Hospede();
                    if (txtCodigo.Text == "0")
                    {
                        hospede.Salvar(txtNome.Text, mtxtCPF.Text, txtEndereco.Text, txtNumero.Text, txtBairro.Text, mtxtCEP.Text, dtpDataNascimento.Value.Date, txtEmail.Text, mtxtTelefone.Text, txtCidade.Text);
                        

                        MessageBox.Show("Hospede salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        hospede.Alterar(Convert.ToInt32(txtCodigo.Text), txtNome.Text, mtxtCPF.Text, txtEndereco.Text, txtNumero.Text, txtBairro.Text, mtxtCEP.Text, dtpDataNascimento.Value.Date, txtEmail.Text, mtxtTelefone.Text, txtCidade.Text);
                        
                    }
                    
                }
                else { }
                

                listarHospede();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void btnBuscarCep_Click(object sender, EventArgs e)
        {
            ListarCEP();
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            hospede = new Hospede();

            try
            {
                if (rbNome.Checked)
                {
                    dtgHospede.DataSource = hospede.PesquisarNome(txtPesquisar.Text);
                }
                else
                {
                    dtgHospede.DataSource = hospede.PesquisarCPF(txtPesquisar.Text);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void listarHospede()
        {
            try
            {
                hospede = new Hospede();
                dtgHospede.DataSource = hospede.Listar();
                Estilo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void Estilo()
        {
            for (int i = 0; i < dtgHospede.Rows.Count; i++)
            {
                dtgHospede.Rows[i].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                i++;
            }
        }

        private void tsbNovo_Click(object sender, EventArgs e)
        {
            Ativar();
            Limpar();
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

        private void dgvHospede_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgHospede.Columns[e.ColumnIndex].Name == "btnEditar")
            {
                txtCodigo.Text = dtgHospede.Rows[e.RowIndex].Cells["ID_CODIGO"].Value.ToString();
                mtxtCPF.Text = dtgHospede.Rows[e.RowIndex].Cells["CPF"].Value.ToString();
                txtNome.Text = dtgHospede.Rows[e.RowIndex].Cells["NOME"].Value.ToString();
                txtEndereco.Text = dtgHospede.Rows[e.RowIndex].Cells["ENDERECO"].Value.ToString();
                txtBairro.Text = dtgHospede.Rows[e.RowIndex].Cells["BAIRRO"].Value.ToString();
                mtxtCEP.Text = dtgHospede.Rows[e.RowIndex].Cells["CEP"].Value.ToString();
                txtNumero.Text = dtgHospede.Rows[e.RowIndex].Cells["NUMERO"].Value.ToString();
                txtCidade.Text = dtgHospede.Rows[e.RowIndex].Cells["CIDADE"].Value.ToString();
                txtEmail.Text = dtgHospede.Rows[e.RowIndex].Cells["EMAIL"].Value.ToString();
                mtxtTelefone.Text = dtgHospede.Rows[e.RowIndex].Cells["TELEFONE"].Value.ToString();
                dtpDataNascimento.Text = dtgHospede.Rows[e.RowIndex].Cells["DATA_NASCIMENTO"].Value.ToString();
            }
            else if (dtgHospede.Columns[e.ColumnIndex].Name == "btnExcluir" &&
                MessageBox.Show("Deseja realmente excluir?", "Dejesa excluir?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    hospede = new Hospede();
                    hospede.Excluir(Convert.ToInt32(dtgHospede.Rows[e.RowIndex].Cells["ID_CODIGO"].Value));
                    MessageBox.Show("Hospede excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listarHospede();
                    Limpar();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            
        }

        private void tsbDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            listarHospede();
        }

        private void ListarCEP()
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
