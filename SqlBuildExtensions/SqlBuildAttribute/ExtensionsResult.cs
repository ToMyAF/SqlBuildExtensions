/**************************************************************************
*   
*   =================================
*   CLR版本    ：4.0.30319.42000
*   命名空间    ：SqlBuildExtensions.SqlBuildAttribute
*   文件名称    ：ExtensionsResult.cs
*   =================================
*   创 建 者    ：李先锋
*   创建日期    ：2020/3/30 16:30:28 
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
    public class ExtensionsResult
    {
        public dynamic Value { get; set; }

        public Type ValueType { get; set; }
    }
}
