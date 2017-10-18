using Chamonix.Domain.Service.Admin;
using System.Linq;
using System.Web.Mvc;

namespace ChamonixResponsivo.Areas.Restaurante.Common.Hepers
{
    public static class BindEstado
    {
        public static MvcHtmlString SelectEstado(this HtmlHelper html, int idEstado = 0)
        {
            var estados = new EstadoService().Listar()
                .Where(x => x.Ativo == true)
                .OrderBy(x => x.UF)
                .ToList();

            TagBuilder tag = new TagBuilder("select");
            tag.MergeAttribute("id", "EstadoId");
            tag.MergeAttribute("name", "EstadoId");
            tag.MergeAttribute("class", "form-control");

            foreach (var item in estados)
            {
                TagBuilder itemTag = new TagBuilder("option");
                itemTag.MergeAttribute("value", item.EstadoId.ToString());
                if (item.EstadoId == idEstado)
                {
                    itemTag.MergeAttribute("selected", "selected");
                }
                itemTag.SetInnerText(item.UF);
                tag.InnerHtml += itemTag.ToString();
            }

            return new MvcHtmlString(tag.ToString());
        }
    }
}