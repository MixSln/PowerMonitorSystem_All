using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PowerServer.DataContracts;

namespace PowerServer.ServerDAL
{
    interface IRoomDAL
    {
        public RoomBaseInfo GetRoomById(int roomId);
        public IList<RoomBaseInfo> GetRoomList();
        public IList<RoomBaseInfo> GetRoomListByUserId(int userId);
        public int AddRoom(RoomBaseInfo room);//return roomId -1 indicate error
        public bool DeleteRoom(int roomId);
        public bool UpdateRoom(RoomBaseInfo room);

        public bool AddDeviceToRoom(int deviceId, int roomId);
        public bool DeleteDeviceFromRoom(int deviceId, int roomId);
    }

    interface IDeviceDAL
    {
        public DeviceBaseInfo GetDeviceById(int deviceId);
        public IList<DeviceBaseInfo> GetDeviceList();
        public IList<DeviceBaseInfo> GetDeviceListByUserId(int userId);
        public IList<DeviceBaseInfo> GetUnAssignedDeviceList();
        public IList<DeviceBaseInfo> GetDeviceListByRoomId(int roomId);

        public int AddDevice(DeviceBaseInfo device);        
        public bool UpdateDevice(DeviceBaseInfo device);

        public bool AddDeviceToRoom(int deviceId, int roomId);
        public bool DeleteDeviceFromRoom(int deviceId, int roomId);
    }

    interface IConfigDAL
    {
        public string GetConfigValue(string configString);
        public bool UpdateConfigValue(ConfigInfo configInfo);
    }

    interface IDeviceWarningDAL
    {
        public DeviceWarningInfo GetDeviceWarning(int deviceId,DeviceWarningType warningType);
        public IList<DeviceWarningInfo> GetDeviceWarningHistoryByDeviceId(int deviceId);
        
        public bool InsertDeviceWaring(DeviceWarningInfo deviceWarning);
        public bool ProcessDeviceWarning(DeviceWarningInfo deviceWarning);
        public bool DisableDeviceWarning(DeviceWarningInfo deviceWarning);
    }

    interface ILogDAL
    {
        public bool InsertLog(LogInfo logInfo);

        public IList<LogInfo> GetLog();//needs to check what's the parameter should be.
    }

    interface IUserDAL
    {
        public bool GetUserByUserId(int userId);
        public bool AddUser(UserBaseInfo userInfo);
        public bool UpdateUser(UserBaseInfo userInfo);
        public bool DeleteUser(int userId);

        public bool AssignUserRole(int userId, int roleId);
        public bool RevokeUserRole(int userId, int roleId);

        public bool AssignUserRoom(int userId, int roomId);
        public bool RevokeUserRoom(int userId, int roomId);
    }
}
