using Chamonix.Domain.Service.Admin;
using System.Linq;
using System.Web.Mvc;

namespace ChamonixResponsivo.Areas.Restaurante.Common.Hepers
{
    public static class BindCargos
    {
        public static MvcHtmlString SelectCargo(this HtmlHelper html, int idCargo = 0)
        {
            var cargos = new CargoService().Listar()
                .Where(x => x.Ativo == true)
                .OrderBy(x => x.Descricao)
                .ToList();

            TagBuilder tag = new TagBuilder("select");
            tag.MergeAttribute("id", "CargoId");
            tag.MergeAttribute("name", "CargoId");
            tag.MergeAttribute("class", "form-control");

            foreach (var item in cargos)
            {
                TagBuilder itemTag = new TagBuilder("option");
                itemTag.MergeAttribute("value", item.CargoId.ToString());
                if (item.CargoId == idCargo)
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