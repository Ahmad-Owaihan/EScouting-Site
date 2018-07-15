using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;

namespace EScouting.Models
{
    public class Global
    {
        public static string Key = "RGAPI-1c15b17f-da72-4cb8-b4f5-3615b6cfed1d";

        // methods

        // method used to get JSON data from the web deserialize it to  .net class             source: "https://www.codeproject.com/Tips/397574/Use-Csharp-to-get-JSON-Data-from-the-Web-and-Map-i"
        public static T _download_serialized_json_data<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }

        // same method but for array of JSON objects (fix for League api)
        public static List<T> _download_serialized_json_data_array<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<List<T>>(json_data) : new List<T>();
            }
        }

        // method used to get list of countries        source: "https://forums.asp.net/t/2090553.aspx?Creating+a+country+dropdown+list+"
        public static Dictionary<string, string> CountryList()
        {
            //Creating Dictionary
            Dictionary<string, string> cultureList = new Dictionary<string, string>();

            //getting the specific CultureInfo from CultureInfo class
            CultureInfo[] getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo getCulture in getCultureInfo)
            {
                //creating the object of RegionInfo class
                RegionInfo getRegionInfo = new RegionInfo(getCulture.LCID);
                //adding each country Name into the Dictionary
                if (!(cultureList.ContainsKey(getRegionInfo.Name)))
                {
                    cultureList.Add(getRegionInfo.Name, getRegionInfo.EnglishName);
                }
            }
            //returning country list
            return cultureList;
        }
    }
}