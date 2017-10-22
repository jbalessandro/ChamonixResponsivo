using Chamonix.Domain.Service.Admin;
using System.Linq;
using System.Web.Mvc;

namespace ChamonixResponsivo.Areas.Restaurante.Common.Hepers
{
    public static class BindContaBancaria
    {
        public static MvcHtmlString SelectContaBancaria(this HtmlHelper html, int idContaBancaria = 0)
        {
            var contas = new ContaBancariaService().Listar()
                .Where(x => x.Ativo == true)
                .OrderBy(x => x.Descricao)
                .ToList();

            TagBuilder tag = new TagBuilder("select");
            tag.MergeAttribute("id", "ContaBancariaId");
            tag.MergeAttribute("name", "ContaBancariaId");
            tag.MergeAttribute("class", "form-control");

            foreach (var item in contas)
            {
                TagBuilder itemTag = new TagBuilder("option");
                itemTag.MergeAttribute("value", item.ContaBancariaId.ToString());
                if (item.ContaBancariaId == idContaBancaria)
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