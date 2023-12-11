using CMS;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;

using SlickSlider.Components.Widgets.HeroSlickSlider;
using SlickSlider.Models.FormComponents;

[assembly: AssemblyDiscoverable]
[assembly: RegisterWidget("Kentico13Base.Core.Components.Widgets.HeroSlickSlider", typeof(HeroSlickSliderViewComponent), "Hero Slider", typeof(HeroSlickSliderProperties),
    Description = "Hero Slider Widget", IconClass = "icon-carousel")]

[assembly: RegisterFormComponent(SliderPageTypeSelectorComponent.IDENTIFIER, typeof(SliderPageTypeSelectorComponent), "Drop-down for Page Type Selector ", IconClass = "icon-menu")]