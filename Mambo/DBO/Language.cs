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

        public Language(int id, string languageName)
        {
            Id = id;
            LanguageName = languageName;
        }
        public bool isEqual(Language l2)
        {
            return this.LanguageName == l2.LanguageName;
        }
    }
}