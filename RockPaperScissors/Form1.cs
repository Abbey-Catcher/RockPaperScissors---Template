using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

/// <summary>
/// A rock, paper, scissors game that utilizes basic methods
/// for repetitive tasks.
/// </summary>

namespace RockPaperScissors
{
    public partial class Form1 : Form
    {
        string playerChoice, cpuChoice;

        int wins = 0;
        int losses = 0;
        int ties = 0;
        int choicePause = 1000;
        int outcomePause = 3000;

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
            /// TODO Set the playerchoice value, show the appropriate image,

            //set player choices
            playerChoice = "rock";
            playerImage.BackgroundImage = rockImage;
            jabPlayer.Play();

            computerTurn();
        }

        private void paperButton_Click(object sender, EventArgs e)
        {
            //set player choices
            playerChoice = "paper";
            playerImage.BackgroundImage = paperImage;
            jabPlayer.Play();

            computerTurn();
        }

        private void scissorsButton_Click(object sender, EventArgs e)
        {
            //set player choices
            playerChoice = "scissors";
            playerImage.BackgroundImage = scissorImage;
            jabPlayer.Play();

            computerTurn();
        }

        public void computerTurn()
        {
            //computer shape
            int randValue = randGen.Next(1, 4);

            //set cpu choices
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
            //select winner and update variables
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