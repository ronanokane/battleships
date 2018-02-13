using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BattleShipsClient
{
    public partial class FrmGames : Form
    {
        public FrmGames(ClientMain clientMain)
        {
            this.clientMain = clientMain;

            InitializeComponent();
        }

        public ListBox lstActiveGamesBox { get { return this.lstActiveGames; } }
        private ClientMain clientMain;

        private void lstActiveGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            // make sure we send ViewerStopViewing command when going from one viewing game to next

            this.btn_GameView.Enabled = (this.lstActiveGames.SelectedIndex != -1);
            this.btnJoinGame.Enabled = (this.lstActiveGames.SelectedIndex != -1);
        }

        private void btn_GameView_Click(object sender, EventArgs e)
        {
            if (lstActiveGames.Items.Count == 0) return;

            if (clientMain.gameInProgress)
                MessageBox.Show("We cannot view another game while we are currently engaged in one");
            else
            {
                clientMain.gameIdOfView = Int32.Parse(lstActiveGames.Items[lstActiveGames.SelectedIndex].ToString());

                clientMain.resetGuiFields();

                clientMain.sendPacketToServer("ViewGrids " + clientMain.gameIdOfView);

                this.Hide();
            }
        }

        private void btnJoinGame_Click(object sender, EventArgs e)
        {
            if (lstActiveGames.Items.Count == 0) return;

            string selectedGameId = lstActiveGames.Items[lstActiveGames.SelectedIndex].ToString();

            if (clientMain.gameInProgress)
            {
                if (selectedGameId == clientMain.gameIdentifier)
                {
                    MessageBox.Show("Already in selected game");
                    return;
                }

                if (MessageBox.Show("Are you sure you want to quit current game to try and join other game ?", "Game " + clientMain.gameIdentifier, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    clientMain.sendPacketToServer("QuitGame " + clientMain.gameIdentifier);
                    clientMain.resetGuiFields();
                    clientMain.sendPacketToServer("JoinGame " + selectedGameId);

                    this.Hide();
                }
            }
            else
            {
                clientMain.resetGuiFields();
                clientMain.sendPacketToServer("JoinGame " + selectedGameId);

                this.Hide();
            }
        }

        private void FrmGames_Load(object sender, EventArgs e)
        {

        }

        //public void InsertGames
    }
}
