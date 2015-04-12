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
        /// <returns></returns>
        [OperationContract]
        bool userLogin(string username,string passwd);

        #region Room Operations
        [OperationContract]
        int roomAdd(RoomBaseInfo room);
        [OperationContract]
        bool roomAddToUser(int userid, int roomid);
        [OperationContract]
        bool roomDel(int roomid);
        [OperationContract]
        bool roomDelFromUser(int userid, int roomid);
        [OperationContract]
        bool roomUpdate(RoomBaseInfo room);
        [OperationContract]
        RoomBaseInfo roomGet(int roomid);
        #endregion

        #region Device Operations
        [OperationContract]
        int deviceAdd(DeviceBaseInfo device);
        [OperationContract]
        bool deviceAddToRoom(int roomid, DeviceBaseInfo device);
        [OperationContract]
        bool deviceDel(int deviceid);
        [OperationContract]
        bool deviceDelFromRoom(int roomid, int deviceid);
        [OperationContract]
        bool deviceUpdate(DeviceBaseInfo device);
        [OperationContract]
        DeviceBaseInfo deviceGet(int deviceid);
        #endregion

        #region UserOperations
        [OperationContract]
        int userAdd(UserBaseInfo user);
        [OperationContract]
        bool userDel(int userid);
        [OperationContract]
        bool userUpdate(UserBaseInfo user);
        [OperationContract]
        UserBaseInfo userGet(int userid);
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
