/**************************************************************************
*   
*   =================================
*   CLR版本    ：4.0.30319.42000
*   命名空间    ：SqlBuildExtensions.Core
*   文件名称    ：ColumnInfo.cs
*   =================================
*   创 建 者    ：李先锋
*   创建日期    ：2020/3/30 15:28:51 
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
using System.Reflection;
using SqlBuildExtensions.SqlBuildAttribute;
using SqlBuildExtensions.Util;

namespace SqlBuildExtensions.Core
{
    public class ColumnInfo
    {
        public string DBType { get; set; } = "ORACLE";
        public bool IsNull { get; set; }
        public bool IsBaseType { get; set; } = true;
        public bool IsClass { get; set; } = false;

        public bool IsGenric { get; set; } = false;

        public string ColumnName { get; set; }

        public dynamic Value { get; set; }

        public Type ColumnType { get; set; }

        public string TableNameAs { get; set; }

        public bool IsTableAs { get; set; } = false;

        internal static void PopulateFromProperty(object objValue,PropertyInfo pi, ref ColumnInfo ci, out ColumnAttribute columnAttr)
        {
            //验证Table修饰符
            var isExplicit = pi.DeclaringType.GetCustomAttributes(typeof(TableAttribute), true).Any();
            var tableAttr = pi.DeclaringType.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault() as TableAttribute;
            columnAttr = pi.GetCustomAttributes(typeof(ColumnAttribute), true).FirstOrDefault() as ColumnAttribute;
            var isIgnore = pi.GetCustomAttributes(typeof(IgnoreAttribute), true).Any();
            if (isIgnore || (isExplicit && columnAttr == null))
            {
                ci = null;
            }
            else if (objValue == null)
            {
                ci = null;
            }
            else
            {
                ci = ci ?? new ColumnInfo();
                ci.ColumnName = columnAttr.NameAs;
                ci.ColumnType = columnAttr.ColumnTypeAs ?? pi.PropertyType;
                ci.IsClass = RefletUtil.IsClass(pi.PropertyType);
                ci.IsGenric = RefletUtil.IsListGeneric(pi.PropertyType);
                ci.IsBaseType = RefletUtil.IsBaseType(pi.PropertyType);
                ci.IsTableAs = string.IsNullOrEmpty(columnAttr.TableNameAs);
                ci.TableNameAs = string.IsNullOrEmpty(columnAttr.TableNameAs) ? tableAttr.TableName : columnAttr.TableNameAs;
                ci.DBType = columnAttr.DbTypeAs == TargetDbType.Oracle ? "ORACLE" : "SQLSERVER";
                object colValue = new BuildColumn() { PropertyInfo = pi }.GetValue(objValue);
                if (colValue != null)
                {
                    if (!columnAttr.HasExtendies)
                    {
                        ci.Value = Convert.ChangeType(colValue, ci.ColumnType);
                    }
                    else
                    {
                        MethodInfo method = pi.DeclaringType.GetMethod(columnAttr.FormatFuncName);
                        ExtensionsResult extensions = (ExtensionsResult)method.Invoke(objValue,new object[] { colValue });
                        ci.Value = extensions.Value;
                        ci.ColumnType = extensions.ValueType;
                    }
                    ci.IsNull = false;
                }
                else
                {
                    ci.IsNull = true;
                }

            }
        }
        public static ColumnInfo FromProperty(object objValue ,PropertyInfo propertyInfo)
        {
            var ci = new ColumnInfo();
            PopulateFromProperty(objValue, propertyInfo,ref ci, out _);
            return ci;
        }

    }
}
