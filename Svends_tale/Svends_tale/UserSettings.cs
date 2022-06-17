using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UserSettings : ApplicationSettingsBase
{
    [UserScopedSetting]
    [DefaultSettingValue("black")]
    public ConsoleColor ConsoleBackgroundColor
    {
        get
        {
            return ((ConsoleColor)this["ConsoleBackgroundColor"]);
        }
        set
        {
            this["ConsoleBackgroundColor"] = (ConsoleColor)value;
        }
    }

    [UserScopedSetting]
    [DefaultSettingValue("white")]
    public ConsoleColor ConsoleForegroundColor
    {
        get
        {
            return ((ConsoleColor)this["ConsoleForegroundColor"]);
        }
        set
        {
            this["ConsoleForegroundColor"] = (ConsoleColor)value;
        }
    }

    [UserScopedSetting]
    [DefaultSettingValue("en")]
    public String Language
    {
        get
        {
            return (String)this["Language"];
        }
        set
        {
            this["Language"] = (String)value;
        }
    }
}

