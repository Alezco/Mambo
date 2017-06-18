using Mambo.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mambo.DBO;

namespace Mambo.DataAccess
{
    public class Language : ICrud<DBO.Language>
    {
        public bool Create(DBO.Language obj)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    long result = bdd.CreateLanguage(obj.LanguageName).FirstOrDefault().Value;
                    return result > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int key)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    long result = bdd.DeleteLanguage(key).FirstOrDefault().Value;
                    return result > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DBO.Language Get(int key)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    var result = bdd.GetLanguage(key).FirstOrDefault();
                    return new DBO.Language(result.language);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DBO.Language> GetAll(Type t)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    List<T_LANGUAGE> tLanguages = bdd.T_LANGUAGE.ToList();
                    List<DBO.Language> languages = new List<DBO.Language>();
                    foreach (T_LANGUAGE tLanguage in tLanguages)
                    {
                        DBO.Language role = new DBO.Language(tLanguage.id, tLanguage.language);
                        languages.Add(role);
                    }
                    return languages;
                }
            }

            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(DBO.Language obj)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    var req = bdd.UpdateLanguage(obj.Id, obj.LanguageName).FirstOrDefault();

                    return obj.isEqual(new DBO.Language(req));
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}