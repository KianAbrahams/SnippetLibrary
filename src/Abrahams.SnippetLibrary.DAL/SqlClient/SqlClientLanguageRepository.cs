using Abrahams.SnippetLibrary.DomainModel;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Abrahams.SnippetLibrary.DAL.SqlClient
{
    public class SqlClientLanguageRepository : SqlClientRepositoryBase, ILanguageRepository
    {
        public List<Language> GetLanguageList()
        {
            var result = new List<Language>();

            using (var ctx = new SqlConnection(connectionString))
            {
                ctx.Open();
                
                using (var cmd = new SqlCommand("dbo.USP_GetAvailableLanguages", ctx))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            result.Add(new Language() 
                            { 
                                Id = dr.GetInt32(dr.GetOrdinal("LanguageId")),
                                Name = dr.GetString(dr.GetOrdinal("LanguageName")) 
                            });
                        }
                    }
                }
            }
            return result;
        }
    }
}