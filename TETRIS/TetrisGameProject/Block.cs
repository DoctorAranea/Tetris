using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TETRIS.TetrisGameProject
{
    public class Block
    {
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        private Point location;

        public Block(Color blockColor, Point location)
        {
            BlockColor = blockColor;
            this.location = location;
        }

        public Color BlockColor { get; set; }
        public Point Location { get => location; set => location = value; }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    location.Y--;
                    break;
                case Direction.Down:
                    location.Y++;
                    break;
                case Direction.Left:
                    location.X--;
                    break;
                case Direction.Right:
                    location.X++;
                    break;
            }
        }

        public bool CheckWall(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return location.Y - 1 >= 0;
                case Direction.Down:
                    return location.Y + 1 < TetrisGame.FieldSize.Height;
                case Direction.Left:
                    return location.X - 1 >= 0;
                case Direction.Right:
                    return location.X + 1 < TetrisGame.FieldSize.Width;
            }
            return false;
        }

        public bool CheckBlocks(Direction direction, List<Block> blocks)
        {
            Point[] fieldBlocks = blocks.Select(x => x.Location).ToArray();

            switch (direction)
            {
                case Direction.Up:
                    return fieldBlocks.FirstOrDefault(x => x.X == location.X && x.Y == location.Y - 1).IsEmpty;
                case Direction.Down:
                    return fieldBlocks.FirstOrDefault(x => x.X == location.X && x.Y == location.Y + 1).IsEmpty;
                case Direction.Left:
                    return fieldBlocks.FirstOrDefault(x => x.X == location.X - 1 && x.Y == location.Y).IsEmpty;
                case Direction.Right:
                    return fieldBlocks.FirstOrDefault(x => x.X == location.X + 1 && x.Y == location.Y).IsEmpty;
            }
            return false;
        }
    }
}
