using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace Misi.MVC.Helpers
{
    public class DictionaryHelper
    { 
        public static DateTime KendoDatePickerToDateTime(string dateTimeString)
        {
            //23 Feb 2015 17:00 =>  2015-02-23T17:00:00.000Z

            var date = dateTimeString.Split('T')[0];
            var time = dateTimeString.Split('T')[1].Split('Z')[0];
            return DateTime.ParseExact(date + " " + time, "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.CurrentCulture);
        }

        public static DateTime KendoDatePickerDateStringToDateTime(string dateTimeString)
        {
            var date = dateTimeString.Replace(dateTimeString.Split(' ')[0]+" ", "");
            return DateTime.ParseExact(date, "MMM dd yyyy", System.Globalization.CultureInfo.CurrentCulture);
        }

        public static string ConvertToIntegerSafeString(string inputString)
        {
            var result = string.Empty;
            var included = false;
            for (int i = 0; i < inputString.Count(); i++)
            {
                if (inputString[i] == '0' && !included) continue;
                included = true;
                result += inputString[i];
            }
            return string.IsNullOrEmpty(result) ? "0" : result;
        }

        public static IEnumerable<SelectListItem> ToSelectListItems(params string[] items)
        {
            return items.Select(i => new SelectListItem
            {
                Text = i,
                Value = i,
                Selected = true
            });
        }

        public static IEnumerable<SelectListItem> ToSelectListItems(string selected, bool isSelected,
            params string[] items)
        {
            return items.Select(i => new SelectListItem
            {
                Text = i,
                Value = i,
                Selected = (i == selected) && isSelected
            });
        }

        public static IDictionary<string, string> ToDictionary(object objectToConvert, Type type)
        {
            var properties = type.GetProperties();
            var dictionaryResult = new Dictionary<string, string>();
            foreach (var prop in properties)
            {
                dictionaryResult[prop.Name] = Convert.ToString(prop.GetValue(objectToConvert));
            }
            return dictionaryResult;
        }

        
    }
}