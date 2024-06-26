﻿using System.Drawing;
using System.Windows.Forms;
using TETRIS.TetrisGameProject;

namespace TETRIS
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
            tetrisGame1.D_UpdateScore = UpdateScore;
            tetrisGame1.D_UpdateNextFigure = UpdateNextFigure;
        }

        private void UpdateNextFigure(BlockFigure figure)
        {
            nextFigurePB.Image = null;
            Bitmap bitmap = new Bitmap(4 * TetrisGame.CELLSIZE, 4 * TetrisGame.CELLSIZE);
            Graphics g = Graphics.FromImage(bitmap);

            g.FillBackground(Color.FromArgb(0, 0, 92), 4, 4);

            Pen linesPen = new Pen(Color.Gray);

            #region --- Отрисовка сетки

            //for (int y = 0; y <= 4; y++)
            //{
            //    for (int x = 0; x <= 4; x++)
            //    {
            //        g.DrawLine(linesPen, TetrisGame.CELLSIZE * x, TetrisGame.CELLSIZE * y, TetrisGame.CELLSIZE * x, 4);
            //        g.DrawLine(linesPen, TetrisGame.CELLSIZE * x, TetrisGame.CELLSIZE * y, 4, TetrisGame.CELLSIZE * y);
            //    }
            //}

            #endregion

            for (int i = 0; i < figure.Blocks.Length; i++)
                g.FillBlock(figure.Blocks[i]);

            #region --- Отрисовка рамки

            g.DrawLine(linesPen, 0, 0, 4 * TetrisGame.CELLSIZE - 1, 0);
            g.DrawLine(linesPen, 0, 0, 0, 4 * TetrisGame.CELLSIZE - 1);
            g.DrawLine(linesPen, 4 * TetrisGame.CELLSIZE - 1, 0, 4 * TetrisGame.CELLSIZE - 1, 4 * TetrisGame.CELLSIZE - 1);
            g.DrawLine(linesPen, 0, 4 * TetrisGame.CELLSIZE - 1, 4 * TetrisGame.CELLSIZE - 1, 4 * TetrisGame.CELLSIZE - 1);

            #endregion

            nextFigurePB.Image = bitmap;
        }

        private void UpdateScore(int score)
        {
            scoreLabel.Text = score.ToString();
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    tetrisGame1.RotatePlayer();
                    break;
                case Keys.A:
                    tetrisGame1.MovePlayer(Block.Direction.Left);
                    break;
                case Keys.S:
                    tetrisGame1.MovePlayer(Block.Direction.Down);
                    break;
                case Keys.D:
                    tetrisGame1.MovePlayer(Block.Direction.Right);
                    break;
                case Keys.R:
                    tetrisGame1.Restart();
                    break;
            }
        }
    }
}
