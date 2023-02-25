using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class PhotosPage : Page
    {
        bool chekScreen = false;
        int number = 1;
        public PhotosPage()
        {
            this.InitializeComponent();
            this.Loaded += PhotosPage_Loaded;
            MainImages.Margin = new Thickness(339,131,469,175);
            MainImages.Width = 1100;
            MainImages.Height = 700;

        }
        private async void PhotosPage_Loaded(object sender, RoutedEventArgs e)
        {
            using (Контекст db = new Контекст())
            {
                List<String> AuthorComm = db.Фотографии.Where(a => a.Код_фотографии == number).Select(b => b.Комментарий_автора).ToList();
                List<String> comm = db.Комментарий.Where(p => p.Код_фотографии == number).Select(c => c.Коментарий).ToList();
                CommeList.ItemsSource = comm;
                AuthorCommLB.ItemsSource = AuthorComm;
            }
            Windows.UI.Xaml.Media.Imaging.BitmapImage bitmap = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
            bitmap.UriSource = new Uri("ms-appx:///Assets/Photos/1.jpg");
            MainImages.Source = bitmap;
        }

        private void NextImageBT_Click(object sender, RoutedEventArgs e)
        {
            number++;
            switch(number)
            {
                case 1:
                    using (Контекст db = new Контекст())
                    {
                        List<String> AuthorComm = db.Фотографии.Where(a => a.Код_фотографии == number).Select(b => b.Комментарий_автора).ToList();
                        List<String> comm = db.Комментарий.Where(p => p.Код_фотографии == number).Select(c => c.Коментарий).ToList();
                        CommeList.ItemsSource = comm;
                        AuthorCommLB.ItemsSource = AuthorComm;
                        TbNames.Text = "User23331";
                        CountOfPictureTB.Text = $"{number}/6";
                    }
                    Windows.UI.Xaml.Media.Imaging.BitmapImage bitmap = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                    bitmap.UriSource = new Uri("ms-appx:///Assets/Photos/1.jpg");
                    MainImages.Source = bitmap;
                    break;
                case 2:
                    using (Контекст db = new Контекст())
                    {
                        List<String> AuthorComm = db.Фотографии.Where(a => a.Код_фотографии == number).Select(b => b.Комментарий_автора).ToList();
                        List<String> comm = db.Комментарий.Where(p => p.Код_фотографии == number).Select(c => c.Коментарий).ToList();
                        CommeList.ItemsSource = comm;
                        AuthorCommLB.ItemsSource = AuthorComm;
                        TbNames.Text = "Vania_2000";
                        CountOfPictureTB.Text = $"{number}/6";
                    }
                    Windows.UI.Xaml.Media.Imaging.BitmapImage bitmap1 = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                    bitmap1.UriSource = new Uri("ms-appx:///Assets/Photos/2.jpg");
                    MainImages.Source = bitmap1;
                    break;
                case 3:
                    using (Контекст db = new Контекст())
                    {
                        List<String> AuthorComm = db.Фотографии.Where(a => a.Код_фотографии == number).Select(b => b.Комментарий_автора).ToList();
                        List<String> comm = db.Комментарий.Where(p => p.Код_фотографии == number).Select(c => c.Коментарий).ToList();
                        CommeList.ItemsSource = comm;
                        AuthorCommLB.ItemsSource = AuthorComm;
                        TbNames.Text = "Anonimus33";
                        CountOfPictureTB.Text = $"{number}/6";
                    }
                    Windows.UI.Xaml.Media.Imaging.BitmapImage bitmap2 = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                    bitmap2.UriSource = new Uri("ms-appx:///Assets/Photos/3.jpg");
                    MainImages.Source = bitmap2;
                    break;
                case 4:
                    using (Контекст db = new Контекст())
                    {
                        List<String> AuthorComm = db.Фотографии.Where(a => a.Код_фотографии == number).Select(b => b.Комментарий_автора).ToList();
                        List<String> comm = db.Комментарий.Where(p => p.Код_фотографии == number).Select(c => c.Коментарий).ToList();
                        CommeList.ItemsSource = comm;
                        AuthorCommLB.ItemsSource = AuthorComm;
                        TbNames.Text = "Sveta_Kolcheva43";
                        CountOfPictureTB.Text = $"{number}/6";
                    }
                    Windows.UI.Xaml.Media.Imaging.BitmapImage bitmap3 = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                    bitmap3.UriSource = new Uri("ms-appx:///Assets/Photos/4.jpg");
                    MainImages.Source = bitmap3;
                    break;
                case 5:
                    using (Контекст db = new Контекст())
                    {
                        List<String> AuthorComm = db.Фотографии.Where(a => a.Код_фотографии == number).Select(b => b.Комментарий_автора).ToList();
                        List<String> comm = db.Комментарий.Where(p => p.Код_фотографии == number).Select(c => c.Коментарий).ToList();
                        CommeList.ItemsSource = comm;
                        AuthorCommLB.ItemsSource = AuthorComm;
                        TbNames.Text = "Kirill_Vasiliev2004";
                        CountOfPictureTB.Text = $"{number}/6";
                    }
                    Windows.UI.Xaml.Media.Imaging.BitmapImage bitmap4 = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                    bitmap4.UriSource = new Uri("ms-appx:///Assets/Photos/5.jpg");
                    MainImages.Source = bitmap4;
                    break;
                case 6:
                    using (Контекст db = new Контекст())
                    {
                        List<String> AuthorComm = db.Фотографии.Where(a => a.Код_фотографии == number).Select(b => b.Комментарий_автора).ToList();
                        List<String> comm = db.Комментарий.Where(p => p.Код_фотографии == number).Select(c => c.Коментарий).ToList();
                        CommeList.ItemsSource = comm;
                        AuthorCommLB.ItemsSource = AuthorComm;
                        TbNames.Text = "Alisa_LoveTravel";
                        CountOfPictureTB.Text = $"{number}/6";
                    }
                    Windows.UI.Xaml.Media.Imaging.BitmapImage bitmap5 = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                    bitmap5.UriSource = new Uri("ms-appx:///Assets/Photos/6.jpg");
                    MainImages.Source = bitmap5;
                    break;
                default:
                    number = 1;
                    using (Контекст db = new Контекст())
                    {
                        List<String> AuthorComm = db.Фотографии.Where(a => a.Код_фотографии == number).Select(b => b.Комментарий_автора).ToList();
                        List<String> comm = db.Комментарий.Where(p => p.Код_фотографии == number).Select(c => c.Коментарий).ToList();
                        CommeList.ItemsSource = comm;
                        AuthorCommLB.ItemsSource = AuthorComm;
                        TbNames.Text = "User23331";
                        CountOfPictureTB.Text = $"{number}/6";
                    }
                    Windows.UI.Xaml.Media.Imaging.BitmapImage bitmap6 = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                    bitmap6.UriSource = new Uri("ms-appx:///Assets/Photos/1.jpg");
                    MainImages.Source = bitmap6;
                    break;
            }
              
        }

        private void LastImageBT_Click(object sender, RoutedEventArgs e)
        {
            number--;
            switch (number)
            {
                case 1:
                    using (Контекст db = new Контекст())
                    {
                        List<String> AuthorComm = db.Фотографии.Where(a => a.Код_фотографии == number).Select(b => b.Комментарий_автора).ToList();
                        List<String> comm = db.Комментарий.Where(p => p.Код_фотографии == number).Select(c => c.Коментарий).ToList();
                        CommeList.ItemsSource = comm;
                        AuthorCommLB.ItemsSource = AuthorComm;
                        TbNames.Text = "User23331";
                        CountOfPictureTB.Text = $"{number}/6";
                    }
                    Windows.UI.Xaml.Media.Imaging.BitmapImage bitmap = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                    bitmap.UriSource = new Uri("ms-appx:///Assets/Photos/1.jpg");
                    MainImages.Source = bitmap;
                    break;
                case 2:
                    using (Контекст db = new Контекст())
                    {
                        List<String> AuthorComm = db.Фотографии.Where(a => a.Код_фотографии == number).Select(b => b.Комментарий_автора).ToList();
                        List<String> comm = db.Комментарий.Where(p => p.Код_фотографии == number).Select(c => c.Коментарий).ToList();
                        CommeList.ItemsSource = comm;
                        AuthorCommLB.ItemsSource = AuthorComm;
                        TbNames.Text = "Vania_2000";
                        CountOfPictureTB.Text = $"{number}/6";
                    }
                    Windows.UI.Xaml.Media.Imaging.BitmapImage bitmap1 = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                    bitmap1.UriSource = new Uri("ms-appx:///Assets/Photos/2.jpg");
                    MainImages.Source = bitmap1;
                    break;
                case 3:

                    using (Контекст db = new Контекст())
                    {
                        List<String> AuthorComm = db.Фотографии.Where(a => a.Код_фотографии == number).Select(b => b.Комментарий_автора).ToList();
                        List<String> comm = db.Комментарий.Where(p => p.Код_фотографии == number).Select(c => c.Коментарий).ToList();
                        CommeList.ItemsSource = comm;
                        AuthorCommLB.ItemsSource = AuthorComm;
                        TbNames.Text = "Anonimus33";
                        CountOfPictureTB.Text = $"{number}/6";
                    }
                    Windows.UI.Xaml.Media.Imaging.BitmapImage bitmap2 = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                    bitmap2.UriSource = new Uri("ms-appx:///Assets/Photos/3.jpg");
                    MainImages.Source = bitmap2;
                    break;
                case 4:
                    using (Контекст db = new Контекст())
                    {
                        List<String> AuthorComm = db.Фотографии.Where(a => a.Код_фотографии == number).Select(b => b.Комментарий_автора).ToList();
                        List<String> comm = db.Комментарий.Where(p => p.Код_фотографии == number).Select(c => c.Коментарий).ToList();
                        CommeList.ItemsSource = comm;
                        AuthorCommLB.ItemsSource = AuthorComm;
                        TbNames.Text = "Sveta_Kolcheva43";
                        CountOfPictureTB.Text = $"{number}/6";
                    }
                    Windows.UI.Xaml.Media.Imaging.BitmapImage bitmap3 = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                    bitmap3.UriSource = new Uri("ms-appx:///Assets/Photos/4.jpg");
                    MainImages.Source = bitmap3;
                    break;
                case 5:
                    using (Контекст db = new Контекст())
                    {
                        List<String> AuthorComm = db.Фотографии.Where(a => a.Код_фотографии == number).Select(b => b.Комментарий_автора).ToList();
                        List<String> comm = db.Комментарий.Where(p => p.Код_фотографии == number).Select(c => c.Коментарий).ToList();
                        CommeList.ItemsSource = comm;
                        AuthorCommLB.ItemsSource = AuthorComm;
                        TbNames.Text = "Kirill_Vasiliev2004";
                        CountOfPictureTB.Text = $"{number}/6";
                    }
                    Windows.UI.Xaml.Media.Imaging.BitmapImage bitmap4 = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                    bitmap4.UriSource = new Uri("ms-appx:///Assets/Photos/5.jpg");
                    MainImages.Source = bitmap4;
                    break;
                case 6:
                    using (Контекст db = new Контекст())
                    {
                        List<String> AuthorComm = db.Фотографии.Where(a => a.Код_фотографии == number).Select(b => b.Комментарий_автора).ToList();
                        List<String> comm = db.Комментарий.Where(p => p.Код_фотографии == number).Select(c => c.Коментарий).ToList();
                        CommeList.ItemsSource = comm;
                        AuthorCommLB.ItemsSource = AuthorComm;
                        TbNames.Text = "Alisa_LoveTravel";
                        CountOfPictureTB.Text = $"{number}/6";
                    }
                    Windows.UI.Xaml.Media.Imaging.BitmapImage bitmap5 = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                    bitmap5.UriSource = new Uri("ms-appx:///Assets/Photos/6.jpg");
                    MainImages.Source = bitmap5;
                    break;
                default:
                    number = 1;
                    using (Контекст db = new Контекст())
                    {
                        List<String> AuthorComm = db.Фотографии.Where(a => a.Код_фотографии == number).Select(b => b.Комментарий_автора).ToList();
                        List<String> comm = db.Комментарий.Where(p => p.Код_фотографии == number).Select(c => c.Коментарий).ToList();
                        CommeList.ItemsSource = comm;
                        AuthorCommLB.ItemsSource = AuthorComm;
                        TbNames.Text = "User23331";
                        CountOfPictureTB.Text = $"{number}/6";
                    }
                    Windows.UI.Xaml.Media.Imaging.BitmapImage bitmap6 = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                    bitmap6.UriSource = new Uri("ms-appx:///Assets/Photos/1.jpg");
                    MainImages.Source = bitmap6;
                    break;
            }
        }

        private void FullScreenBT_Click(object sender, RoutedEventArgs e)
        {
            switch (chekScreen)
            {
                case true:
                    MainImages.Margin = new Thickness(0,0,0,0);
                    MainImages.Width = 1920;
                    MainImages.Height = 1080;
                    chekScreen = false;
                    break;
                case false:
                    MainImages.Margin = new Thickness(339, 131, 469, 175);
                    MainImages.Width = 1100;
                    MainImages.Height = 700;
                    chekScreen = true;
                    break;
            }
        }
    }
}
