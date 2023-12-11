using CMS.DocumentEngine;

using SlickSlider.Models;

namespace SlickSlider.Components.Widgets.HeroSlickSlider
{
    public class HeroSlickSliderViewModel
    {
        /// <summary>
        /// PageType
        /// </summary>
        public string? PageTypeClass { get; set; }

        /// <summary>
        /// Visible
        /// </summary>
        public bool Visible { get; set; }
        /// <summary>
        /// PageType
        /// </summary>
        public string? PageType { get; set; }
        /// <summary>
        /// HeroSliderList
        /// </summary>
        public IList<TreeNode>? HeroSliderList { get; set; }
        /// <summary>
        /// TopN
        /// </summary>
        public string? TopN { get; set; }
        /// <summary>
        /// SlidesToShow
        /// </summary>
        public string? SlidesToShow { get; set; }
        /// <summary>
        /// SlidesToScroll
        /// </summary>
        public string? SlidesToScroll { get; set; }
        /// <summary>
        /// Speed
        /// </summary>
        public string? Speed { get; set; }
        /// <summary>
        /// AutoPlay
        /// </summary>
        public bool AutoPlay { get; set; }
        /// <summary>
        /// AutoPlaySpeed
        /// </summary>
        public string? AutoPlaySpeed { get; set; }
        /// <summary>
        /// ShowDots
        /// </summary>
        public bool ShowDots { get; set; }
        /// <summary>
        /// Fade
        /// </summary>
        public bool Fade { get; set; }
        /// <summary>
        /// CSSEase
        /// </summary>
        public string? CSSEase { get; set; }
        /// <summary>
        /// Transformation
        /// </summary>
        public string? Transformation { get; set; }
        /// <summary>
        /// Content
        /// </summary>
        public string? Content { get; set; }
    }
}
