/**************************************************************************
*   
*   =================================
*   CLR版本    ：4.0.30319.42000
*   命名空间    ：SqlBuildExtensions
*   文件名称    ：DefaultMapper.cs
*   =================================
*   创 建 者    ：李先锋
*   创建日期    ：2020/4/19 16:49:10 
*   功能描述    ：
*   使用说明    ：
*   =================================
*   修改者    ：
*   修改日期    ：
*   修改内容    ：
*   =================================
*  
***************************************************************************/

using SqlBuildExtensions.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SqlBuildExtensions.Core;
using System.Reflection;
using SqlBuildExtensions.Util;

namespace SqlBuildExtensions
{
    public class DefaultMapper : IStandardMapper
    {
        public T ToEntity<T>(DataSet ds) where T : class, new()
        {
            T obj = new T();
            if (ds == null)
            {
                return obj;
            }
            IDataTableMapper mapper = new DefaultTableMapper();
            PropertyInfo[] properties = mapper.GetAllProperty(obj.GetType());
            foreach (var property in properties)
            {
                MapperInfo mi = mapper.GetMapperInfo(ds, property);
                if (RefletUtil.IsBaseType(property.PropertyType))
                {
                    object pvalue =
                        mi.HasExtend.Key ? mi.HasExtend.Value.Invoke(obj, new object[] { property.Name,mi.SourceTb.Rows[0][mi.ColumnName] }) :
                        mi.SourceTb.Rows[0][mi.ColumnName];
                    property.SetValue(obj, Convert.ChangeType(pvalue,property.PropertyType), null);
                }
                if (RefletUtil.IsClass(property.PropertyType))
                {
                    object subClassInstance = property.PropertyType.Assembly.CreateInstance(property.PropertyType.FullName);
                    PropertyInfo[] SubClassProperties = mapper.GetAllProperty(property.PropertyType);
                    foreach (var SubClassProperty in SubClassProperties)
                    {
                        MapperInfo subClassPropertyMi = mapper.GetMapperInfo(ds, SubClassProperty);
                        if (RefletUtil.IsBaseType(SubClassProperty.PropertyType))
                        {
                            object subclasspvalue =
                                subClassPropertyMi.HasExtend.Key ? subClassPropertyMi.HasExtend.Value.Invoke(subClassInstance, new object[] { SubClassProperty.Name,subClassPropertyMi.SourceTb.Rows[0][subClassPropertyMi.ColumnName] }) :
                                subClassPropertyMi.SourceTb.Rows[0][subClassPropertyMi.ColumnName];
                            SubClassProperty.SetValue(subClassInstance, Convert.ChangeType(subclasspvalue, SubClassProperty.PropertyType), null);
                        }
                    }
                    property.SetValue(obj, Convert.ChangeType(subClassInstance, property.PropertyType), null);

                }
                if (RefletUtil.IsListGeneric(property.PropertyType))
                {
                    var instance = RefletUtil.CreateGenericInstance(property.PropertyType,out Type instancetype);
                    var instancelList = RefletUtil.CreateGeneric(instancetype);
                    RefletUtil.AddObjToGeneric(instancelList, instance);
                    property.SetValue(obj, instancelList, null);

                }



            }


            return obj;
        }

        List<T> IStandardMapper.ToListEntity<T>(DataSet ds)
        {
            throw new NotImplementedException();
        }
    }
}
