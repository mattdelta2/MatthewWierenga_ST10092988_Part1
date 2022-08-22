using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatthewWierenga_ST10092988_Part1
{
    public partial class Form1 : Form
    {
        protected GameEngine GM;
        public Form1()
        {
            InitializeComponent();

            GM = new GameEngine();

            RedrawMap();
            rtbInfo.Text = GM.GAMEMAP.PLAYERCHARACTER.ToString();

            foreach (Enemy G in GM.GAMEMAP.ENEMIES)
            {
                cbxEnemies.Items.Add(G.ToString());
            }

            cbxEnemies.SelectedIndex = 0;
            rtbSelectedEnemy.Text = GM.GAMEMAP.ENEMIES[cbxEnemies.SelectedIndex].ToString();
        }

        void RedrawMap()
        {
            lblMap.Text = GM.GAMEMAP.ToString();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (GM.MovePlayer(MovementDirection.Right))
            {
                
                RedrawMap();
                GM.GAMEMAP.UpdateVision();
                rtbInfo.Text = GM.GAMEMAP.PLAYERCHARACTER.ToString();
            }

        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (GM.MovePlayer(MovementDirection.Up))
            {
                
                RedrawMap();
                GM.GAMEMAP.UpdateVision();
                rtbInfo.Text = GM.GAMEMAP.PLAYERCHARACTER.ToString();
            }

        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (GM.MovePlayer(MovementDirection.Left))
            {
                
                RedrawMap();
                GM.GAMEMAP.UpdateVision();
                rtbInfo.Text = GM.GAMEMAP.PLAYERCHARACTER.ToString();
            }

        }

        private void btnDown_Click(object sender, EventArgs e)
        {

            if (GM.MovePlayer(MovementDirection.Down))
            {
                
                RedrawMap();
                GM.GAMEMAP.UpdateVision();
                rtbInfo.Text = GM.GAMEMAP.PLAYERCHARACTER.ToString();
            }

        }

        private void cbxEnemies_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbSelectedEnemy.Text = GM.GAMEMAP.ENEMIES[cbxEnemies.SelectedIndex].ToString();
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {

            rtbAttackLog.Text += GM.PlayerAttack(cbxEnemies.SelectedIndex) + "\n \n";
            rtbSelectedEnemy.Text = GM.GAMEMAP.ENEMIES[cbxEnemies.SelectedIndex].ToString();
        }

    }
    }

