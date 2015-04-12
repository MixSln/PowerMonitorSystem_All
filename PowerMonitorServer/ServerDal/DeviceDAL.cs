using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using PowerServer.DataContracts;

namespace PowerServer.ServerDAL
{
    class DeviceDAL:IDeviceDAL
    {
        private static string STMT_GETDEVICEBYID = @"SELECT [devId],[devName],[addressCode],[current_max],[current_warning]
                                                ,[voltage_warning_high],[voltage_warning_low],[devStatus],[distId]
                                                FROM [dbo].[device]
                                                Where devId = @devId";
        private static string STMT_GETDEVICELIST = @"SELECT [devId],[devName],[addressCode],[current_max],[current_warning]
                                                ,[voltage_warning_high],[voltage_warning_low],[devStatus],[distId]
                                                FROM [dbo].[device]";

        private static string STMT_GETDEVICELISTBYUSERID = @"SELECT [devId],[devName],[addressCode],[current_max],[current_warning]
                                              ,[voltage_warning_high],[voltage_warning_low],[devStatus],a.[distId] distId
                                                FROM [dbo].[device] a
	                                         join dbo.userDistribution b on a.distId = b.distId
                                             where b.userId = @userId";
        private static string STMT_GETUNASSIGNEDDEVICELIST = @"SELECT [devId],[devName],[addressCode],[current_max],[current_warning]
                                                ,[voltage_warning_high],[voltage_warning_low],[devStatus],[distId]
                                                FROM [dbo].[device]
                                                where distId is null";
        private static string STMT_GETDEVICELISTBYROOMID = @"SELECT [devId],[devName],[addressCode],[current_max],[current_warning]
                                                ,[voltage_warning_high],[voltage_warning_low],[devStatus],[distId]
                                                FROM [dbo].[device]
                                                where distId = @distId";
        private static string STMT_ADDDEVICE = @"INSERT INTO [dbo].[device]
                                           ([devName],[addressCode],[current_max],[current_warning]
                                           ,[voltage_warning_high],[voltage_warning_low],[devStatus],[distId])
                                     VALUES
                                           (@devName,@addressCode,@current_max,@current_warning,@voltage_warning_high
                                           ,@voltage_warning_low,@devStatus,@distId);
                                                        select SCOPE_IDENTITY() DevId;";
        private static string STMT_DELETEDevice = @"update dbo.Device Set distID = NULL where devId = @devId";
        private static string STMT_UPDATEDevice = @"update dbo.distribution set devName = @devName,addressCode=@addressCode,current_max,current_max,current_warning
                                            ,voltage_warning_high = @voltage_warning_high,voltage_warning_low = @voltage_warning_low,devStatus = @devStatus,distId = @distId
                                             where devId = @devId";
        private static string STMT_ADDDEVICETOROOM = @"Updae dbo.Device set distId = NULL where devId = @devId and distId = @distId";
        private static string STMT_DELETEDEVICEFROMROOM = @"Updae dbo.Device set distId = @distId where devId = @devId";

        DeviceBaseInfo GetDeviceById(int deviceId) {
            Database db;
            string sqlCommand;
            DbCommand dbCommand;
            DeviceBaseInfo instance = null;

            db = DatabaseFactory.CreateDatabase();
            sqlCommand = STMT_GETDEVICEBYID;
            dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@devId", DbType.Int32, deviceId);

            // Get results.
            using (IDataReader objReader = db.ExecuteReader(dbCommand))
            {
                instance = ReadReader(objReader);
            }
            return instance;
        }
        IList<DeviceBaseInfo> GetDeviceList() {
            Database db;
            string sqlCommand;
            DbCommand dbCommand;
            IList<DeviceBaseInfo> instances = null;

            db = DatabaseFactory.CreateDatabase();
            sqlCommand = STMT_GETDEVICELIST;
            dbCommand = db.GetSqlStringCommand(sqlCommand);

            // Get results.
            using (IDataReader objReader = db.ExecuteReader(dbCommand))
            {
                instances = ReadReaders(objReader);
            }
            return instances;
        }
        IList<DeviceBaseInfo> GetDeviceListByUserId(int userId) {
            Database db;
            string sqlCommand;
            DbCommand dbCommand;
            IList<DeviceBaseInfo> instances = null;

            db = DatabaseFactory.CreateDatabase();
            sqlCommand = STMT_GETDEVICELISTBYUSERID;
            dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@userId", DbType.Int32, userId);

            // Get results.
            using (IDataReader objReader = db.ExecuteReader(dbCommand))
            {
                instances = ReadReaders(objReader);
            }
            return instances;
        }
        IList<DeviceBaseInfo> GetUnAssignedDeviceList() { 
        //
            Database db;
            string sqlCommand;
            DbCommand dbCommand;
            IList<DeviceBaseInfo> instances = null;

            db = DatabaseFactory.CreateDatabase();
            sqlCommand = STMT_GETUNASSIGNEDDEVICELIST;
            dbCommand = db.GetSqlStringCommand(sqlCommand);

            // Get results.
            using (IDataReader objReader = db.ExecuteReader(dbCommand))
            {
                instances = ReadReaders(objReader);
            }
            return instances;
        }
        IList<DeviceBaseInfo> GetDeviceListByRoomId(int roomId) {
            //STMT_GETDEVICELISTBYROOMID
            Database db;
            string sqlCommand;
            DbCommand dbCommand;
            IList<DeviceBaseInfo> instances = null;

            db = DatabaseFactory.CreateDatabase();
            sqlCommand = STMT_GETDEVICELISTBYUSERID;
            dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@distId", DbType.Int32, roomId);

            // Get results.
            using (IDataReader objReader = db.ExecuteReader(dbCommand))
            {
                instances = ReadReaders(objReader);
            }
            return instances;
        }

        int? AddDevice(DeviceBaseInfo device) {
            Database db;
            string sqlCommand;
            DbCommand dbCommand;
            int? deviceId = 0;
            bool returnValue = false;

            db = DatabaseFactory.CreateDatabase();
            sqlCommand = STMT_ADDDEVICE;
            dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@devName", DbType.String, device.DeviceName);
            db.AddInParameter(dbCommand, "@addressCode", DbType.String, device.AddressCode);
            db.AddInParameter(dbCommand, "@current_max", DbType.Double, device.MaxCurrent);
            db.AddInParameter(dbCommand, "@current_warning", DbType.Double, device.WarningCurrent);
            db.AddInParameter(dbCommand, "@voltage_warning_high", DbType.Double, device.WarningVoltageHigh);
            db.AddInParameter(dbCommand, "@voltage_warning_low", DbType.Double, device.WarningVoltageLow);
            db.AddInParameter(dbCommand, "@devStatus", DbType.Int16, Convert.ToInt16( device.DeviceStatus));
            db.AddInParameter(dbCommand, "@distId", DbType.Int32, device.RoomId);
            //@distName,@nickName,@distAddress,@distDesc,@contact_primary,@phoneNumber_primary,@contact_bak1
            //,@phoneNumber_bak1,@contact_bak2,@phoneNumber_bak2
            // Get results.
            using (IDataReader objReader = db.ExecuteReader(dbCommand))
            {
                if (objReader.Read())
                {
                    returnValue = true;
                    deviceId = objReader["DevId"] != DBNull.Value ? Convert.ToInt32(objReader["DevId"]) : deviceId = null;
                }
            }
            if (returnValue)
                return null;
            else
                return deviceId;
        }
        void UpdateDevice(DeviceBaseInfo device)
        {
            Database db;
            string sqlCommand;
            DbCommand dbCommand;

            db = DatabaseFactory.CreateDatabase();
            sqlCommand = STMT_UPDATEDevice;
            dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@devName", DbType.String, device.DeviceName);
            db.AddInParameter(dbCommand, "@addressCode", DbType.String, device.AddressCode);
            db.AddInParameter(dbCommand, "@current_max", DbType.Double, device.MaxCurrent);
            db.AddInParameter(dbCommand, "@current_warning", DbType.Double, device.WarningCurrent);
            db.AddInParameter(dbCommand, "@voltage_warning_high", DbType.Double, device.WarningVoltageHigh);
            db.AddInParameter(dbCommand, "@voltage_warning_low", DbType.Double, device.WarningVoltageLow);
            db.AddInParameter(dbCommand, "@devStatus", DbType.Int16, Convert.ToInt16(device.DeviceStatus));
            db.AddInParameter(dbCommand, "@distId", DbType.Int32, device.RoomId);
            db.AddInParameter(dbCommand, "@devId", DbType.Int32, device.DeviceId);
            //@distName,@nickName,@distAddress,@distDesc,@contact_primary,@phoneNumber_primary,@contact_bak1
            //,@phoneNumber_bak1,@contact_bak2,@phoneNumber_bak2
            // Get results.
            db.ExecuteNonQuery(dbCommand);

            return;
        }

        void AddDeviceToRoom(int deviceId, int roomId) {
            Database db;
            string sqlCommand;
            DbCommand dbCommand;

            db = DatabaseFactory.CreateDatabase();
            sqlCommand = STMT_ADDDEVICETOROOM;
            dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@distId", DbType.Int32, roomId);
            db.AddInParameter(dbCommand, "@devId", DbType.Int32, deviceId);

            // Get results.
            db.ExecuteNonQuery(dbCommand);

            return;
        }
        void DeleteDeviceFromRoom(int deviceId, int roomId) {
            Database db;
            string sqlCommand;
            DbCommand dbCommand;

            db = DatabaseFactory.CreateDatabase();
            sqlCommand = STMT_DELETEDEVICEFROMROOM;
            dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@distId", DbType.Int32, roomId);
            db.AddInParameter(dbCommand, "@devId", DbType.Int32, deviceId);

            // Get results.
            db.ExecuteNonQuery(dbCommand);

            return;
        }

        private static DeviceBaseInfo ReadReader(IDataReader objReader)
        {
            DeviceBaseInfo instance = new DeviceBaseInfo();
            bool isnull = true;
            while (objReader.Read())
            {
                isnull = false;
                instance.DeviceId = objReader["devId"] != DBNull.Value ?
                  Convert.ToInt32(objReader["devId"]) : instance.DeviceId = null;
                instance.DeviceName = objReader["devName"] != DBNull.Value ?
                  Convert.ToString(objReader["devName"]) : instance.DeviceName = null;
                instance.AddressCode = objReader["addressCode"] != DBNull.Value ?
                  Convert.ToString(objReader["addressCode"]) : instance.AddressCode = null;
                instance.MaxCurrent = objReader["current_max"] != DBNull.Value ?
                  Convert.ToDouble(objReader["current_max"]) : instance.MaxCurrent = null;

                instance.WarningCurrent = objReader["current_warning"] != DBNull.Value ?
                  Convert.ToDouble(objReader["current_warning"]) : instance.WarningCurrent = null;
                instance.WarningVoltageHigh = objReader["voltage_warning_high"] != DBNull.Value ?
                  Convert.ToDouble(objReader["voltage_warning_high"]) : instance.WarningVoltageHigh = null;
                instance.WarningVoltageLow = objReader["voltage_warning_low"] != DBNull.Value ?
                  Convert.ToDouble(objReader["voltage_warning_low"]) : instance.WarningVoltageLow = null;
                instance.DeviceStatus = objReader["devStatus"] != DBNull.Value ?
                  (DeviceStatus)Convert.ToInt32(objReader["devStatus"]) : instance.DeviceStatus = null;
                instance.RoomId = objReader["distId"] != DBNull.Value ?
                  Convert.ToInt32(objReader["distId"]) : instance.RoomId = null;
                
            }
            if (isnull) return null;
            else return instance;
        }

        private static IList<DeviceBaseInfo> ReadReaders(IDataReader objReader)
        {
            IList<DeviceBaseInfo> instances = new List<DeviceBaseInfo>();
            DeviceBaseInfo instance;
            bool isnull = true;
            while (objReader.Read())
            {
                isnull = false;
                instance = new DeviceBaseInfo();
                instance.DeviceId = objReader["devId"] != DBNull.Value ?
                  Convert.ToInt32(objReader["devId"]) : instance.DeviceId = null;
                instance.DeviceName = objReader["devName"] != DBNull.Value ?
                  Convert.ToString(objReader["devName"]) : instance.DeviceName = null;
                instance.AddressCode = objReader["addressCode"] != DBNull.Value ?
                  Convert.ToString(objReader["addressCode"]) : instance.AddressCode = null;
                instance.MaxCurrent = objReader["current_max"] != DBNull.Value ?
                  Convert.ToDouble(objReader["current_max"]) : instance.MaxCurrent = null;

                instance.WarningCurrent = objReader["current_warning"] != DBNull.Value ?
                  Convert.ToDouble(objReader["current_warning"]) : instance.WarningCurrent = null;
                instance.WarningVoltageHigh = objReader["voltage_warning_high"] != DBNull.Value ?
                  Convert.ToDouble(objReader["voltage_warning_high"]) : instance.WarningVoltageHigh = null;
                instance.WarningVoltageLow = objReader["voltage_warning_low"] != DBNull.Value ?
                  Convert.ToDouble(objReader["voltage_warning_low"]) : instance.WarningVoltageLow = null;
                instance.DeviceStatus = objReader["devStatus"] != DBNull.Value ?
                  (DeviceStatus)Convert.ToInt32(objReader["devStatus"]) : instance.DeviceStatus = null;
                instance.RoomId = objReader["distId"] != DBNull.Value ?
                  Convert.ToInt32(objReader["distId"]) : instance.RoomId = null;

                instances.Add(instance);

            }
            if (isnull) return null;
            else return instances;
        }
    }
}
