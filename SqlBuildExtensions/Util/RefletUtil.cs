/**************************************************************************
*   
*   =================================
*   CLR版本    ：4.0.30319.42000
*   命名空间    ：AhFORM
*   文件名称    ：RefletUtil.cs
*   =================================
*   创 建 者    ：李先锋
*   创建日期    ：2020/3/22 11:52:42 
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

namespace SqlBuildExtensions.Util
{
    public static class RefletUtil
    {
        /// <summary>
        /// 创建实例（外）
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="dllFile">DLL绝对路径</param>
        /// <param name="className">类限定名</param>
        /// <param name="param">类构造参数</param>
        /// <returns></returns>
        public static object AssemblyType(string dllFile, string className, IList<object> param = null)
        {
            Assembly ass = Assembly.LoadFile(dllFile);
            Type tp = ass.GetType(className);//类名
            if (param != null)
            {
                return Activator.CreateInstance(tp, param.ToArray());//实例化
            }
            else
            {
                return  Activator.CreateInstance(tp);//实例化
            }
        }
        /// <summary>
        /// 创建实例（外）
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="dllFile">DLL绝对路径</param>
        /// <param name="className">类限定名</param>
        /// <param name="param">类构造参数</param>
        /// <returns></returns>
        public static T AssemblyType<T>(string dllFile, string className, IList<object> param = null)
        {
            Assembly ass = Assembly.LoadFile(dllFile);
            Type tp = ass.GetType(className);//类名
            if (param != null)
            {
                object obj = Activator.CreateInstance(tp, param.ToArray());//实例化
                return (T)obj;
            }
            else
            {
                object obj = Activator.CreateInstance(tp);//实例化
                return (T)obj;
            }
        }
        /// <summary>
        /// 创建实例（本+依赖）
        /// </summary>
        /// <param name="dllFile"></param>
        /// <param name="className"></param>
        /// <param name="eventName"></param>
        /// <param name="eventParams"></param>
        /// <returns></returns>
        public static T AssemblyType<T>(string className)
        {
            Type tp = Type.GetType(className);//类名
            object obj = Activator.CreateInstance(tp);//实例化
            return (T)obj;
        }
        public static List<T> GetPropertyAttribute<T>(PropertyInfo pi) where T: Attribute
        {
            List<T> ts = new List<T>();
            object[] attrs = pi.GetCustomAttributes(typeof(T), true);
            if (attrs == null)
            {
                return ts;
            }
            else
            {
                foreach (var attr in attrs)
                {
                    ts.Add((T)attr);
                }
            }
            return ts;
        }

        public static PropertyInfo[] GetPropertys<T>() where T : class
        {
            Type objType = typeof(T);
            return objType.GetProperties();
        }
        public static PropertyInfo[] GetPropertys(Type t)
        {
            return t.GetProperties();
        }
        public static object[] GetClassAttribute<T>(Type attrType) where T : class
        {
            Type objType = typeof(T);
            return objType.GetCustomAttributes(attrType, true);
        }
        public static bool IsBaseType(Type type)
        {
            switch (type.ToString())
            {
                case "System.Int32":
                    return true;
                case "System.Int64":
                    return true;
                case "System.String":
                    return true;
                case "System.Bool":
                    return true;
                case "System.Double":
                    return true;
                case "System.Decimal":
                    return true;
                default:
                    return false;
            }
        }
        public static bool IsListGeneric(Type type)
        {
            return type.FullName.Contains("System.Collections.Generic.List");
        }
        public static bool IsClass(Type type)
        {
            if (!type.FullName.Contains("System.Collections.Generic.List") && type.IsClass && !IsBaseType(type))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 构建List对象
        /// </summary>
        /// <param name="generic"></param>
        /// <param name="innerType"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static object CreateGeneric(Type generic, Type innerType, params object[] args)
        {
            Type specificType = generic.MakeGenericType(new System.Type[] { innerType });
            return Activator.CreateInstance(specificType, args);
        }
        public static void AddObjToGeneric<T>(T genericList,params object[] objs)
        {
            genericList.GetType().InvokeMember("Add", BindingFlags.Default | BindingFlags.InvokeMethod, null, genericList, objs);
        }
    }
}
