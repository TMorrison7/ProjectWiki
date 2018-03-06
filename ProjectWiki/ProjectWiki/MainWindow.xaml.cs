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
            dataResult.Items.Clear();
            String start_date = startDate.Text;
            String end_date = endDate.Text;
            bool error = checkDate(start_date, end_date);
            if (error == true)
            {
                String query = sqlQuery(start_date, end_date);
                String connection = "Server=RYANLAPTOP;Database=WikipediaTest;Trusted_Connection=Yes"; //change connection string

                SqlConnection connector = new SqlConnection(connection);
                SqlDataReader reader;
                connector.Open();

                SqlCommand command = new SqlCommand(query, connector);
                reader = command.ExecuteReader();

                if(!reader.HasRows) {

                    MessageBox.Show("Invalid Input. Try Again");
     
                }
                else
                {
                    while (reader.Read())
                    {
                        WikiDataSet set = new WikiDataSet();
                        set.page_name = reader.GetString(1);
                        set.blurb = reader.GetString(4);
                        set.start_year = reader.GetDateTime(2);
                        set.end_year = reader.GetDateTime(3);
                        set.unique_id = reader.GetString(0);

                        dataResult.Items.Add(set);
                    }

                   
                }
                

            }
            else
            {
                MessageBox.Show("Invalid Input. Try Again");
            }

        }

        private bool checkDate(String start_date, String end_date)
        {
            bool isValid = false;
            if (String.IsNullOrWhiteSpace(start_date) || start_date.Contains("Start Date") || end_date.Contains("End Date") || String.IsNullOrWhiteSpace(end_date))
            {
                isValid = false;
            }
            else
            {
                int startdate = Int32.Parse(start_date);
                int enddate = Int32.Parse(end_date);
                if (startdate < enddate)
                {
                    if (startdate> 0 && startdate < enddate)
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
            SqlConnection connector = new SqlConnection(connectionString);
            SqlDataReader reader;
            connector.Open();

            SqlCommand command = new SqlCommand(queryString);
            reader = command.ExecuteReader();
           

           
        }
    }
}
