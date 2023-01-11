using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Negocio.Entidades
{
    public abstract class EntidadePersistente
    {
        /// <summary>
        /// Identificador único do usuário.
        /// </summary>
        public Guid Id { get; set; }
    }
}
