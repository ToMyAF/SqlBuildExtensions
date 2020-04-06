/**************************************************************************
*   
*   =================================
*   CLR版本    ：4.0.30319.42000
*   命名空间    ：SqlBuildExtensions.Interface
*   文件名称    ：ISqlBuildFactory.cs
*   =================================
*   创 建 者    ：李先锋
*   创建日期    ：2020/3/26 11:13:40 
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
using System.Text;

namespace SqlBuildExtensions.Interface
{
    public interface ISqlBuildFactory
    {
        ISqlBuid CreateSqlBuild();
        ISqlBuidFarmat CreateBuildFormat();
        string BuildSql<T>(T obj) where T : class, new();
        ArrayList BuildSqlArry<T>(T obj) where T : class, new();
    }
}
