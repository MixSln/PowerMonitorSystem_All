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
                      FROM [PowerMonitor].[dbo].[distribution]
                        Where distId = @distId";
        private static string STMT_GETROOMLIST = @"SELECT [distId]
                          ,[distName],[nickName],[distAddress],[distDesc],[contact_primary]
                          ,[phoneNumber_primary],[contact_bak1],[phoneNumber_bak1],[contact_bak2],[phoneNumber_bak2]
                      FROM [PowerMonitor].[dbo].[distribution]";

        private static string STMT_GETROOMLISTBYUSERID = @"SELECT a.[distId]
                          ,[distName],[nickName],[distAddress],[distDesc],[contact_primary]
                          ,[phoneNumber_primary],[contact_bak1],[phoneNumber_bak1],[contact_bak2],[phoneNumber_bak2]
                      FROM [PowerMonitor].[dbo].[distribution] a
                      JOIN dbo.userDistribution b on a.distId = b.distId
                      where b.userId = @userId";
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
        

            public int AddRoom(RoomBaseInfo room){

            }
    }
}
