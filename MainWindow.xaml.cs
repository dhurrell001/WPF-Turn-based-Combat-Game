using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPfF_Turn_based_Game
{
    public partial class MainWindow : Window
    {
        private Character playerOne;
        private Character playerTwo;
        private Character currentPlayer;
        private bool gameStart = false;

        public MainWindow()
        {

            InitializeComponent();
            playerOne = new Character("Dave", 10, 12, 4);
            playerTwo = new Character("Bex", 10, 12, 4);
            //StartGame();


        }

        private void AttackButton_Click(object sender, RoutedEventArgs e)
        {


            if (currentPlayer.IsAlive && (currentPlayer == playerOne ? playerTwo : playerOne).IsAlive)
            {
                Combat.DealDamage(currentPlayer, currentPlayer == playerOne ? playerTwo : playerOne, statusBar);
                playTwoStats.Text = $"{(currentPlayer == playerOne ? playerTwo : playerOne).Health}";

                // Switch turns
                currentPlayer = currentPlayer == playerOne ? playerTwo : playerOne;



                // Update UI and status
                Display_Stats();

            }
            else
            {
                // Game over, display appropriate message
                UpdateStatus($"Game over - {currentPlayer.Name} wins!");
            }
        }



        private void Weapon_Menu_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of WeaponSelection. Remember the page is an object !!. Public properties set in weapons page
            // can be accessed elsewhere
            var weaponSelection = new WeaponSelection();

            // Show the WeaponSelection window
            weaponSelection.ShowDialog();

            // Access the selected weapon after the window is closed. Using dot notation to access the selected weapon property.
            Weapon selectedWeapon = weaponSelection.selectedWeapon;

            // Assign weapon to player
            if (selectedWeapon != null)
            {
                currentPlayer.EquippedWeapon = selectedWeapon;
                //statusBar.Text = currentPlayer.EquippedWeapon.Type;

            }
            Display_Stats();
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            // Toggle the gameStart variable
            gameStart = !gameStart;

            // If the game is starting, initialize the game
            if (gameStart)
            {
                StartGame();
                StartButton.Content = "QUIT";
            }
            else
            {
                // Reset the game state
                playerOne = new Character("Dave", 10, 12, 4);
                playerTwo = new Character("Bex", 10, 12, 4);
                currentPlayer = playerOne;

                // Update UI and status
                Display_Stats();

                StartButton.Content = "START";
            }
        }
        private void StartGame()
        {
            //playerOne = new Character("dave", 10, 12, 4);
            //playerTwo = new Character("bex", 10, 12, 4);
            currentPlayer = playerOne;
            playOneStats.Text = $"Name : {playerOne.Name}\nHealth : {playerOne.Health}\nStrength : {playerOne.Strength}\n Weapon: {playerOne.EquippedWeapon.Type}";
            playTwoStats.Text = $"Name : {playerTwo.Name}\nHealth : {playerTwo.Health}\nStrength : {playerTwo.Strength}\n Weapon: {playerTwo.EquippedWeapon.Type}";
            UpdateStatus($"{currentPlayer.Name}'s turn");
        }
        public void Display_Stats()
        {
            playOneStats.Text = $"Name : {playerOne.Name}\nHealth : {playerOne.Health}\nStrength : {playerOne.Strength}\n Weapon: {playerOne.EquippedWeapon.Type}";
            playTwoStats.Text = $"Name : {playerTwo.Name}\nHealth : {playerTwo.Health}\nStrength : {playerTwo.Strength}\n Weapon: {playerTwo.EquippedWeapon.Type}";
        }
        public void Use_Health_Potion(object sender, RoutedEventArgs e)
        {
            if (currentPlayer.Health_Potion != 0)
            {
                currentPlayer.Health += 10;
                currentPlayer.Health_Potion -= 1;
                Display_Stats();
            }
            else
            {
                statusBar.Text = ("You have used all your health potions");
            }
        }

        private void UpdateStatus(string message)
        {
            statusBar.Text = message;

            // Clear the TextBox after displaying the message
            ClearTextBoxAfterDelay(statusBar, 2000); // Clear after 2000 milliseconds (adjust as needed)
        }

        // Method to clear TextBox after a specified delay
        public async void ClearTextBoxAfterDelay(TextBox textBox, int delayMilliseconds)
        {
            await Task.Delay(delayMilliseconds);
            textBox.Text = string.Empty;
        }

    }
}
