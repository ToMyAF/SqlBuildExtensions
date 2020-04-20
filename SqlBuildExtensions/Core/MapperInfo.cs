/**************************************************************************
*   
*   =================================
*   CLR版本    ：4.0.30319.42000
*   命名空间    ：SqlBuildExtensions.Core
*   文件名称    ：MapperInfo.cs
*   =================================
*   创 建 者    ：李先锋
*   创建日期    ：2020/4/19 15:34:13 
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
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using SqlBuildExtensions.SqlBuildAttribute;

namespace SqlBuildExtensions.Core
{
    public class MapperInfo
    {
        public string ColumnName { get; set; }
        public DataTable SourceTb { get; set; }
        public KeyValuePair<bool, MethodInfo> HasExtend { get; set; } = new KeyValuePair<bool, MethodInfo>(false, null);
        internal static void PopulateFromProperty(DataSet ds,PropertyInfo pi, ref MapperInfo mi, out DataMapperAttribute dmAttr)
        {
            //验证Table修饰符
            var isExplicit = pi.DeclaringType.GetCustomAttributes(typeof(DataMapperAttribute), true).Any();
            //var parrentAttr = pi.DeclaringType.GetCustomAttributes(typeof(DataMapperAttribute), true).FirstOrDefault() as DataMapperAttribute;
            dmAttr = pi.GetCustomAttributes(typeof(DataMapperAttribute), true).FirstOrDefault() as DataMapperAttribute;
            var isIgnore = pi.GetCustomAttributes(typeof(IgnoreAttribute), true).Any();
            if (ds == null)
            {
                mi = null;
            }
            else if (isIgnore || (isExplicit && dmAttr == null))
            {
                mi = null;
            }
            else
            {
                mi = mi ?? new MapperInfo();
                mi.SourceTb = dmAttr.TableFlag == TableFlag.ByTableName ? ds.Tables[dmAttr.TableName] : ds.Tables[dmAttr.TableIndex];
                mi.ColumnName = string.IsNullOrEmpty(dmAttr.ColumnName) ? pi.Name:dmAttr.ColumnName;
                if (dmAttr.HasEntend)
                {
                    mi.HasExtend = new KeyValuePair<bool, MethodInfo>(true,pi.DeclaringType.GetMethod(dmAttr.ConvertFuncName));
                }
            }

        }
        public static MapperInfo FromProperty(DataSet ds,PropertyInfo pi)
        {
            var mi = new MapperInfo();
            PopulateFromProperty(ds, pi, ref mi, out _);
            return mi;
        }
    }
}
