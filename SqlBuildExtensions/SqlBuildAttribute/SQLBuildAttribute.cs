/**************************************************************************
*   
*   =================================
*   CLR版本    ：4.0.30319.42000
*   命名空间    ：SqlBuildExtensions.Attribute
*   文件名称    ：SQLBuildAttribute.cs
*   =================================
*   创 建 者    ：李先锋
*   创建日期    ：2020/3/25 16:56:41 
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

namespace SqlBuildExtensions.SqlBuildAttribute
{
    /// <summary>
    /// 对应数据库列类型
    /// </summary>
    public enum ColumnType
    {
        DateTime,
        Varchar,
        /// <summary>
        /// 目前只支持Long类型，请注意！
        /// </summary>
        Number,
        String
    }
    /// <summary>
    /// 日期格式化（暂未启用）
    /// </summary>
    public enum DateRuleFormat
    {
        YYYYMMDD,
        YYYYMMDDHHmmss,
        HHmmss
    }
    /// <summary>
    /// DB类型(默认Oracle)
    /// </summary>
    public enum DbType
    {
        SqlServer,
        Oracle
    }

    public class SQLBuildAttribute : Attribute
    {
        /// <summary>
        /// 除表名外全部默认值
        /// </summary>
        /// <param name="tableas">表名</param>
        public SQLBuildAttribute(string tableas)
        {
            TableAs = tableas;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableas">表名</param>
        /// <param name="columnas">列名</param>
        public SQLBuildAttribute(string tableas, string columnas)
        {
            TableAs = tableas;
            ColumnAs = columnas;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableas">表名</param>
        /// <param name="columnas">列名</param>
        /// <param name="columntype">列类型</param>
        public SQLBuildAttribute(string tableas, string columnas,ColumnType columntype = ColumnType.String)
        {
            ColumnTypeAs = columntype;
            TableAs = tableas;
            ColumnAs = columnas;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableas">表名</param>
        /// <param name="columnas">列名</param>
        /// <param name="daterule">格式化类型</param>
        /// <param name="dbtype">数据库类型</param>
        public SQLBuildAttribute(string tableas, string columnas, DateRuleFormat daterule, DbType dbtype = DbType.Oracle)
        {
            DateRuleFormatAs = daterule;
            ColumnTypeAs = ColumnType.DateTime;
            DbTypeAs = dbtype;
            TableAs = tableas;
            ColumnAs = columnas;
        }
        //public SQLBuildAttribute(string tableas, string columnas, string daterule, DbType dbtype = DbType.Oracle)
        //{
        //    DateRuleString = daterule;
        //    ColumnTypeAs = ColumnType.DateTime;
        //    DbTypeAs = dbtype;
        //    TableAs = tableas;
        //    ColumnAs = columnas;
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableas">表名</param>
        /// <param name="columnas">列名</param>
        /// <param name="NumBd">标度</param>
        /// <param name="NumJd">精度</param>
        /// <param name="dbtype">数据库类型</param>
        public SQLBuildAttribute(string tableas, string columnas, int NumBd,int NumJd, DbType dbtype = DbType.Oracle)
        {
            NumberSpot = NumJd;
            NumberBD = NumBd;
            ColumnTypeAs = ColumnType.Number;
            DbTypeAs = dbtype;
            TableAs = tableas;
            ColumnAs = columnas;
        }
        public string DateRuleString { get;  private set; }
        public ColumnType ColumnTypeAs { get;  private set; } = ColumnType.String;
        public DateRuleFormat DateRuleFormatAs { get;  private set; } = DateRuleFormat.YYYYMMDDHHmmss;
        public DbType DbTypeAs { get;  private set; } = DbType.Oracle;

        
        public string ColumnAs { get; private set; }

        public string TableAs { get;  private set; }

        
        public string DateFormatRule { get { return GetDateFormatRule(DateRuleFormatAs); }}

        /// <summary>
        /// 精度（小数点）
        /// </summary>
        public int NumberSpot { get;  private set; } = 2;
        /// <summary>
        /// 标度
        /// </summary>
        public int NumberBD { get;  private set; } = 18;

        public string GetDateFormatRule(DateRuleFormat fas)
        {
            switch (fas)
            {
                case DateRuleFormat.YYYYMMDD:
                    return "yyyy-MM-dd";
                case DateRuleFormat.YYYYMMDDHHmmss:
                    return "yyyy-MM-dd hh:mm:ss";
                case DateRuleFormat.HHmmss:
                    return "hh:mm:ss";
                default:
                    return "yyyy-MM-dd hh:mm:ss";
            }
        }
    }
}
