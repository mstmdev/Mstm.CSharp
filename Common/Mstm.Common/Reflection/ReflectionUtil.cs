using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Common.Reflection
{
    /// <summary>
    /// 反射相关工具类
    /// </summary>
    public class ReflectionUtil
    {
        #region 成员与句柄之间的转换

        /// <summary>
        /// 获取指定对象的类型句柄
        /// </summary>
        /// <param name="obj">要查询的对象实例</param>
        /// <returns>对象所属的类型的句柄</returns>
        public static RuntimeTypeHandle GetTypeHandle(Object obj)
        {
            return Type.GetTypeHandle(obj);
        }

        /// <summary>
        /// 获取句柄引用的类型
        /// </summary>
        /// <param name="handle">要查询的句柄实例</param>
        /// <returns>句柄对应的类型信息</returns>
        public static Type GetTypeFromHandle(RuntimeTypeHandle handle)
        {
            return Type.GetTypeFromHandle(handle);
        }

        /// <summary>
        /// 获取指定字段的句柄
        /// </summary>
        /// <param name="fieldInfo">要查询的字段信息</param>
        /// <returns>字段对应的句柄实例</returns>
        public static RuntimeFieldHandle GetFieldHandle(FieldInfo fieldInfo)
        {
            return fieldInfo.FieldHandle;
        }

        /// <summary>
        /// 获取指定句柄对应的字段信息
        /// </summary>
        /// <param name="handle">要查询的句柄实例</param>
        /// <returns>句柄对应得字段信息</returns>
        public static FieldInfo GetFieldFromHandle(RuntimeFieldHandle handle)
        {
            return FieldInfo.GetFieldFromHandle(handle);
        }

        /// <summary>
        /// 获取指定方法对应的句柄
        /// </summary>
        /// <param name="methodInfo">要查询的方法信息</param>
        /// <returns>方法对应的句柄实例</returns>
        public static RuntimeMethodHandle GetMethodHandle(MethodInfo methodInfo)
        {
            return methodInfo.MethodHandle;
        }

        /// <summary>
        /// 获取句柄对应的方法信息
        /// </summary>
        /// <param name="handle">要查询的句柄实例</param>
        /// <returns>句柄对应的方法信息</returns>
        public static MethodBase GetMethodFromHandle(RuntimeMethodHandle handle)
        {
            return MethodInfo.GetMethodFromHandle(handle);
        }

        #endregion

        #region FieldInfo

        /// <summary>
        /// 获取指定类型的所有字段信息
        /// </summary>
        /// <param name="type">要查询的类型</param>
        /// <returns>类型的所有字段信息</returns>
        public static FieldInfo[] GetFields(Type type)
        {
            return type.GetFields();
        }

        /// <summary>
        /// 获取指定类型的字段信息
        /// </summary>
        /// <param name="type">要查询的类型</param>
        /// <param name="bindingAttr">筛选标记</param>
        /// <returns>指定的类型筛选后的字段信息</returns>
        public static FieldInfo[] GetFields(Type type, BindingFlags bindingAttr)
        {
            return type.GetFields(bindingAttr);
        }

        /// <summary>
        /// 获取指定实例的所有字段信息
        /// </summary>
        /// <param name="obj">对象实例</param>
        /// <returns>对象实例的所有字段信息</returns>
        public static FieldInfo[] GetFields(Object obj)
        {
            Type type = obj.GetType();
            return GetFields(type);
        }

        /// <summary>
        /// 获取指定实例的所有字段信息
        /// </summary>
        /// <param name="obj">要查询的对象实例</param>
        /// <param name="bindingAttr">筛选标记</param>
        /// <returns>指定的对象实例筛选后的字段信息</returns>
        public static FieldInfo[] GetFields(Object obj, BindingFlags bindingAttr)
        {
            Type type = obj.GetType();
            return GetFields(type, bindingAttr);
        }
        #endregion

        #region MethodInfo

        /// <summary>
        /// 获取指定类型上的所有方法信息
        /// </summary>
        /// <param name="type">要查询的类型</param>
        /// <returns>指定类型上的所有方法信息</returns>
        public static MethodInfo[] GetMethods(Type type)
        {
            return type.GetMethods();
        }

        /// <summary>
        /// 获取指定类型上的方法信息
        /// </summary>
        /// <param name="type">要查询的类型</param>
        /// <param name="bindingAttr">筛选标记</param>
        /// <returns>指定类型筛选后的方法信息</returns>
        public static MethodInfo[] GetMethods(Type type, BindingFlags bindingAttr)
        {
            return type.GetMethods(bindingAttr);
        }

        /// <summary>
        /// 获取指定对象实例上的所有方法信息
        /// </summary>
        /// <param name="obj">要查询的对象实例</param>
        /// <returns>指定对象实例上的所有方法信息</returns>
        public static MethodInfo[] GetMethods(Object obj)
        {
            Type type = obj.GetType();
            return GetMethods(type);
        }

        /// <summary>
        /// 获取指定对象实例上的方法信息
        /// </summary>
        /// <param name="obj">要查询的对象实例</param>
        /// <param name="bindingAttr">筛选标记</param>
        /// <returns>指定对象实例筛选后的方法信息</returns>
        public static MethodInfo[] GetMethods(Object obj, BindingFlags bindingAttr)
        {
            Type type = obj.GetType();
            return GetMethods(type, bindingAttr);
        }

        #endregion

        #region PropertyInfo

        /// <summary>
        /// 获取指定类型上的所有属性信息
        /// </summary>
        /// <param name="type">要查询的类型</param>
        /// <returns>指定类型上的所有属性信息</returns>
        public static PropertyInfo[] GetProperties(Type type)
        {
            return type.GetProperties();
        }

        /// <summary>
        /// 获取指定类型上的属性信息
        /// </summary>
        /// <param name="type">要查询的类型</param>
        /// <param name="bindingAttr">筛选标记</param>
        /// <returns>指定类型筛选后的属性信息</returns>
        public static PropertyInfo[] GetProperties(Type type, BindingFlags bindingAttr)
        {
            return type.GetProperties(bindingAttr);
        }

        /// <summary>
        /// 获取指定对象实例上的所有属性信息
        /// </summary>
        /// <param name="obj">要查询的对象实例</param>
        /// <returns>指定对象实例上的所有属性信息</returns>
        public static PropertyInfo[] GetProperties(Object obj)
        {
            Type type = obj.GetType();
            return GetProperties(type);
        }

        /// <summary>
        /// 获取指定对象实例上的属性信息
        /// </summary>
        /// <param name="obj">要查询的对象实例</param>
        /// <param name="bindingAttr">筛选标记</param>
        /// <returns>指定对象实例筛选后的属性信息</returns>
        public static PropertyInfo[] GetProperties(Object obj, BindingFlags bindingAttr)
        {
            Type type = obj.GetType();
            return GetProperties(type, bindingAttr);
        }

        #endregion

        #region ConstructorInfo

        /// <summary>
        /// 获取指定类型的所有构造函数信息
        /// </summary>
        /// <param name="type">要查询的类型</param>
        /// <returns>指定类型的所有构造函数信息</returns>
        public static ConstructorInfo[] GetConstructors(Type type)
        {
            return type.GetConstructors();
        }

        /// <summary>
        /// 获取指定类型的构造函数信息
        /// </summary>
        /// <param name="type">要查询的类型</param>
        /// <param name="bindingAttr">筛选标记</param>
        /// <returns>指定类型筛选后的构造函数信息</returns>
        public static ConstructorInfo[] GetConstructors(Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructors(bindingAttr);
        }

        /// <summary>
        /// 获取指定对象实例的所有构造函数信息
        /// </summary>
        /// <param name="obj">要查询的对象实例</param>
        /// <returns>指定对象实例的所有构造函数信息</returns>
        public static ConstructorInfo[] GetConstructors(Object obj)
        {
            Type type = obj.GetType();
            return GetConstructors(type);
        }

        /// <summary>
        /// 获取指定对象实例的构造函数信息
        /// </summary>
        /// <param name="obj">要查询的对象实例</param>
        /// <param name="bindingAttr">筛选标记</param>
        /// <returns>指定对象实例筛选后的构造函数信息</returns>
        public static ConstructorInfo[] GetConstructors(Object obj, BindingFlags bindingAttr)
        {
            Type type = obj.GetType();
            return GetConstructors(type, bindingAttr);
        }

        #endregion

        #region CustomAttributes

        /// <summary>
        /// 获取指定类型上的所有自定义特性信息
        /// </summary>
        /// <param name="type">要查询的类型</param>
        /// <returns>指定类型上的所有自定义特性信息</returns>
        public static List<Attribute> GetCustomAttributes(Type type)
        {
            return type.GetCustomAttributes().ToList();
        }

        /// <summary>
        /// 获取指定对象实例上的所有自定义特性信息
        /// </summary>
        /// <param name="obj">要查询的对象实例</param>
        /// <returns>指定对象实例上的所有自定义特性信息</returns>
        public static List<Attribute> GetCustomAttributes(Object obj)
        {
            Type type = obj.GetType();
            return GetCustomAttributes(type);
        }

        #endregion

        #region Interfaces

        /// <summary>
        /// 获取指定类型上的所有接口信息
        /// </summary>
        /// <param name="type">要查询的类型</param>
        /// <returns>指定类型上的所有接口信息</returns>
        public static Type[] GetInterfaces(Type type)
        {
            return type.GetInterfaces();
        }

        /// <summary>
        /// 获取指定对象实例上的所有接口信息
        /// </summary>
        /// <param name="obj">要查询的对象实例</param>
        /// <returns>指定对象实例上的所有接口信息</returns>
        public static Type[] GetInterfaces(Object obj)
        {
            Type type = obj.GetType();
            return GetInterfaces(type);
        }

        #endregion
    }
}
