using System;
using System.IO;

namespace RegawMOD.Android
{
    public interface IBootloaderPlugin
    {
        string DEVELOPER_NAME { get; }
        int DEVELOPER_XDA_PROFILE_ID { get; }
        string DEVELOPER_PERSONAL_WEBSITE { get; }
        string PLUGIN_DESCRIPTION { get; }

        HTC_DEVICE DEVICE { get; }
        Stream HBOOT_IMAGE { get; }
        Stream ANDROID_INFO { get; }

        string BOOTLOADER_ORIG_VERSION { get; }
        string FIRMWARE_ZIP_NAME { get; }

        bool ALLOW_CHANGE_BANNER_TEXT { get; }
        long OFFSET_BANNER_TEXT_START { get; }
        int LENGTH_MAX_BANNER_TEXT { get; }

        bool ALLOW_CHANGE_S_OFF_TEXT { get; }
        long OFFSET_S_OFF_TEXT_START { get; }

        bool ALLOW_CHANGE_MINOR_VERSION_NUMBER_TEXT { get; }
        long OFFSET_MINOR_VERSION_TEXT_START { get; }

        bool ALLOW_CHANGE_HTC_DEVELOPMENT_DISCLAIMER { get; }
        long[] OFFSETS_HTC_DEVELOPMENT_DISCLAIMER { get; }
        int[] LENGTHS_MAX_HTC_DEVELOPMENT_DISCLAIMER { get; }

        bool ALLOW_CHANGE_BUILD_DATE_TIME { get; }
        long OFFSET_DATE_TIME_TEXT_START { get; }
        string FORMAT_DATE_TIME_DISPLAY { get; }
        int LENGTH_MAX_DATE_TIME { get; }
    }
}