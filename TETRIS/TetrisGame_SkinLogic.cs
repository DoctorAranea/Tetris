using ColorMine.ColorSpaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TETRIS.TetrisGameProject;

namespace TETRIS
{
    public static class TetrisGame_SkinLogic
    {
        public static Bitmap GetSkinBlock(Block block)
        {
            Bitmap skin = new Bitmap(TetrisGame.CELLSIZE, TetrisGame.CELLSIZE);
            for (int y = 0; y < TetrisGame.CELLSIZE; y++)
            {
                for (int x = 0; x < TetrisGame.CELLSIZE; x++)
                {
                    Rgb rgb = new Rgb() { R = block.BlockColor.R, G = block.BlockColor.G, B = block.BlockColor.B };
                    Hsb hsb = rgb.To<Hsb>();
                    hsb.S = .5;
                    hsb.B = TetrisGame.BlockSkinBrightnessMap[x, y];
                    Color pixelColor = hsb.ToSystemColor();
                    if (TetrisGame.BlockSkinBrightnessMap[x, y] == 0)
                        pixelColor = Color.FromArgb(0, pixelColor.R, pixelColor.G, pixelColor.B);
                    skin.SetPixel(x, y, pixelColor);
                }
            }

            return skin;
        }
    }
}
