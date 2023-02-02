using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace ricknMort
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            HttpClient client = new HttpClient();
            string json = client.GetStringAsync("https://rickandmortyapi.com/api/character").Result;

            client.Dispose();

            RickAndMortyAPI api = JsonConvert.DeserializeObject<RickAndMortyAPI>(json);

            cboCharacters.Items.Add(api);

            foreach(ResultItem character in api.results)
            {
                cboCharacters.Items.Add(character);
            }
        }

        private void btnGetInfo_Click(object sender, RoutedEventArgs e)
        {
            ResultItem selectedCharacter = (ResultItem)cboCharacters.SelectedItem;

            txtName.Text = selectedCharacter.name;

            imgPicture.Source = new BitmapImage(new Uri(selectedCharacter.image));
        }
    }
}
