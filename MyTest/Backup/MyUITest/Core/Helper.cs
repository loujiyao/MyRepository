using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyUITest
{
    public class Helper
    {
        public object GetValue(object target, string memberName)
        {
            return target.GetType()
                         .InvokeMember(memberName,
                                       BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetField | BindingFlags.GetProperty,
                                       null, target, null);
        }

        public object GetStaticValue(string typeName, string memberName)
        {
            var type = Type.GetType(typeName);
            if (type == null)
                throw new Exception("Can't find type name " + typeName);

            return type.InvokeMember(memberName,
                                     BindingFlags.Public | BindingFlags.Static | BindingFlags.GetField |
                                     BindingFlags.GetProperty, null, null, null);
        }

        /// <summary>
        /// Invokes public instance method
        /// </summary>
        public object InvokeMethod(object target, string methodName, params object[] args)
        {
            var methods = target.GetType()
                                .GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod)
                                .Where(
                                    item =>
                                    String.Compare(item.Name, methodName, StringComparison.OrdinalIgnoreCase) == 0 &&
                                    (item.GetParameters().Length == args.Length))
                                .ToArray();

            //Start: no Param Array support
            //(item.GetParameters().Length == args.Length + 1 &&
            //                          item.GetParameters()[args.Length].GetCustomAttributes(
            //                              typeof (ParamArrayAttribute), true).Length == 1)
            //End: no Param Array Support

            //if (methods.Length == 1)
            //{
            //    var paramCollection = methods[0].GetParameters();
            //    var parameters = GetParameters(args, paramCollection);

            //    return methods[0].Invoke(target, parameters);
            //}

            return target.GetType()
                         .InvokeMember(methodName,
                                       BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod, null,
                                       target, args);
        }

        public void SetField(object target, string fieldName, object value)
        {
            FieldInfo fi = target.GetType().GetField(fieldName);
            if (fi != null)
            {
                fi.SetValue(target, value);
            }
        }


        public void SetProperty(object target, string propertyName, object value)
        {

        }


        ///// <summary>
        ///// Invokes public static method
        ///// </summary>
        ///// <param name="typeName"></param>
        ///// <param name="methodName"></param>
        ///// <param name="args"></param>
        ///// <returns></returns>
        //public object InvokeStaticMethod(string typeName, string methodName, params object[] args)
        //{
        //    var type = Type.GetType(typeName);
        //    if (type == null)
        //        throw new TypeNotFoundException(typeName, "Loaded Assembly List");

        //    var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.InvokeMethod)
        //                      .Where(
        //                          item =>
        //                          String.Compare(item.Name, methodName, StringComparison.OrdinalIgnoreCase) == 0 &&
        //                          (item.GetParameters().Length == args.Length))
        //                      .ToArray();

        //    //Start: no Param Array support
        //    //(item.GetParameters().Length == args.Length + 1 &&
        //    //                          item.GetParameters()[args.Length].GetCustomAttributes(
        //    //                              typeof (ParamArrayAttribute), true).Length == 1)
        //    //End: no Param Array Support

        //    if (methods.Length == 1)
        //    {
        //        var paramCollection = methods[0].GetParameters();
        //        var parameters = GetParameters(args, paramCollection);

        //        return type.InvokeMember(methodName,
        //                                 BindingFlags.Public | BindingFlags.Static | BindingFlags.InvokeMethod,
        //                                 null, null, parameters);
        //    }

        //    return type.InvokeMember(methodName, BindingFlags.Public | BindingFlags.Static | BindingFlags.InvokeMethod,
        //                             null, null, args);
        //}

        //private object[] GetParameters(IEnumerable<object> items, IList<ParameterInfo> paramCollection)
        //{
        //    int[] index = { 0 };

        //    var result = new List<object>();

        //    foreach (var value in items.Select(item => (item is IConvertible
        //                                                    ? (paramCollection[index[0]].ParameterType.IsArray
        //                                                           ? item.ToString()
        //                                                                 .ToStringList(",")
        //                                                                 .Select(
        //                                                                     subItem =>
        //                                                                     Convert.ChangeType(
        //                                                                         (_executionEngine != null
        //                                                                              ? _executionEngine
        //                                                                                    .ProcessInputValue(subItem)
        //                                                                              : subItem),
        //                                                                         paramCollection[index[0]].ParameterType
        //                                                                                                  .GetElementType
        //                                                                             ())).ToArray()
        //                                                           : ((paramCollection[index[0]]
        //                                                                  .ParameterType.IsEnum)
        //                                                                  ? Enum.Parse(
        //                                                                      paramCollection[index[0]].ParameterType,
        //                                                                      (_executionEngine != null
        //                                                                           ? _executionEngine.ProcessInputValue(
        //                                                                               item.ToString())
        //                                                                           : item), true)
        //                                                                  : Convert.ChangeType(
        //                                                                      (_executionEngine != null
        //                                                                           ? _executionEngine.ProcessInputValue(
        //                                                                               item.ToString())
        //                                                                           : item),
        //                                                                      paramCollection[index[0]]
        //                                                                          .ParameterType)))
        //                                                    : item)))
        //    {
        //        if (paramCollection[index[0]].ParameterType.IsArray &&
        //            (paramCollection[index[0]].ParameterType.GetElementType() == Type.GetType("System.String") ||
        //             paramCollection[index[0]].ParameterType.GetElementType().IsValueType))
        //        {
        //            var generic = typeof(List<>);
        //            var typeArgs = new[] { paramCollection[index[0]].ParameterType.GetElementType() };
        //            var genericType = generic.MakeGenericType(typeArgs);

        //            dynamic subList = Activator.CreateInstance(genericType);

        //            foreach (var valueItem in value)
        //            {
        //                subList.Add(valueItem);
        //            }
        //            result.Add(subList.ToArray());
        //        }
        //        else
        //        {
        //            result.Add(value);
        //        }

        //        index[0]++;
        //    }
        //    return result.ToArray();
        //}
    }
}
