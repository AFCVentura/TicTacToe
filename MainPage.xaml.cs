namespace TicTacToe
{
    public partial class MainPage : ContentPage
    {
        string turn = "X"; // Variable to keep track of the current player's turn
        List<Button> buttons; // List to store the buttons
        public MainPage()
        {
            InitializeComponent();
            // Initialize the buttons list with the buttons from the XAML
            buttons = new List<Button>
            {
                btn10, btn11, btn12,
                btn20, btn21, btn22,
                btn30, btn31, btn32
            };
        }

        // This method is called when the button is clicked
        // Sender is the button that was clicked
        // You need to cast the sender to a Button type
        // EventArgs contains information about the event
        private void Button_Clicked(object sender, EventArgs e)
        {
            buttons = new List<Button>
            {
                btn10, btn11, btn12,
                btn20, btn21, btn22,
                btn30, btn31, btn32
            };
            // Cast the sender to a Button and save to a variable
            Button button = (Button)sender;

            button.IsEnabled = false; // Disable the button to prevent further clicks

            // Set the text of the button to the current value of turn
            button.Text = turn;


            var firstRow = btn10.Text == turn && btn11.Text == turn && btn12.Text == turn;
            var secondRow = btn20.Text == turn && btn21.Text == turn && btn22.Text == turn;
            var thirdRow = btn30.Text == turn && btn31.Text == turn && btn32.Text == turn;

            var firstColumn = btn10.Text == turn && btn20.Text == turn && btn30.Text == turn;
            var secondColumn = btn11.Text == turn && btn21.Text == turn && btn31.Text == turn;
            var thirdColumn = btn12.Text == turn && btn22.Text == turn && btn32.Text == turn;

            var firstDiagonal = btn10.Text == turn && btn21.Text == turn && btn32.Text == turn;
            var secondDiagonal = btn12.Text == turn && btn21.Text == turn && btn30.Text == turn;

            // Check if any of the winning conditions are met
            if (firstRow || secondRow || thirdRow || firstColumn || secondColumn || thirdColumn || firstDiagonal || secondDiagonal)
            {
                Endgame(); // Call the Endgame method to reset the game
            }
            turn = turn == "X" ? turn = "O" : turn = "X"; // Toggle the turn between "X" and "O"
        }

        public void Endgame()
        {
            // Display an alert to the user indicating the game has ended
            DisplayAlert("Game Over", $"Player {turn} wins!", "OK");

            foreach (var button in buttons)
            {
                button.Text = ""; // Clear the text of all buttons
                button.IsEnabled = true; // Enable all buttons
            }
        }
    }

}
