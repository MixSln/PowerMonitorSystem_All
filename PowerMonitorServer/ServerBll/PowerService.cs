using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using PowerServer.ServerAil;
using PowerServer.ServerBll.IModules;
using PowerServer.DataContracts;

namespace PowerServer.ServerBll
{
    [ServiceBehavior(ConcurrencyMode=ConcurrencyMode.Multiple,InstanceContextMode=InstanceContextMode.Single)]
    public class PowerService:IPowerService,IDisposable
    {
        #region Service Control
        private void _initialService()
        {
            //initial work threads here
        }

        protected ServiceHost _host = null;
        public void startService()
        {
            _initialService();
            _host = new ServiceHost(typeof(PowerService));
            _host.Open();
        }

        public void stopService()
        {
            _host.Close();
        }

        bool _disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {

            }
            _disposed = true;
        }
        #endregion

        #region Logic member
        private PublisherServer.PubliserServer _publisher = PublisherServer.PubliserServer.GetInstance();
        #endregion

        #region Implement Interface
        public int userLogin(string username, string passwd)
        {
            
            return 0;
        }

        #region 配电室
        public int roomAdd(RoomBaseInfo room)
        {
            return 0;
        }
        public bool roomAddToUser(int userid, int roomid)
        {
            return false;
        }
        public bool roomDel(int roomid)
        {
            return false;
        }
        public bool roomDelFromUser(int userid, int roomid)
        {
            return false;
        }
        public bool roomBaseInfoUpdate(RoomBaseInfo room)
        {
            return false;
        }
        public RoomBaseInfo roomBaseInfoGet(int roomid)
        {
            return new RoomBaseInfo();
        }
        public RoomInfo roomInfoGet(int userid, int roomid)
        {
            return new RoomInfo();
        }
        public Dictionary<int, RoomInfo> roomInfoOfUserGet(int userid)
        {
            return new Dictionary<int, RoomInfo>();
        }
        public Dictionary<int, RoomInfo> roomInfoAllGet()
        {
            return new Dictionary<int, RoomInfo>();
        }
        #endregion

        #region 设备
        public int deviceAdd(DeviceBaseInfo device)
        {
            return 0;
        }
        public bool deviceAddToRoom(int roomid, DeviceBaseInfo device)
        {
            return false;
        }
        public bool deviceDel(int deviceid)
        {
            return false;
        }
        public bool deviceDelFromRoom(int roomid, int deviceid)
        {
            return false;
        }
        public bool deviceBaseInfoUpdate(DeviceBaseInfo device)
        {
            return false;
        }
        public DeviceBaseInfo deviceBaseInfoGet(int deviceid)
        {
            return new DeviceBaseInfo();
        }
        public List<DeviceRealTimeInfo> deviceHistoryGet(int deviceid)
        {
            return new List<DeviceRealTimeInfo>();
        }
        public Dictionary<int, DeviceBaseInfo> deviceBaseInfoOfRoomGet(int roomid)
        {
            return new Dictionary<int, DeviceBaseInfo>();
        }
        public Dictionary<int, DeviceBaseInfo> deviceBaseInfoOfUserGet(int userid)
        {
            return new Dictionary<int, DeviceBaseInfo>();
        }
        public Dictionary<int, DeviceBaseInfo> deviceBaseInfoAllGet()
        {
            return new Dictionary<int, DeviceBaseInfo>();
        }
        #endregion

        #region 用户
        public int userAdd(UserBaseInfo user)
        {
            return 0;
        }
        public bool userDel(int userid)
        {
            return false;
        }
        public bool userBaseInfoUpdate(UserBaseInfo user)
        {
            return false;
        }
        public UserBaseInfo userBaseInfoGet(int userid)
        {
            return new UserBaseInfo();
        }
        public Dictionary<int, UserBaseInfo> userBaseInfoAllGet()
        {
            return new Dictionary<int, UserBaseInfo>();
        }
        #endregion
        #endregion
    }
}
