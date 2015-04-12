using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using PowerServer.DataContracts;

using System.Data;
using System.Data.SqlClient;


namespace PowerServer.ServerAil
{
    [ServiceContract(Namespace="PowerServer",CallbackContract=typeof(IPublisherEvents))]
    public interface IPowerService
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="passwd">密码</param>
        /// <returns>返回用户ID</returns>
        [OperationContract]
        int userLogin(string username,string passwd);

        #region Room Operations
        //增加一个配电室信息
        [OperationContract]
        int roomAdd(RoomBaseInfo room);
        //将一个配电室与一个用户管理
        [OperationContract]
        bool roomAddToUser(int userid, int roomid);
        //删除一个配电室，以及其与所有用户和设备的关联
        [OperationContract]
        bool roomDel(int roomid);
        //删除一个配电室与一个用户的管理
        [OperationContract]
        bool roomDelFromUser(int userid, int roomid);
        //更新一个配电室的基本信息
        [OperationContract]
        bool roomBaseInfoUpdate(RoomBaseInfo room);
        //获取一个配电室的基本信息
        [OperationContract]
        RoomBaseInfo roomBaseInfoGet(int roomid);
        //获取某个用户名下某个配电室的详细信息（包括其中的设备）
        [OperationContract]
        RoomInfo roomInfoGet(int userid, int roomid);
        //获取某个用户名下的配电室列表
        Dictionary<int, RoomInfo> roomInfoOfUserGet(int userid);
        //获取所有配电室列表
        Dictionary<int, RoomInfo> roomInfoAllGet();
        #endregion

        #region Device Operations
        //添加一个设备
        [OperationContract]
        int deviceAdd(DeviceBaseInfo device);
        //添加一个设备到一个配电室
        [OperationContract]
        bool deviceAddToRoom(int roomid, DeviceBaseInfo device);
        //删除一个设备
        [OperationContract]
        bool deviceDel(int deviceid);
        //从一个配电室删除一个设备
        [OperationContract]
        bool deviceDelFromRoom(int roomid, int deviceid);
        //更新一个设备
        [OperationContract]
        bool deviceBaseInfoUpdate(DeviceBaseInfo device);
        //获取一个设备的基本信息
        [OperationContract]
        DeviceBaseInfo deviceBaseInfoGet(int deviceid);
        //获取一个设备的历史数据
        [OperationContract]
        List<DeviceRealTimeInfo> deviceHistoryGet(int deviceid);
        //获取一个配电室的设备列表
        [OperationContract]
        Dictionary<int, DeviceBaseInfo> deviceBaseInfoOfRoomGet(int roomid);
        //获取一个用户的所有设备列表
        [OperationContract]
        Dictionary<int, DeviceBaseInfo> deviceBaseInfoOfUserGet(int userid);
        //获取所有设备列表
        [OperationContract]
        Dictionary<int, DeviceBaseInfo> deviceBaseInfoAllGet();
        #endregion

        #region UserOperations
        //添加用户，并获得添加后用户的id，以便继续添加配电室（以及可能设备）
        [OperationContract]
        int userAdd(UserBaseInfo user);
        //删除一个用户及其所有配电室和设备关联信息
        [OperationContract]
        bool userDel(int userid);
        //更新一个用户本身的基本信息（不涉及配电室和设备）
        [OperationContract]
        bool userBaseInfoUpdate(UserBaseInfo user);
        //获取一个用户的基本信息(不包含配电室和设备)
        [OperationContract]
        UserBaseInfo userBaseInfoGet(int userid);
        //获取当前所有用户列表
        [OperationContract]
        Dictionary<int, UserBaseInfo> userBaseInfoAllGet();
        #endregion
    }

    public interface IPublisherEvents
    {
        [OperationContract(IsOneWay = true)]
        void notifyAD();

        [OperationContract(IsOneWay=true)]
        void pushRTInfo(ClientInfo clientinfo);
    }
}
