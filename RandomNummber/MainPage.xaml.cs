
using System.Diagnostics;

namespace RandomNummber
{
    public partial class MainPage : ContentPage
    {
        int computerRandom = 0;
        int count = 0;
        int attempt = 0;
        public MainPage()
        {
            InitializeComponent();
            right.IsVisible = false;
            wrong.IsVisible = false;
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                if (selectedIndex == 0)
                {
                    Random random = new Random();
                    computerRandom = random.Next(1, 10);
                    Debug.WriteLine(computerRandom);
                    GuessOfUser.IsEnabled = true;
                    picker.IsEnabled = false;
                    Debug.WriteLine(computerRandom);
                    
                }  // Easy
                else if (selectedIndex == 1)
                {
                    Random random = new Random();
                    computerRandom = random.Next(1, 100);
                    Debug.WriteLine(computerRandom);
                    GuessOfUser.IsEnabled = true;
                    picker.IsEnabled = false;
                    Debug.WriteLine(computerRandom);
                } //Medium
                else if (selectedIndex == 2)
                {
                    Random random = new Random();
                    computerRandom = random.Next(1, 1000);
                    Debug.WriteLine(computerRandom);
                    GuessOfUser.IsEnabled = true;
                    picker.IsEnabled = false; 
                    Debug.WriteLine(computerRandom);

                } //Hard

            }
        } //Svårhetsgrad programet
        private void UserGuess(object? sender, EventArgs e)
        {
            if (int.TryParse(UserInputEntry.Text, out int aCorrectInteger))
            {
                Debug.WriteLine(computerRandom);
                if (computerRandom < aCorrectInteger)
                {
                    Debug.WriteLine("user guess: " + UserInputEntry.Text);
                    Debug.WriteLine("The correct nummber is smaller");
                    ShowGuess.Text = $"{UserInputEntry.Text} is to big guess one more time ";
                    GuessOfUser.IsEnabled = false;
                    GuessOfUser.IsVisible= false;
                    Restart.IsEnabled = true;
                    Restart.IsVisible = true;
                    wrong.IsVisible = true;
                }
                else if (computerRandom > aCorrectInteger)
                {
                    Debug.WriteLine("user guess: " + UserInputEntry.Text);
                    Debug.WriteLine("The correct nummber is bigger");
                    ShowGuess.Text = $"{UserInputEntry.Text} is to small guess one more time";
                    GuessOfUser.IsEnabled = false;
                    GuessOfUser.IsVisible = false;
                    Restart.IsEnabled = true;
                    Restart.IsVisible = true;
                    wrong.IsVisible= true;
                }
                if (computerRandom == aCorrectInteger)
                {
                    Debug.WriteLine("user guess: " + UserInputEntry.Text);
                    Debug.WriteLine("du valde rätt");
                    ShowGuess.Text = $"{UserInputEntry.Text} is correct ";
                    GuessOfUser.IsEnabled = false;
                    GameRestart.IsVisible = true;
                    GameRestart.IsEnabled = true;
                    Restart.IsVisible = false;
                    Restart.IsEnabled = false;
                    count++;
                    countLabel.Text = count.ToString();
                    right.IsVisible = true;
                }
            }
            else
            {
                Debug.WriteLine("enter a Correct integer");
                ShowGuess.Text = "enter a correctos numbreros";
            }
        } //är programet för gisningar och att visa upp dem för spelarn
        private void Reset_Guess(object? sender, EventArgs e)
        {
            GuessOfUser.IsEnabled = true;
            Restart.IsEnabled = false;
            
        } //låtter dig gisa igen effter man gisat
        private void Reset_Game(object? sender, EventArgs e) 
        {
            picker.IsEnabled = true;
            GameRestart.IsEnabled = false;
            GameRestart.IsVisible = false;
            
        } // startar om spelet och ger dig score för att se hur bra du kan gissa
    }


}
