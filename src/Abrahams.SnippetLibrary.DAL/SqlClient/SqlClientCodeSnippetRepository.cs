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

        public int SaveCodeSnippet(CodeSnippet codeSnippet)
        {
            using (var ctx = new SqlConnection(connectionString))
            {
                ctx.Open();

                using (var cmd = new SqlCommand("dbo.USP_SaveCodeSnippet", ctx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 255).Value = codeSnippet.Description;
                    // TODO: check how to deal with NVarChar(max) ...
                    cmd.Parameters.Add("@CodeSample", SqlDbType.NVarChar).Value = codeSnippet.CodeSample;
                    cmd.Parameters.Add("@LanguageId", SqlDbType.Int).Value = codeSnippet.Language.Id;
                    cmd.Parameters.Add("@CodeSnippetId", SqlDbType.Int).Value = codeSnippet.CodeSnippetId;

                    cmd.Parameters.Add(new SqlParameter("@ReturnVal", SqlDbType.Int) { Direction = ParameterDirection.ReturnValue });

                    cmd.ExecuteNonQuery();

                    return (int)cmd.Parameters["@ReturnVal"].Value;
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
