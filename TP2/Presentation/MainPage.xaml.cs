using Microsoft.UI.Xaml.Controls;
using Windows.Media.Core;
using Uno.WinUI;
using Uno.UI;
namespace TP2.Presentation;


// "ms-appx:///Assets/Images/MEMO_FRUITS.mp4"

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();

        
    }

    private void GoToGame(object sender, EventArgs e)
    {
        Frame.Navigate(typeof(GamePage));
    }

    private void ShowRules(object sender, RoutedEventArgs e)
    {
        RulesOverlay.Visibility = Visibility.Visible;
    }

    private void CloseRulesOverlay(object sender, RoutedEventArgs e)
    {
        RulesOverlay.Visibility = Visibility.Collapsed;
    }

}




