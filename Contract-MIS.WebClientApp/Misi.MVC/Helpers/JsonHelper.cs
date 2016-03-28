using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Misi.MVC.Resources;

namespace Misi.MVC.Helpers
{
    public class JsonHelper
    {
        private const string ViewDelimiter = " | ";
        private const string ServiceDelimiter = ";";

        /// <summary>
        /// Generate Json object from given array of string
        /// </summary>
        /// <param name="serviceModel"></param>
        /// <param name="displayIdProperty">Indicate whether the ID property is diplayed on the screen</param>
        /// <returns></returns>
        public static object ConvertToJson(IEnumerable<string> serviceModel, bool displayIdProperty = true)
        {
            string [] dummy = {"this is just a dummy array, which contains only 1"};
            var stringList = dummy.Select(e => new
            {
                value = SharedResource.NA,
                text = string.Empty
            }).ToList(); 
            
            if (!serviceModel.Any())
            {
                return stringList;
            }
           
            stringList.AddRange(serviceModel.Select(e => new
            {
                value = e.Split(ServiceDelimiter.ToCharArray())[0],
                text = displayIdProperty ?
                e.Split(ServiceDelimiter.ToCharArray())
                    .Aggregate((word, followingWord) => word + ViewDelimiter + followingWord) :
                e.Remove(0, e.IndexOf(ServiceDelimiter, StringComparison.Ordinal) + 1).Split(ServiceDelimiter.ToCharArray())
                    .Aggregate((word, followingWord) => word + ViewDelimiter + followingWord)
            }));

            return stringList;
        }

        public static object GenerateEmptyJson()
        {
            string[] dummy = { "this is just a dummy array, which contains only 1" };
            var stringList = dummy.Select(e => new
            {
                value = SharedResource.NA,
                text = string.Empty
            }).ToList();

            return stringList;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="type"></param>
        /// <param name="displayIdProperty"></param>
        /// <returns></returns>
        public static object ConvertToJson(object viewModel, Type type, bool displayIdProperty = true)
        {
            var iListObject = viewModel as IList;
            var listOfDelimitedStrings = (from object obj in iListObject select ConverToDelimitedString(obj, type));
            return ConvertToJson(listOfDelimitedStrings, displayIdProperty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static string ConverToDelimitedString(object viewModel, Type type)
        {
            var properties = type.GetProperties();
            return properties.Aggregate(string.Empty, (current, prop) => current + (prop.GetValue(viewModel) + ServiceDelimiter));
        }
    }
}