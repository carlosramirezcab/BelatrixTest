using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BelatrixTest.Domain.Log;

namespace BelatrixTest.Repository
{
    public class LogRepository
    {
        private string _connectionString = "";

        public LogRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logMessage"></param>
        public void LogMessage(LogMessage logMessage)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var selectCommand = new SqlCommand("spuInsertLog", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    selectCommand.Parameters.AddWithValue("@Message", logMessage.Message).SqlDbType = SqlDbType.NVarChar;
                    selectCommand.Parameters.AddWithValue("@Type", (int)logMessage.Type).SqlDbType = SqlDbType.Int;

                    connection.Open();
                    selectCommand.ExecuteNonQuery();
                    connection.Close();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
