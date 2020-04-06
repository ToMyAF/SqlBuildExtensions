/**************************************************************************
*   
*   =================================
*   CLR版本    ：4.0.30319.42000
*   命名空间    ：SqlBuildExtensions
*   文件名称    ：StandardMapper.cs
*   =================================
*   创 建 者    ：李先锋
*   创建日期    ：2020/3/30 15:40:01 
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
using System.Reflection;
using System.Text;
using SqlBuildExtensions.Core;
using SqlBuildExtensions.Interface;

namespace SqlBuildExtensions
{
    public class StandardMapper : IEntityMapper
    {
        public PropertyInfo[] GetAllProperty(Type type)
        {
            return type.GetProperties();
        }

        public ColumnInfo GetColumnInfo(object obj, PropertyInfo property)
        {
            return ColumnInfo.FromProperty(obj, property);
        }

        public TableInfo GetTableInfo(Type type)
        {
            return TableInfo.FromTable(type);
        }
    }
}
