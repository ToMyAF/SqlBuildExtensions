/**************************************************************************
*   
*   =================================
*   CLR版本    ：4.0.30319.42000
*   命名空间    ：SqlBuildExtensions.Entity
*   文件名称    ：SqlBuildParameter.cs
*   =================================
*   创 建 者    ：李先锋
*   创建日期    ：2020/3/25 17:51:07 
*   功能描述    ：
*   使用说明    ：
*   =================================
*   修改者    ：
*   修改日期    ：
*   修改内容    ：
*   =================================
*  
***************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using SqlBuildExtensions.SqlBuildAttribute;

namespace SqlBuildExtensions.Entity
{
    public class SqlBuildParameter
    {
        public string TableNameAs { get; set; }

        public List<ColumnBuild> ColumnBuilds { get; set; }

        public static SqlBuildParameter Create()
        {
            return new SqlBuildParameter();
        }
        public static SqlBuildParameter Create(string tablename)
        {
            return new SqlBuildParameter() { TableNameAs = tablename };
        }
        public static SqlBuildParameter Create(string tablename,List<ColumnBuild> columnBuilds)
        {
            return new SqlBuildParameter() { TableNameAs = tablename,ColumnBuilds = columnBuilds };
        }
         
    }
    public class ColumnBuild
    {
        public string ColumnName { get; set; }

        public dynamic Value { get; set; }

        public string DateFormatRule { get; set; }

        public Type ColType { get; set; }

        public string DbType { get; set; }

        public static ColumnBuild Create()
        {
            return new ColumnBuild();
        }
        public static ColumnBuild Create(string colName,dynamic value,Type type,SQLBuildAttribute attr)
        {
            return new ColumnBuild() { ColumnName = colName,Value = value,ColType = type};
        }
        public static ColumnBuild Create(string colName, dynamic value, Type type)
        {
            return new ColumnBuild() { ColumnName = colName, Value = value, ColType = type};
        }
        public static ColumnBuild Create(string colName, dynamic value, Type type,string DBtype)
        {
            return new ColumnBuild() { ColumnName = colName, Value = value, ColType = type,DbType = DBtype };
        }
    }
}
