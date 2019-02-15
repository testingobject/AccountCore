using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static SGPC.Helpers.Enums;

namespace SGPC.Helpers
{
    public  class Common
    {
        public static string GetDescription(System.Enum value)
        {
            var enumMember = value.GetType().GetMember(value.ToString()).FirstOrDefault();
            var descriptionAttribute =
                enumMember == null
                    ? default(DescriptionAttribute)
                    : enumMember.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
            return
                descriptionAttribute == null
                    ? value.ToString()
                    : descriptionAttribute.Description;
        }
        public static List<SelectListItem> GetEnumTicketStatus(int SelectedValue=-1)
        {
            List<SelectListItem> list = Enum.GetValues(typeof(EnumTicketStatus)).Cast<EnumTicketStatus>().Select(x => new SelectListItem()
            {
                Selected=(((int)x) == SelectedValue),
                Text = GetDescription(x),
                Value = ((int)x).ToString()
            }).ToList();
            return list;
        }
    }
}
