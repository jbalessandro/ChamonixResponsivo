using Chamonix.Domain.Service.Admin;
using System.Linq;
using System.Web.Mvc;

namespace ChamonixResponsivo.Areas.Restaurante.Common.Hepers
{
    public static class BindFornecedor
    {
        public static MvcHtmlString SelectFornecedor(this HtmlHelper html, int idCargo = 0)
        {
            var fornecedores = new FornecedorService().Listar()
                .Where(x => x.Ativo == true)
                .OrderBy(x => x.Fantasia)
                .ToList();

            TagBuilder tag = new TagBuilder("select");
            tag.MergeAttribute("id", "FornecedorId");
            tag.MergeAttribute("name", "FornecedorId");
            tag.MergeAttribute("class", "form-control");

            foreach (var item in fornecedores)
            {
                TagBuilder itemTag = new TagBuilder("option");
                itemTag.MergeAttribute("value", item.FornecedorId.ToString());
                if (item.FornecedorId == idCargo)
                {
                    itemTag.MergeAttribute("selected", "selected");
                }
                itemTag.SetInnerText(item.Fantasia);
                tag.InnerHtml += itemTag.ToString();
            }

            return new MvcHtmlString(tag.ToString());
        }
    }
}