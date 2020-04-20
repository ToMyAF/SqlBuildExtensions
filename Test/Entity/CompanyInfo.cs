/**************************************************************************
*
*   =================================
*   CLR版本    ：4.0.30319.42000
*   命名空间    ：Test.Entity
*   文件名称    ：CompanyInfo.cs
*   =================================
*   创 建 者    ：李先锋
*   创建日期    ：2020/3/31 17:32:48
*   功能描述    ：
*   使用说明    ：
*   =================================
*   修改者    ：
*   修改日期    ：
*   修改内容    ：
*   =================================
*
***************************************************************************/

using SqlBuildExtensions.SqlBuildAttribute;
using System;
using System.Collections.Generic;

namespace Test.Entity
{
    [Table("GL_CUSTOMER")]
    public class CompanyInfo
    {

        [Column("CompanyName")]
        public string Name { get; set; }

        [Column("XXDZ")]
        public string Addr { get; set; }

        [Column("TEL")]
        public string Phone { get; set; }

        [Column("IsHY", typeof(string), true)]
        public string IsSupper { get; set; }

        [Column("EmployeeInfoSub")]
        public List<EmployeeInfo> EmployeeInfos { get; set; }

        public static ExtensionsResult ExtendHandle(object obj)
        {
            if (obj.ToString() == "1")
            {
                return new ExtensionsResult { Value = "Y", ValueType = typeof(string) };
            }
            else
            {
                return new ExtensionsResult { Value = "N", ValueType = typeof(string) };
            }
        }

        [Column]
        public BossInfo boss { get; set; }
    }

    [Table("EmployeeInfo")]
    public class EmployeeInfo
    {
        [Column("EName")]
        public string EmployeeName { get; set; }

        [Column("EPhone")]
        public string EmployeePhone { get; set; }
    }

    [Table("BossInfo")]
    public class BossInfo
    {
        [Column("BName")]
        public string BossName { get; set; }

        [Column("BPhone")]
        public string BossPhone { get; set; }

        [Column("BDate", typeof(DateTime))]
        public string CreateDate { get; set; }
    }
}