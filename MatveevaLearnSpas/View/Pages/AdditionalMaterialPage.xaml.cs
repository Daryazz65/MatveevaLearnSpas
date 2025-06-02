using MatveevaLearnSpas.AppData;
using System.Windows;
using System.Windows.Controls;

namespace MatveevaLearnSpas.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdditionalMaterialPage.xaml
    /// </summary>
    public partial class AdditionalMaterialPage : Page
    {
        public AdditionalMaterialPage()
        {
            InitializeComponent();
            BylvarnoePage bylvarnoePage = new BylvarnoePage();
            AdditionalFrame.Navigate(bylvarnoePage);
            FrameHelper.selectedFrame = AdditionalFrame;
        }
        private void BylvarBtn_Click(object sender, RoutedEventArgs e)
        {
            BylvarnoePage bylvarnoePage = new BylvarnoePage();
            AdditionalFrame.Navigate(bylvarnoePage);
        }
        private void MkadBtn_Click(object sender, RoutedEventArgs e)
        {
            MkadPage mkadPage = new MkadPage();
            AdditionalFrame.Navigate(mkadPage);
        }
        private void SadovoeBtn_Click(object sender, RoutedEventArgs e)
        {
            SadovoePage sadovoePage = new SadovoePage();
            AdditionalFrame.Navigate(sadovoePage);
        }
        private void AuzaBtn_Click(object sender, RoutedEventArgs e)
        {
            YauzaPage yauzaPage = new YauzaPage();
            AdditionalFrame.Navigate(yauzaPage);   
        }
    }
}