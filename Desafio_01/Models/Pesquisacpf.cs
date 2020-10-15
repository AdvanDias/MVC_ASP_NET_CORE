using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_01.Models
{
    public class Pesquisacpf
    {
        public List<Paciente> Pacientes { get; set; }
        public SelectList Genrecpf { get; set; }
        public string cpfGenre { get; set; }
        public string Pesquisa { get; set; }
    }

}
