using ProductReview.Negocio.Dtos;
using ProductReview.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Negocio.Conversores
{
    public class ConversorDeProduto
    {
        private static ConversorDeProduto _instancia;

        public static ConversorDeProduto Instancia
        {
            get
            {
                if (_instancia is null)
                {
                    _instancia = new ConversorDeProduto();
                }

                return _instancia;
            }
        }

        public List<Produto> Converta(List<DtoProduto> listaDeDtoProduto)
        {
            var listaDeProdutos = new List<Produto>();

            listaDeDtoProduto.ForEach(dtoProduto =>
            {
                listaDeProdutos.Add(Converta(dtoProduto));
            });

            return listaDeProdutos;
        }

        public Produto Converta(DtoProduto dtoProduto)
        {
            Guid idGuid;
            Guid.TryParse(dtoProduto.Id, out idGuid);

            return new Produto
            {
                Id = idGuid,
                Nome = dtoProduto.Nome,
                Descricao = dtoProduto.Descricao,
                Categoria = dtoProduto.Categoria,
                ValorUnitario = dtoProduto.ValorUnitario
            };
        }

        public List<DtoProduto> Converta(List<Produto> listaDeProdutos)
        {
            var listaDeDtoProdutos = new List<DtoProduto>();

            listaDeProdutos.ForEach(produto =>
            {
                listaDeDtoProdutos.Add(Converta(produto));
            });

            return listaDeDtoProdutos;
        }

        public DtoProduto Converta(Produto produto)
        {
            return new DtoProduto
            {
                Id = produto.Id.ToString(),
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Categoria = produto.Categoria,
                ValorUnitario = produto.ValorUnitario
            };
        }

        
    }
}
