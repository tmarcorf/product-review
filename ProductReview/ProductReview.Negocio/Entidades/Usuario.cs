namespace ProductReview.Negocio.Entidades
{
    public class Usuario
    {
        /// <summary>
        /// Identificador único do usuário.
        /// </summary>
        public Guid Id { get; set; }

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
