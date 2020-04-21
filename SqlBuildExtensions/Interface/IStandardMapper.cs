/**************************************************************************
*   
*   =================================
*   CLR版本    ：4.0.30319.42000
*   命名空间    ：SqlBuildExtensions.Interface
*   文件名称    ：IStandardMapper.cs
*   =================================
*   创 建 者    ：李先锋
*   创建日期    ：2020/4/19 15:20:05 
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
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SqlBuildExtensions.Interface
{
    public interface IStandardMapper
    {
        T ToEntity<T>(DataSet ds) where T : class, new();
    }
}
