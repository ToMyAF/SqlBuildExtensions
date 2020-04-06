using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlBuildExtensions;
using Test.Entity;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            CompanyInfo info = new CompanyInfo
            {
                Addr = "山东省青岛市",
                IsSupper = "1",
                Name = "李大富",
                Phone = "15020986697",
                EmployeeInfos = new List<EmployeeInfo> {
                    new EmployeeInfo {
                        EmployeeName = "员工A",
                        EmployeePhone = "17863968705"
                    },
                    new EmployeeInfo {
                        EmployeeName = "员工B",
                        EmployeePhone = "17645825698"
                    },
                },
                boss = new BossInfo {
                    BossName = "大Boos",
                    BossPhone = "6666",
                    CreateDate = "2020-04-01 18:00:00"
                }
            };
            string sql = info.BuildSql();
            int aa = 0;

        }
    }
}
