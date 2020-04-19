/**************************************************************************
*   
*   =================================
*   CLR版本    ：4.0.30319.42000
*   命名空间    ：SqlBuildExtensions.Interface
*   文件名称    ：IDataTableMapper.cs
*   =================================
*   创 建 者    ：李先锋
*   创建日期    ：2020/4/13 16:30:38 
*   功能描述    ：Datatable转实体类
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
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using SqlBuildExtensions.Core;

namespace SqlBuildExtensions.Interface
{
    public interface IDataTableMapper
    {
        PropertyInfo[] GetAllProperty(Type type);

        MapperInfo GetMapperInfo(DataSet ds, int rowindex, object objValue, PropertyInfo pi);
    }

}
