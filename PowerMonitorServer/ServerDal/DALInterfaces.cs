using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PowerServer.DataContracts;

namespace PowerServer.ServerDAL
{
    public interface IRoomDAL
    {
        RoomBaseInfo GetRoomById(int roomId);
        IList<RoomBaseInfo> GetRoomList();
        IList<RoomBaseInfo> GetRoomListByUserId(int userId);
        int? AddRoom(RoomBaseInfo room);//return roomId -1 indicate error
        void DeleteRoom(int roomId);
        void UpdateRoom(RoomBaseInfo room);

        void AddDeviceToRoom(int deviceId, int roomId);
        void DeleteDeviceFromRoom(int deviceId, int roomId);
    }

    public interface IDeviceDAL
    {
        DeviceBaseInfo GetDeviceById(int deviceId);
        IList<DeviceBaseInfo> GetDeviceList();
        IList<DeviceBaseInfo> GetDeviceListByUserId(int userId);
        IList<DeviceBaseInfo> GetUnAssignedDeviceList();
        IList<DeviceBaseInfo> GetDeviceListByRoomId(int roomId);

        int? AddDevice(DeviceBaseInfo device);        
        void UpdateDevice(DeviceBaseInfo device);

        void AddDeviceToRoom(int deviceId, int roomId);
        void DeleteDeviceFromRoom(int deviceId, int roomId);
    }

    public interface IConfigDAL
    {
        string GetConfigValue(string configString);
        bool UpdateConfigValue(ConfigInfo configInfo);
    }

    public interface IDeviceWarningDAL
    {
        DeviceWarningInfo GetDeviceWarning(int deviceId,DeviceWarningType warningType);
        IList<DeviceWarningInfo> GetDeviceWarningHistoryByDeviceId(int deviceId);
        
        bool InsertDeviceWaring(DeviceWarningInfo deviceWarning);
        bool ProcessDeviceWarning(DeviceWarningInfo deviceWarning);
        bool DisableDeviceWarning(DeviceWarningInfo deviceWarning);
    }

    public interface ILogDAL
    {
        bool InsertLog(LogInfo logInfo);

        IList<LogInfo> GetLog();//needs to check what's the parameter should be.
    }

    public interface IUserDAL
    {
        bool GetUserByUserId(int userId);
        bool AddUser(UserBaseInfo userInfo);
        bool UpdateUser(UserBaseInfo userInfo);
        bool DeleteUser(int userId);

        bool AssignUserRole(int userId, int roleId);
        bool RevokeUserRole(int userId, int roleId);

        bool AssignUserRoom(int userId, int roomId);
        bool RevokeUserRoom(int userId, int roomId);
    }
}
