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
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Collections;
using System.Configuration;
using UIControls;
using System.Collections.Generic;

namespace Mosaic_Toolkit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<string> sections = new List<string> { "Author", "Title", "Comment" };
            wrkSearchA.SectionsList = sections;
            wrkSearchB.SectionsList = sections;

            wrkSearchA.SectionsStyle = SearchTextBox.SectionsStyles.RadioBoxStyle;
            wrkSearchB.SectionsStyle = SearchTextBox.SectionsStyles.RadioBoxStyle;

            wrkSearchA.OnSearch += new RoutedEventHandler(wrkSearchA_OnSearch);
            wrkSearchB.OnSearch += new RoutedEventHandler(wrkSearchB_OnSearch);
        }

        private void wrkSearchB_OnSearch(object sender, RoutedEventArgs e)
        {

            
        }

        private void wrkSearchA_OnSearch(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Help_Button_Click(object sender, RoutedEventArgs e)
        {
            var helpWin = new Help();
            helpWin.Show();
        }
    }
}
