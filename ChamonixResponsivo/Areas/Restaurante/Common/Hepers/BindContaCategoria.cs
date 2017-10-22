using Chamonix.Domain.Service.Admin;
using System.Linq;
using System.Web.Mvc;

namespace ChamonixResponsivo.Areas.Restaurante.Common.Hepers
{
    public static class BindContaCategoria
    {
        public static MvcHtmlString SelectContaCategoria(this HtmlHelper html, int idContaCategoria = 0)
        {
            var contas = new ContaCategoriaService().Listar()
                .Where(x => x.Ativo == true)
                .OrderBy(x => x.Descricao)
                .ToList();

            TagBuilder tag = new TagBuilder("select");
            tag.MergeAttribute("id", "ContaCategoriaId");
            tag.MergeAttribute("name", "ContaCategoriaId");
            tag.MergeAttribute("class", "form-control");

            foreach (var item in contas)
            {
                TagBuilder itemTag = new TagBuilder("option");
                itemTag.MergeAttribute("value", item.ContaCategoriaId.ToString());
                if (item.ContaCategoriaId == idContaCategoria)
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