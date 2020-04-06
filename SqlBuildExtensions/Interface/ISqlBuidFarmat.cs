/**************************************************************************
*   
*   =================================
*   CLR版本    ：4.0.30319.42000
*   命名空间    ：SqlBuildExtensions.Interface
*   文件名称    ：ISqlBuidFarmat.cs
*   =================================
*   创 建 者    ：李先锋
*   创建日期    ：2020/3/25 19:02:48 
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
using System.Text;

namespace SqlBuildExtensions.Interface
{
    public interface ISqlBuidFarmat
    {
        string ToSql(List<SqlBuildParameter> sqlBuilds);
        ArrayList ToSqlArray(List<SqlBuildParameter> sqlBuilds);
    }
}
