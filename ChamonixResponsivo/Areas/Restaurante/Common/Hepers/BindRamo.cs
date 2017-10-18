using Chamonix.Domain.Service.Admin;
using System.Linq;
using System.Web.Mvc;

namespace ChamonixResponsivo.Areas.Restaurante.Common.Hepers
{
    public static class BindRamo
    {
        public static MvcHtmlString SelectRamo(this HtmlHelper html, int idRamo = 0)
        {
            var cargos = new RamoService().Listar()
                .Where(x => x.Ativo == true)
                .OrderBy(x => x.Descricao)
                .ToList();

            TagBuilder tag = new TagBuilder("select");
            tag.MergeAttribute("id", "RamoId");
            tag.MergeAttribute("name", "RamoId");
            tag.MergeAttribute("class", "form-control");

            foreach (var item in cargos)
            {
                TagBuilder itemTag = new TagBuilder("option");
                itemTag.MergeAttribute("value", item.RamoId.ToString());
                if (item.RamoId == idRamo)
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