using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TETRIS.TetrisGameProject;

namespace TETRIS
{
    public static class TetrisGame_AnimationLogic
    {
        private static Dictionary<Point, int> doneBlocksDict = new Dictionary<Point, int>();
        private static int doneFrames = 6;

        // Обновление кадров эффектов
        public static void UpdateEffects()
        {
            List<Point> removedBlocks = new List<Point>();
            for (int i = 0; i < doneBlocksDict.Count; i++)
            {
                var block = doneBlocksDict.ElementAt(i);
                doneBlocksDict[block.Key] = block.Value - 1;
                if (block.Value == 0)
                    removedBlocks.Add(block.Key);
            }
            for (int i = 0; i < removedBlocks.Count; i++)
                doneBlocksDict.Remove(removedBlocks[i]);
        }

        // Отрисовка эффектов
        public static void DrawEffects(Graphics g)
        {
            var brush = new SolidBrush(Color.White);
            for (int i = 0; i < doneBlocksDict.Count; i++)
            {
                var block = doneBlocksDict.ElementAt(i);
                int animShift = (int)((doneFrames - block.Value) * 3);
                g.FillRectangle(brush, block.Key.X * TetrisGame.CELLSIZE + 1 + animShift, block.Key.Y * TetrisGame.CELLSIZE + 1 + animShift, TetrisGame.CELLSIZE - animShift * 2, TetrisGame.CELLSIZE - animShift * 2);
            }
        }

        // Добавление блока в список разрушенных
        public static void AddDestroyedBlock(int count, Block item)
        {
            Point effectPoint = new Point(item.Location.X, item.Location.Y - count);
            if (!doneBlocksDict.ContainsKey(item.Location))
                doneBlocksDict.Add(effectPoint, doneFrames);
            else
                doneBlocksDict[effectPoint] = doneFrames;
        }

        // Тряска элемента управления
        public static void ControlShake(Control control)
        {
            Point startPos = control.Location;
            int shakeCount = 3;
            int shakeStrength = 3;
            for (int i = 0; i < shakeCount; i++)
            {
                control.Location = new Point(TetrisGame.Rand.Next(startPos.X - shakeStrength, startPos.X + shakeStrength + 1), TetrisGame.Rand.Next(startPos.Y - shakeStrength, startPos.Y + shakeStrength + 1));
                Thread.Sleep(50);
            }
            control.Location = startPos;
        }
    }
}
