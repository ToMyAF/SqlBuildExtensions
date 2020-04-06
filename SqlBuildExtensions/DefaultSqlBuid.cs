/**************************************************************************
*   
*   =================================
*   CLR版本    ：4.0.30319.42000
*   命名空间    ：SqlBuildExtensions
*   文件名称    ：DefaultSqlBuid.cs
*   =================================
*   创 建 者    ：李先锋
*   创建日期    ：2020/3/25 17:47:28 
*   功能描述    ：
*   使用说明    ：
*   =================================
*   修改者    ：
*   修改日期    ：
*   修改内容    ：
*   =================================
*  
***************************************************************************/

using SqlBuildExtensions.Entity;
using SqlBuildExtensions.Interface;
using SqlBuildExtensions.SqlBuildAttribute;
using SqlBuildExtensions.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SqlBuildExtensions
{
    public class DefaultSqlBuid : ISqlBuid
    {
        public List<SqlBuildParameter> BuildParameter<T>(T obj) where T : class, new()
        {
            ISqlBuid sqlBuid = new StandardBuild();
            return sqlBuid.BuildParameter(obj);
        }

        public void BasePropertySetValue(ref List<SqlBuildParameter> buildParmes, object obj,SQLBuildAttribute buildAttribute, PropertyInfo property,bool isList = false)
        {
            Type bindType = MatchAttrProperty(buildAttribute.ColumnTypeAs, property);
            string AddColName = string.IsNullOrEmpty(buildAttribute.ColumnAs) ? property.Name : buildAttribute.ColumnAs;
            object AddValue = property.GetValue(obj, null);
            SqlBuildParameter classbuildparameter = SqlBuildParameter.Create(buildAttribute.TableAs);
            List<ColumnBuild> classBuilList = new List<ColumnBuild>() { ColumnBuild.Create(AddColName,AddValue,bindType, buildAttribute)};
            classbuildparameter.ColumnBuilds = classBuilList;
            SqlBuildSuppot.ContainsAdd(ref buildParmes,classbuildparameter, isList);
        }
        public Type MatchAttrProperty(ColumnType columntype,PropertyInfo property)
        {
            string bindtype = string.Empty;
            switch (columntype)
            {
                case ColumnType.DateTime:
                    bindtype = "System.DateTime";
                    break;
                case ColumnType.Varchar:
                    bindtype = "System.String";
                    break;
                case ColumnType.Number:
                    bindtype = "System.Int64";
                    break;
                case ColumnType.String:
                    bindtype = "System.String";
                    break;
                default:
                    bindtype = "System.String";
                    break;
            }
            if (property.PropertyType.FullName.Contains(bindtype))
            {
                return property.PropertyType;
            }
            else
            {
                return Type.GetType(bindtype);
            }


        }
    }
}
