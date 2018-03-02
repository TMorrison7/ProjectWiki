using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectWiki
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
    
        public MainWindow()
        {
            InitializeComponent();

        
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            String start_date = startDate.Text;
            String end_date = endDate.Text;
            bool error = checkDate(start_date, end_date);
            if (error == true)
            {
                String query = sqlQuery(start_date, end_date);
                String connection = "Data Source=ServerName;Intial Catalog=DatabaseName;User ID=Username;Password=password"; //change connection string
                getData(query, connection); 

            }
            else
            {
                MessageBox.Show("Invalid Input. Try Again");
            }
            
        }

        private bool checkDate(String start_date, String end_date)
        {
            bool isValid = false;
            if (String.IsNullOrWhiteSpace(start_date) || String.IsNullOrWhiteSpace(end_date))
            {
                isValid = false;
            }
            else
            {
                int startdate = Int32.Parse(start_date);
                int enddate = Int32.Parse(end_date);
                if (startdate < enddate)
                {
                    if (startdate > 0 && startdate < 2019)
                    {
                        isValid = true;
                    }
                    else
                    {
                        isValid = false;
                    }
                }
                else
                {
                    isValid = false;
                }
            }
            return isValid;
        }

        static bool startBeenFocused = false;
        private void startDate_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!startBeenFocused)
            {
                startDate.Text = "";
                startBeenFocused = true;
            }
        }

        static bool endBeenFocused = false;
        private void endDate_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!endBeenFocused)
            {
                endDate.Text = "";
                endBeenFocused = true;
            }
        }
        private String sqlQuery(String startdate, String enddate)
        {
            String query = "Select * from item_table where start_year <= '" + enddate + "-12-31' and end_year >= '" + startdate + "-01-01' or start_year <= '" + startdate + "-01-01' and end_year >= '" + enddate + "-12-31'";
            return query;
        }

        public static void getData(String queryString, String connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }

        }
    }
}
