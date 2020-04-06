/**************************************************************************
*   
*   =================================
*   CLR版本    ：4.0.30319.42000
*   命名空间    ：SqlBuildExtensions
*   文件名称    ：SqlBuildFactory.cs
*   =================================
*   创 建 者    ：李先锋
*   创建日期    ：2020/3/26 10:04:14 
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
using System.Text;

namespace SqlBuildExtensions
{
    public class SqlBuildFactory 
    {
        private static ISqlBuid sqlBuid;
        public static ISqlBuid GetInterface()
        {
            if (sqlBuid == null)
            {
                sqlBuid = new DefaultSqlBuid();
            }
            return sqlBuid;
        }
    }
}
