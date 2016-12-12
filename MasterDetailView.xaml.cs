using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Meetup
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public sealed partial class MasterDetailView : Page
    {
        public MasterDetailView()
        {
            this.InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            var APIKey = "";
            var client = new HttpClient();
            var result = await client.GetAsync("https://api.meetup.com/recommended/events?&signed=true&key=" + APIKey);
            var resultString = await result.Content.ReadAsStringAsync();
            var json = JArray.Parse(resultString);
            var items = new List<Item>();
            foreach (dynamic item in json)
            {
                
                items.Add(new Item() { Name = item.name, Id = item.id, json = item });
            }
            listView.ItemsSource = items;
        }
    }
    public class Item {
        public string Name { get; set; }
        public string Id { get; set; }
        public dynamic json;
    }
}