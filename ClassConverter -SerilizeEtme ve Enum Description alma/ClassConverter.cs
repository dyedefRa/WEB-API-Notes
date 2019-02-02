using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SiparisTakip2.WebApi.App_Classes.Attribute
{
    public class ClassConverter
    {
        //Bir classı diger bir class a cevırme (Serilization için)
        public static T2 Convert<T1, T2>(T1 Type1)
        {
            var t = Activator.CreateInstance<T2>();
            foreach (var propTarget in t.GetType().GetProperties())
                foreach (var propSource in typeof(T1).GetProperties())
                    if (propTarget.Name == propSource.Name && propTarget.PropertyType.Equals(propSource.PropertyType))
                        propTarget.SetValue(t, propSource.GetValue(Type1));
            return t;
        }

        //Enum Description Almak 
        //Kullanımı => string descriptiondegeri= ClassConverter.GetDescription(Status.OturumHatasi);
        public static string GetDescription(System.Enum input)
        {
            Type type = input.GetType();
            MemberInfo[] memInfo = type.GetMember(input.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = (object[])memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
         
            return input.ToString();
        }
    }
}