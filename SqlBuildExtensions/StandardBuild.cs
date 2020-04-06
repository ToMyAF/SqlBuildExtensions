/**************************************************************************
*   
*   =================================
*   CLR版本    ：4.0.30319.42000
*   命名空间    ：SqlBuildExtensions
*   文件名称    ：StandardBuild.cs
*   =================================
*   创 建 者    ：李先锋
*   创建日期    ：2020/3/31 8:56:15 
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
using SqlBuildExtensions.Entity;
using SqlBuildExtensions.Interface;
using System.Reflection;
using SqlBuildExtensions.Core;

namespace SqlBuildExtensions
{
    public class StandardBuild : ISqlBuid
    {
        public List<SqlBuildParameter> BuildParameter<T>(T obj) where T : class, new()
        {
            List<SqlBuildParameter> builds = new List<SqlBuildParameter>();
            if (obj == null) return builds;
            IEntityMapper mapper = new StandardMapper();
            IStandardConvert standardConvert = new StandObjectConvert();
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
                if (itemcolinfo.IsClass)
                {
                    object classobjValue = buildColumn.GetValue(obj);
                    PropertyInfo[] classproperties = mapper.GetAllProperty(itemcolinfo.ColumnType);
                    foreach (var classitem in classproperties)
                    {
                        ColumnInfo classitemcolinfo = mapper.GetColumnInfo(classobjValue, classitem);
                        buildColumn.SetProperty(classitem);
                        if (classitemcolinfo == null | classitemcolinfo.IsNull) continue;
                        if (classitemcolinfo.IsBaseType)
                        {
                            buildColumn.SetBuildParameter(ref builds, classobjValue, classitemcolinfo);
                        }
                        if (classitemcolinfo.IsClass)
                        {
                            builds.AddRange(standardConvert.SigleClassConvert(classitemcolinfo.Value));
                        }
                        if (classitemcolinfo.IsGenric)
                        {
                            builds.AddRange(standardConvert.GenericConvert(classitemcolinfo.Value));
                        }
                    }
                }
                if (itemcolinfo.IsGenric)
                {
                   builds.AddRange(standardConvert.GenericConvert(itemcolinfo.Value));
                }
            }
            return builds;
        }
    }
}
