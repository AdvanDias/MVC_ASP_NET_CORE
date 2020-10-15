using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_01.Models
{
    public class ConsultaMarca
    {
        public int Id { get; set; }
        public string Filtranome { get; set; }
        public string Filtracpf { get; set; }
        public int PacienteId { get; set; }
        public DateTime Data { get; set; }
        public string NumeroProtocolo { get; set; }
        public Paciente Paciente { get; set; }
    }
}
