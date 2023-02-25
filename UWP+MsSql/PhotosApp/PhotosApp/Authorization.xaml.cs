using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace PhotosApp
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class Authorization : Page
    {
        public Authorization()
        {
            this.InitializeComponent();
        }

        private async void SignInBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<int> userCheck = new List<int>();
                int userId = Convert.ToInt32(LoginTb.Text);
                using (Контекст db = new Контекст())
                {
                    userCheck = db.Фотографии.Where(a => a.Код_пользователя == userId).Select(b => b.Код_пользователя).ToList();
                }
                if (userId == userCheck[0])
                {
                    var dialog = new MessageDialog("Suckesfull!");
                    await dialog.ShowAsync();
                    MainFrame.Content = new PhotosPage(userCheck[0]);
                }
            }
            catch
            {
                var dialog2 = new MessageDialog("No user! Sorry");
                await dialog2.ShowAsync();
            }
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
