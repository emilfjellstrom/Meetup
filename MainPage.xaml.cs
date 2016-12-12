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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Meetup
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

        }

        private async void getDataClicked(object sender, RoutedEventArgs e)
        {
            //19:22
            var client = new HttpClient();
            var result = await client.GetAsync("https://api.meetup.com/recommended/events?&signed=true&key=" + APIKey.Text + "&lat=" + LatText.Text + "&lon=" +LonText.Text);              
            var resultString = await result.Content.ReadAsStringAsync();
            dynamic json = JArray.Parse(resultString);
            outputLabel.Text = json[0].name;
        }
    }
}
