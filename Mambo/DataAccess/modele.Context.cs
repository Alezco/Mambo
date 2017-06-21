﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mambo.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class dbNetEntities : DbContext
    {
        public dbNetEntities()
            : base("name=dbNetEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<T_ARTICLE> T_ARTICLE { get; set; }
        public virtual DbSet<T_ARTICLE_LIKE> T_ARTICLE_LIKE { get; set; }
        public virtual DbSet<T_COMMENT_ARTICLE> T_COMMENT_ARTICLE { get; set; }
        public virtual DbSet<T_LANGUAGE> T_LANGUAGE { get; set; }
        public virtual DbSet<T_RESOURCES> T_RESOURCES { get; set; }
        public virtual DbSet<T_ROLE> T_ROLE { get; set; }
        public virtual DbSet<T_TRANSLATION> T_TRANSLATION { get; set; }
        public virtual DbSet<T_USER> T_USER { get; set; }
    
        public virtual ObjectResult<Nullable<int>> CreateArticle(Nullable<int> adminID, Nullable<System.DateTime> creationDate, string status, Nullable<int> nbViews)
        {
            var adminIDParameter = adminID.HasValue ?
                new ObjectParameter("adminID", adminID) :
                new ObjectParameter("adminID", typeof(int));
    
            var creationDateParameter = creationDate.HasValue ?
                new ObjectParameter("creationDate", creationDate) :
                new ObjectParameter("creationDate", typeof(System.DateTime));
    
            var statusParameter = status != null ?
                new ObjectParameter("status", status) :
                new ObjectParameter("status", typeof(string));
    
            var nbViewsParameter = nbViews.HasValue ?
                new ObjectParameter("nbViews", nbViews) :
                new ObjectParameter("nbViews", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("CreateArticle", adminIDParameter, creationDateParameter, statusParameter, nbViewsParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> CreateArticle_Like(Nullable<int> userID, Nullable<int> articleID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            var articleIDParameter = articleID.HasValue ?
                new ObjectParameter("articleID", articleID) :
                new ObjectParameter("articleID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("CreateArticle_Like", userIDParameter, articleIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> CreateComment_Article(Nullable<int> userID, Nullable<int> articleID, Nullable<System.DateTime> creationDate, string commentContent)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            var articleIDParameter = articleID.HasValue ?
                new ObjectParameter("articleID", articleID) :
                new ObjectParameter("articleID", typeof(int));
    
            var creationDateParameter = creationDate.HasValue ?
                new ObjectParameter("creationDate", creationDate) :
                new ObjectParameter("creationDate", typeof(System.DateTime));
    
            var commentContentParameter = commentContent != null ?
                new ObjectParameter("commentContent", commentContent) :
                new ObjectParameter("commentContent", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("CreateComment_Article", userIDParameter, articleIDParameter, creationDateParameter, commentContentParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> CreateLanguage(string language)
        {
            var languageParameter = language != null ?
                new ObjectParameter("language", language) :
                new ObjectParameter("language", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("CreateLanguage", languageParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> CreateResources(string title, string description, string path, Nullable<int> languageID)
        {
            var titleParameter = title != null ?
                new ObjectParameter("title", title) :
                new ObjectParameter("title", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("description", description) :
                new ObjectParameter("description", typeof(string));
    
            var pathParameter = path != null ?
                new ObjectParameter("path", path) :
                new ObjectParameter("path", typeof(string));
    
            var languageIDParameter = languageID.HasValue ?
                new ObjectParameter("languageID", languageID) :
                new ObjectParameter("languageID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("CreateResources", titleParameter, descriptionParameter, pathParameter, languageIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> CreateRole(string role)
        {
            var roleParameter = role != null ?
                new ObjectParameter("role", role) :
                new ObjectParameter("role", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("CreateRole", roleParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> CreateTranslation(Nullable<int> articleID, Nullable<int> translatorID, Nullable<int> language, string translationArticleContent, string translationArticleTitle)
        {
            var articleIDParameter = articleID.HasValue ?
                new ObjectParameter("articleID", articleID) :
                new ObjectParameter("articleID", typeof(int));
    
            var translatorIDParameter = translatorID.HasValue ?
                new ObjectParameter("translatorID", translatorID) :
                new ObjectParameter("translatorID", typeof(int));
    
            var languageParameter = language.HasValue ?
                new ObjectParameter("language", language) :
                new ObjectParameter("language", typeof(int));
    
            var translationArticleContentParameter = translationArticleContent != null ?
                new ObjectParameter("translationArticleContent", translationArticleContent) :
                new ObjectParameter("translationArticleContent", typeof(string));
    
            var translationArticleTitleParameter = translationArticleTitle != null ?
                new ObjectParameter("translationArticleTitle", translationArticleTitle) :
                new ObjectParameter("translationArticleTitle", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("CreateTranslation", articleIDParameter, translatorIDParameter, languageParameter, translationArticleContentParameter, translationArticleTitleParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> CreateUser(string pseudo, string email, string password, Nullable<int> roleID)
        {
            var pseudoParameter = pseudo != null ?
                new ObjectParameter("pseudo", pseudo) :
                new ObjectParameter("pseudo", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var roleIDParameter = roleID.HasValue ?
                new ObjectParameter("roleID", roleID) :
                new ObjectParameter("roleID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("CreateUser", pseudoParameter, emailParameter, passwordParameter, roleIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> DeleteArticle(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("DeleteArticle", idParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> DeleteArticle_Like(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("DeleteArticle_Like", idParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> DeleteComment_Article(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("DeleteComment_Article", idParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> DeleteLanguage(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("DeleteLanguage", idParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> DeleteResources(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("DeleteResources", idParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> DeleteRole(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("DeleteRole", idParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> DeleteTranslation(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("DeleteTranslation", idParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> DeleteUser(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("DeleteUser", idParameter);
        }
    
        public virtual ObjectResult<GetArticle_Result> GetArticle(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetArticle_Result>("GetArticle", idParameter);
        }
    
        public virtual ObjectResult<GetArticle_Like_Result> GetArticle_Like(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetArticle_Like_Result>("GetArticle_Like", idParameter);
        }
    
        public virtual ObjectResult<GetComment_Article_Result> GetComment_Article(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetComment_Article_Result>("GetComment_Article", idParameter);
        }
    
        public virtual ObjectResult<GetLanguage_Result> GetLanguage(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetLanguage_Result>("GetLanguage", idParameter);
        }
    
        public virtual ObjectResult<GetResources_Result> GetResources(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetResources_Result>("GetResources", idParameter);
        }
    
        public virtual ObjectResult<GetRole_Result> GetRole(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetRole_Result>("GetRole", idParameter);
        }
    
        public virtual ObjectResult<GetTranslation_Result> GetTranslation(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetTranslation_Result>("GetTranslation", idParameter);
        }
    
        public virtual ObjectResult<GetUser_Result> GetUser(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetUser_Result>("GetUser", idParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<UpdateArticle_Result> UpdateArticle(Nullable<int> id, Nullable<int> adminID, Nullable<System.DateTime> creationDate, string status, Nullable<int> nbViews)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var adminIDParameter = adminID.HasValue ?
                new ObjectParameter("adminID", adminID) :
                new ObjectParameter("adminID", typeof(int));
    
            var creationDateParameter = creationDate.HasValue ?
                new ObjectParameter("creationDate", creationDate) :
                new ObjectParameter("creationDate", typeof(System.DateTime));
    
            var statusParameter = status != null ?
                new ObjectParameter("status", status) :
                new ObjectParameter("status", typeof(string));
    
            var nbViewsParameter = nbViews.HasValue ?
                new ObjectParameter("nbViews", nbViews) :
                new ObjectParameter("nbViews", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UpdateArticle_Result>("UpdateArticle", idParameter, adminIDParameter, creationDateParameter, statusParameter, nbViewsParameter);
        }
    
        public virtual ObjectResult<UpdateArticle_Like_Result> UpdateArticle_Like(Nullable<int> id, Nullable<int> userID, Nullable<int> articleID)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            var articleIDParameter = articleID.HasValue ?
                new ObjectParameter("articleID", articleID) :
                new ObjectParameter("articleID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UpdateArticle_Like_Result>("UpdateArticle_Like", idParameter, userIDParameter, articleIDParameter);
        }
    
        public virtual ObjectResult<UpdateComment_Article_Result> UpdateComment_Article(Nullable<int> id, Nullable<int> userID, Nullable<int> articleID, Nullable<System.DateTime> creationDate, string commentContent)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            var articleIDParameter = articleID.HasValue ?
                new ObjectParameter("articleID", articleID) :
                new ObjectParameter("articleID", typeof(int));
    
            var creationDateParameter = creationDate.HasValue ?
                new ObjectParameter("creationDate", creationDate) :
                new ObjectParameter("creationDate", typeof(System.DateTime));
    
            var commentContentParameter = commentContent != null ?
                new ObjectParameter("commentContent", commentContent) :
                new ObjectParameter("commentContent", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UpdateComment_Article_Result>("UpdateComment_Article", idParameter, userIDParameter, articleIDParameter, creationDateParameter, commentContentParameter);
        }
    
        public virtual ObjectResult<string> UpdateLanguage(Nullable<int> id, string language)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var languageParameter = language != null ?
                new ObjectParameter("language", language) :
                new ObjectParameter("language", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("UpdateLanguage", idParameter, languageParameter);
        }
    
        public virtual ObjectResult<UpdateResources_Result> UpdateResources(Nullable<int> id, string title, string description, string path, Nullable<int> languageID)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var titleParameter = title != null ?
                new ObjectParameter("title", title) :
                new ObjectParameter("title", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("description", description) :
                new ObjectParameter("description", typeof(string));
    
            var pathParameter = path != null ?
                new ObjectParameter("path", path) :
                new ObjectParameter("path", typeof(string));
    
            var languageIDParameter = languageID.HasValue ?
                new ObjectParameter("languageID", languageID) :
                new ObjectParameter("languageID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UpdateResources_Result>("UpdateResources", idParameter, titleParameter, descriptionParameter, pathParameter, languageIDParameter);
        }
    
        public virtual ObjectResult<string> UpdateRole(Nullable<int> id, string role)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var roleParameter = role != null ?
                new ObjectParameter("role", role) :
                new ObjectParameter("role", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("UpdateRole", idParameter, roleParameter);
        }
    
        public virtual ObjectResult<UpdateTranslation_Result> UpdateTranslation(Nullable<int> id, Nullable<int> articleID, Nullable<int> translatorID, Nullable<int> language, string translationArticleContent, string translationArticleTitle)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var articleIDParameter = articleID.HasValue ?
                new ObjectParameter("articleID", articleID) :
                new ObjectParameter("articleID", typeof(int));
    
            var translatorIDParameter = translatorID.HasValue ?
                new ObjectParameter("translatorID", translatorID) :
                new ObjectParameter("translatorID", typeof(int));
    
            var languageParameter = language.HasValue ?
                new ObjectParameter("language", language) :
                new ObjectParameter("language", typeof(int));
    
            var translationArticleContentParameter = translationArticleContent != null ?
                new ObjectParameter("translationArticleContent", translationArticleContent) :
                new ObjectParameter("translationArticleContent", typeof(string));
    
            var translationArticleTitleParameter = translationArticleTitle != null ?
                new ObjectParameter("translationArticleTitle", translationArticleTitle) :
                new ObjectParameter("translationArticleTitle", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UpdateTranslation_Result>("UpdateTranslation", idParameter, articleIDParameter, translatorIDParameter, languageParameter, translationArticleContentParameter, translationArticleTitleParameter);
        }
    
        public virtual ObjectResult<UpdateUser_Result> UpdateUser(Nullable<int> id, string pseudo, string email, string password, Nullable<int> roleID)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var pseudoParameter = pseudo != null ?
                new ObjectParameter("pseudo", pseudo) :
                new ObjectParameter("pseudo", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var roleIDParameter = roleID.HasValue ?
                new ObjectParameter("roleID", roleID) :
                new ObjectParameter("roleID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UpdateUser_Result>("UpdateUser", idParameter, pseudoParameter, emailParameter, passwordParameter, roleIDParameter);
        }

        public System.Data.Entity.DbSet<Mambo.DBO.Article> Articles { get; set; }
    }
}
