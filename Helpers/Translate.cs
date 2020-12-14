using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Web;

namespace MVCWebApplicationTD.Helpers
{
    public class Translate
    {
        
        
        public static string TranslateTo(string word, string lang)
        {

            Assembly assembly = System.Reflection.Assembly.Load("App_GlobalResources");

            List<string> available = new List<string>();
            ResourceManager rm = new ResourceManager("Resources.Lang_" + lang, assembly);

            string sentence = rm.GetString(word);

            return sentence;
        }
    }
}