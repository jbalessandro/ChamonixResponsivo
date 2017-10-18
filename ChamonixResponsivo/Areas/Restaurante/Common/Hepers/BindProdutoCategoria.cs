using Chamonix.Domain.Service.Produtos;
using System.Linq;
using System.Web.Mvc;

namespace ChamonixResponsivo.Areas.Restaurante.Common.Hepers
{
    public static class BindProdutoCategoria
    {
        public static MvcHtmlString SelectProdutoCategoria(this HtmlHelper html, int idProdutoCategoria = 0)
        {
            var cargos = new ProdutoCategoriaService().Listar()
                .Where(x => x.Ativo == true)
                .OrderBy(x => x.Descricao)
                .ToList();

            TagBuilder tag = new TagBuilder("select");
            tag.MergeAttribute("id", "ProdutoCategoriaId");
            tag.MergeAttribute("name", "ProdutoCategoriaId");
            tag.MergeAttribute("class", "form-control");

            foreach (var item in cargos)
            {
                TagBuilder itemTag = new TagBuilder("option");
                itemTag.MergeAttribute("value", item.ProdutoCategoriaId.ToString());
                if (item.ProdutoCategoriaId == idProdutoCategoria)
                {
                    itemTag.MergeAttribute("selected", "selected");
                }
                itemTag.SetInnerText(item.Descricao);
                tag.InnerHtml += itemTag.ToString();
            }

            return new MvcHtmlString(tag.ToString());
        }
    }
}