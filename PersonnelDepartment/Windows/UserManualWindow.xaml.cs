using System.IO;
using System.Reflection;
using System.Windows;

namespace PersonnelDepartment.Windows
{
    /// <summary>
    /// Логика взаимодействия для UserManualWindow.xaml
    /// </summary>
    public partial class UserManualWindow : Window
    {
        public UserManualWindow()
        {
            InitializeComponent();
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "PersonnelDepartment.Manual.txt";

            using(Stream stream = assembly.GetManifestResourceStream(resourceName))
            using(StreamReader reader = new StreamReader(stream))
                Manual.Text = reader.ReadToEnd();
        }
    }
}
