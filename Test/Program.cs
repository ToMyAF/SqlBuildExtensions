using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using SqlBuildExtensions;
using Test.Entity;
using DatabaseFactoryL;
using System.Data;
using SqlBuildExtensions.Interface;

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

            List<MyListDemo> listDemos = new List<MyListDemo>();
            string className = "MyListDemo";
            string namespaceStr = "Test.Entity";
            var model = Assembly.GetExecutingAssembly().CreateInstance(string.Join(".", new object[] { namespaceStr, className }));
            PropertyInfo[] pros = model.GetType().GetProperties();
            foreach (var item in pros)
            {
                item.SetValue(model, "123456", null);
            }
            var modelList = Activator.CreateInstance(typeof(List<>).MakeGenericType(new Type[] { model.GetType() }));
            var addMethod = modelList.GetType().GetMethod("Add");
            addMethod.Invoke(modelList, new object[] { model });
            listDemos = (List<MyListDemo>)modelList;

            DatabaseFactoryF dbcontext = DatabaseSimpleFactoryL.GetInstance("Data Source=.;database=AhFApi;User ID=sa;Password=123456;", "SQLSERVER");
            DataSet ds = dbcontext.GetDataSet($"SELECT '五菱宏光PLUS' as SPPM,'WLHG-201904200014G' as SPXH,'上海柳州汽车制造厂' as CJ,'Y' as IsSale,'0.89' as ZHEKOU,'69800' as Price from OrgDemo;SELECT OrgName as PNAME,OrgType as PVALUE from OrgDemo ");
            IStandardMapper mapper = new DefaultMapper();
            Car car = mapper.ToEntity<Car>(ds);
            List<Car> cars = mapper.ToEntity<List<Car>>(ds);
            Console.ReadLine();
            
        }
    }

}
