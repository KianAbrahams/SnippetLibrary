﻿namespace Abrahams.SnippetLibrary.DAL.SqlClient
{
    public abstract class SqlClientRepositoryBase
    {
        // TODO: Refactor to config
        protected const string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=SnippetLibrary;Trusted_Connection=True";
    }
}
