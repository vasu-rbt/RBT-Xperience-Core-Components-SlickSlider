using CMS.Core;
using CMS.DocumentEngine;
using Kentico.Content.Web.Mvc;

using SlickSlider.Models;

namespace SlickSlider.Repositories
{
    public class HeroSlickSliderRepository : IHeroSlickSliderRepository
    {

        private readonly IPageRetriever _pageRetriever;
        private readonly IEventLogService _eventLogService;

        public HeroSlickSliderRepository(IPageRetriever pageRetriever, IEventLogService eventLogService)
        {
            _pageRetriever = pageRetriever ?? throw new ArgumentNullException(nameof(pageRetriever));
            _eventLogService = eventLogService ?? throw new ArgumentNullException(nameof(eventLogService));
        }
        public List<TreeNode> GetParticularPageTypeData(Slider dto)
        {

            string? className = dto.PageTypeClassName;
            string? selectedPath = dto.SelectedPath;

            List<TreeNode> PageTypeData = new();
            try
            {
                if (selectedPath != string.Empty)
                {
                    PageTypeData = _pageRetriever.Retrieve(className,
                                                    query => query
                                                            .Path(selectedPath, PathTypeEnum.Children),

                                                    buildCacheAction: cache => cache
                                                            .Key($"{selectedPath}")
                                                            .Dependencies((_, builder) => builder
                                                            .PageType(className)
                                                            .PagePath(selectedPath, PathTypeEnum.Children)
                                                            .PageOrder())).ToList();
                }
                return PageTypeData;
            }
            catch (Exception ex)
            {
                _eventLogService.LogException(nameof(HeroSlickSliderRepository), nameof(GetParticularPageTypeData), ex);
                return PageTypeData;
            }
        }
    }
}
