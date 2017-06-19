using Mambo.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mambo.DBO;

namespace Mambo.BusinessManagement
{
    public class Translation : ICrud<DBO.Translation>
    {
        private DataAccess.Translation translationAccess;
        public Translation()
        {
            translationAccess = new DataAccess.Translation();
        }

        public bool Create(DBO.Translation obj)
        {
            return translationAccess.Create(obj);
        }

        public bool Delete(int key)
        {
            return translationAccess.Delete(key);
        }

        public DBO.Translation Get(int key)
        {
            return translationAccess.Get(key);
        }

        public List<DBO.Translation> GetTranslationsByArticleId(int key)
        {
            return translationAccess.GetTranslationsByArticleId(key);
        }

        public List<DBO.Translation> GetAll()
        {
            return translationAccess.GetAll();
        }

        public bool Update(DBO.Translation obj)
        {
            return translationAccess.Update(obj);
        }
    }
}