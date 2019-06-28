using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace extractFromFolder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string getInitialInput;
        string getInitialOutput;
        public MainWindow()
        {
            InitializeComponent();
            getInitialInput = txtbk_input.Text;
            getInitialOutput = txtbk_output.Text;

        }

        private void Btn_input_Click(object sender, RoutedEventArgs e)
        {
            var folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            var result = folderDialog.ShowDialog();
            switch (result)
            {
                case System.Windows.Forms.DialogResult.OK:
                    var folderpath = folderDialog.SelectedPath;
                    txtbk_input.Text = folderpath;
                    txtbk_input.ToolTip = folderpath;
                    break;
                case System.Windows.Forms.DialogResult.Cancel:
                default:
                    //txtbk_input.Text = null;
                    //txtbk_input.ToolTip = null;
                    break;
            }
        }

        private void Btn_output_Click(object sender, RoutedEventArgs e)
        {
            var folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            var result = folderDialog.ShowDialog();
            switch (result)
            {
                case System.Windows.Forms.DialogResult.OK:
                    var folderpath = folderDialog.SelectedPath;
                    txtbk_output.Text = folderpath;
                    txtbk_output.ToolTip = folderpath;
                    break;
                case System.Windows.Forms.DialogResult.Cancel:
                default:
                    //txtbk_output.Text = null;
                    //txtbk_output.ToolTip = null;
                    break;
            }
        }

        private void Btn_start_Click(object sender, RoutedEventArgs e)
        {
            if (txtbk_output.ToolTip != null && txtbk_input.ToolTip != null)
            {
                try
                {
                    //Main code goes here!
                    List<string> allfiles = Directory.GetFiles(txtbk_input.Text, "*", SearchOption.AllDirectories).ToList();
                    foreach (String file in allfiles)
                    {
                        //Console.WriteLine(file);// Test case to print out
                        string filename = System.IO.Path.GetFileName(file);
                        string pathNamewFile = System.IO.Path.Combine(txtbk_output.Text, filename);
                        //Console.WriteLine(pathNamewFile);
                        File.Copy(file, pathNamewFile, true);
                    }

                    // Completed converting
                    txtbk_result.Text = txtbk_input.Text + " extracted to: " + txtbk_output.Text;
                    MessageBox.Show("Files extracted!", "Complete");
                }
                catch
                {
                    MessageBox.Show("Something went wrong!", "Error");
                }

            }
            else
            {
                txtbk_result.Text = "No input/output selected!";
            }
        }
        private void Hyperlink_OnClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/xjer/WIN10_extractFromFolder");

        }
    }
}
