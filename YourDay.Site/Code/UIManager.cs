using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;
using System.Reflection;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Configuration;

namespace YourDay.Site
{
    public class UIManager
    {
        //TODO: Вынести общую составляющую

        public static string CreateLinks(POCO.Contractor currentContractor)
        {
            
            string specializationLinks = String.Empty;
            foreach (POCO.ContractorCategory cc in currentContractor.ContractorCategories)
            {
                HyperLink hpl = new HyperLink();
                hpl.Text = BLL.Get.SubCategory(cc.SubcategoryId).Title;
                hpl.NavigateUrl = Constants.Config.GetLink(Constants.Strings.SubcategoryLink, cc.SubcategoryId.ToString());

                using (TextWriter sw = new StringWriter())
                {
                    using (Html32TextWriter htmlWriter = new Html32TextWriter(sw))
                    {
                        hpl.RenderControl(htmlWriter);
                        specializationLinks += String.Format("{0}{1} ", htmlWriter.InnerWriter, ",");
                    }
                }
            }
            specializationLinks = specializationLinks.Substring(0, specializationLinks.Length - 2);
            return specializationLinks;
        }

        public static string CreateLinks(POCO.Contractor currentContractor, POCO.EventCard ec)
        {
            string specializationLinks = String.Empty;
            var eccs = BLL.Get.EventCardCompanies(currentContractor.Id).Where(x => x.EventCardId == ec.Id);
            foreach (var ecc in eccs)
            {
                specializationLinks = String.Format("{0}, {1}", specializationLinks, BLL.Get.SubCategory(ecc.SubcategoryId).Title);
            }
            return specializationLinks.Substring(2);
        }

        public static string RenderControl(string controlTypeName, Dictionary<string, object> properties, string path)
        {
            Page pageHolder = new Page();
            HtmlForm tempForm = new HtmlForm(); 
            Type t = Type.GetType(controlTypeName);
            UserControl c = (UserControl)pageHolder.LoadControl(path);
            if (properties != null)
            {
                foreach (var d in properties)
                {
                    PropertyInfo pi = t.GetProperty(d.Key);
                    pi.SetValue(c, d.Value, null);
                }
            }
            tempForm.Controls.Add(c);
            pageHolder.Controls.Add(tempForm);
            StringWriter output = new StringWriter();
            HttpContext.Current.Server.Execute(pageHolder, output, true);
            string regexIn = ConfigurationManager.AppSettings["clearFormTag"];
            string regexOut = ConfigurationManager.AppSettings["htmlCodeInsideFormTag"];
            string result = Regex.Replace(output.ToString(), regexIn, regexOut, RegexOptions.IgnoreCase);
            return result;
        }

        public static string IsEmpty(params string[] sArray)
        {
            foreach (string s in sArray)
            {
                if (!String.IsNullOrEmpty(s.Trim()))
                    return s;
            }
            return String.Empty;
        }
    }
}