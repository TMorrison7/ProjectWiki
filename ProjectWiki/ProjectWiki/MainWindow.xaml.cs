﻿using System;
using System.Collections.Generic;
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
            checkDate(start_date, end_date);
            MessageBox.Show(start_date + " - " + end_date);
        }

        private void checkDate(String start_date, String end_date)
        {
            String errorMessage = "";
            int startdate = Int32.Parse(start_date);
            int enddate = Int32.Parse(end_date);
            if (startdate < enddate)
            {
                if (startdate > 0 && startdate < 2019)
                {
                    
                }
                else if (enddate > 0 && enddate < 2019)
                {

                }
                else
                {
                    errorMessage = "Your end date or start date is invalid.";
                }
            }
            else
            {
                errorMessage = "Your start date and end date are switched.";
            }
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
    }
}
