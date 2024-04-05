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
            try
            {
                float[,] newBrightnessMap = GetBrightnessMap("blockSkin.png");
                TetrisGame.BlockSkinBrightnessMap = newBrightnessMap;
            }
            catch { }

            try
            {
                float[,] newBackgroundBrightnessMap = GetBrightnessMap("backgroundSkin.png");
                TetrisGame.BackgroundBlockSkinBrightnessMap = newBackgroundBrightnessMap;
            }
            catch { }

            game = new GameForm();
            game.TopLevel = false;
            game.TopMost = true;
            mainPanel.Controls.Add(game);
            game.Show();
            ResizeGameForm();
        }

        private static float[,] GetBrightnessMap(string filename)
        {
            Bitmap skin = new Bitmap(filename);
            float[,] newBrightnessMap = new float[skin.Width, skin.Height];
            for (int y = 0; y < skin.Height; y++)
            {
                for (int x = 0; x < skin.Width; x++)
                {
                    Color pixel = skin.GetPixel(x, y);
                    float brightness = pixel.GetBrightness();
                    newBrightnessMap[x, y] = brightness;
                }
            }

            return newBrightnessMap;
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
