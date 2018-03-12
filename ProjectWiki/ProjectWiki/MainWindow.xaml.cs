using System;
using System.Data.SqlClient;
using System.Windows;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;
using System.Text;
using System.Windows.Controls;

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
                String connection = "Server=NULL-VALUE\\JACOBSQL;Database=Wikipedia;Trusted_Connection=Yes"; //change connection string
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
            String query = "Select top 100 * from item_table where start_year <= '" + enddate + "-12-31' and end_year >= '" + startdate + "-01-01' or start_year <= '" + startdate + "-01-01' and end_year >= '" + enddate + "-12-31'";
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

        public async Task mongoConnection(String id)
        {
            String connectionString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase db = client.GetDatabase("wikipedia"); //change for the DB
            var collection = db.GetCollection<BsonDocument>("wiki"); //change text for the Collection
            var filter = "{ _ID: {$lte: '" + id + "'}}";
            await collection.Find(filter).ForEachAsync(document => 
            { MessageBox.Show(document.ToString()); });

            //Console.WriteLine(document));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                string id_search = ID_Search.Text;
                byte[] utf8bytes = Encoding.UTF8.GetBytes(id_search);
                byte[] unicodebytes = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, utf8bytes);
                String code = Encoding.Unicode.GetString(unicodebytes);
                MessageBox.Show(code);
                mongoConnection(Encoding.Unicode.GetString(unicodebytes));
        }
        //this is where the shit breaks cause of unicode.
       
    }
}
