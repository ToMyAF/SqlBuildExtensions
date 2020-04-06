/**************************************************************************
*   
*   =================================
*   CLR版本    ：4.0.30319.42000
*   命名空间    ：SqlBuildExtensions.Interface
*   文件名称    ：DefauleFactory.cs
*   =================================
*   创 建 者    ：李先锋
*   创建日期    ：2020/3/26 11:14:21 
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
    public class DefaultFactory : ISqlBuildFactory
    {
        public string BuildSql<T>(T obj) where T : class, new()
        {
            return CreateBuildFormat().ToSql(CreateSqlBuild().BuildParameter(obj));
        }

        public ArrayList BuildSqlArry<T>(T obj) where T : class, new()
        {
            return CreateBuildFormat().ToSqlArray(CreateSqlBuild().BuildParameter(obj));
        }

        public ISqlBuidFarmat CreateBuildFormat()
        {
            return new DefaultBuildFormat();
        }

        public ISqlBuid CreateSqlBuild()
        {
            return new DefaultSqlBuid();
        }
    }
}
