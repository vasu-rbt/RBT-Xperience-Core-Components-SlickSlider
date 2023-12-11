using CMS.DocumentEngine;
using DocumentFormat.OpenXml.Bibliography;

using SlickSlider.Models;

namespace SlickSlider.Repositories
{
    public interface IHeroSlickSliderRepository
    {
        /// <summary>
        /// GetParticularPageTypeData
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<TreeNode> GetParticularPageTypeData(Slider dto);
    }
}
