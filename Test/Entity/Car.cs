/**************************************************************************
*   
*   =================================
*   CLR版本    ：4.0.30319.42000
*   命名空间    ：Test.Entity
*   文件名称    ：Car.cs
*   =================================
*   创 建 者    ：李先锋
*   创建日期    ：2020/4/20 10:48:35 
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
using SqlBuildExtensions.SqlBuildAttribute;
using SqlBuildExtensions.Interface;

namespace Test.Entity
{
    [DataMapper(0)]
    public class Car:IConvertFunction
    {
        [DataMapper(0,"SPPM")]
        public string PM { get; set; }

        [DataMapper(0,"SPXH")]
        public string XH { get; set; }

        [DataMapper(0)]
        public string CJ { get; set; }

        [DataMapper(0, "IsSale",true)]
        public int IsSale { get; set; }

        [DataMapper(0)]
        public Money Money { get; set; }

        public List<Info> Infos { get; set; }

        public object ConvertHandle(string propertyName,object value)
        {
            if (value.ToString() == "Y")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
    public class Money
    {
        [DataMapper(0,"ZHEKOU")]
        public double ZK { get; set; }

        [DataMapper(0)]
        public double Price { get; set; }
    }
    public class Info
    {
        [DataMapper(1, "PNAME")]
        public double PName { get; set; }

        [DataMapper(1,"PVALUE")]
        public double PValue { get; set; }
    }
}
