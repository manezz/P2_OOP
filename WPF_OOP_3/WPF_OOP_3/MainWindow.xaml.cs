﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Drawing;
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

namespace WPF_OOP_3
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		string connectionString = @"Data Source=192.168.4.124;Initial Catalog = joe; User ID = sa; Password=Passw0rd;Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
		

		public MainWindow()
		{
			InitializeComponent();
		}

		private void connectButton_Click(object sender, RoutedEventArgs e)
		{
			SqlConnection cnn = new SqlConnection(connectionString);
			cnn.Open();
			if (cnn.State == ConnectionState.Open)
            {
				MessageBox.Show("Open");
            }
			else
            {
				MessageBox.Show("Closed");
            }
		}
	}
}
