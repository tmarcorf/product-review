namespace ProductReview.Negocio.Entidades
{
    public class Usuario : EntidadePersistente
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
        public int Idade { get; set; }
    }
}
