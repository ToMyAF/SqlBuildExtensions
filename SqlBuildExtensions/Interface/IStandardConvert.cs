/**************************************************************************
*   
*   =================================
*   CLR版本    ：4.0.30319.42000
*   命名空间    ：SqlBuildExtensions.Interface
*   文件名称    ：IStandardConvert.cs
*   =================================
*   创 建 者    ：李先锋
*   创建日期    ：2020/3/31 15:18:02 
*   功能描述    ：
*   使用说明    ：
*   =================================
*   修改者    ：
*   修改日期    ：
*   修改内容    ：
*   =================================
*  
***************************************************************************/

using SqlBuildExtensions.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlBuildExtensions.Interface
{
    public interface IStandardConvert
    {
        List<SqlBuildParameter> SigleClassConvert<T>(T obj) where T : class;

        List<SqlBuildParameter> GenericConvert<T>(T obj) where T : class, IList;
    }
}
