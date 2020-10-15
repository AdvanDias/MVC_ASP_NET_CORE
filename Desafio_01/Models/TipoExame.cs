using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_01.Models
{
    public class TipoExame
    {
        public int Id { get; set; }
        public string Nometipo { get; set; }
        public string Descricao { get; set; }
        public List<Exame> Exames { get; set; }

        

        
    }
}
