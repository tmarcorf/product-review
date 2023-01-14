using ProductReview.Negocio.Dtos;
using ProductReview.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Negocio.Conversores
{
    public class ConversorDeAvaliacao
    {
        private static ConversorDeAvaliacao _instancia;

        public static ConversorDeAvaliacao Instancia
        {
            get
            {
                if (_instancia is null)
                {
                    _instancia = new ConversorDeAvaliacao();
                }

                return _instancia;
            }
        }

        public Avaliacao ConvertaParaInsercaoAtualizacao(DtoAvaliacaoInsercaoAtualizacao dtoAvaliacao)
        {
            Guid idGuid, idGuidProduto, idGuidUsuario;
            Guid.TryParse(dtoAvaliacao.Id, out idGuid);
            Guid.TryParse(dtoAvaliacao.IdDoProduto, out idGuidProduto);
            Guid.TryParse(dtoAvaliacao.IdDoUsuario, out idGuidUsuario);

            return new Avaliacao
            {
                Id = idGuid,
                Titulo = dtoAvaliacao.Titulo,
                Comentario = dtoAvaliacao.Comentario,
                QuantidadeEstrelas = dtoAvaliacao.QuantidadeEstrelas,
                IdDoProduto = idGuidProduto,
                IdDoUsuario = idGuidUsuario
            };
        }

        public List<DtoAvaliacao> ConvertaComMesmoProduto(List<Avaliacao> listaDeAvaliacoes, List<Usuario> listaDeUsuarios, Produto produto)
        {
            var listaDtoAvaliacao = new List<DtoAvaliacao>();

            listaDeAvaliacoes.ForEach(avaliacao =>
            {
                var usuario = listaDeUsuarios.Where(x => x.Id == avaliacao.IdDoUsuario).FirstOrDefault();

                listaDtoAvaliacao.Add(Converta(avaliacao, produto, usuario));
            });

            return listaDtoAvaliacao;
        }

        public List<DtoAvaliacao> ConvertaComMesmoUsuario(List<Avaliacao> listaDeAvaliacoes, List<Produto> listaDeProdutos, Usuario usuario)
        {
            var listaDtoAvaliacao = new List<DtoAvaliacao>();

            listaDeAvaliacoes.ForEach(avaliacao =>
            {
                var produto = listaDeProdutos.Where(x => x.Id == avaliacao.IdDoProduto).FirstOrDefault();

                listaDtoAvaliacao.Add(Converta(avaliacao, produto, usuario));
            });

            return listaDtoAvaliacao;
        }

        public DtoAvaliacao Converta(Avaliacao avaliacao, Produto produto, Usuario usuario)
        {
            return new DtoAvaliacao
            {
                Id = avaliacao.Id.ToString(),
                Titulo = avaliacao.Titulo,
                Comentario = avaliacao.Comentario,
                QuantidadeEstrelas = avaliacao.QuantidadeEstrelas,
                DtoProduto = ConversorDeProduto.Instancia.Converta(produto),
                DtoUsuario = ConversorDeUsuario.Instancia.Converta(usuario)
            };
        }

        public List<Avaliacao> Converta(List<DtoAvaliacao> listaDtoAvaliacao)
        {
            var listaAvaliacao = new List<Avaliacao>();

            listaDtoAvaliacao.ForEach(dtoAvaliacao =>
            {
                listaAvaliacao.Add(Converta(dtoAvaliacao));
            });

            return listaAvaliacao;
        }

        public Avaliacao Converta(DtoAvaliacao dtoAvaliacao)
        {
            Guid idGuid, idGuidProduto, idGuidUsuario;
            Guid.TryParse(dtoAvaliacao.Id, out idGuid);
            Guid.TryParse(dtoAvaliacao.DtoProduto.Id, out idGuidProduto);
            Guid.TryParse(dtoAvaliacao.DtoUsuario.Id, out idGuidUsuario);

            return new Avaliacao
            {
                Id = idGuid,
                Titulo = dtoAvaliacao.Titulo,
                Comentario = dtoAvaliacao.Comentario,
                QuantidadeEstrelas = dtoAvaliacao.QuantidadeEstrelas,
                IdDoProduto = idGuidProduto,
                IdDoUsuario = idGuidUsuario
            };
        }
    }
}
