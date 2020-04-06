/**************************************************************************
*   
*   =================================
*   CLR版本    ：4.0.30319.42000
*   命名空间    ：SqlBuildExtensions.SqlBuildAttribute
*   文件名称    ：IgnoreAttribute.cs
*   =================================
*   创 建 者    ：李先锋
*   创建日期    ：2020/3/30 15:32:35 
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

namespace SqlBuildExtensions.SqlBuildAttribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class IgnoreAttribute:Attribute
    {

    }
}
