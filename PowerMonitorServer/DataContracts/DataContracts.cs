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
    public class RoomBaseInfo
    {
        public int? RoomId { get; set; }
        public string? RoomName { get; set; }
        public string? RoomNickName { get; set; }
        public string? RoomAddress { get; set; }
        public string? RoomDescription { get; set; }
        public string? PrimaryContact { get; set; }
        public string? PrimaryPhoneNumber { get; set; }
        public string? Bak1Contact { get; set; }
        public string? Bak1PhoneNumber { get; set; }
        public string? Bak2Contact { get; set; }
        public string? Bak2PhoneNumber { get; set; }
    }
#endregion

#region Device Data
    [DataContract]
    public struct DeviceBaseInfo
    {
        public int DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string AddressCode { get; set; }
        public double MaxCurrent { get; set; }
        public double WarningCurrent { get; set; }
        public double WarningVoltageHigh { get; set; }
        public double WarningVoltageLow { get; set; }
        public DeviceStatus DeviceStatus { get; set; }
        public int RoomId { get; set; }
    }
    [DataContract]
    public enum DeviceStatus{Online,Offline}
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

#region device monitor parameter detail
public struct DeviceMonitorParameter
{
    public DateTime ParameterDate { get; set; }
    public int DeviceId { get; set; }
    public int VoltageA { get; set; }
    public int VoltageB { get; set; }
    public int VoltageC { get; set; }
    public int VoltageAB { get; set; }
    public int VoltageBC { get; set; }
    public int VoltageCA { get; set;}
    public int CurrentA { get; set; }
    public int CurrentB { get; set; }
    public int CurrentC { get; set; }
    public int RealPowerA { get; set; }
    public int RealPowerB { get; set; }
    public int RealPowerC { get; set; }
    public int RealPowerTotal { get; set; }
    public int ReactivePowerA { get; set; }
    public int ReactivePowerB { get; set; }
    public int ReactivePowerC { get; set; }
    public int ReactivePowerTotal { get; set; }
    public int ApparentPowerTotal { get; set; }
    public double PowerFactor { get; set; }
    public double Frequency { get; set; }
    public double ActivePowerEnergyPositive { get; set; }
    public double ActivePowerEnergyNegative { get; set; }
    public double ReactivePowerEnergyPositive { get; set; }
    public double ReactivePowerEnergyNegative { get; set; }
    public int SwitchValue { get; set; }
}
#endregion
}
