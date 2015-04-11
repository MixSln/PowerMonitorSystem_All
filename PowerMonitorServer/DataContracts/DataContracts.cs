using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace PowerServer.DataContracts
{
    [DataContract]
    public struct ClientInfo
    {

    }

#region Room Data
    [DataContract]
    public struct RoomBaseInfo
    {

    }
#endregion

#region Device Data
    [DataContract]
    public struct DeviceBaseInfo
    {

    }
#endregion

#region User Data
    [DataContract]
    public struct UserBaseInfo
    {

    }
#endregion

#region config info
[DataContract]
    public struct ConfigInfo
    {
    public String ConfigString { get; set; }
    public String ConfigValue { get; set; }
    }
#endregion

#region deviceWarning
    [DataContract]
public struct DeviceWarningInfo
{
    public int DevId { get; set; }
    public DateTime WarningTime { get; set; }
    public DeviceWarningType WarningValue { get; set; }
    public string WarningContent { get; set; }
    public DateTime WarningProcessTime { get; set; }
    public int ProcessedBy { get; set; }
    public int WarningDisableTime{get; set;}
}

[DataContract]
public enum DeviceWarningType { SwitchValue,Voltage_AB,Voltage_CA,Voltage_BC,Current_A,Current_B,Current_C}

#endregion

#region log
public struct LogInfo
{

}
#endregion
}
