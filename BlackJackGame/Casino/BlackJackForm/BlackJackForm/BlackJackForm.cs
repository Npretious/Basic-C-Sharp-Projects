using System;
using System.Windows.Forms;
using Casino;
using Casino.BlackJackGame;

namespace BlackJack
{
    public partial class BlackJackForm : Form
    {
        private Label dealerHandLabel;
        private Label playerHandLabel;
        private Button hitButton;
        private Button stayButton;

        private BlackJackGame game;
        private Player player;
        private BlackJackDealer Dealer;

        public BlackJackForm()
        {
            InitializeComponent();

            // Initialize the game and player
            game = new BlackJackGame();
            player = new Player("Player", 100);
            game.Players.Add(player);
            Dealer = game.Dealer;

            // Create the dealer hand label
            dealerHandLabel = new Label();
            dealerHandLabel.Text = "Dealer's Hand:";
            dealerHandLabel.Location = new System.Drawing.Point(10, 10);
            dealerHandLabel.AutoSize = true;
            this.Controls.Add(dealerHandLabel);

            // Create the player hand label
            playerHandLabel = new Label();
            playerHandLabel.Text = "Player's Hand:";
            playerHandLabel.Location = new System.Drawing.Point(10, 30);
            playerHandLabel.AutoSize = true;
            this.Controls.Add(playerHandLabel);

            // Create the hit button
            hitButton = new Button();
            hitButton.Text = "Hit";
            hitButton.Location = new System.Drawing.Point(10, 50);
            hitButton.Click += HitButton_Click;
            this.Controls.Add(hitButton);

            // Create the stay button
            stayButton = new Button();
            stayButton.Text = "Stay";
            stayButton.Location = new System.Drawing.Point(80, 50);
            stayButton.Click += StayButton_Click;
            this.Controls.Add(stayButton);

            // Start a new game
            StartNewGame();
        }

        private void StartNewGame()
        {
            // Initialize the game state
            Dealer.Deck.Shuffle();
            player.Hand.Clear();
            Dealer.Hand.Clear();

            // Deal two cards to the player and dealer
            Dealer.Deal(player.Hand);
            Dealer.Deal(player.Hand);
            Dealer.Deal(Dealer.Hand);
            Dealer.Deal(Dealer.Hand);

            // Update the hand labels to display the initial cards
            dealerHandLabel.Text = "Dealer's Hand: " + string.Join(", ", Dealer.Hand);
            playerHandLabel.Text = "Player's Hand: " + string.Join(", ", player.Hand);
        }

        private void HitButton_Click(object sender, EventArgs e)
        {
            // Add code to handle the "hit" action
            // Example: Deal a card to the player's hand
            Dealer.Deal(player.Hand);
            // Update the player hand label to display the new card
            playerHandLabel.Text = "Player's Hand: " + string.Join(", ", player.Hand);

            // Check if the player has a blackjack or is busted
            if (BlackJackRules.CheckForBlackJack(player.Hand))
            {
                // Handle blackjack
                MessageBox.Show("Blackjack! You win!");
                // Update the player's balance and other game state as needed
                // ...
            }
            else if (BlackJackRules.IsBusted(player.Hand))
            {
                // Handle bust
                MessageBox.Show("Busted! You lose!");
                // Update the player's balance and other game state as needed
                // ...
            }
        }

        private void StayButton_Click(object sender, EventArgs e)
        {
            // Add code to handle the "stay" action
            // Example: Set the player's stay flag to true
            player.Stay = true;

            // Check if the dealer has a blackjack or is busted
            if (BlackJackRules.CheckForBlackJack(Dealer.Hand))
            {
                // Handle dealer blackjack
                MessageBox.Show("Dealer has blackjack! You lose!");
                // Update the player's balance and other game state as needed
                // ...
            }
            else if (BlackJackRules.IsBusted(Dealer.Hand))
            {
                // Handle dealer bust
                MessageBox.Show("Dealer is busted! You win!");
                // Update the player's balance and other game state as needed
                // ...
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BlackJackForm
            // 
            this.ClientSize = new System.Drawing.Size(1480, 581);
            this.Name = "BlackJackForm";
            this.ResumeLayout(false);

        }
    }
}

