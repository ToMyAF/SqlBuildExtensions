/**************************************************************************
*   
*   =================================
*   CLR版本    ：4.0.30319.42000
*   命名空间    ：SqlBuildExtensions.SqlBuildAttribute
*   文件名称    ：ColumnAttribute.cs
*   =================================
*   创 建 者    ：李先锋
*   创建日期    ：2020/3/30 15:46:44 
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
using System.Linq;
using System.Text;
using System.Reflection;

namespace SqlBuildExtensions.SqlBuildAttribute
{
    public enum TargetDbType
    {
        Oracle,
        Sqlserver
    }
    public enum FollowClass
    {
        Yes,
        No
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public bool HasExtendies { get; set; } = false;
        public TargetDbType DbTypeAs { get; set; } = TargetDbType.Oracle;
        public Type ColumnTypeAs { get; set; }
        public FollowClass FollowClass { get; set; }
        public string NameAs { get; set; }
        public string TableNameAs { get; set; }

        public string FormatFuncName { get { return "ExtendHandle"; } }

        public ColumnAttribute()
        {
            FollowClass = FollowClass.Yes;
        }
        public ColumnAttribute(string colname, bool extend = false)
        {
            NameAs = colname;
            FollowClass = FollowClass.Yes;
            HasExtendies = extend;
        }
        public ColumnAttribute(string colname,Type coltype)
        {
            NameAs = colname;
            FollowClass = FollowClass.Yes;
            ColumnTypeAs = coltype;
        }
        public ColumnAttribute(string colname, Type coltype, bool extend)
        {
            NameAs = colname;
            FollowClass = FollowClass.Yes;
            ColumnTypeAs = coltype;
            HasExtendies = extend;
        }
        public ColumnAttribute(string colname, bool extend, Type coltype,TargetDbType dbType)
        {
            NameAs = colname;
            FollowClass = FollowClass.Yes;
            HasExtendies = extend;
            ColumnTypeAs = coltype;
            DbTypeAs = dbType;
        }
        public ColumnAttribute(string colname, string tablename)
        {
            NameAs = colname;
            TableNameAs = tablename;
            FollowClass = FollowClass.No;
        }
        public ColumnAttribute(string colname, string tablename,Type coltype)
        {
            NameAs = colname;
            TableNameAs = tablename;
            FollowClass = FollowClass.No;
            ColumnTypeAs = coltype;
        }
        public ColumnAttribute(string colname, string tablename, bool extend)
        {
            HasExtendies = extend;
            NameAs = colname;
            TableNameAs = tablename;
            FollowClass = FollowClass.No;
        }
        public ColumnAttribute(string colname, string tablename, bool extend,Type coltype)
        {
            HasExtendies = extend;
            NameAs = colname;
            TableNameAs = tablename;
            FollowClass = FollowClass.No;
            ColumnTypeAs = coltype;
        }
        /*
         * 当数据类型为DateTime类型时，不同DB的日期格式化函数不一
         */
        public ColumnAttribute(string colname, string tablename, bool extend, Type coltype,TargetDbType dbType)
        {
            NameAs = colname;
            TableNameAs = tablename;
            FollowClass = FollowClass.No;  
            ColumnTypeAs = coltype;
            DbTypeAs = dbType;
            HasExtendies = extend;
        }
    }
}
