using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.Xna.Framework.Graphics; 

namespace ChessGame
{
    public partial class Options : Form
    {
        ColorDialog colors;


        public Microsoft.Xna.Framework.Graphics.Color player1Color = Microsoft.Xna.Framework.Graphics.Color.White;
        public Microsoft.Xna.Framework.Graphics.Color player2Color = Microsoft.Xna.Framework.Graphics.Color.Black;
        public Boolean highlight = true;
        public Options()
        {
            InitializeComponent();
            
            highlight = OptionsHolder.HighlightMoves;
            System.Drawing.Color bg = System.Drawing.Color.FromArgb(100, 149, 237);
            this.BackColor = bg;
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            if (changed())
            {
                DialogResult re = MessageBox.Show("Would you like to Save?", "Cancel", MessageBoxButtons.YesNoCancel);
                if (re == DialogResult.Yes)
                {
                    //Save stuff
                    save();
                }
                else if (re == DialogResult.No)
                {
                    this.Close();
                }
                else if (re == DialogResult.Cancel)
                {
                    //nothing
                }
            }
            else
            {
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Save Stuff
            if (changed())
            {
                save();
            }
            else
            {
                this.Close();
            }

        }

        private void chkHighlight_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHighlight.Checked)
            {
                highlight = true;
            }
            else
            {
                highlight = false;
            }
        }

        private void btnPlayer1_Click(object sender, EventArgs e)
        {
            colors = new ColorDialog();
            if (colors.ShowDialog() != DialogResult.Cancel)
            {
                picPlayer1.BackColor = colors.Color;
                //player1Color = new Microsoft.Xna.Framework.Graphics.Color(colormaker(picPlayer1.BackColor));
                player1Color = new Microsoft.Xna.Framework.Graphics.Color( picPlayer1.BackColor.R, picPlayer1.BackColor.G, picPlayer1.BackColor.B, picPlayer1.BackColor.A );
            }
        }

        private void btnPlayer2_Click(object sender, EventArgs e)
        {
            colors = new ColorDialog();
            if (colors.ShowDialog() != DialogResult.Cancel)
            {
                picPlayer2.BackColor = colors.Color;
                player2Color = new Microsoft.Xna.Framework.Graphics.Color(picPlayer2.BackColor.R, picPlayer2.BackColor.G, picPlayer2.BackColor.B, picPlayer2.BackColor.A);
            }
        }

        private void save()
        {

                if (player1Color == player2Color)
                {
                    MessageBox.Show("You cannot have both players with the same color!", "Error", MessageBoxButtons.OK);
                }
                else
                {
                    OptionsHolder.Player1Color = player1Color;
                    OptionsHolder.Player2Color = player2Color;
                    OptionsHolder.HighlightMoves = highlight;
                    this.Close();
                }
        }

        private bool changed()
        {
            if (OptionsHolder.Player1Color == player1Color && OptionsHolder.Player2Color == player2Color && OptionsHolder.HighlightMoves == highlight)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Options_Load(object sender, EventArgs e)
        {
            highlight = OptionsHolder.HighlightMoves;
            chkHighlight.Checked = highlight;
            player1Color = OptionsHolder.Player1Color;
            player2Color = OptionsHolder.Player2Color;

            picPlayer1.BackColor = System.Drawing.Color.FromArgb((int)player1Color.A, (int)player1Color.R, (int)player1Color.G, (int)player1Color.B);
            picPlayer2.BackColor = System.Drawing.Color.FromArgb(player2Color.A, player2Color.R, player2Color.G, player2Color.B);
        }


    }
}
