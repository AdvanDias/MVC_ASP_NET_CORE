using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_01.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nomepaciente { get; set; }
        public string Cpf { get; set; }
        public DateTimeOffset Data { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public List<Consulta> Consultas { get; set; }
    }
}
