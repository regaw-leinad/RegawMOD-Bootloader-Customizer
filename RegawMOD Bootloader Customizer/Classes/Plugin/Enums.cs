using System.ComponentModel;
using System.Reflection;

namespace RegawMOD.Android
{
    public enum HTC_DEVICE
    {
        [Description("HTC Evo 4G LTE")]
        JEWEL = 0,
        [Description("HTC Evo 4G")]
        SUPERSONIC = 1,
        [Description("HTC Evo 3D")]
        SHOOTER = 2,
        [Description("HTC Sensation")]
        PYRAMID = 3,
        [Description("HTC Wildfire S")]
        MARVEL = 4,
        [Description("HTC Incredible S")]
        VIVO = 5,
        [Description("Droid Incredible 2")]
        VIVOW = 6,
        [Description("HTC Amaze 4G")]
        RUBY = 7,
        [Description("HTC One X")]
        ENDEAVOR = 8,
        [Description("HTC One S")]
        VILLE = 9,
        [Description("HTC One V")]
        PRIMO = 10,
        [Description("HTC One XL")]
        EVITA = 11,
        [Description("HTC Thunderbolt")]
        MECHA = 12,
        [Description("HTC Desire HD")]
        ACE = 13,
        [Description("HTC Insipre 4G")]
        STALLION = 14,
        [Description("HTC Evo Shift 4G")]
        SPEEDY = 15,
        [Description("HTC Desire S")]
        SAGA = 16,
        [Description("HTC Tattoo")]
        CLICK = 17,
        [Description("Droid Eris")]
        DESIREC = 18,
        [Description("HTC Desire")]
        BRAVO = 19,
        [Description("HTC Incredible")]
        INCREDIBLE = 20,
        [Description("HTC Wildfire")]
        BUZZ = 21,
        [Description("HTC Aria")]
        LIBERTY = 22,
        [Description("HTC Desire Z")]
        VISION = 23,
        [Description("HTC Evo 4G+")]
        RIDER = 24,
        [Description("HTC Vivid 4G")]
        HOLIDAY = 25,
        [Description("HTC Evo Design 4G")]
        KINGDOM = 26,
        [Description("HTC Sensation XE")]
        RUNNYMEDE = 27,
        [Description("HTC Rezound")]
        VIGOR = 28,
        [Description("HTC Desire C")]
        GOLF = 29,
        [Description("HTC Droid Incredible 4G LTE")]
        FIREBALL = 30,
        [Description("HTC DNA")]
        DLX = 31,
        [Description("HTC One (GSM)")]
        M7UL,
        [Description("HTC One (ATT)")]
        M7ATT,
        [Description("HTC One (Sprint)")]
        M7SPR,
        [Description("HTC One (TMobile)")]
        M7TMO,
        [Description("HTC One (Verizon)")]
        M7VZW
    }

    internal class EnumHelper
    {
        internal static string GetEnumDescription(HTC_DEVICE value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}