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
        // Получение битмапы из карты яркости и цвета
        public static Bitmap GetSkin(float[,] brightnessMap, Color color)
        {
            Bitmap skin = new Bitmap(brightnessMap.GetLength(0), brightnessMap.GetLength(1));
            for (int y = 0; y < brightnessMap.GetLength(1); y++)
            {
                for (int x = 0; x < brightnessMap.GetLength(0); x++)
                {
                    Rgb rgb = new Rgb() { R = color.R, G = color.G, B = color.B };
                    Hsb hsb = rgb.To<Hsb>();
                    hsb.S = .5;
                    hsb.B = brightnessMap[x, y];
                    Color pixelColor = hsb.ToSystemColor();
                    if (brightnessMap[x, y] == 0)
                        pixelColor = Color.FromArgb(0, pixelColor.R, pixelColor.G, pixelColor.B);
                    skin.SetPixel(x, y, pixelColor);
                }
            }

            return skin;
        }

        // Отрисовка экземпляра блока
        public static void FillBlock(this Graphics g, Block block)
        {
            var location = block.Location;
            if (TetrisGame.BlockSkinBrightnessMap != default)
            {
                Bitmap skin = GetSkin(TetrisGame.BlockSkinBrightnessMap, block.BlockColor);
                g.DrawImage(skin, location.X * TetrisGame.CELLSIZE + 1, location.Y * TetrisGame.CELLSIZE + 1);
            }
            else
            {
                g.FillRectangle(new SolidBrush(block.BlockColor), location.X * TetrisGame.CELLSIZE + 1, location.Y * TetrisGame.CELLSIZE + 1, TetrisGame.CELLSIZE, TetrisGame.CELLSIZE);
            }
        }

        // Отрисовка заднего плана игрового поля
        public static void FillBackground(this Graphics g, Color color, int width, int height)
        {
            if (TetrisGame.BackgroundBlockSkinBrightnessMap != default)
            {
                Bitmap skin = GetSkin(TetrisGame.BackgroundBlockSkinBrightnessMap, color);

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        g.DrawImage(skin, new Point(x * skin.Width, y * skin.Height));
                    }
                }
            }
            else
            {
                g.Clear(color);
            }
        }
    }
}
