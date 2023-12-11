using Kentico.Components.Web.Mvc.FormComponents;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using SlickSlider.Models.FormComponents;
using System.ComponentModel.DataAnnotations;

namespace SlickSlider.Components.Widgets.HeroSlickSlider
{
    public class HeroSlickSliderProperties : IWidgetProperties
    {
        #region ToolTips Constants
        /// <summary>
        /// 
        /// </summary>
        public const string visibleToolTip = "Indicates if the widget should be displayed.";
        /// <summary>
        /// 
        /// </summary>
        public const string pathToolTip = "Specifies the path of the selected pages. If you leave the path empty, the widget either loads all child pages or selects the current page(depending on the page type and configuration of the widget other properties).";
        /// <summary>
        /// viewPathToolTip
        /// </summary>
        public const string viewPathToolTip = "Configure the view with the corresponding page type-related fields and with the proper design after assigning the view path to this field(View Path). View path is being considered from 'Views/Shared/' path, just input the remaining path of a partial view without the extension. E.g.: Articles/_ArticleViewList";

        public const string maxNumberOfSlidesToolTip = "Specifies the path of the selected pages. If you leave the path empty, the widget either loads all child pages or selects the current page(depending on the page type and configuration of the widget other properties).";
        public const string slidestoshow = "";
        public const string slidestoscroll = "";
        public const string speed = "";
        public const string autoplay = "";
        public const string autoplayspeed = "";
        public const string showdots = "";
        public const string fade = "";
        public const string cssease = "";
        public const string transformation = "";
        #endregion


        #region Widget Properties
        /// <summary>
        /// Declaring to st the visibility of the widget
        /// </summary>
        [EditingComponent(CheckBoxComponent.IDENTIFIER, Label = "Visible", Order = 0, Tooltip = visibleToolTip)]
        public bool Visible { get; set; }
        /// <summary>
        /// Declaring to select the path for the page types 
        /// </summary>
        [EditingComponent(PathSelector.IDENTIFIER, Order = 1, Label = "Page Path*", Tooltip = pathToolTip)]
        [EditingComponentProperty(nameof(PathSelectorProperties.RootPath), "/")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Select the path")]
        public IList<PathSelectorItem>? Path { get; set; }
        public string? PageType { get; set; }
        public string OrderBy { get; set; } = "NodeLevel, NodeOrder, NodeName";
        /// <summary>
        /// Declaring to select Maximum number of slides
        /// </summary>
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Maximum number of slides", Order = 2)]
        [Range(1, 100, ErrorMessage = "Please enter valid number")]
        public string TopN { get; set; } = "10";
        /// <summary>
        /// Slides to Show
        /// </summary>
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Slides to Show", DefaultValue = "1", Order = 3, Tooltip = slidestoshow)]
        public string SlidesToShow { get; set; } = "";
        /// <summary>
        /// SlidesToScroll
        /// </summary>
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Slides to Scroll", DefaultValue = "1", Order = 4, Tooltip = slidestoscroll)]
        public string SlidesToScroll { get; set; } = "";
        /// <summary>
        /// Speed
        /// </summary>
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Speed", DefaultValue = "1000", Order = 5, Tooltip = speed)]
        public string Speed { get; set; } = "";
        /// <summary>
        /// AutoPlay
        /// </summary>
        [EditingComponent(CheckBoxComponent.IDENTIFIER, Label = "Autoplay", DefaultValue = true, Order = 6, Tooltip = autoplay)]
        public bool AutoPlay { get; set; }
        /// <summary>
        /// AutoPlaySpeed
        /// </summary>
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Autoplay Speed", DefaultValue = "5000", Order = 7, Tooltip = autoplayspeed)]
        public string AutoPlaySpeed { get; set; } = "";
        /// <summary>
        /// ShowDots
        /// </summary>
        [EditingComponent(CheckBoxComponent.IDENTIFIER, Label = "Show Dots", DefaultValue = true, Order = 8, Tooltip = showdots)]
        public bool ShowDots { get; set; }
        /// <summary>
        /// Fade
        /// </summary>
        [EditingComponent(CheckBoxComponent.IDENTIFIER, Label = "Fade", DefaultValue = false, Order = 9, Tooltip = fade)]
        public bool Fade { get; set; }
        /// <summary>
        /// Transformation
        /// </summary>
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "transformation", Order = 10, Tooltip = viewPathToolTip)]
        public string Transformation { get; set; } = "";

        /// <summary>
        ///Content
       /// </summary>
        [EditingComponent(RichTextComponent.IDENTIFIER, Order = 11, Label = "Content")]
        [VisibilityCondition(nameof(Transformation), ComparisonTypeEnum.IsEqualTo, "_SliderTopLayout", StringComparison = StringComparison.OrdinalIgnoreCase)]
        public string? Content { get; set; }

        /// <summary>
        /// Select Page type classname
        /// </summary>
        [EditingComponent(SliderPageTypeSelectorComponent.IDENTIFIER, Order = 12, Label = "Page Types*")]
        public string? PageTypes { get; set; }

        #endregion
    }
}
