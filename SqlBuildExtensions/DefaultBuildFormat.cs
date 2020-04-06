/**************************************************************************
*   
*   =================================
*   CLR版本    ：4.0.30319.42000
*   命名空间    ：SqlBuildExtensions
*   文件名称    ：DefaultBuildFormat.cs
*   =================================
*   创 建 者    ：李先锋
*   创建日期    ：2020/3/26 10:10:30 
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
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;
using SqlBuildExtensions.SqlBuildAttribute;

namespace SqlBuildExtensions
{
    public class DefaultBuildFormat : ISqlBuidFarmat
    {
        public string ToSql(List<SqlBuildParameter> sqlBuilds)
        {
            StringBuilder sql = new StringBuilder();
            foreach (var builditem in sqlBuilds)
            {
                sql.Append($"INSERT INTO {builditem.TableNameAs}");
                sql.Append($" ({string.Join(",",builditem.ColumnBuilds.Select(s => s.ColumnName).ToArray())})");
                sql.Append($" VALUES (");
                foreach (var colBuilditem in builditem.ColumnBuilds)
                {
                    sql.Append(ValueFormat(colBuilditem.Value,colBuilditem.DbType,colBuilditem.ColType)+",");
                }
                sql.Remove(sql.Length - 1, 1);
                sql.Append(");");
            }
            return sql.ToString();
        }
        public string ValueFormat(dynamic value,string dbType,Type type)
        {
            
            //object convertedValue = Convert.ChangeType(value, type);
            switch (type.ToString())
            {
                case "System.Int32":
                    return $"{value ?? 0}";
                case "System.Int64":
                    return $"{value ?? 0}";
                case "System.String":
                    return $"'{value}'";
                case "System.Bool":
                    return $"{value??"null"}";
                case "System.Double":
                    return $"{value??0}";
                case "System.Decimal":
                    return $"{value ?? 0}";
                case "System.DateTime":
                    if (value == null)
                    {
                        return "null";
                    }
                    else
                    {
                        if (dbType.ToUpper() == "ORACLE")
                        {
                            if (value is DateTime)
                            {
                                return $"to_date('{value.ToString("yyyy-MM-dd hh:mm:ss")}','yyyy-mm-dd hh24:mi:ss')";
                            }
                            return $"to_date('{Convert.ToDateTime((string)value).ToString("yyyy-MM-dd hh:mm:ss")}','yyyy-mm-dd hh24:mi:ss')";
                        }
                        else
                        {
                            if (value is DateTime)
                            {
                                return $"CONVERT(DATETIME,{ value.ToString("yyyy-MM-dd hh:mm:ss")},112)";
                            }
                            return $"CONVERT(DATETIME,{ Convert.ToDateTime((string)value).ToString("yyyy-MM-dd hh:mm:ss")},112)";
                        }
                    }
                default:
                    return $"'{value}'";
            }
        }
        public ArrayList ToSqlArray(List<SqlBuildParameter> sqlBuilds)
        {
            ArrayList arrayList = new ArrayList();
            foreach (var builditem in sqlBuilds)
            {
                StringBuilder sql = new StringBuilder();
                sql.Append($"INSERT INTO {builditem.TableNameAs}");
                sql.Append($" ({string.Join(",", builditem.ColumnBuilds.Select(s => s.ColumnName).ToArray())})");
                sql.Append($" VALUES (");
                foreach (var colBuilditem in builditem.ColumnBuilds)
                {
                    sql.Append(ValueFormat(colBuilditem.Value, colBuilditem.DbType,colBuilditem.ColType) + ",");
                }
                sql.Remove(sql.Length - 1, 1);
                sql.Append(");");
                arrayList.Add(sql);
            }
            return arrayList;
        }
    }
}
