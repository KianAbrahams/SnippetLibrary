using Abrahams.SnippetLibrary.DomainModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Abrahams.SnippetLibrary.DAL.SqlClient
{
    internal class SqlClientTagRepository : SqlClientRepositoryBase, ITagRepository
    {
        public List<Tag> GetTags()
        {
            return new List<Tag> 
            {
                new Tag() {Name = "MVVM", TagId = 1},
                new Tag() {Name = "PRISM", TagId = 2}
            };
        }


        public int SaveTag(Tag tag)
        {
            using (var ctx = new SqlConnection(connectionString))
            {
                ctx.Open();

                using (var cmd = new SqlCommand("dbo.USP_SaveTag", ctx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@TagName", SqlDbType.NVarChar, 255).Value = tag.Name;
                    cmd.Parameters.Add("@TagId", SqlDbType.Int).Value = tag.TagId;

                    cmd.Parameters
                        .Add(new SqlParameter("@ReturnVal", SqlDbType.Int)
                        { Direction = ParameterDirection.ReturnValue });

                    cmd.ExecuteNonQuery();

                    return (int)cmd.Parameters["@ReturnVal"].Value;
                }
            }
        }
    }
}
