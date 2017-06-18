using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mambo.DBO
{
    public class Language
    {
        public int Id { get; set; }
        public string LanguageName { get; set; }

        public Language() { }

        public Language(string languageName)
        {
            LanguageName = languageName;
        }
    }
}