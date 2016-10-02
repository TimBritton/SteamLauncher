using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace SteamLauncher
{
	/// <summary>
	/// Interaction logic for FolderEntryxaml.xaml
	/// </summary>
	public partial class FolderEntry : System.Windows.Controls.UserControl
	{
		public FolderEntry()
		{
			InitializeComponent();
		}

     public static DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(FolderEntry), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    public static DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(FolderEntry), new PropertyMetadata(null));

    public string Text { get { return GetValue(TextProperty) as string; } set { SetValue(TextProperty, value); }}

    public string Description { get { return GetValue(DescriptionProperty) as string; } set { SetValue(DescriptionProperty, value); } }

  //public FolderEntry() {}

    private void BrowseFolder(object sender, RoutedEventArgs e) {
        using (FolderBrowserDialog dlg = new FolderBrowserDialog()) {
            dlg.Description = Description;
            dlg.SelectedPath = Text;
            dlg.ShowNewFolderButton = true;
            DialogResult result = dlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK) {
                Text = dlg.SelectedPath;
                BindingExpression be = GetBindingExpression(TextProperty);
                if (be != null)
                    be.UpdateSource();
            }
        }
    }


    internal bool hasResults()
    {
        return (!(Text == String.Empty));
    }
    }
}