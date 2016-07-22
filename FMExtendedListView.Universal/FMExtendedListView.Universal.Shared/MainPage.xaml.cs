using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FMExtendedListView.Universal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int page;
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.NavigationMode == NavigationMode.New)
                updateListView(page++, 11);
        }
        void listv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FMExtendedListView lv = sender as FMExtendedListView;
            this.Frame.Navigate(typeof(BlankPage));
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //listView.IsPullToRefreshEnabled = !listView.IsPullToRefreshEnabled;
            //var items = (ObservableCollection<int>)listView.ItemsSource;
            //items.RemoveAt(6);
            //items.Insert(5, 6);
            //items.RemoveAt(6);
            //items.Insert(5, 6);
            //items.RemoveAt(6);
            //items.Insert(5, 6);
            //await updateListView();
        }
        private async Task updateListView(int page, int items)
        {
            await Task.Delay(1000);
            var list = (this.DataContext as DummyVM).List;

            var colors = new List<Color>() { Colors.DarkBlue, Colors.DarkCyan, Colors.DarkGoldenrod, Colors.DarkGray, Colors.DarkGreen, Colors.DarkKhaki,
                                             Colors.DarkMagenta, Colors.DarkOliveGreen, Colors.DarkOrange, Colors.DarkOrchid, Colors.DarkRed, Colors.DarkSalmon};
            Random random = new Random();
            for (int i = 1; i < items; i++)
            {
                var num = i + (page * 10);
                list.Add(new DummyObject
                {
                    Index = num,
                    Title = NumberToWords(num),
                    Color = new SolidColorBrush(colors[random.Next(0, colors.Count)]),
                    Image = "http://lorempixel.com/800/480/?q=" + DateTime.Now.Ticks.ToString()
                });
            }
        }
        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        private async Task listView_PullToRefreshRequested(object sender, EventArgs e)
        {
            var list = (this.DataContext as DummyVM).List;
            list.Clear();
            page = 0;
            await updateListView(page++, 11);
        }

        private async Task listView_MoreDataRequested(object sender, EventArgs e)
        {
            await updateListView(page++, 11);
        }
    }
    public class DummyVM : ViewModelBase
    {
        private ObservableCollection<DummyObject> list = new ObservableCollection<DummyObject>();
        public ObservableCollection<DummyObject> List
        {
            get { return list; }
            set
            {
                Set(() => List, ref list, value);
            }
        }
        public ICommand command
        {
            get
            {
                return null;
                //return new AsyncDelegateCommand(async (s) =>
                //{
                //    await Task.Delay(1000);
                //    await new MessageDialog("test").ShowAsync();
                //});
            }
        }
        public ICommand command2
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    await Task.Delay(1000);
                    await new MessageDialog("Command 2").ShowAsync();
                });
            }
        }
    }

    public class DummyObject
    {
        public int Index { get; set; }
        public string Title { get; set; }
        public SolidColorBrush Color { get; set; }
        public string Image { get; set; }
    }

}
