using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TETRIS.TetrisGameProject
{
    public class BlockFigure
    {
        private Block[] blocks;
        private Color figureColor;

        public BlockFigure(Point[] blockPoints)
        {
            int mainChannel = TetrisGame.Rand.Next(3);

            int upperBound = 220;

            int[] rgb = new int[3]
            {
                TetrisGame.Rand.Next(180, upperBound),
                TetrisGame.Rand.Next(180, upperBound),
                TetrisGame.Rand.Next(180, upperBound)
            };
            for (int i = 0; i < rgb.Length; i++)
            {
                if (i == mainChannel)
                    rgb[i] = 255/*(int)(rgb[i] * 1.5)*/;
                else
                    rgb[i] = (int)(rgb[i] / 1.3);
            }

            if (rgb[mainChannel] > upperBound) rgb[mainChannel] = upperBound;
            figureColor = Color.FromArgb(rgb[0], rgb[1], rgb[2]);

            blocks = new Block[blockPoints.Length];
            for (int i = blockPoints.Length - 1; i >= 0; i--)
            {
                blocks[i] = new Block(FigureColor, blockPoints[i]);
            }
        }

        public Block[] Blocks { get => blocks; }
        public Color FigureColor { get => figureColor; }
        public Point UpLeftBlockLocation { get => new Point(blocks.Min(y => y.Location.X), blocks.Min(y => y.Location.Y)); }
        public int Width { get => blocks.Max(x => x.Location.X) - blocks.Min(x => x.Location.X) + 1; }
        public int Height { get => blocks.Max(x => x.Location.Y) - blocks.Min(x => x.Location.Y) + 1; }

        public BlockFigure GetCopy()
        {
            List<Point> newBlocks = new List<Point>();
            for (int i = 0; i < blocks.Length; i++)
                newBlocks.Add(blocks[i].Location);

            return new BlockFigure(newBlocks.ToArray());
        }

        public Point GetBlockLocalPosition(Point blockPosition) => new Point(blockPosition.X - UpLeftBlockLocation.X, blockPosition.Y - UpLeftBlockLocation.Y);

        public Block[] Move(Block.Direction direction, List<Block> fieldBlocks)
        {
            bool canMove = true;
            for (int i = 0; i < blocks.Length; i++)
            {
                if (blocks[i].CheckWall(direction))
                    if (blocks[i].CheckBlocks(direction, fieldBlocks))
                        continue;
                canMove = false;
                break;
            }

            if (canMove)
            {
                for (int i = 0; i < blocks.Length; i++)
                {
                    blocks[i].Move(direction);
                }

                return null;
            }
            else
                return Blocks;
        }

        public bool Rotate(List<Block> fieldBlocks)
        {
            Block[,] twoDimensionalBlocksArray = new Block[Width, Height];
            Block[,] newTwoDimensionalBlocksArray = new Block[Height, Width];

            for (int i = 0; i < blocks.Length; i++)
            {
                var localPos = GetBlockLocalPosition(blocks[i].Location);
                twoDimensionalBlocksArray[localPos.X, localPos.Y] = blocks[i];
            }

            for (int y = 0; y < twoDimensionalBlocksArray.GetLength(1); y++)
            {
                for (int x = 0; x < twoDimensionalBlocksArray.GetLength(0); x++)
                {
                    Point newPos = new Point(twoDimensionalBlocksArray.GetLength(1) - 1 - y, x);
                    newTwoDimensionalBlocksArray[newPos.X, newPos.Y] = twoDimensionalBlocksArray[x, y];
                }
            }

            Point rotationCenter = UpLeftBlockLocation;
            for (int y = 0; y < newTwoDimensionalBlocksArray.GetLength(1); y++)
            {
                for (int x = 0; x < newTwoDimensionalBlocksArray.GetLength(0); x++)
                {
                    if (newTwoDimensionalBlocksArray[x, y] != null)
                        if (
                                x + rotationCenter.X >= TetrisGame.FieldSize.Width ||
                                y + rotationCenter.Y >= TetrisGame.FieldSize.Height ||
                                fieldBlocks.FirstOrDefault(block => block.Location.X == x + rotationCenter.X && block.Location.Y == y + rotationCenter.Y) != null
                            )
                            return false;
                }
            }

            for (int y = 0; y < newTwoDimensionalBlocksArray.GetLength(1); y++)
            {
                for (int x = 0; x < newTwoDimensionalBlocksArray.GetLength(0); x++)
                {
                    if (newTwoDimensionalBlocksArray[x, y] != null)
                        newTwoDimensionalBlocksArray[x, y].Location = new Point(x + rotationCenter.X, y + rotationCenter.Y);
                }
            }

            return true;
        }
    }
}
