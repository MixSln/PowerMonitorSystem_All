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
        [DataMember]
        public int RoomId { get; set; }
        [DataMember]
        public string RoomName { get; set; }
        [DataMember]
        public string RoomNickName { get; set; }
        [DataMember]
        public string RoomAddress { get; set; }
        [DataMember]
        public string RoomDescription { get; set; }
        [DataMember]
        public string PrimaryContact { get; set; }
        [DataMember]
        public string PrimaryPhoneNumber { get; set; }
        [DataMember]
        public string Bak1Contact { get; set; }
        [DataMember]
        public string Bak1PhoneNumber { get; set; }
        [DataMember]
        public string Bak2Contact { get; set; }
        [DataMember]
        public string Bak2PhoneNumber { get; set; }
    }

    [DataContract]
    public class RoomInfo
    {
        [DataMember]
        RoomBaseInfo baseInfo;
        [DataMember]
        Dictionary<int, DeviceBaseInfo> deviceDic;

        public RoomInfo()
        {
            deviceDic = new Dictionary<int, DeviceBaseInfo>();
        }
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
    [DataContract]
    public struct DeviceRealTimeInfo
    {

    }
    [DataContract]
    public class DeviceInfo
    {
        DeviceBaseInfo baseInfo;
        DeviceRealTimeInfo rtInfo;
    }
#endregion

#region User Data
    [DataContract]
    public struct UserBaseInfo
    {

    }
    [DataContract]
    public class UserInfo
    {
        [DataMember]
        UserBaseInfo baseInfo;
        [DataMember]
        Dictionary<int, RoomInfo> roomDic;

        public UserInfo()
        {
            roomDic = new Dictionary<int, RoomInfo>();
        }
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
