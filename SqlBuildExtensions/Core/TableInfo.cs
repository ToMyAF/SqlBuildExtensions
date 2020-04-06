/**************************************************************************
*   
*   =================================
*   CLR版本    ：4.0.30319.42000
*   命名空间    ：SqlBuildExtensions.Core
*   文件名称    ：TableInfo.cs
*   =================================
*   创 建 者    ：李先锋
*   创建日期    ：2020/3/30 15:35:24 
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
using SqlBuildExtensions.SqlBuildAttribute;

namespace SqlBuildExtensions.Core
{
    public class TableInfo
    {
        public string Value { get; set; }
        internal static void PopulateTableFromAttr(Type t, ref TableInfo ti, out TableAttribute tbAttr)
        {
            ti = ti ?? new TableInfo();
            tbAttr = t.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault() as TableAttribute;
            ti.Value = tbAttr?.TableName ?? t.Name;
        }
        public static TableInfo FromTable(Type t)
        {
            var ti = new TableInfo();
            PopulateTableFromAttr(t,ref ti, out _);
            return ti;
        }
    }
}
