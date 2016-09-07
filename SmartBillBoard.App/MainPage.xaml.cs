using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
//using SmartBillBoard.Models.Helpers;
//using SmartBillBoard.Models;
using System.Data.SqlClient;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SmartBillBoard.App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
                          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SetQuestions();
        }

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
                        //Banner question = new Banner();
                        ////question.QuestionNo = Convert.ToInt32(dr["QUESTION_NO"]);
                        ////question.QuestionRow = Convert.ToInt32(dr["QUESTION_ROW"]);
                        //questions.Add(question);
                    }
                    connection.Close();
                }
            }
        }
    }
}
