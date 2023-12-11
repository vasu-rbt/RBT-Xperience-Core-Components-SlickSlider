
using CMS.Core;
using CMS.DocumentEngine;
using CMS.Helpers;

using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

using SlickSlider.Components.Widgets.HeroSlickSlider;
using SlickSlider.Models;
using SlickSlider.Repositories;

[assembly: RegisterWidget("Kentico13Base.Core.Components.Widgets.HeroSlickSlider", typeof(HeroSlickSliderViewComponent), "Hero Slider", typeof(HeroSlickSliderProperties),
    Description = "Hero Slider Widget", IconClass = "icon-carousel")]
namespace SlickSlider.Components.Widgets.HeroSlickSlider
{
    public class HeroSlickSliderViewComponent : ViewComponent
    {
        private readonly IEventLogService _eventLogService;
        private readonly IPageRetriever _pageRetriever;
        public HeroSlickSliderViewComponent(IEventLogService eventLogService,IPageRetriever pageRetriever)
        {
            _pageRetriever = pageRetriever ?? throw new ArgumentNullException(nameof(pageRetriever));

            _eventLogService = eventLogService ?? throw new ArgumentNullException(nameof(eventLogService));
        }
        public async Task<IViewComponentResult> InvokeAsync(HeroSlickSliderProperties properties)
        {


            try
            {
                HeroSlickSliderRepository heroSlickSliderRepository = new HeroSlickSliderRepository(_pageRetriever, _eventLogService);
                if (properties != null && properties.Visible)
                {
                    //string selectedPagePath = properties?.Path == null ? "/" : properties.Path.First().NodeAliasPath;
                    //var sliderList = await heroSlickSliderRepository.GetParticularPageTypeData(
                    //         filter => filter
                    //             .FilterDuplicates()
                    //             .Path(selectedPagePath, PathTypeEnum.Children)
                    //             ,
                    //              buildCacheAction: cache => cache
                    //        .Key($"{nameof(HeroSlickSliderViewComponent)}|{selectedPagePath}.Remove(0)")
                    //            .Dependencies((_, builder) => builder
                    //            .PageType(CMS.DocumentEngine.Types.Kentico13Base.Slider.CLASS_NAME)
                    //            .PagePath(selectedPagePath, PathTypeEnum.Children)
                    //            .PageOrder()));
                    int topN = ValidationHelper.GetInteger(properties?.TopN, 10);
                    string? selectedPath = properties?.Path == null ? "" : properties?.Path?.FirstOrDefault()?.NodeAliasPath;
                    Slider slider = new()
                    {
                        PageTypeClassName = properties?.PageTypes,
                        SelectedPath = selectedPath,
                       
                    };
                    IList<TreeNode> pagetypesData = await Task.Run(() => heroSlickSliderRepository.GetParticularPageTypeData(slider));


                    if (properties.Visible!=null)
                    {
                        return View("~/Components/Widgets/HeroSlickSlider/" + properties.Transformation + ".cshtml", new HeroSlickSliderViewModel
                        {
                            PageTypeClass=properties.PageTypes,
                            Visible = properties.Visible,
                            PageType = properties.PageType,
                            HeroSliderList = pagetypesData,
                            TopN = properties.TopN,
                            SlidesToShow = properties.SlidesToShow,
                            SlidesToScroll = properties.SlidesToScroll,
                            Speed = properties.Speed,
                            AutoPlay = properties.AutoPlay,
                            AutoPlaySpeed = properties.AutoPlaySpeed,
                            ShowDots = properties.ShowDots,
                            Fade = properties.Fade,
                            //CSSEase = properties.CSSEase,
                            Transformation = properties.Transformation,
                            Content = properties.Content,
                        });
                    }
                }
                return await Task.FromResult<IViewComponentResult>(Content(string.Empty));
            }
            catch (Exception ex)
            {
                _eventLogService.LogException(nameof(HeroSlickSliderViewComponent), "InvokeAysnc", ex);
                return await Task.FromResult<IViewComponentResult>(Content(string.Empty));
            }
        }
    }
}
