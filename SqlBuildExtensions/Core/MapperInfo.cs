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
        public dynamic Value { get; set; }
        internal static void PopulateFromProperty(DataSet ds,int rowInddex,object objValue,PropertyInfo pi, ref MapperInfo mi, out DataMapperAttribute dmAttr)
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
                DataRow row = dmAttr.TableFlag == TableFlag.ByTableName ? ds.Tables[dmAttr.TableName].Rows[rowInddex] : ds.Tables[dmAttr.TableIndex].Rows[rowInddex];
                if ((string.IsNullOrEmpty(dmAttr.ColumnName) ? row[pi.Name] : row[dmAttr.ColumnName]) != DBNull.Value)
                {
                    mi.Value = null;
                }
                 else if (dmAttr.HasEntend)
                {
                    MethodInfo method = pi.DeclaringType.GetMethod(dmAttr.ConvertFuncName);
                    object extensions = method.Invoke(objValue, new object[] { string.IsNullOrEmpty(dmAttr.ColumnName)?row[pi.Name]:row[dmAttr.ColumnName]});
                    mi.Value = Convert.ChangeType(extensions,pi.PropertyType);
                }
                else
                {
                    mi.Value = Convert.ChangeType(string.IsNullOrEmpty(dmAttr.ColumnName) ? row[pi.Name] : row[dmAttr.ColumnName],pi.PropertyType);
                }
            }

        }
        public static MapperInfo FromProperty(DataSet ds,int rowindex,object objValue,PropertyInfo pi)
        {
            var mi = new MapperInfo();
            PopulateFromProperty(ds, rowindex, objValue, pi, ref mi, out _);
            return mi;
        }
    }
}
