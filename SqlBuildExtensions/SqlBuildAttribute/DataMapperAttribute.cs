/**************************************************************************
*   
*   =================================
*   CLR版本    ：4.0.30319.42000
*   命名空间    ：SqlBuildExtensions.SqlBuildAttribute
*   文件名称    ：DataMapperAttribute.cs
*   =================================
*   创 建 者    ：李先锋
*   创建日期    ：2020/4/19 15:10:42 
*   功能描述    ：Column对应Property
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
using System.Linq;
using System.Text;

namespace SqlBuildExtensions.SqlBuildAttribute
{
    public enum TableFlag
    {
        ByTableName = 0,
        ByTableIndex = 1
    }
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Property)]
    public class DataMapperAttribute: Attribute
    {
        public string ColumnName { get; set; }

        public string TableName { get; set; }

        public string ConvertFuncName { get { return "ConvertHandle"; } }
        
        public int TableIndex { get; set; }

        public TableFlag TableFlag { get; set; }

        public bool HasEntend { get; set; } = false;

        public DataMapperAttribute(string tablename)
        {
            TableFlag = TableFlag.ByTableName;
            TableName = tablename;
        }
        public DataMapperAttribute(int tableindex)
        {
            TableFlag = TableFlag.ByTableIndex;
            TableIndex = tableindex;
        }
        public DataMapperAttribute(string tablename,string colname)
        {
            TableFlag = TableFlag.ByTableName;
            TableName = tablename;
            ColumnName = colname;
        }
        public DataMapperAttribute(int tableindex,string colname)
        {
            TableFlag = TableFlag.ByTableIndex;
            TableIndex = tableindex;
            ColumnName = colname;
        }
        public DataMapperAttribute(string tablename,bool hasextend)
        {
            TableFlag = TableFlag.ByTableName;
            TableName = tablename;
            HasEntend = hasextend;
        }
        public DataMapperAttribute(int tableindex, bool hasextend)
        {
            TableFlag = TableFlag.ByTableIndex;
            TableIndex = tableindex;
            HasEntend = hasextend;
        }
        public DataMapperAttribute(string tablename, string colname, bool hasextend)
        {
            TableFlag = TableFlag.ByTableName;
            TableName = tablename;
            HasEntend = hasextend;
            ColumnName = colname;
        }
        public DataMapperAttribute(int tableindex, string colname, bool hasextend)
        {
            TableFlag = TableFlag.ByTableIndex;
            TableIndex = tableindex;
            HasEntend = hasextend;
            ColumnName = colname;
        }
    }
}
