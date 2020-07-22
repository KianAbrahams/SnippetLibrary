using Abrahams.SnippetLibrary.DomainModel;
using System.Data;
using System.Data.SqlClient;

namespace Abrahams.SnippetLibrary.DAL.SqlClient
{
    internal class SqlClientCodeSnippetRepository : SqlClientRepositoryBase, ICodeSnippetRepository
    {
        public CodeSnippet GetCodeSnippet(int codeSnippet)
        {
            using (var ctx = new SqlConnection(connectionString))
            {
                ctx.Open();

                using (var cmd = new SqlCommand("dbo.USP_GetCodeSnippet", ctx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodeSnippetId", SqlDbType.Int).Value = codeSnippet;

                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read() == false)
                            return null;

                        return FetchData(dr);
                    }
                }
            }
        }

        private CodeSnippet FetchData(SqlDataReader dr)
        {
            return new CodeSnippet()
            {
                CodeSnippetId = dr.GetInt32(dr.GetOrdinal("CodeSnippetId")),
                Description = dr.GetString(dr.GetOrdinal("Description")),
                CodeSample = dr.GetString(dr.GetOrdinal("CodeSample")),
                Language = new Language()
                {
                    Id = dr.GetInt32(dr.GetOrdinal("LanguageId")),
                    Name = dr.GetString(dr.GetOrdinal("LanguageName"))
                }
                // TODO: implement Tag
            };
        }
    }
}
