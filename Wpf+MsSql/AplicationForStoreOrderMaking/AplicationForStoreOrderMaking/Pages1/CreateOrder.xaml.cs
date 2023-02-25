using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

namespace AplicationForStoreOrderMaking.Pages1
{
    public partial class CreateOrder : Page
    {
        List<int> differentNumbers = new List<int>();
        string AdressStroka = "";
        string DoubleInfoStroka = "";
        int random = 0;
        Random rnd = new Random();
        List<int> indexes = new List<int>();
        int counterOfIndex = 9;
        static string connectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        SqlConnection cnn = new SqlConnection(connectionString);

        public CreateOrder()
        {
            InitializeComponent();
            SaveAllBut.Visibility = Visibility.Hidden;
            ChangeOrder.Visibility = Visibility.Hidden;
            Cb1.Visibility = Visibility.Hidden;
            Cb2.Visibility = Visibility.Hidden;
            Cb3.Visibility = Visibility.Hidden;
            Cb4.Visibility = Visibility.Hidden;
            Cb5.Visibility = Visibility.Hidden;
            Cb6.Visibility = Visibility.Hidden;
            Cb7.Visibility = Visibility.Hidden;
            Cb8.Visibility = Visibility.Hidden;
            Cb9.Visibility = Visibility.Hidden;
            Cb10.Visibility = Visibility.Hidden;
            Tb1.IsEnabled = false;
            Tb2.IsEnabled = false;
            Tb3.IsEnabled = false;
            Tb4.IsEnabled = false;
            Tb5.IsEnabled = false;
            Tb6.IsEnabled = false;
            Tb7.IsEnabled = false;
            Tb8.IsEnabled = false;
            Tb9.IsEnabled = false;
            Tb10.IsEnabled = false;
            Tb1.Text = 0.ToString();
            Tb2.Text = 0.ToString();
            Tb3.Text = 0.ToString();
            Tb4.Text = 0.ToString();
            Tb5.Text = 0.ToString();
            Tb6.Text = 0.ToString();
            Tb7.Text = 0.ToString();
            Tb8.Text = 0.ToString();
            Tb9.Text = 0.ToString();
            Tb10.Text = 0.ToString();
            BtMinus1.IsEnabled = false;
            BtMinus2.IsEnabled = false;
            BtMinus3.IsEnabled = false;
            BtMinus4.IsEnabled = false;
            BtMinus5.IsEnabled = false;
            BtMinus6.IsEnabled = false;
            BtMinus7.IsEnabled = false;
            BtMinus8.IsEnabled = false;
            BtMinus9.IsEnabled = false;
            BtMinus10.IsEnabled = false;
            BtPlus1.IsEnabled = false;
            BtPlus2.IsEnabled = false;
            BtPlus3.IsEnabled = false;
            BtPlus4.IsEnabled = false;
            BtPlus5.IsEnabled = false;
            BtPlus6.IsEnabled = false;
            BtPlus7.IsEnabled = false;
            BtPlus8.IsEnabled = false;
            BtPlus9.IsEnabled = false;
            BtPlus10.IsEnabled = false;
            Tb1.Visibility = Visibility.Hidden;
            Tb2.Visibility = Visibility.Hidden;
            Tb3.Visibility = Visibility.Hidden;
            Tb4.Visibility = Visibility.Hidden;
            Tb5.Visibility = Visibility.Hidden;
            Tb6.Visibility = Visibility.Hidden;
            Tb7.Visibility = Visibility.Hidden;
            Tb8.Visibility = Visibility.Hidden;
            Tb9.Visibility = Visibility.Hidden;
            Tb10.Visibility = Visibility.Hidden;
            BtMinus1.Visibility = Visibility.Hidden;
            BtMinus2.Visibility = Visibility.Hidden;
            BtMinus3.Visibility = Visibility.Hidden;
            BtMinus4.Visibility = Visibility.Hidden;
            BtMinus5.Visibility = Visibility.Hidden;
            BtMinus6.Visibility = Visibility.Hidden;
            BtMinus7.Visibility = Visibility.Hidden;
            BtMinus8.Visibility = Visibility.Hidden;
            BtMinus9.Visibility = Visibility.Hidden;
            BtMinus10.Visibility = Visibility.Hidden;
            BtPlus1.Visibility = Visibility.Hidden;
            BtPlus2.Visibility = Visibility.Hidden;
            BtPlus3.Visibility = Visibility.Hidden;
            BtPlus4.Visibility = Visibility.Hidden;
            BtPlus5.Visibility = Visibility.Hidden;
            BtPlus6.Visibility = Visibility.Hidden;
            BtPlus7.Visibility = Visibility.Hidden;
            BtPlus8.Visibility = Visibility.Hidden;
            BtPlus9.Visibility = Visibility.Hidden;
            BtPlus10.Visibility = Visibility.Hidden;
            ListOfOrders.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cnn.Open();
            List<string> names = new List<string>();
            SqlCommand command = cnn.CreateCommand();
            command.CommandText = @"Select Код_товара from Товары";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                names.Add(String.Format("{0}", reader.GetValue(0).ToString()));
            reader.Close();
            SqlCommand command1 = cnn.CreateCommand();
            command1.CommandText = @"Select Название from Товары";
            SqlDataReader reader1 = command1.ExecuteReader();
            ListBoxTovars.Items.Clear();
            int i = 0;
            while (reader1.Read())
            {
                ListBoxTovars.Items.Add(names[i] + "." + String.Format("{0}", reader1.GetValue(0).ToString()));
                i++;
            }
            reader1.Close();
            cnn.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                List<string> index = new List<string>();
                if (ListBoxTovars.SelectedIndex == -1)
                {
                    MessageBox.Show("Вы не выбрали товар!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    index.Add(ListBoxTovars.SelectedItem.ToString());
                    for (int i = 0; i < index.Count; i++)
                    {
                        string c = index[i];
                        if (ListOfOrders.Items.Contains(c))
                        {
                            MessageBox.Show("Нельзя добавлять один и тот же товар дважды", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            switch (counterOfIndex)
                            {
                                case 9:
                                    ListOfOrders.Items.Add(ListBoxTovars.SelectedItem);
                                    BtMinus1.IsEnabled = true;
                                    BtPlus1.IsEnabled = true;
                                    Tb1.Text = 1.ToString();
                                    Tb1.Visibility = Visibility.Visible;
                                    BtPlus1.Visibility = Visibility.Visible;
                                    BtMinus1.Visibility = Visibility.Visible;
                                    Cb1.Visibility = Visibility.Visible;
                                    Cb1.SelectedIndex = 1;
                                    counterOfIndex -= 1;
                                    indexes.Add(ListBoxTovars.SelectedIndex);
                                    break;
                                case 8:
                                    ListOfOrders.Items.Add(ListBoxTovars.SelectedItem);
                                    BtMinus2.IsEnabled = true;
                                    BtPlus2.IsEnabled = true;
                                    Tb2.Text = 1.ToString();
                                    Tb2.Visibility = Visibility.Visible;
                                    BtPlus2.Visibility = Visibility.Visible;
                                    BtMinus2.Visibility = Visibility.Visible;
                                    Cb2.Visibility = Visibility.Visible;
                                    Cb2.SelectedIndex = 1;
                                    counterOfIndex -= 1;
                                    indexes.Add(ListBoxTovars.SelectedIndex);
                                    break;
                                case 7:
                                    ListOfOrders.Items.Add(ListBoxTovars.SelectedItem);
                                    BtMinus3.IsEnabled = true;
                                    BtPlus3.IsEnabled = true;
                                    Tb3.Text = 1.ToString();
                                    Tb3.Visibility = Visibility.Visible;
                                    BtPlus3.Visibility = Visibility.Visible;
                                    BtMinus3.Visibility = Visibility.Visible;
                                    Cb3.Visibility = Visibility.Visible;
                                    Cb3.SelectedIndex = 1;
                                    counterOfIndex -= 1;
                                    indexes.Add(ListBoxTovars.SelectedIndex);
                                    break;
                                case 6:
                                    ListOfOrders.Items.Add(ListBoxTovars.SelectedItem);
                                    BtMinus4.IsEnabled = true;
                                    BtPlus4.IsEnabled = true;
                                    Tb4.Text = 1.ToString();
                                    Tb4.Visibility = Visibility.Visible;
                                    BtPlus4.Visibility = Visibility.Visible;
                                    BtMinus4.Visibility = Visibility.Visible;
                                    Cb4.Visibility = Visibility.Visible;
                                    Cb4.SelectedIndex = 1;
                                    counterOfIndex -= 1;
                                    indexes.Add(ListBoxTovars.SelectedIndex);
                                    break;
                                case 5:
                                    ListOfOrders.Items.Add(ListBoxTovars.SelectedItem);
                                    BtMinus5.IsEnabled = true;
                                    BtPlus5.IsEnabled = true;
                                    Tb5.Text = 1.ToString();
                                    Tb5.Visibility = Visibility.Visible;
                                    BtPlus5.Visibility = Visibility.Visible;
                                    BtMinus5.Visibility = Visibility.Visible;
                                    Cb5.Visibility = Visibility.Visible;
                                    Cb5.SelectedIndex = 1;
                                    counterOfIndex -= 1;
                                    indexes.Add(ListBoxTovars.SelectedIndex);
                                    break;
                                case 4:
                                    ListOfOrders.Items.Add(ListBoxTovars.SelectedItem);
                                    BtMinus6.IsEnabled = true;
                                    BtPlus6.IsEnabled = true;
                                    Tb6.Text = 1.ToString();
                                    Tb6.Visibility = Visibility.Visible;
                                    BtPlus6.Visibility = Visibility.Visible;
                                    BtMinus6.Visibility = Visibility.Visible;
                                    Cb6.Visibility = Visibility.Visible;
                                    Cb6.SelectedIndex = 1;
                                    counterOfIndex -= 1;
                                    indexes.Add(ListBoxTovars.SelectedIndex);
                                    break;
                                case 3:
                                    ListOfOrders.Items.Add(ListBoxTovars.SelectedItem);
                                    BtMinus7.IsEnabled = true;
                                    BtPlus7.IsEnabled = true;
                                    Tb7.Text = 1.ToString();
                                    Tb7.Visibility = Visibility.Visible;
                                    BtPlus7.Visibility = Visibility.Visible;
                                    BtMinus7.Visibility = Visibility.Visible;
                                    Cb7.Visibility = Visibility.Visible;
                                    Cb7.SelectedIndex = 1;
                                    counterOfIndex -= 1;
                                    indexes.Add(ListBoxTovars.SelectedIndex);
                                    break;
                                case 2:
                                    ListOfOrders.Items.Add(ListBoxTovars.SelectedItem);
                                    BtMinus8.IsEnabled = true;
                                    BtPlus8.IsEnabled = true;
                                    Tb8.Text = 1.ToString();
                                    Tb8.Visibility = Visibility.Visible;
                                    BtPlus8.Visibility = Visibility.Visible;
                                    BtMinus8.Visibility = Visibility.Visible;
                                    Cb8.Visibility = Visibility.Visible;
                                    Cb8.SelectedIndex = 1;
                                    counterOfIndex -= 1;
                                    indexes.Add(ListBoxTovars.SelectedIndex);
                                    break;
                                case 1:
                                    ListOfOrders.Items.Add(ListBoxTovars.SelectedItem);
                                    BtMinus9.IsEnabled = true;
                                    BtPlus9.IsEnabled = true;
                                    Tb9.Text = 1.ToString();
                                    Tb9.Visibility = Visibility.Visible;
                                    BtPlus9.Visibility = Visibility.Visible;
                                    BtMinus9.Visibility = Visibility.Visible;
                                    Cb9.Visibility = Visibility.Visible;
                                    Cb9.SelectedIndex = 1;
                                    counterOfIndex -= 1;
                                    indexes.Add(ListBoxTovars.SelectedIndex);
                                    break;
                                case 0:
                                    ListOfOrders.Items.Add(ListBoxTovars.SelectedItem);
                                    BtMinus10.IsEnabled = true;
                                    BtPlus10.IsEnabled = true;
                                    Tb10.Text = 1.ToString();
                                    Tb10.Visibility = Visibility.Visible;
                                    BtPlus10.Visibility = Visibility.Visible;
                                    BtMinus10.Visibility = Visibility.Visible;
                                    Cb10.Visibility = Visibility.Visible;
                                    Cb10.SelectedIndex = 1;
                                    counterOfIndex -= 1;
                                    indexes.Add(ListBoxTovars.SelectedIndex);
                                    break;
                                default:
                                    counterOfIndex = 9;
                                    break;
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void BtPlus1_Click(object sender, RoutedEventArgs e)
        {
            int count = Convert.ToInt32(Tb1.Text);
            count++;
            Tb1.Text = count.ToString();
        }

        private void BtMinus1_Click(object sender, RoutedEventArgs e)
        {
            if (Tb1.Text == 1.ToString())
            {
            }
            else
            {
                int count = Convert.ToInt32(Tb1.Text);
                count--;
                Tb1.Text = count.ToString();
            }
        }

        private void BtPlus2_Click(object sender, RoutedEventArgs e)
        {
            int count = Convert.ToInt32(Tb2.Text);
            count++;
            Tb2.Text = count.ToString();
        }

        private void BtMinus2_Click(object sender, RoutedEventArgs e)
        {
            if (Tb2.Text == 1.ToString())
            {
            }
            else
            {
                int count = Convert.ToInt32(Tb2.Text);
                count--;
                Tb2.Text = count.ToString();
            }
        }

        private void BtPlus3_Click(object sender, RoutedEventArgs e)
        {
            int count = Convert.ToInt32(Tb3.Text);
            count++;
            Tb3.Text = count.ToString();
        }

        private void BtMinus3_Click(object sender, RoutedEventArgs e)
        {
            if (Tb3.Text == 1.ToString())
            {
            }
            else
            {
                int count = Convert.ToInt32(Tb3.Text);
                count--;
                Tb3.Text = count.ToString();
            }
        }

        private void BtPlus4_Click(object sender, RoutedEventArgs e)
        {
            int count = Convert.ToInt32(Tb4.Text);
            count++;
            Tb4.Text = count.ToString();
        }

        private void BtMinus4_Click(object sender, RoutedEventArgs e)
        {
            if (Tb4.Text == 1.ToString())
            {
            }
            else
            {
                int count = Convert.ToInt32(Tb4.Text);
                count--;
                Tb4.Text = count.ToString();
            }
        }

        private void BtPlus5_Click(object sender, RoutedEventArgs e)
        {
            int count = Convert.ToInt32(Tb5.Text);
            count++;
            Tb5.Text = count.ToString();
        }

        private void BtMinus5_Click(object sender, RoutedEventArgs e)
        {
            if (Tb5.Text == 1.ToString())
            {
            }
            else
            {
                int count = Convert.ToInt32(Tb5.Text);
                count--;
                Tb5.Text = count.ToString();
            }
        }

        private void BtPlus6_Click(object sender, RoutedEventArgs e)
        {
            int count = Convert.ToInt32(Tb6.Text);
            count++;
            Tb6.Text = count.ToString();
        }

        private void BtMinus6_Click(object sender, RoutedEventArgs e)
        {
            if (Tb6.Text == 1.ToString())
            {
            }
            else
            {
                int count = Convert.ToInt32(Tb6.Text);
                count--;
                Tb6.Text = count.ToString();
            }
        }

        private void BtPlus7_Click(object sender, RoutedEventArgs e)
        {
            int count = Convert.ToInt32(Tb7.Text);
            count++;
            Tb7.Text = count.ToString();
        }

        private void BtMinus7_Click(object sender, RoutedEventArgs e)
        {
            if (Tb7.Text == 1.ToString())
            {
            }
            else
            {
                int count = Convert.ToInt32(Tb7.Text);
                count--;
                Tb7.Text = count.ToString();
            }
        }

        private void BtPlus8_Click(object sender, RoutedEventArgs e)
        {
            int count = Convert.ToInt32(Tb8.Text);
            count++;
            Tb8.Text = count.ToString();
        }

        private void BtMinus8_Click(object sender, RoutedEventArgs e)
        {
            if (Tb8.Text == 1.ToString())
            {
            }
            else
            {
                int count = Convert.ToInt32(Tb8.Text);
                count--;
                Tb8.Text = count.ToString();
            }
        }

        private void BtPlus9_Click(object sender, RoutedEventArgs e)
        {
            int count = Convert.ToInt32(Tb9.Text);
            count++;
            Tb9.Text = count.ToString();
        }

        private void BtMinus9_Click(object sender, RoutedEventArgs e)
        {
            if (Tb9.Text == 1.ToString())
            {
            }
            else
            {
                int count = Convert.ToInt32(Tb9.Text);
                count--;
                Tb9.Text = count.ToString();
            }
        }

        private void BtPlus10_Click(object sender, RoutedEventArgs e)
        {
            int count = Convert.ToInt32(Tb10.Text);
            count++;
            Tb10.Text = count.ToString();
        }

        private void BtMinus10_Click(object sender, RoutedEventArgs e)
        {
            if (Tb10.Text == 1.ToString())
            {
            }
            else
            {
                int count = Convert.ToInt32(Tb10.Text);
                count--;
                Tb10.Text = count.ToString();
            }
        }

        private void GetOrderButt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ListOfOrders.Items.Count == 0)
                {
                    MessageBox.Show("Для оформления заказа сначала выберите товар!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    int valuesOfOrders1 = Convert.ToInt32(Tb1.Text);
                    int valuesOfOrders2 = Convert.ToInt32(Tb2.Text);
                    int valuesOfOrders3 = Convert.ToInt32(Tb3.Text);
                    int valuesOfOrders4 = Convert.ToInt32(Tb4.Text);
                    int valuesOfOrders5 = Convert.ToInt32(Tb5.Text);
                    int valuesOfOrders6 = Convert.ToInt32(Tb6.Text);
                    int valuesOfOrders7 = Convert.ToInt32(Tb7.Text);
                    int valuesOfOrders8 = Convert.ToInt32(Tb8.Text);
                    int valuesOfOrders9 = Convert.ToInt32(Tb9.Text);
                    int valuesOfOrders10 = Convert.ToInt32(Tb10.Text);
                    random = rnd.Next(0, 6);
                    DateTime dateTime = DateTime.Now;
                    SqlConnection cnn = new SqlConnection(connectionString);
                    cnn.Open();
                    SqlCommand cmd = cnn.CreateCommand();
                    cmd.CommandText = $"INSERT INTO Заказы (Дата_заказа, Срок_сборки, Доп_информация, Адрес_доставки) values ('{dateTime}','{random}','{MoreInfoTb.Text}','{AdressTb.Text}')";
                    cmd.ExecuteNonQuery();
                    SqlCommand command = cnn.CreateCommand();
                    command.CommandText = "Select top 1 Номер_Заказа from Заказы order by Дата_заказа DESC";
                    string YO = command.ExecuteScalar().ToString();
                    if (valuesOfOrders1 >= 1)
                    {
                        SqlCommand cmd1 = cnn.CreateCommand();
                        cmd1.CommandText = $"INSERT INTO Содержимое_заказов values ('{indexes[0]}','{Convert.ToInt32(YO)}', '{Convert.ToInt32(Tb1.Text)}','{Cb1.Text}')";
                        cmd1.ExecuteNonQuery();
                    }
                    if (valuesOfOrders2 >= 1)
                    {
                        SqlCommand cmd2 = cnn.CreateCommand();
                        cmd2.CommandText = $"INSERT INTO Содержимое_заказов values ('{indexes[1]}','{Convert.ToInt32(YO)}', '{Convert.ToInt32(Tb2.Text)}','{Cb2.Text}')";
                        cmd2.ExecuteNonQuery();
                    }
                    if (valuesOfOrders3 >= 1)
                    {
                        SqlCommand cmd3 = cnn.CreateCommand();
                        cmd3.CommandText = $"INSERT INTO Содержимое_заказов values ('{indexes[2]}','{Convert.ToInt32(YO)}', '{Convert.ToInt32(Tb3.Text)}','{Cb3.Text}')";
                        cmd3.ExecuteNonQuery();
                    }
                    if (valuesOfOrders4 >= 1)
                    {
                        SqlCommand cmd4 = cnn.CreateCommand();
                        cmd4.CommandText = $"INSERT INTO Содержимое_заказов values ('{indexes[3]}','{Convert.ToInt32(YO)}', '{Convert.ToInt32(Tb4.Text)}','{Cb4.Text}')";
                        cmd4.ExecuteNonQuery();
                    }
                    if (valuesOfOrders5 >= 1)
                    {
                        SqlCommand cmd5 = cnn.CreateCommand();
                        cmd5.CommandText = $"INSERT INTO Содержимое_заказов values ('{indexes[4]}','{Convert.ToInt32(YO)}', '{Convert.ToInt32(Tb5.Text)}','{Cb5.Text}')";
                        cmd5.ExecuteNonQuery();
                    }
                    if (valuesOfOrders6 >= 1)
                    {
                        SqlCommand cmd6 = cnn.CreateCommand();
                        cmd6.CommandText = $"INSERT INTO Содержимое_заказов values ('{indexes[5]}','{Convert.ToInt32(YO)}', '{Convert.ToInt32(Tb6.Text)}','{Cb6.Text}')";
                        cmd6.ExecuteNonQuery();
                    }
                    if (valuesOfOrders7 >= 1)
                    {
                        SqlCommand cmd7 = cnn.CreateCommand();
                        cmd7.CommandText = $"INSERT INTO Содержимое_заказов values ('{indexes[6]}','{Convert.ToInt32(YO)}', '{Convert.ToInt32(Tb7.Text)}','{Cb7.Text}')";
                        cmd7.ExecuteNonQuery();
                    }
                    if (valuesOfOrders8 >= 1)
                    {
                        SqlCommand cmd8 = cnn.CreateCommand();
                        cmd8.CommandText = $"INSERT INTO Содержимое_заказов values ('{indexes[7]}','{Convert.ToInt32(YO)}', '{Convert.ToInt32(Tb8.Text)}','{Cb8.Text}')";
                        cmd8.ExecuteNonQuery();
                    }
                    if (valuesOfOrders9 >= 1)
                    {
                        SqlCommand cmd9 = cnn.CreateCommand();
                        cmd9.CommandText = $"INSERT INTO Содержимое_заказов values ('{indexes[8]}','{Convert.ToInt32(YO)}', '{Convert.ToInt32(Tb9.Text)}','{Cb9.Text}')";
                        cmd9.ExecuteNonQuery();
                    }
                    if (valuesOfOrders10 >= 1)
                    {
                        SqlCommand cmd10 = cnn.CreateCommand();
                        cmd10.CommandText = $"INSERT INTO Содержимое_заказов values ('{indexes[9]}','{Convert.ToInt32(YO)}', '{Convert.ToInt32(Tb10.Text)}','{Cb10.Text}')";
                        cmd10.ExecuteNonQuery();
                    }
                    cnn.Close();
                    Cb1.IsEnabled = false;
                    Cb2.IsEnabled = false;
                    Cb3.IsEnabled = false;
                    Cb4.IsEnabled = false;
                    Cb5.IsEnabled = false;
                    Cb6.IsEnabled = false;
                    Cb7.IsEnabled = false;
                    Cb8.IsEnabled = false;
                    Cb9.IsEnabled = false;
                    Cb10.IsEnabled = false;
                    Tb1.IsEnabled = false;
                    Tb2.IsEnabled = false;
                    Tb3.IsEnabled = false;
                    Tb4.IsEnabled = false;
                    Tb5.IsEnabled = false;
                    Tb6.IsEnabled = false;
                    Tb7.IsEnabled = false;
                    Tb8.IsEnabled = false;
                    Tb9.IsEnabled = false;
                    Tb10.IsEnabled = false;
                    BtMinus1.IsEnabled = false;
                    BtMinus2.IsEnabled = false;
                    BtMinus3.IsEnabled = false;
                    BtMinus4.IsEnabled = false;
                    BtMinus5.IsEnabled = false;
                    BtMinus6.IsEnabled = false;
                    BtMinus7.IsEnabled = false;
                    BtMinus8.IsEnabled = false;
                    BtMinus9.IsEnabled = false;
                    BtMinus10.IsEnabled = false;
                    BtPlus1.IsEnabled = false;
                    BtPlus2.IsEnabled = false;
                    BtPlus3.IsEnabled = false;
                    BtPlus4.IsEnabled = false;
                    BtPlus5.IsEnabled = false;
                    BtPlus6.IsEnabled = false;
                    BtPlus7.IsEnabled = false;
                    BtPlus8.IsEnabled = false;
                    BtPlus9.IsEnabled = false;
                    BtPlus10.IsEnabled = false;
                    DeleteAllBut.Visibility = Visibility.Hidden;
                    ListBoxTovars.IsEnabled = false;
                    InsertButt.IsEnabled = false;
                    GetOrderButt.Visibility = Visibility.Hidden;
                    ChangeOrder.Visibility = Visibility.Visible;
                    AdressTb.IsEnabled = false;
                    MoreInfoTb.IsEnabled = false;
                    AdressStroka = AdressTb.Text;
                    DoubleInfoStroka = MoreInfoTb.Text;
                    for (int i = 0; i < ListOfOrders.Items.Count; i++)
                        differentNumbers.Add(indexes[i]);
                    DeleteOrderBt.Visibility = Visibility.Visible;
                    MessageBox.Show("Заказ оформлен!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("Некоректно введены данные!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ChangeOrder_Click(object sender, RoutedEventArgs e)
        {
            if (random <= 1)
                MessageBox.Show("Увы, у вас истек срок сборки!\nВы не можете отредактировать ваш заказ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                SaveAllBut.Visibility = Visibility.Visible;
                BtMinus1.IsEnabled = true;
                BtMinus2.IsEnabled = true;
                BtMinus3.IsEnabled = true;
                BtMinus4.IsEnabled = true;
                BtMinus5.IsEnabled = true;
                BtMinus6.IsEnabled = true;
                BtMinus7.IsEnabled = true;
                BtMinus8.IsEnabled = true;
                BtMinus9.IsEnabled = true;
                BtMinus10.IsEnabled = true;
                BtPlus1.IsEnabled = true;
                BtPlus2.IsEnabled = true;
                BtPlus3.IsEnabled = true;
                BtPlus4.IsEnabled = true;
                BtPlus5.IsEnabled = true;
                BtPlus6.IsEnabled = true;
                BtPlus7.IsEnabled = true;
                BtPlus8.IsEnabled = true;
                BtPlus9.IsEnabled = true;
                BtPlus10.IsEnabled = true;
                InsertButt.Visibility = Visibility.Visible;
                AdressTb.IsEnabled = true;
                MoreInfoTb.IsEnabled = true;
                Cb1.IsEnabled = true;
                Cb2.IsEnabled = true;
                Cb3.IsEnabled = true;
                Cb4.IsEnabled = true;
                Cb5.IsEnabled = true;
                Cb6.IsEnabled = true;
                Cb7.IsEnabled = true;
                Cb8.IsEnabled = true;
                Cb9.IsEnabled = true;
                Cb10.IsEnabled = true;
                ListBoxTovars.IsEnabled = true;
                InsertButt.IsEnabled = true;
            }
        }

        private void SaveAllBut_Click(object sender, RoutedEventArgs e)
        {
            int valuesOfOrders1 = Convert.ToInt32(Tb1.Text);
            int valuesOfOrders2 = Convert.ToInt32(Tb2.Text);
            int valuesOfOrders3 = Convert.ToInt32(Tb3.Text);
            int valuesOfOrders4 = Convert.ToInt32(Tb4.Text);
            int valuesOfOrders5 = Convert.ToInt32(Tb5.Text);
            int valuesOfOrders6 = Convert.ToInt32(Tb6.Text);
            int valuesOfOrders7 = Convert.ToInt32(Tb7.Text);
            int valuesOfOrders8 = Convert.ToInt32(Tb8.Text);
            int valuesOfOrders9 = Convert.ToInt32(Tb9.Text);
            int valuesOfOrders10 = Convert.ToInt32(Tb10.Text);
            random = rnd.Next(0, 6);
            DateTime dateTime = DateTime.Now;
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlCommand command = cnn.CreateCommand();
            command.CommandText = "Select top 1 Номер_Заказа from Заказы order by Дата_заказа DESC";
            string YO = command.ExecuteScalar().ToString();
            SqlCommand command2 = cnn.CreateCommand();
            command2.CommandText = $"Delete from Содержимое_заказов where Номер_заказа = {Convert.ToInt32(YO)}";
            command2.ExecuteNonQuery();
            if (valuesOfOrders1 >= 1)
            {
                SqlCommand cmd1 = cnn.CreateCommand();
                cmd1.CommandText = $"INSERT INTO Содержимое_заказов values ('{indexes[0]}','{Convert.ToInt32(YO)}', '{Convert.ToInt32(Tb1.Text)}','{Cb1.Text}')";
                cmd1.ExecuteNonQuery();
            }
            if (valuesOfOrders2 >= 1)
            {
                SqlCommand cmd2 = cnn.CreateCommand();
                cmd2.CommandText = $"INSERT INTO Содержимое_заказов values ('{indexes[1]}','{Convert.ToInt32(YO)}', '{Convert.ToInt32(Tb2.Text)}','{Cb2.Text}')";
                cmd2.ExecuteNonQuery();
            }
            if (valuesOfOrders3 >= 1)
            {
                SqlCommand cmd3 = cnn.CreateCommand();
                cmd3.CommandText = $"INSERT INTO Содержимое_заказов values ('{indexes[2]}','{Convert.ToInt32(YO)}', '{Convert.ToInt32(Tb3.Text)}','{Cb3.Text}')";
                cmd3.ExecuteNonQuery();
            }
            if (valuesOfOrders4 >= 1)
            {
                SqlCommand cmd4 = cnn.CreateCommand();
                cmd4.CommandText = $"INSERT INTO Содержимое_заказов values ('{indexes[3]}','{Convert.ToInt32(YO)}', '{Convert.ToInt32(Tb4.Text)}','{Cb4.Text}')";
                cmd4.ExecuteNonQuery();
            }
            if (valuesOfOrders5 >= 1)
            {
                SqlCommand cmd5 = cnn.CreateCommand();
                cmd5.CommandText = $"INSERT INTO Содержимое_заказов values ('{indexes[4]}','{Convert.ToInt32(YO)}', '{Convert.ToInt32(Tb5.Text)}','{Cb5.Text}')";
                cmd5.ExecuteNonQuery();
            }
            if (valuesOfOrders6 >= 1)
            {
                SqlCommand cmd6 = cnn.CreateCommand();
                cmd6.CommandText = $"INSERT INTO Содержимое_заказов values ('{indexes[5]}','{Convert.ToInt32(YO)}', '{Convert.ToInt32(Tb6.Text)}','{Cb6.Text}')";
                cmd6.ExecuteNonQuery();
            }
            if (valuesOfOrders7 >= 1)
            {
                SqlCommand cmd7 = cnn.CreateCommand();
                cmd7.CommandText = $"INSERT INTO Содержимое_заказов values ('{indexes[6]}','{Convert.ToInt32(YO)}', '{Convert.ToInt32(Tb7.Text)}','{Cb7.Text}')";
                cmd7.ExecuteNonQuery();
            }
            if (valuesOfOrders8 >= 1)
            {
                SqlCommand cmd8 = cnn.CreateCommand();
                cmd8.CommandText = $"INSERT INTO Содержимое_заказов values ('{indexes[7]}','{Convert.ToInt32(YO)}', '{Convert.ToInt32(Tb8.Text)}','{Cb8.Text}')";
                cmd8.ExecuteNonQuery();
            }
            if (valuesOfOrders9 >= 1)
            {
                SqlCommand cmd9 = cnn.CreateCommand();
                cmd9.CommandText = $"INSERT INTO Содержимое_заказов values ('{indexes[8]}','{Convert.ToInt32(YO)}', '{Convert.ToInt32(Tb9.Text)}','{Cb9.Text}')";
                cmd9.ExecuteNonQuery();
            }
            if (valuesOfOrders10 >= 1)
            {
                SqlCommand cmd10 = cnn.CreateCommand();
                cmd10.CommandText = $"INSERT INTO Содержимое_заказов values ('{indexes[9]}','{Convert.ToInt32(YO)}', '{Convert.ToInt32(Tb10.Text)}','{Cb10.Text}')";
                cmd10.ExecuteNonQuery();
            }
            if (AdressStroka != AdressTb.Text)
            {
                SqlCommand cmdUpdateAdress = cnn.CreateCommand();
                cmdUpdateAdress.CommandText = @"Update Заказы set Адрес_доставки ='" + AdressTb.Text + @"' where Номер_заказа = " + Convert.ToInt32(YO);
                cmdUpdateAdress.ExecuteNonQuery();
            }
            if (DoubleInfoStroka != MoreInfoTb.Text)
            {
                SqlCommand cmdUpdateAdress = cnn.CreateCommand();
                cmdUpdateAdress.CommandText = @"Update Заказы set Доп_информация ='" + MoreInfoTb.Text + @"' where Номер_заказа = " + Convert.ToInt32(YO);
                cmdUpdateAdress.ExecuteNonQuery();
            }
            cnn.Close();
            SaveAllBut.Visibility = Visibility.Hidden;
            ChangeOrder.Visibility = Visibility.Visible;
            MessageBox.Show("Заказ сохранен", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
            BtMinus1.IsEnabled = false;
            BtMinus2.IsEnabled = false;
            BtMinus3.IsEnabled = false;
            BtMinus4.IsEnabled = false;
            BtMinus5.IsEnabled = false;
            BtMinus6.IsEnabled = false;
            BtMinus7.IsEnabled = false;
            BtMinus8.IsEnabled = false;
            BtMinus9.IsEnabled = false;
            BtMinus10.IsEnabled = false;
            BtPlus1.IsEnabled = false;
            BtPlus2.IsEnabled = false;
            BtPlus3.IsEnabled = false;
            BtPlus4.IsEnabled = false;
            BtPlus5.IsEnabled = false;
            BtPlus6.IsEnabled = false;
            BtPlus7.IsEnabled = false;
            BtPlus8.IsEnabled = false;
            BtPlus9.IsEnabled = false;
            BtPlus10.IsEnabled = false;
            Cb1.IsEnabled = false;
            Cb2.IsEnabled = false;
            Cb3.IsEnabled = false;
            Cb4.IsEnabled = false;
            Cb5.IsEnabled = false;
            Cb6.IsEnabled = false;
            Cb7.IsEnabled = false;
            Cb8.IsEnabled = false;
            Cb9.IsEnabled = false;
            Cb10.IsEnabled = false;
        }
        private void DeleteAllBut_Click(object sender, RoutedEventArgs e)
        {
            ListOfOrders.Items.Clear();
            Tb1.Text = 0.ToString();
            Tb1.Visibility = Visibility.Hidden;
            BtMinus1.Visibility = Visibility.Hidden;
            BtPlus1.Visibility = Visibility.Hidden;
            Tb2.Text = 0.ToString();
            Tb2.Visibility = Visibility.Hidden;
            BtMinus2.Visibility = Visibility.Hidden;
            BtPlus2.Visibility = Visibility.Hidden;
            Tb3.Text = 0.ToString();
            Tb3.Visibility = Visibility.Hidden;
            BtMinus3.Visibility = Visibility.Hidden;
            BtPlus3.Visibility = Visibility.Hidden;
            Tb4.Text = 0.ToString();
            Tb4.Visibility = Visibility.Hidden;
            BtMinus4.Visibility = Visibility.Hidden;
            BtPlus4.Visibility = Visibility.Hidden;
            Tb5.Text = 0.ToString();
            Tb5.Visibility = Visibility.Hidden;
            BtMinus5.Visibility = Visibility.Hidden;
            BtPlus5.Visibility = Visibility.Hidden;
            Tb6.Text = 0.ToString();
            Tb6.Visibility = Visibility.Hidden;
            BtMinus6.Visibility = Visibility.Hidden;
            BtPlus6.Visibility = Visibility.Hidden;
            Tb7.Text = 0.ToString();
            Tb7.Visibility = Visibility.Hidden;
            BtMinus7.Visibility = Visibility.Hidden;
            BtPlus7.Visibility = Visibility.Hidden;
            Tb8.Text = 0.ToString();
            Tb8.Visibility = Visibility.Hidden;
            BtMinus8.Visibility = Visibility.Hidden;
            BtPlus8.Visibility = Visibility.Hidden;
            Tb9.Text = 0.ToString();
            Tb9.Visibility = Visibility.Hidden;
            BtMinus9.Visibility = Visibility.Hidden;
            BtPlus9.Visibility = Visibility.Hidden;
            Tb10.Text = 0.ToString();
            Tb10.Visibility = Visibility.Hidden;
            BtMinus10.Visibility = Visibility.Hidden;
            BtPlus10.Visibility = Visibility.Hidden;
            counterOfIndex = 9;
            Cb1.Visibility = Visibility.Hidden;
            Cb2.Visibility = Visibility.Hidden;
            Cb3.Visibility = Visibility.Hidden;
            Cb4.Visibility = Visibility.Hidden;
            Cb5.Visibility = Visibility.Hidden;
            Cb6.Visibility = Visibility.Hidden;
            Cb7.Visibility = Visibility.Hidden;
            Cb8.Visibility = Visibility.Hidden;
            Cb9.Visibility = Visibility.Hidden;
            Cb10.Visibility = Visibility.Hidden;
        }

        private void DeleteOrderBt_Click_1(object sender, RoutedEventArgs e)
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlCommand command = cnn.CreateCommand();
            command.CommandText = "Select top 1 Номер_Заказа from Заказы order by Дата_заказа DESC";
            string YO = command.ExecuteScalar().ToString();
            SqlCommand command2 = cnn.CreateCommand();
            command2.CommandText = $"Delete from Заказы where Номер_заказа = {Convert.ToInt32(YO)}";
            command2.ExecuteNonQuery();
            MessageBox.Show("Заказ отменен!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
    }
}
