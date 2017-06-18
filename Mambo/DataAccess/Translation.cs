using Mambo.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mambo.DBO;

namespace Mambo.DataAccess
{
    public class Translation : ICrud<DBO.Translation>
    {
        public bool Create(DBO.Translation obj)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    long result = bdd.CreateTranslation(obj.ArticleId, obj.TranslatorId, obj.LanguageId,
                                                        obj.TranslationArticleContent, obj.TranslationArticleTitle).FirstOrDefault().Value;
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
                    long result = bdd.DeleteTranslation(key).FirstOrDefault().Value;
                    return result > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DBO.Translation Get(int key)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    var result = bdd.GetTranslation(key).FirstOrDefault();
                    return new DBO.Translation(result.id, result.articleID, result.translatorID, result.language, result.translationArticleTitle, result.translationArticleContent);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DBO.Translation> GetAll(Type t)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    List<T_TRANSLATION> tTranslations = bdd.T_TRANSLATION.ToList();
                    List<DBO.Translation> translations = new List<DBO.Translation>();
                    foreach (T_TRANSLATION tTranslation in tTranslations)
                    {
                        DBO.Translation translation = new DBO.Translation(tTranslation.id, tTranslation.articleID, tTranslation.translatorID,
                                                                    tTranslation.language, tTranslation.translationArticleTitle, tTranslation.translationArticleContent);
                        translations.Add(translation);
                    }
                    return translations;
                }
            }

            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(DBO.Translation obj)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    var req = bdd.UpdateTranslation(obj.Id, obj.ArticleId, obj.TranslatorId, obj.LanguageId, obj.TranslationArticleContent, obj.TranslationArticleTitle).FirstOrDefault();

                    return req != null && obj.isEqual(new DBO.Translation(req.articleID, req.translatorID, req.language, req.translationArticleTitle, req.translationArticleContent));
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}