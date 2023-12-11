using CMS.DataEngine;
using Kentico.Forms.Web.Mvc;

namespace SlickSlider.Models.FormComponents
{
    public class SliderPageTypeSelectorComponentProperties : FormComponentProperties<string>
    {
        public SliderPageTypeSelectorComponentProperties()
             : base(FieldDataType.Text)
        {
        }
        [DefaultValueEditingComponent("SliderPageTypeSelectorProperties", DefaultValue = "")]
        public override string DefaultValue { get; set; }
    
    }
}
