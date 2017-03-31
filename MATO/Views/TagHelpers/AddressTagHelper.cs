using MATO.ViewModels;
using Microsoft.AspNetCore.Razor;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace AuthoringTagHelpers.TagHelpers
{
    public class AddressTagHelper : TagHelper
    {
        public AddressViewModel address { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "address";
            output.Content.SetHtmlContent(
                $@"<div class='row'>
                      <div class='col - lg - 12'>
                          <h5>Adress</h5>
                      </div>
                   </div>
                   < div class='row'>
                      <div class='form-group'>
                         <label asp-for='Street'></label>
                         <input asp-for='Street' class='form-control' />
                         <span asp-validation-for='Street' class='text-muted'></span>
                      </div>  
                      <div class='form-group'>
                         <label asp-for='PostNumber'></label>
                         <input asp-for='PostNumber' class='form-control' />
                         <span asp-validation-for='PostNumber' class='text-muted'></span>
                      </div>  
                      <div class='form-group'>
                         <label asp-for='PostBox'></label>
                         <input asp-for='PostBox' class='form-control' />
                         <span asp-validation-for='PostBox' class='text-muted'></span>
                      </div>  
                      <div class='form-group'>
                         <label asp-for='PostCode'></label>
                         <input asp-for='PostCode' class='form-control' />
                         <span asp-validation-for='PostCode' class='text-muted'></span>
                      </div>  
                      <div class='form-group'>
                         <label asp-for='City'></label>
                         <input asp-for='City' class='form-control' />
                         <span asp-validation-for='City' class='text-muted'></span>
                      </div>  
                      <div class='form-group'>
                         <label asp-for='Country'></label>
                         <input asp-for='Country' class='form-control' />
                         <span asp-validation-for='Country' class='text-muted'></span>
                      </div>  
                   </div>");
        }
    }
}
