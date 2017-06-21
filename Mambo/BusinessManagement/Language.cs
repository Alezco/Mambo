using Mambo.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mambo.DBO;

namespace Mambo.BusinessManagement
{
    public class Language : ICrud<DBO.Language>
    {
        private DataAccess.Language languageAccess;
        public Language()
        {
            languageAccess = new DataAccess.Language();
        }

        public bool Create(DBO.Language obj)
        {
            return languageAccess.Create(obj);
        }

        public bool Delete(int key)
        {
            return languageAccess.Delete(key);
        }

        public DBO.Language Get(int key)
        {
            return languageAccess.Get(key);
        }

        public DBO.Language GetLanguageByName(string name)
        {
            return languageAccess.GetLanguageByName(name);
        }

        public List<DBO.Language> GetAll()
        {
            return languageAccess.GetAll();
        }

        public bool Update(DBO.Language obj)
        {
            return languageAccess.Update(obj);
        }
    }
}