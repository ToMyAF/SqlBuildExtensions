using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SqlBuildExtensions.Interface;
using SqlBuildExtensions;
using System.Collections;

namespace SqlBuildExtensions
{
    public static class SqlEntityBuild
    {
        static ISqlBuildFactory sqlBuildFactory = new DefaultFactory();
        public static string BuildSql<T>(this T obj) where T:class,new()
        {
            return sqlBuildFactory.BuildSql(obj);
        }
        public static ArrayList BuildSqlArray<T>(this T obj) where T : class, new()
        {
            return sqlBuildFactory.BuildSqlArry(obj);
        }
        
    }
}
