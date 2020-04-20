/**************************************************************************
*   
*   =================================
*   CLR版本    ：4.0.30319.42000
*   命名空间    ：SqlBuildExtensions
*   文件名称    ：DefaultTableMapper.cs
*   =================================
*   创 建 者    ：李先锋
*   创建日期    ：2020/4/19 17:14:44 
*   功能描述    ：
*   使用说明    ：
*   =================================
*   修改者    ：
*   修改日期    ：
*   修改内容    ：
*   =================================
*  
***************************************************************************/

using SqlBuildExtensions.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlBuildExtensions.Core;
using System.Data;
using System.Reflection;

namespace SqlBuildExtensions
{
    public class DefaultTableMapper : IDataTableMapper
    {
        public PropertyInfo[] GetAllProperty(Type type)
        {
             return type.GetProperties();
        }

        public MapperInfo GetMapperInfo(DataSet ds, PropertyInfo pi)
        {
            return MapperInfo.FromProperty(ds, pi);
        }
    }
}
