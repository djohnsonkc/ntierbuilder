using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace GenericSorter
{

    public class GenericComparer<T> : IComparer<T>
    {
        private string memberName = string.Empty;
        private string sortOrder = string.Empty;
        private List<object> methodParameters = new List<object>();
        PropertyInfo propertyInfo = null;
        MethodInfo methodInfo = null;

        public string MemberName
        {
            get
            {
                return memberName;
            }
            set
            {
                memberName = value;
                GetReflected();
            }
        }

        public string SortOrder
        {
            get
            {
                return sortOrder;
            }
            set
            {
                sortOrder = value;
            }
        }

        public List<object> MethodParameters
        {
            get
            {
                return methodParameters;
            }
        }

        public GenericComparer()
        {
        }

        public GenericComparer(string memberName, string sortOrder, 
               List<object> methodParameters)
        {
            this.memberName = memberName;
            this.sortOrder = sortOrder;
            this.methodParameters = methodParameters;

            GetReflected();
        }

        private void GetReflected()
        {
            Type[] underlyingTypes = this.GetType().GetGenericArguments();
            Type thisUnderlyingtype = underlyingTypes[0];

            MemberInfo[] mi = thisUnderlyingtype.GetMember(memberName);
            if (mi.Length > 0)
            {
                if (mi[0].MemberType == MemberTypes.Property)
                {
                    propertyInfo = thisUnderlyingtype.GetProperty(memberName);
                }
                else if (mi[0].MemberType == MemberTypes.Method)
                {
                    Type[] signatureTypes = new Type[0];
                    if (methodParameters != null && methodParameters.Count > 0)
                    {
                        signatureTypes = new Type[methodParameters.Count];
                        for (int i = 0; i < methodParameters.Count; i++)
                        {
                            signatureTypes[i] = methodParameters[i].GetType();
                        }
                        methodInfo = 
                          thisUnderlyingtype.GetMethod(memberName, 
                          signatureTypes);
                    }
                    else
                    {
                        methodInfo = 
                          thisUnderlyingtype.GetMethod(memberName, 
                          signatureTypes);
                    }
                }
                else
                {
                    throw new Exception("Member name: " + memberName + 
                          " is not a Public Property or " + 
                          "a Public Method in Type: " + 
                          thisUnderlyingtype.Name + ".");
                }
            }
            else
            {
                throw new Exception("Member name: " + 
                          memberName + " not found.");
            }
        }

        private IComparable GetComparable(T obj)
        {
            if (methodInfo != null)
            {
                return (IComparable)methodInfo.Invoke(obj, 
                                    methodParameters.ToArray());
            }
            else
            {
                return (IComparable)propertyInfo.GetValue(obj, null);
            }

        }

        public int Compare(T objOne, T objTwo)
        {
            IComparable iComparable1 = GetComparable(objOne);
            IComparable iComparable2 = GetComparable(objTwo);

            if (sortOrder != null && sortOrder.ToUpper().Equals("ASCENDING"))
            {
                return iComparable1.CompareTo(iComparable2);
            }
            else
            {
                return iComparable2.CompareTo(iComparable1);
            }
        }

    }
}
