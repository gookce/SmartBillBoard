using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SmartBillBoard.Models.Helpers
{
    public class ConnectToSQL
    {
        public static List<Banner> questions = new List<Banner>();
        public static List<SaleInfo> users = new List<SaleInfo>();
        public static string connectionString = "Server=sqlserverkullan.cloudapp.net,1433;Integrated Security = false; User ID =gokce; Password=12345";

        public static void SetQuestions()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "Select * from Account";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Banner question = new Banner();
                        //question.QuestionNo = Convert.ToInt32(dr["QUESTION_NO"]);
                        //question.QuestionRow = Convert.ToInt32(dr["QUESTION_ROW"]);
                        questions.Add(question);
                    }
                    connection.Close();
                }
            }
        }

        public static void GetMergeInfo()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "Operation";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SaleInfo userInfo = new SaleInfo();
                        //userInfo.C3POTaskID = dr["TASK_EXT_ID"].ToString();
                        //userInfo.ChenkInUser = dr["NAME"].ToString();
                        users.Add(userInfo);
                    }
                    connection.Close();
                }
            }
        }
    }
}
