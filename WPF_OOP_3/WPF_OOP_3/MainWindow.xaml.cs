using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
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

			Thread t1 = new Thread(new ThreadStart(SeverStatus));
			t1.IsBackground = true;
			t1.Start();
		}

		private void SeverStatus()
		{
			while (true)
            {
				SqlConnection joeTest = new SqlConnection(connectionString);
				SqlConnection joeGrid = new SqlConnection(connectionString);
				try
				{
					joeTest.Open();
					Dispatcher.Invoke(new Action(() =>
					{
						connectText.Text = $"Server Status: {joeTest.State}";
					}));
					joeTest.Close();
				}
				catch (Exception)
				{
					Dispatcher.Invoke(new Action(() =>
					{
						connectText.Text = "Server Status: Closed";
					}));
				}

				joeGrid.Open();

				SqlCommand cmd = new SqlCommand();
				cmd.CommandText = "select * from [MovieTable]";
				cmd.Connection = joeGrid;
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable("MovieTable");
				da.Fill(dt);

				Dispatcher.Invoke(new Action(() =>
				{
					MovieTableGrid.ItemsSource = dt.DefaultView;
				}));

				Thread.Sleep(5000);
			}
		}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
			SqlDataAdapter adapter = new SqlDataAdapter();
			SqlConnection cnn = new SqlConnection(connectionString);
			SqlCommand command;
			string sql = "";

			try
            {
				cnn.Open();

				sql = $"Insert into MovieTable (Name,Director,YearOfRelease) values('{Name.Text}','{Director.Text}',{YearOfRelease.Text})";

				command = new SqlCommand(sql, cnn);

				adapter.InsertCommand = new SqlCommand(sql, cnn);
				adapter.InsertCommand.ExecuteNonQuery();

				command.Dispose();
				cnn.Close();
			}
			catch (Exception)
            {
				MessageBox.Show("You have til fill the form out");
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
			SqlDataAdapter adapter = new SqlDataAdapter();
			SqlConnection cnn = new SqlConnection(connectionString);
			SqlCommand command;
			string sql = "";

			cnn.Open();

			sql =  $"Delete MovieTable where Name='{Name.Text}' and Director='{Director.Text}' and YearOfRelease={YearOfRelease.Text}";

			adapter.DeleteCommand = new SqlCommand(sql, cnn);
			adapter.DeleteCommand.ExecuteNonQuery();

			command = new SqlCommand(sql, cnn);
			cnn.Close();
		}
    }
}
