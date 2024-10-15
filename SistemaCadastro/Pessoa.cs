using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCadastro
{
    class Pessoa
    {
        public string Nome { get; set; }             // Armazena o nome da pessoa.
        public string DataNascimento { get; set; }   // Armazena a data de nascimento da pessoa.
        public string EstadoCivil { get; set; }      // Armazena o estado civil da pessoa (casado, solteiro, etc.).
        public string Telefone { get; set; }         // Armazena o número de telefone da pessoa.
        public bool CasaPropria { get; set; }        // Indica se a pessoa possui casa própria (true/false).
        public bool Veiculo { get; set; }            // Indica se a pessoa possui um veículo (true/false).
        public char Sexo { get; set; }               // Armazena o sexo da pessoa ('M' para masculino, 'F' para feminino, etc.).
    }
}
