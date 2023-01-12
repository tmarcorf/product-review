using ProductReview.Negocio.Dtos;
using ProductReview.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Negocio.Conversores
{
    public class ConversorDeUsuario
    {
        private static ConversorDeUsuario _instancia;

        public static ConversorDeUsuario Instancia
        {
            get
            {
                if (_instancia is null)
                {
                    _instancia = new ConversorDeUsuario();
                }

                return _instancia;
            }
        }

        public List<DtoUsuario> Converta(List<Usuario> listaDeUsuario)
        {
            var listaDeDtoUsuarios = new List<DtoUsuario>();

            listaDeUsuario.ForEach(usuario =>
            {
                listaDeDtoUsuarios.Add(Converta(usuario));
            });

            return listaDeDtoUsuarios;
        }

        public DtoUsuario Converta(Usuario usuario)
        {
            return new DtoUsuario
            {
                Id = usuario.Id.ToString(),
                PrimeiroNome = usuario.PrimeiroNome,
                UltimoNome = usuario.UltimoNome,
                DataDeNascimento = usuario.DataDeNascimento
            };
        }

        public List<Usuario> Converta(List<DtoUsuario> listaDeDtoUsuario)
        {
            var listaDeUsuarios = new List<Usuario>();

            listaDeDtoUsuario.ForEach(dtoUsuario =>
            {
                listaDeUsuarios.Add(Converta(dtoUsuario));
            });

            return listaDeUsuarios;
        }

        public Usuario Converta(DtoUsuario dtoUsuario)
        {
            Guid idGuid;
            Guid.TryParse(dtoUsuario.Id, out idGuid);

            return new Usuario
            {
                Id = idGuid,
                PrimeiroNome = dtoUsuario.PrimeiroNome,
                UltimoNome = dtoUsuario.UltimoNome,
                DataDeNascimento = dtoUsuario.DataDeNascimento
            };
        }
    }
}
