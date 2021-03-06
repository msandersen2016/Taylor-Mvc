﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Web;

namespace Taylor_Mvc.DataAccess
{
    public static class SQLDataAccess
    {
        public static string GetConnectionString(string connectionName = "DefaultConnection")
        {
            //return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            return "Data Source=tcp:taylorsql2.database.windows.net,1433;Initial Catalog=ProServices2;User Id=Group1@taylorsql2;Password=Pr0gre$$11";
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
            }

        }

        public static void ExecuteData(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                cnn.Execute(sql);
            }
        }
    }
}