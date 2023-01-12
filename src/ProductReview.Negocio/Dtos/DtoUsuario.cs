using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Negocio.Dtos
{
    public class DtoUsuario : DtoPadrao
    {
        /// <summary>
        /// Primeiro nome do usuário.
        /// </summary>
        public string PrimeiroNome { get; set; }

        /// <summary>
        /// Último nome do usuário.
        /// </summary>
        public string UltimoNome { get; set; }

        /// <summary>
        /// Idade do usuário.
        /// </summary>
        public DateTime DataDeNascimento { get; set; }
    }
}
