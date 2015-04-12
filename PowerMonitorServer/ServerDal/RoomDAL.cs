using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PowerServer.DataContracts;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using System.Data;
using System.Data.Common;
using System.Data.SqlClient;


namespace PowerServer.ServerDAL
{
    class RoomDAL:IRoomDAL
    {
        private static string STMT_GETROOMBYID = @"SELECT [distId]
                          ,[distName],[nickName],[distAddress],[distDesc],[contact_primary]
                          ,[phoneNumber_primary],[contact_bak1],[phoneNumber_bak1],[contact_bak2],[phoneNumber_bak2]
                      FROM [dbo].[distribution]
                        Where distId = @distId";
        private static string STMT_GETROOMLIST = @"SELECT [distId]
                          ,[distName],[nickName],[distAddress],[distDesc],[contact_primary]
                          ,[phoneNumber_primary],[contact_bak1],[phoneNumber_bak1],[contact_bak2],[phoneNumber_bak2]
                      FROM [dbo].[distribution]";

        private static string STMT_GETROOMLISTBYUSERID = @"SELECT a.[distId]
                          ,[distName],[nickName],[distAddress],[distDesc],[contact_primary]
                          ,[phoneNumber_primary],[contact_bak1],[phoneNumber_bak1],[contact_bak2],[phoneNumber_bak2]
                      FROM [dbo].[distribution] a
                      JOIN dbo.userDistribution b on a.distId = b.distId
                      where b.userId = @userId";
        private static string STMT_ADDROOM = @"INSERT INTO [dbo].[distribution]
                       ([distName],[nickName],[distAddress],[distDesc],[contact_primary],[phoneNumber_primary]
                       ,[contact_bak1],[phoneNumber_bak1],[contact_bak2],[phoneNumber_bak2])
                 VALUES(@distName,@nickName,@distAddress,@distDesc,@contact_primary,@phoneNumber_primary,@contact_bak1
                       ,@phoneNumber_bak1,@contact_bak2,@phoneNumber_bak2);
                        select SCOPE_IDENTITY() RoomId;";
        private static string  STMT_DELETEROOM = @"delete dbo.distribution where distId = @distId";
        private static string STMT_UPDATEROOM = @"update dbo.distribution set distName = @distName,nickName = @nickName,distAddress = @distAddress
                    ,distDesc = @distDesc,distDesc = @distDesc,contact_primary = @contact_primary,phoneNumber_primary = @phoneNumber_primary
                    ,contact_bak1 = @contact_bak1,phoneNumber_bak1 = @phoneNumber_bak1,contact_bak2=@contact_bak2,phoneNumber_bak2=@phoneNumber_bak2 
                    where distId = @distId";
        private static string STMT_ADDDEVICETOROOM = @"Updae dbo.Device set distId = NULL where devId = @devId and distId = @distId";
        private static string STMT_DELETEDEVICEFROMROOM = @"Updae dbo.Device set distId = @distId where devId = @devId";
        private static RoomBaseInfo ReadReader(IDataReader objReader)
        {
            RoomBaseInfo instance = new RoomBaseInfo();
            bool isnull = true;
            while (objReader.Read())
            {
                isnull = false;
                instance.RoomId = objReader["distId"] != DBNull.Value ?
                  Convert.ToInt32(objReader["distId"]) : instance.RoomId = null;
                instance.RoomName = objReader["distName"] != DBNull.Value ?
                  Convert.ToString(objReader["distName"]) : instance.RoomName = null;
                instance.RoomNickName = objReader["nickName"] != DBNull.Value ?
                  Convert.ToString(objReader["nickName"]) : instance.RoomNickName = null;
                instance.RoomAddress = objReader["distAddress"] != DBNull.Value ?
                  Convert.ToString(objReader["distAddress"]) : instance.RoomAddress = null;

                instance.RoomDescription = objReader["distDesc"] != DBNull.Value ?
                  Convert.ToString(objReader["distDesc"]) : instance.RoomDescription = null;
                instance.PrimaryContact = objReader["contact_primary"] != DBNull.Value ?
                  Convert.ToString(objReader["contact_primary"]) : instance.PrimaryContact = null;
                instance.PrimaryPhoneNumber = objReader["phoneNumber_primary"] != DBNull.Value ?
                  Convert.ToString(objReader["phoneNumber_primary"]) : instance.PrimaryPhoneNumber = null;
                instance.Bak1Contact = objReader["contact_bak1"] != DBNull.Value ?
                  Convert.ToString(objReader["contact_bak1"]) : instance.Bak1Contact = null;
                instance.Bak1PhoneNumber = objReader["phoneNumber_bak1"] != DBNull.Value ?
                  Convert.ToString(objReader["phoneNumber_bak1"]) : instance.Bak1PhoneNumber = null;
                instance.Bak2Contact = objReader["contact_bak2"] != DBNull.Value ?
                  Convert.ToString(objReader["contact_bak2"]) : instance.Bak2Contact = null;
                instance.Bak2PhoneNumber = objReader["phoneNumber_bak2"] != DBNull.Value ?
                  Convert.ToString(objReader["phoneNumber_bak2"]) : instance.Bak2PhoneNumber = null;

            }
            if (isnull) return null;
            else return instance;
        }

        private static IList<RoomBaseInfo> ReadReaders(IDataReader objReader)
        {
            IList<RoomBaseInfo> instances = new List<RoomBaseInfo>();
            RoomBaseInfo instance;
            bool isnull = true;
            while (objReader.Read())
            {
                isnull = false;
                instance = new RoomBaseInfo();
                instance.RoomId = objReader["distId"] != DBNull.Value ?
                  Convert.ToInt32(objReader["distId"]) : instance.RoomId = null;
                instance.RoomName = objReader["distName"] != DBNull.Value ?
                  Convert.ToString(objReader["distName"]) : instance.RoomName = null;
                instance.RoomNickName = objReader["nickName"] != DBNull.Value ?
                  Convert.ToString(objReader["nickName"]) : instance.RoomNickName = null;
                instance.RoomAddress = objReader["distAddress"] != DBNull.Value ?
                  Convert.ToString(objReader["distAddress"]) : instance.RoomAddress = null;

                instance.RoomDescription = objReader["distDesc"] != DBNull.Value ?
                  Convert.ToString(objReader["distDesc"]) : instance.RoomDescription = null;
                instance.PrimaryContact = objReader["contact_primary"] != DBNull.Value ?
                  Convert.ToString(objReader["contact_primary"]) : instance.PrimaryContact = null;
                instance.PrimaryPhoneNumber = objReader["phoneNumber_primary"] != DBNull.Value ?
                  Convert.ToString(objReader["phoneNumber_primary"]) : instance.PrimaryPhoneNumber = null;
                instance.Bak1Contact = objReader["contact_bak1"] != DBNull.Value ?
                  Convert.ToString(objReader["contact_bak1"]) : instance.Bak1Contact = null;
                instance.Bak1PhoneNumber = objReader["phoneNumber_bak1"] != DBNull.Value ?
                  Convert.ToString(objReader["phoneNumber_bak1"]) : instance.Bak1PhoneNumber = null;
                instance.Bak2Contact = objReader["contact_bak2"] != DBNull.Value ?
                  Convert.ToString(objReader["contact_bak2"]) : instance.Bak2Contact = null;
                instance.Bak2PhoneNumber = objReader["phoneNumber_bak2"] != DBNull.Value ?
                  Convert.ToString(objReader["phoneNumber_bak2"]) : instance.Bak2PhoneNumber = null;

                instances.Add(instance);

            }
            if (isnull) return null;
            else return instances;
        }

        public RoomBaseInfo GetRoomById(int roomId)
        {
            Database db;
            string sqlCommand;
            DbCommand dbCommand;
            RoomBaseInfo instance = null;

            db = DatabaseFactory.CreateDatabase();
            sqlCommand = STMT_GETROOMBYID;
            dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@distId", DbType.Int32, roomId);

            // Get results.
            using (IDataReader objReader = db.ExecuteReader(dbCommand))
            {
                instance = ReadReader(objReader);
            }
            return instance;
        }

        public IList<RoomBaseInfo> GetRoomList()
        {
            Database db;
            string sqlCommand;
            DbCommand dbCommand;
            IList<RoomBaseInfo> instances = null;

            db = DatabaseFactory.CreateDatabase();
            sqlCommand = STMT_GETROOMLIST;
            dbCommand = db.GetSqlStringCommand(sqlCommand);

            // Get results.
            using (IDataReader objReader = db.ExecuteReader(dbCommand))
            {
                instances = ReadReaders(objReader);
            }
            return instances;
        }

        public IList<RoomBaseInfo> GetRoomListByUserId(int userId)
        {
            Database db;
            string sqlCommand;
            DbCommand dbCommand;
            IList<RoomBaseInfo> instances = null;

            db = DatabaseFactory.CreateDatabase();
            sqlCommand = STMT_GETROOMLISTBYUSERID;
            dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@userId", DbType.Int32, userId);

            // Get results.
            using (IDataReader objReader = db.ExecuteReader(dbCommand))
            {
                instances = ReadReaders(objReader);
            }
            return instances;
        
        }

        public int? AddRoom(RoomBaseInfo room){
            Database db;
            string sqlCommand;
            DbCommand dbCommand;
            int? roomId = 0;
            bool returnValue = false;

            db = DatabaseFactory.CreateDatabase();
            sqlCommand = STMT_ADDROOM;
            dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@distName", DbType.String, room.RoomName);
            db.AddInParameter(dbCommand, "@nickName", DbType.String, room.RoomNickName);
            db.AddInParameter(dbCommand, "@distAddress", DbType.String, room.RoomAddress);
            db.AddInParameter(dbCommand, "@distDesc", DbType.String, room.RoomDescription);
            db.AddInParameter(dbCommand, "@contact_primary", DbType.String, room.PrimaryContact);
            db.AddInParameter(dbCommand, "@phoneNumber_primary", DbType.String, room.PrimaryPhoneNumber);
            db.AddInParameter(dbCommand, "@contact_bak1", DbType.String, room.Bak1Contact);
            db.AddInParameter(dbCommand, "@phoneNumber_bak1", DbType.String, room.Bak1PhoneNumber);
            db.AddInParameter(dbCommand, "@contact_bak2", DbType.String, room.Bak2Contact);
            db.AddInParameter(dbCommand, "@phoneNumber_bak2", DbType.String, room.Bak2PhoneNumber);
            //@distName,@nickName,@distAddress,@distDesc,@contact_primary,@phoneNumber_primary,@contact_bak1
            //,@phoneNumber_bak1,@contact_bak2,@phoneNumber_bak2
            // Get results.
            using (IDataReader objReader = db.ExecuteReader(dbCommand))
            {
                if(objReader.Read()){
                    returnValue = true;
                    roomId = objReader["RoomId"] != DBNull.Value ? Convert.ToInt32(objReader["RoomId"] ):roomId = null;
                }
            }
            if( returnValue)
                  return null;
            else
                return roomId;
        }

        public void DeleteRoom(int roomId)
        {
            Database db;
            string sqlCommand;
            DbCommand dbCommand;

            db = DatabaseFactory.CreateDatabase();
            sqlCommand = STMT_DELETEROOM;
            dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@distId", DbType.Int32, roomId);

            // Get results.
            db.ExecuteNonQuery(dbCommand);

            return;
        }

        public void UpdateRoom(RoomBaseInfo room){
            Database db;
            string sqlCommand;
            DbCommand dbCommand;

            db = DatabaseFactory.CreateDatabase();
            sqlCommand = STMT_UPDATEROOM;
            dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@distName", DbType.String, room.RoomName);
            db.AddInParameter(dbCommand, "@nickName", DbType.String, room.RoomNickName);
            db.AddInParameter(dbCommand, "@distAddress", DbType.String, room.RoomAddress);
            db.AddInParameter(dbCommand, "@distDesc", DbType.String, room.RoomDescription);
            db.AddInParameter(dbCommand, "@contact_primary", DbType.String, room.PrimaryContact);
            db.AddInParameter(dbCommand, "@phoneNumber_primary", DbType.String, room.PrimaryPhoneNumber);
            db.AddInParameter(dbCommand, "@contact_bak1", DbType.String, room.Bak1Contact);
            db.AddInParameter(dbCommand, "@phoneNumber_bak1", DbType.String, room.Bak1PhoneNumber);
            db.AddInParameter(dbCommand, "@contact_bak2", DbType.String, room.Bak2Contact);
            db.AddInParameter(dbCommand, "@phoneNumber_bak2", DbType.String, room.Bak2PhoneNumber);
            db.AddInParameter(dbCommand, "@distId", DbType.Int32, room.RoomId);
            //@distName,@nickName,@distAddress,@distDesc,@contact_primary,@phoneNumber_primary,@contact_bak1
            //,@phoneNumber_bak1,@contact_bak2,@phoneNumber_bak2
            // Get results.
            db.ExecuteNonQuery(dbCommand);

            return;
        }

        public void AddDeviceToRoom(int deviceId, int roomId){
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

        public void DeleteDeviceFromRoom(int deviceId, int roomId){
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
   
}
