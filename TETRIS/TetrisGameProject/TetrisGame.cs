using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TETRIS.TetrisGameProject
{
    public class TetrisGame : Control
    {
        public const int CELLSIZE = 25;

        public delegate void DG_UpdateScore(int score);
        public DG_UpdateScore D_UpdateScore = (int score) => { };

        public delegate void DG_UpdateNextFigure(BlockFigure figure);
        public DG_UpdateNextFigure D_UpdateNextFigure = (BlockFigure figure) => { };

        public static Random Rand { get; } = new Random();

        private static Size fieldSize;

        private PictureBox pBox;
        private Timer timer;

        private int score;
        private List<Block> blocks;
        private BlockFigure currentFigure;
        private BlockFigure nextFigure;

        private bool isGameplay = false;

        public TetrisGame() : base()
        {
            DoubleBuffered = true;

            pBox = new PictureBox();
            pBox.Parent = this;
            pBox.Dock = DockStyle.Fill;
            pBox.Paint += PictureBox_Paint;

            timer = new Timer();
            timer.Interval = 250;
            timer.Tick += Timer_Tick;
            timer.Start();

            Initialize();
        }

        private void Initialize()
        {
            fieldSize = new Size(10, 20);
            blocks = new List<Block>();
            score = 0;

            isGameplay = true;
            SpawnNewPlayer();
        }

        public static Size FieldSize { get => fieldSize; }

        private void SpawnNewPlayer()
        {
            if (nextFigure != null)
                currentFigure = nextFigure;
            else
                currentFigure = Figures.FigureTypes[Rand.Next(Figures.FigureTypes.Count)].GetCopy();

            var width = currentFigure.Blocks.Max(x => x.Location.X);
            int offset = fieldSize.Width / 2 - width;
            if (width == 3)
                offset++;

            for (int i = 0; i < offset; i++)
            {
                if (!MovePlayer(Block.Direction.Right))
                {
                    isGameplay = false;
                    return;
                }
            }

            nextFigure = Figures.FigureTypes[Rand.Next(Figures.FigureTypes.Count)].GetCopy();
        }

        public bool MovePlayer(Block.Direction direction)
        {
            if (!isGameplay)
                return false;

            lock (__lockTick)
            {
                if (currentFigure != null)
                    if (currentFigure.Move(direction, this.blocks) != null)
                        return false;
            }

            pBox.Invalidate();
            return true;
        }

        internal void Restart()
        {
            Initialize();
            D_UpdateScore(score);
            pBox.Invalidate();
        }

        public bool RotatePlayer()
        {
            if (!isGameplay)
                return false;

            lock (__lockTick)
            {
                if (currentFigure != null)
                    if (currentFigure.Rotate(this.blocks))
                        return false;
            }

            pBox.Invalidate();
            return true;
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (nextFigure != null)
                D_UpdateNextFigure(nextFigure);

            var g = e.Graphics;

            g.Clear(Color.DarkBlue);

            Pen linesPen = new Pen(Color.Gray);
            for (int y = 0; y <= fieldSize.Height; y++)
            {
                for (int x = 0; x <= fieldSize.Width; x++)
                {
                    g.DrawLine(linesPen, CELLSIZE * x, CELLSIZE * y, CELLSIZE * x, fieldSize.Height);
                    g.DrawLine(linesPen, CELLSIZE * x, CELLSIZE * y, fieldSize.Width, CELLSIZE * y);
                }
            }

            g.DrawLine(linesPen, fieldSize.Width * CELLSIZE - 1, 0, fieldSize.Width * CELLSIZE - 1, fieldSize.Height * CELLSIZE - 1);
            g.DrawLine(linesPen, 0, fieldSize.Height * CELLSIZE - 1, fieldSize.Width * CELLSIZE - 1, fieldSize.Height * CELLSIZE - 1);

            for (int i = 0; i < blocks.Count; i++)
            {
                var block = blocks[i];
                var location = block.Location;
                g.FillRectangle(new SolidBrush(block.BlockColor), location.X * CELLSIZE + 1, location.Y * CELLSIZE + 1, CELLSIZE/* + 1*/, CELLSIZE/* + 1*/);
            }

            if (currentFigure != null)
                for (int i = 0; i < currentFigure.Blocks.Length; i++)
                {
                    var block = currentFigure.Blocks[i];
                    var location = block.Location;
                    g.FillRectangle(new SolidBrush(block.BlockColor), location.X * CELLSIZE + 1, location.Y * CELLSIZE + 1, CELLSIZE/* + 1*/, CELLSIZE/* + 1*/);
                }
        }

        public static object __lockTick = new { };

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!isGameplay)
                return;

            if (currentFigure == null)
            {
                SpawnNewPlayer();
                pBox.Invalidate();
                return;
            }

            lock (__lockTick)
            {
                var blocks = currentFigure.Move(Block.Direction.Down, this.blocks);
                if (blocks != null)
                {
                    this.blocks.AddRange(blocks);
                    currentFigure = null;

                    int newScore = DoneLines();
                    score += newScore;
                    D_UpdateScore(score);
                }
            }
            pBox.Invalidate();
        }

        private int DoneLines()
        {
            int count = 0;

            for (int i = fieldSize.Height - 1; i >= 0; i--)
            {
                int blocksInLineCount = blocks.Count(x => x.Location.Y == i);

                if (blocksInLineCount == fieldSize.Width)
                {
                    blocks.RemoveAll(x => x.Location.Y == i);
                    blocks.Where(x => x.Location.Y < i).ToList().ForEach(new Action<Block>((Block x) => { x.Move(Block.Direction.Down); }));
                    count++;
                    i++;
                }
            }

            return count;
        }
    }
}
