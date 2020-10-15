using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_01.Models
{
    public class Exame
    {
        public int Id { get; set; }
        public string Nomeexame { get; set; }
        public string Observacao { get; set; }
        public int TipoExameId { get; set; }
        public TipoExame TipoExame { get; set; }


    }
}
