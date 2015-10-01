using System;
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
using FeserWard.Controls;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Collections;
using System.Configuration;

namespace Mosaic_Toolkit
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	/// 
	public partial class MainWindow : Window
	{
		public IIntelliboxResultsProvider WorkerA
		{
			get;
			private set;
		}

		public IIntelliboxResultsProvider WorkerB
		{
			get;
			private set;
		}
		public MainWindow()
		{
			InitializeComponent();
			WorkerA = new WorkerSearchBox();
			WorkerB = new WorkerSearchBox();
		}

		private void WorkerASearchBox_LostFocus(object sender, RoutedEventArgs e)
		{
			getAllocations();
		}


		private void WorkerBSearchBox_LostFocus(object sender, RoutedEventArgs e)
		{

		}

		private void getAllocations()
		{
			throw new NotImplementedException();
		}
	}

	public class WorkerSearchBox : IIntelliboxResultsProvider
	{
		public IEnumerable DoSearch(string searchTerm, int maxResults, object extraInfo)
		{
			var query = String.Format(@" select 
															ID	'ID',
															(first_names + ' ' + last_names) 'Name',
															SYSTEM_USER_ID	'Username',
															LAST_LOGON	'Last Login'
														from WORKERS with(nolock)
														where 
														(first_names + ' ' + last_names) like '%{0}%'", searchTerm);
			var ds = new DataSet();
			var reader = new AppSettingsReader();
			var sCon = reader.GetValue("MOSTEST", typeof(string));
			try
			{
				using (var con = new SqlConnection())
				{
					con.ConnectionString = (string)sCon;
					var da = new SqlDataAdapter(query, con);
					da.Fill(ds);
				}
				return ((IListSource)ds.Tables[0]).GetList();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return null;
			}

		}
	}
}
