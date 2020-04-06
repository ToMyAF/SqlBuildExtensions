/**************************************************************************
*   
*   =================================
*   CLR版本    ：4.0.30319.42000
*   命名空间    ：SqlBuildExtensions
*   文件名称    ：StandObjectConvert.cs
*   =================================
*   创 建 者    ：李先锋
*   创建日期    ：2020/3/31 15:27:18 
*   功能描述    ：
*   使用说明    ：
*   =================================
*   修改者    ：
*   修改日期    ：
*   修改内容    ：
*   =================================
*  
***************************************************************************/

using SqlBuildExtensions.Core;
using SqlBuildExtensions.Entity;
using SqlBuildExtensions.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SqlBuildExtensions
{
    public class StandObjectConvert : IStandardConvert
    {
        public List<SqlBuildParameter> GenericConvert<T>(T obj) where T : class,IList
        {
            List<SqlBuildParameter> builds = new List<SqlBuildParameter>();
            if (obj == null) return builds;
            IEntityMapper mapper = new StandardMapper();
            BuildColumn buildColumn = new BuildColumn();
            IList objArray = obj as IList;
            foreach (var item in objArray)
            {
                TableInfo tableInfo = mapper.GetTableInfo(item.GetType());
                SqlBuildParameter param = SqlBuildParameter.Create(tableInfo.Value);
                List<ColumnBuild> colPrams = new List<ColumnBuild>();
                //解析类的属性字段
                PropertyInfo[] properties = mapper.GetAllProperty(item.GetType());
                foreach (var property in properties)
                {
                    ColumnInfo colinfo = mapper.GetColumnInfo(item, property);
                    if (colinfo == null || colinfo.IsNull) continue;
                    if (colinfo.IsBaseType)
                    {
                        buildColumn.SetProperty(property);
                        colPrams.Add(new ColumnBuild {
                            ColumnName = colinfo.TableNameAs,
                            ColType = colinfo.ColumnType,
                            Value = colinfo.Value,
                            DbType = colinfo.DBType
                        });
                    }
                }
                param.ColumnBuilds = colPrams;
                builds.Add(param);
            }
            return builds;
        }

        public List<SqlBuildParameter> SigleClassConvert<T>(T obj) where T : class
        {
            List<SqlBuildParameter> builds = new List<SqlBuildParameter>();
            if (obj == null) return builds;
            IEntityMapper mapper = new StandardMapper();
            BuildColumn buildColumn = new BuildColumn();
            PropertyInfo[] properties = mapper.GetAllProperty(obj.GetType());
            foreach (var item in properties)
            {
                ColumnInfo itemcolinfo = mapper.GetColumnInfo(obj, item);
                buildColumn.SetProperty(item);
                if (itemcolinfo == null || itemcolinfo.IsNull) continue;
                if (itemcolinfo.IsBaseType)
                {
                    buildColumn.SetBuildParameter(ref builds, obj, itemcolinfo);
                }
            }
            return builds;
        }
    }
}
