
using CMS.DataEngine;

using CMS.Helpers;
using Kentico.Forms.Web.Mvc;

using Microsoft.AspNetCore.Mvc.Rendering;

using SlickSlider.Models.FormComponents;

using System.Data;

[assembly: RegisterFormComponent(SliderPageTypeSelectorComponent.IDENTIFIER, typeof(SliderPageTypeSelectorComponent), "Drop-down for Page Type Selector ", IconClass = "icon-menu")]

namespace SlickSlider.Models.FormComponents
{
    public class SliderPageTypeSelectorComponent : FormComponent<SliderPageTypeSelectorComponentProperties, string>
    {
        public const string IDENTIFIER = "PageTypeSelectorComponent";

        [BindableProperty]
        public string? SelectedValue { get; set; }

        // Retrieves data to be displayed in the selector
        public List<SelectListItem> GetPageTypes()
        {
            string sqlQuery = "SELECT * FROM cms_class WHERE  ClassIsDocumentType=1  AND ClassIsCoupledClass = 1";
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            QueryDataParameters parameters = new QueryDataParameters();
            // Execute the query
            DataSet results = ConnectionHelper.ExecuteQuery(sqlQuery, null, QueryTypeEnum.SQLQuery);

            // Loop through the results if needed
            if (!DataHelper.DataSourceIsEmpty(results))
            {
                foreach (DataRow row in results.Tables[0].Rows)
                {
                    // Access data from the row as needed
                    selectListItems.Add(new SelectListItem
                    {
                        Value = ValidationHelper.GetString(row["ClassName"], ""),
                        Text = ValidationHelper.GetString(row["ClassDisplayName"], "")
                    });
                }
            }
            return selectListItems;
        }

        public override string GetValue()
        {
            return SelectedValue;
        }

        public override void SetValue(string value)
        {
            SelectedValue = value;
        }
    
    }
}
