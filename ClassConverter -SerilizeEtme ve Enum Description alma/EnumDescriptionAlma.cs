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