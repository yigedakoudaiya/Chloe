﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Chloe.SqlServer
{
    static class UtilExceptions
    {
        public static Exception NotSupportedMethod(MethodInfo method)
        {
            StringBuilder sb = new StringBuilder();
            ParameterInfo[] parameters = method.GetParameters();

            for (int i = 0; i < parameters.Length; i++)
            {
                ParameterInfo p = parameters[i];

                if (i > 0)
                    sb.Append(",");

                string s = null;
                if (p.IsOut)
                    s = "out ";

                sb.AppendFormat("{0}{1} {2}", s, p.ParameterType.Name, p.Name);
            }

            return new NotSupportedException(string.Format("不支持方法 {0}.{1}({2})", method.DeclaringType.Name, method.Name, sb.ToString()));
        }
    }
}
