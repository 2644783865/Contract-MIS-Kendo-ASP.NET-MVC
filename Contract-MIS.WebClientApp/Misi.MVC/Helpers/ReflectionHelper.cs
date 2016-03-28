using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Misi.MVC.Helpers
{
    public class ReflectionHelper
    {
        public static string GetRandomString(int seed)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random(seed + DateTime.Now.Millisecond);
            return new string(
                Enumerable.Repeat(chars, (74 - seed) % 25)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
        }


        public static string GenerateRandomString(int length = 20)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random(Convert.ToInt32(DateTime.Now.Ticks % 10000));

            return new string(
                Enumerable.Repeat(chars, length)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
        }

        /// <summary>
        /// Return list of YourObject with randomized properties
        /// </summary>s
        /// <param name="mockedModel">new YourObject()</param>
        /// <param name="type">typeof(YourObject)</param>
        /// <param name="count">length of your expected list as result</param>
        /// <returns></returns>
        public static IList GetRandomValuedList(IList list, object mockedModel, Type type, int count)
        {
            for (var i = 0; i < count;)
            {
                list.Add(GetRandomValueForAllProperties(mockedModel, type, i++));
            }
            return list;
        }


        public static object GetRandomValueForAllProperties(object viewModel, Type type)
        {
            var properties = type.GetProperties();
            foreach (var prop in properties)
            {
                try
                {
                    prop.SetValue(viewModel, GetRandomString(0));
                }
                catch (Exception)
                {
                    continue;
                }
            }
            return viewModel;
        }

        public static object GetRandomValueForAllProperties(object viewModel, Type type, int seed)
        {
            var properties = type.GetProperties();
            foreach (var prop in properties)
            {
                try
                {
                    prop.SetValue(viewModel, GetRandomString(seed));
                }
                catch (Exception)
                {
                    continue;
                }
            }
            return viewModel;
        }

    }
}