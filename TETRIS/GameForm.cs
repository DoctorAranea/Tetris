using System.Drawing;
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

            g.Clear(Color.DarkBlue);

            Pen linesPen = new Pen(Color.Gray);
            for (int y = 0; y <= 4; y++)
            {
                for (int x = 0; x <= 4; x++)
                {
                    g.DrawLine(linesPen, TetrisGame.CELLSIZE * x, TetrisGame.CELLSIZE * y, TetrisGame.CELLSIZE * x, 4);
                    g.DrawLine(linesPen, TetrisGame.CELLSIZE * x, TetrisGame.CELLSIZE * y, 4, TetrisGame.CELLSIZE * y);
                }
            }

            g.DrawLine(linesPen, 4 * TetrisGame.CELLSIZE - 1, 0, 4 * TetrisGame.CELLSIZE - 1, 4 * TetrisGame.CELLSIZE - 1);
            g.DrawLine(linesPen, 0, 4 * TetrisGame.CELLSIZE - 1, 4 * TetrisGame.CELLSIZE - 1, 4 * TetrisGame.CELLSIZE - 1);

            SolidBrush brush = new SolidBrush(figure.FigureColor);
            for (int i = 0; i < figure.Blocks.Length; i++)
            {
                var loc = figure.Blocks[i].Location;
                g.FillRectangle(brush, new Rectangle(new Point(loc.X * TetrisGame.CELLSIZE, loc.Y * TetrisGame.CELLSIZE), new Size(TetrisGame.CELLSIZE, TetrisGame.CELLSIZE)));
            }

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
