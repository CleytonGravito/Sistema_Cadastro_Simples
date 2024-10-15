using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCadastro
{
    public partial class Form1 : Form
    {
        // Lista para armazenar os objetos 'Pessoa'.
        List<Pessoa> pessoas;

        public Form1()
        {
            InitializeComponent();

            // Inicializa a lista de pessoas.
            pessoas = new List<Pessoa>();

            // Adiciona opções ao ComboBox de Estado Civil.
            comboEC.Items.Add("Casado");
            comboEC.Items.Add("Solteiro");
            comboEC.Items.Add("Viuvo");
            comboEC.Items.Add("Separado");

            // Define a primeira opção selecionada como "Casado".
            comboEC.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Método chamado ao clicar no botão "Cadastrar/Alterar".
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            int index = -1;

            // Verifica se já existe uma pessoa com o mesmo nome.
            foreach (Pessoa pessoa in pessoas)
            {
                if (pessoa.Nome == txtNome.Text)
                {
                    index = pessoas.IndexOf(pessoa);
                }
            }

            // Valida se o campo "Nome" foi preenchido.
            if (txtNome.Text == "")
            {
                MessageBox.Show("Preencha o campo nome.");
                txtNome.Focus();
                return;
            }

            // Valida se o campo "Telefone" foi preenchido.
            if (txtTelefone.Text == "(  )      -")
            {
                MessageBox.Show("Preencha o campo telefone.");
                txtTelefone.Focus();
                return;
            }

            // Define o sexo com base no botão de rádio selecionado.
            char sexo;

            if (radioM.Checked)
            {
                sexo = 'M';
            }
            else if (radioF.Checked)
            {
                sexo = 'F';
            }
            else
            {
                sexo = 'O';
            }

            // Cria um novo objeto Pessoa e preenche com os dados inseridos.
            Pessoa p = new Pessoa();
            p.Nome = txtNome.Text;
            p.DataNascimento = txtData.Text;
            p.EstadoCivil = comboEC.SelectedItem.ToString();
            p.Telefone = txtTelefone.Text;
            p.CasaPropria = checkCasa.Checked;
            p.Veiculo = checkVeiculo.Checked;
            p.Sexo = sexo;

            // Se o nome não estiver na lista, adiciona. Caso contrário, altera os dados.
            if (index < 0)
            {
                pessoas.Add(p);
            }
            else
            {
                pessoas[index] = p;
            }

            // Limpa os campos do formulário e atualiza a lista.
            btnLimpar_Click(btnLimpar, EventArgs.Empty);

            Listar();
        }

        // Método chamado ao clicar no botão "Excluir".
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int indice = lista.SelectedIndex;
            // Remove a pessoa selecionada da lista.
            pessoas.RemoveAt(indice);
            Listar();
        }

        // Método chamado ao clicar no botão "Limpar".
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            // Limpa todos os campos e restaura o estado inicial do formulário.
            txtNome.Text = "";
            txtData.Text = "";
            comboEC.SelectedIndex = 0;
            txtTelefone.Text = "";
            checkCasa.Checked = false;
            checkVeiculo.Checked = false;
            radioM.Checked = true;
            radioF.Checked = false;
            radioO.Checked = false;
            txtNome.Focus();
        }

        // Atualiza a lista de nomes no ListBox.
        private void Listar()
        {
            lista.Items.Clear();

            // Adiciona o nome de cada pessoa na lista.
            foreach (Pessoa p in pessoas)
            {
                lista.Items.Add(p.Nome);
            }
        }

        // Método chamado ao clicar duas vezes em um item da lista.
        private void lista_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int indice = lista.SelectedIndex;
            Pessoa p = pessoas[indice];

            // Preenche os campos do formulário com os dados da pessoa selecionada.
            txtNome.Text = p.Nome;
            txtData.Text = p.DataNascimento;
            comboEC.SelectedItem = p.EstadoCivil;
            txtTelefone.Text = p.Telefone;
            checkCasa.Checked = p.CasaPropria;
            checkVeiculo.Checked = p.Veiculo;

            // Seleciona o botão de rádio de acordo com o sexo.
            switch (p.Sexo)
            {
                case 'M':
                    radioM.Checked = true;
                    break;
                case 'F':
                    radioF.Checked = true;
                    break;
                default:
                    radioO.Checked = true;
                    break;
            }
        }

        private void checkVeiculo_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
