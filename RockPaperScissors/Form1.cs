using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace RockPaperScissors
{
    public partial class Form1 : Form
    {
        string playerChoice, cpuChoice;

        int wins, losses, ties = 0;

        Random randGen = new Random();

        SoundPlayer jabPlayer = new SoundPlayer(Properties.Resources.jabSound);
        SoundPlayer gongPlayer = new SoundPlayer(Properties.Resources.gong);

        Image rockImage = Properties.Resources.rock168x280;
        Image paperImage = Properties.Resources.paper168x280;
        Image scissorImage = Properties.Resources.scissors168x280;
        Image winImage = Properties.Resources.winTrans;
        Image loseImage = Properties.Resources.loseTrans;
        Image tieImage = Properties.Resources.tieTrans;

        public Form1()
        {
            InitializeComponent();
        }

        private void rockButton_Click(object sender, EventArgs e)
        {
            playerChoice = "rock";
            playerImage.BackgroundImage = rockImage;

            computerTurn();
            decideWinner();
        }

        private void paperButton_Click(object sender, EventArgs e)
        {
            playerChoice = "paper";
            playerImage.BackgroundImage = paperImage;

            computerTurn();
            decideWinner();
        }

        private void scissorsButton_Click(object sender, EventArgs e)
        {
            playerChoice = "scissors";
            playerImage.BackgroundImage = scissorImage;

            computerTurn();
            decideWinner();
        }

        public void computerTurn()
        {
            jabPlayer.Play();

            int randValue = randGen.Next(1, 4);

            if (randValue == 1)
            {
                cpuChoice = "rock";
                cpuImage.BackgroundImage = rockImage;
            }
            else if (randValue == 2)
            {
                cpuChoice = "paper";
                cpuImage.BackgroundImage = paperImage;
            }
            else
            {
                cpuChoice = "scissors";
                cpuImage.BackgroundImage = scissorImage;
            }

            Refresh();
            Thread.Sleep(1000);
            gongPlayer.Play();
        }

        public void decideWinner()
        {
            if (playerChoice == cpuChoice)
            {
                resultImage.BackgroundImage = tieImage;
                ties++;
                tiesLabel.Text = $"Ties: {ties}";
            }
            else if ((playerChoice == "rock" && cpuChoice == "scissors") || (playerChoice == "scissors" && cpuChoice == "paper") || (playerChoice == "paper" && cpuChoice == "rock"))
            {
                resultImage.BackgroundImage = winImage;
                wins++;
                winsLabel.Text = $"Wins: {wins}";
            }
            else
            {
                resultImage.BackgroundImage = loseImage;
                losses++;
                lossesLabel.Text = $"Losses: {losses}";
            }

            Refresh();
            Thread.Sleep(2000);
            playerImage.BackgroundImage = null;
            cpuImage.BackgroundImage = null;
            resultImage.BackgroundImage = null;
        }
    }
}