using ColorMine.ColorSpaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TETRIS.TetrisGameProject;

namespace TETRIS
{
    public partial class MainForm : Form
    {
        GameForm game;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            Bitmap skin = new Bitmap("blockSkin.png");
            float[,] newBrightnessMap = new float[TetrisGame.CELLSIZE, TetrisGame.CELLSIZE];
            for (int y = 0; y < TetrisGame.CELLSIZE; y++)
            {
                for (int x = 0; x < TetrisGame.CELLSIZE; x++)
                {
                    Color pixel = skin.GetPixel(x, y);
                    float brightness = pixel.GetBrightness();
                    newBrightnessMap[x, y] = brightness;
                }
            }
            TetrisGame.BlockSkinBrightnessMap = newBrightnessMap;

            game = new GameForm();
            game.TopLevel = false;
            game.TopMost = true;
            mainPanel.Controls.Add(game);
            game.Show();
            ResizeGameForm();
        }

        private void ResizeGameForm()
        {
            game.Size = new Size(game.Width, mainPanel.Height);
            game.Location = new Point(mainPanel.Width / 2 - game.Width / 2, mainPanel.Height / 2 - game.Height / 2);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            ResizeGameForm();
        }
    }
}
