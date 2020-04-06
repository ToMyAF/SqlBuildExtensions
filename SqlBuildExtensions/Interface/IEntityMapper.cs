/**************************************************************************
*   
*   =================================
*   CLR版本    ：4.0.30319.42000
*   命名空间    ：SqlBuildExtensions.Interface
*   文件名称    ：IEntityMapper.cs
*   =================================
*   创 建 者    ：李先锋
*   创建日期    ：2020/3/30 15:34:43 
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
using SqlBuildExtensions.Core;
using System.Reflection;

namespace SqlBuildExtensions.Interface
{
    public interface IEntityMapper
    {
        TableInfo GetTableInfo(Type type);
        ColumnInfo GetColumnInfo(object obj,PropertyInfo colType);

        PropertyInfo[] GetAllProperty(Type type);
    }
}
