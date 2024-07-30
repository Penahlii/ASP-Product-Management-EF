using Microsoft.AspNetCore.Razor.TagHelpers;
using ProductManagementDomainLayer.Entities.Concretes;

namespace ProductManagement.TagHelpers
{
    [HtmlTargetElement("product-item")]
    public class ProductItemTagHelper : TagHelper
    {
        const string product = "product";

        [HtmlAttributeName(product)]
        public Product Product { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "li";
            output.Attributes.SetAttribute("style", "border:1px solid #ccc;padding:15px;margin:10px;border-radius:8px;flex:1 1 300px;display:flex;flex-direction:column;align-items:center;justify-content:center;text-align:center;box-shadow:0 2px 5px rgba(0,0,0,0.1);");

            var content = $@"
<img width='150' height='100' src='{Product.ImageLink}' style='border-radius:8px;' />
<h2 style='font-size:1.5em;margin:10px 0;'>{Product.Name}</h2>
<p style='color:gray;'>{Product.Description}</p>
<p style='font-size:1.2em;color:green;'>Discounted Price: ${Product.Price}</p>
<p style='color:tomato;'>Discount: {Product.Discount}%</p>
<div style='display:flex;gap:10px;margin-top:10px;'>
    <a href='Home/Delete/{Product.Id}' style='color:white;background-color:red;padding:5px 10px;border-radius:5px;text-decoration:none;'>Delete</a>
    <a href='Home/Edit/{Product.Id}' style='color:white;background-color:blue;padding:5px 10px;border-radius:5px;text-decoration:none;'>Edit</a>
</div>
";
            output.Content.SetHtmlContent(content);
        }
    }
}
