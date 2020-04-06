/**************************************************************************
*   
*   =================================
*   CLR版本    ：4.0.30319.42000
*   命名空间    ：SqlBuildExtensions.Core
*   文件名称    ：BuildColumn.cs
*   =================================
*   创 建 者    ：李先锋
*   创建日期    ：2020/3/30 15:25:44 
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
using SqlBuildExtensions.Entity;
using System.Diagnostics;

namespace SqlBuildExtensions.Core
{
    public class BuildColumn
    {

        public PropertyInfo PropertyInfo;

        public virtual void SetProperty(PropertyInfo pi)
        {
            PropertyInfo = pi;
        }

        public virtual void SetValue(object target, object val)
        {
            PropertyInfo.SetValue(target, val, null);
        }

        public virtual object GetValue(object target)
        {
            return PropertyInfo.GetValue(target, null);
        }

        public virtual object ChangeType(object val)
        {
            var t = PropertyInfo.PropertyType;
            if (val.GetType().IsValueType && PropertyInfo.PropertyType.IsGenericType && PropertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                t = t.GetGenericArguments()[0];
            return Convert.ChangeType(val, t);
        }
        public virtual void SetBuildParameter(ref List<SqlBuildParameter> buildParmes,object ojbValue,ColumnInfo columnInfo)
        {
            SqlBuildParameter classbuildparameter = SqlBuildParameter.Create(columnInfo.TableNameAs);
            List<ColumnBuild> classBuilList = new List<ColumnBuild>() {
                ColumnBuild.Create(columnInfo.ColumnName, columnInfo.Value,columnInfo.ColumnType,columnInfo.DBType)
            };
            classbuildparameter.ColumnBuilds = classBuilList;
            ContainsAdd(ref buildParmes, classbuildparameter, columnInfo.IsGenric);
        }
        public  void ContainsAdd(ref List<SqlBuildParameter> obj, SqlBuildParameter build, bool isGenericList = false)
        {
            try
            {
                var r = obj.Where(w => w.TableNameAs == build.TableNameAs).ToList();
                if (r == null || r.Count() == 0)
                {
                    obj.Add(build);
                }
                else
                {
                    if (isGenericList)
                    {
                        obj.Add(build);
                    }
                    else
                    {
                        SqlBuildParameter upds = r.ToList()[0];
                        int sourceIndex = obj.IndexOf(upds);
                        //加至末尾
                        upds.ColumnBuilds.AddRange(build.ColumnBuilds);
                        obj[sourceIndex] = upds;
                    }

                }
            }
            catch (Exception err)
            {
                Trace.WriteLine(err.ToString());
            }
        }
    }
}
