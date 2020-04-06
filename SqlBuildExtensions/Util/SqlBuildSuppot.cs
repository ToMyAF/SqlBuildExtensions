/**************************************************************************
*   
*   =================================
*   CLR版本    ：4.0.30319.42000
*   命名空间    ：SqlBuildExtensions.Util
*   文件名称    ：ListGenericExtend.cs
*   =================================
*   创 建 者    ：李先锋
*   创建日期    ：2020/3/25 18:22:19 
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
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;

namespace SqlBuildExtensions.Util
{
    public static class SqlBuildSuppot
    {
        public static void ContainsAdd(ref List<SqlBuildParameter> obj, SqlBuildParameter build,bool isGenericList = false)
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
