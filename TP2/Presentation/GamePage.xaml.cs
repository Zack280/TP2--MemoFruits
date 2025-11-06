using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Media.Imaging;
using Uno.Toolkit.UI;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;


namespace TP2.Presentation;


public sealed partial class GamePage : Page
{

    private List<CardModel> cards = new List<CardModel>(16);
    private List<Button> buttons;

    private int moves;
    private int remainingPairs = 8;
    private Button firstCard, secondCard;
    private bool isComparing = false;

    public GamePage()
    {
        this.InitializeComponent();
        startNewGame();
    }

    private async void Card_Click(object sender, RoutedEventArgs e)
    {
        if (isComparing)
        {
            Console.WriteLine("Already Comparing");
            return;
        }
        var button = sender as Button;
        int index = buttons.IndexOf(button);
        var card = cards[index];
        

        // Ignore le click si la carte est revele ou en paire
        if (card.IsRevealed || card.IsMatched)
            return;

        card.IsRevealed = true;
        UpdateBoard();

        if (firstCard == null)
        {
            firstCard = button;
            return;
        }

        secondCard = button;
        isComparing = true;
        moves++;
        MovesTextBlock.Text = $"Coups : {moves}";
        

        // Comparaison des cartes
        int firstIndex = buttons.IndexOf(firstCard);
        var firstModel = cards[firstIndex];

        if (firstModel.ImagePath == card.ImagePath)
        {
            firstModel.IsMatched = true;
            card.IsMatched = true;
            remainingPairs--;
            PairsTextBlock.Text = $"Paires Restantes : {remainingPairs}";
            firstCard = null;
            secondCard = null;
        }
        else
        {
            await Task.Delay(1000);
            firstModel.IsRevealed = false;
            card.IsRevealed = false;
            firstCard = null;
            secondCard = null;
        }

        UpdateBoard();

        isComparing = false;
    }


    private void startNewGame()
    {
        NewGameBtn.IsEnabled = false;

        remainingPairs = 8;
        PairsTextBlock.Text = $"Paires Restantes : {remainingPairs}";
        moves = 0;
        firstCard = secondCard = null;

        InitializeButtons();
        InitializeCards();
       // ShowAllCards();
        UpdateBoard();

        NewGameBtn.IsEnabled = true;
    }

    

    private void InitializeButtons()
    {
        buttons = new List<Button>
    {
        Card0, Card1, Card2, Card3,
        Card4, Card5, Card6, Card7,
        Card8, Card9, Card10, Card11,
        Card12, Card13, Card14, Card15
    };
    }


    private void InitializeCards()
    {

        // cards.Clear();

        List<string> fruitImages = new List<string>()
        {

            "cerise.png",
            "ananas.png",
            "fraise.png",
            "orange.png",
            "melon.png",
            "poire.png",
            "pomme.png",
            "raisin.png"

        };

        foreach(string image in fruitImages)
        {

            cards.Add(new CardModel { ImagePath = image });
            cards.Add(new CardModel { ImagePath = image });

        }

        Random rng = new Random();
        cards = cards.OrderBy(c => rng.Next()).ToList();

    }

    private void ShowAllCards()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            var card = cards[i];
            var button = buttons[i];

            var image = new Image
            {
                Source = new BitmapImage(new Uri($"ms-appx:///Assets/Images/{card.ImagePath}")),
                
            };

            button.Content = image;
        }
    }

    private void UpdateBoard()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            var card = cards[i];
            var button = buttons[i];

            if (card.IsRevealed || card.IsMatched)
            {
                button.Content = new Image
                {
                    Source = new BitmapImage(new Uri($"ms-appx:///Assets/Images/{card.ImagePath}")),
                    Stretch = Stretch.Uniform,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    RenderTransform = new TranslateTransform()
                };
            }
            else
            {
                button.Content = new Image
                {
                    Source = new BitmapImage(new Uri($"ms-appx:///Assets/Images/fruitbasket.png")),
                    Stretch = Stretch.Uniform,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    //Animations
                    RenderTransform = new TranslateTransform()
                };
                
            }
            
        }
    }

    private void newGameButton(object sender, EventArgs e)
    {
        startNewGame(); 
    }


}
