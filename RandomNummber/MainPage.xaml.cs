using System.Diagnostics;

namespace RandomNummber
{
    public partial class MainPage : ContentPage
    {
        int computerRandom = 0;
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
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
                }  // Easy
                else if (selectedIndex == 1)
                {
                    Random random = new Random();
                    computerRandom = random.Next(1, 100);
                    Debug.WriteLine(computerRandom);
                    GuessOfUser.IsEnabled = true;
                    picker.IsEnabled = false;
                } //Medium
                else if (selectedIndex == 2)
                {
                    Random random = new Random();
                    computerRandom = random.Next(1, 1000);
                    Debug.WriteLine(computerRandom);
                    GuessOfUser.IsEnabled = true;
                    picker.IsEnabled = false;
                } //Hard

            }
        }
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
                    Restart.IsEnabled = true;
                }
                else if (computerRandom > aCorrectInteger)
                {
                    Debug.WriteLine("user guess: " + UserInputEntry.Text);
                    Debug.WriteLine("The correct nummber is bigger");
                    ShowGuess.Text = $"{UserInputEntry.Text} is to small guess one more time";
                    GuessOfUser.IsEnabled = false;
                    Restart.IsEnabled = true;
                }
                if (computerRandom == aCorrectInteger)
                {
                    Debug.WriteLine("user guess: " + UserInputEntry.Text);
                    Debug.WriteLine("du valde rätt");
                    ShowGuess.Text = $"{UserInputEntry.Text} is correct ";
                    GuessOfUser.IsEnabled = false;

                }
            }
            else
            {
                Debug.WriteLine("enter a Correct integer");
                ShowGuess.Text = "enter a correctos numbreros";
            }
        }
        private void Reset_Guess(object? sender, EventArgs e)
        {
            count++;
            countLabel.Text = count.ToString();
        }
        private void Reset_Game(object? sender, EventArgs e) 
        {
            picker.IsEnabled = true;
            count = 0;
        }
    }


}
