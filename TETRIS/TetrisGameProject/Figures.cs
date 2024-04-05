using System.Collections.Generic;

namespace TETRIS.TetrisGameProject
{
    public static class Figures
    {
        /// <summary>
        /// Список всех возможных фигур
        /// </summary>
        public static List<BlockFigure> FigureTypes { get; } = new List<BlockFigure>
        {
            new BlockFigure(new System.Drawing.Point[]
                {
                    /// .##
                    /// ##.
                    
                    new System.Drawing.Point(1, 0),
                    new System.Drawing.Point(2, 0),
                    new System.Drawing.Point(0, 1),
                    new System.Drawing.Point(1, 1),
                }
            ),
            new BlockFigure(new System.Drawing.Point[]
                {
                    /// ####

                    new System.Drawing.Point(0, 0),
                    new System.Drawing.Point(1, 0),
                    new System.Drawing.Point(2, 0),
                    new System.Drawing.Point(3, 0),
                }
            ),
            new BlockFigure(new System.Drawing.Point[]
                {
                    /// ##.
                    /// .##

                    new System.Drawing.Point(0, 0),
                    new System.Drawing.Point(0, 1),
                    new System.Drawing.Point(1, 1),
                    new System.Drawing.Point(2, 1),
                }
            ),
            new BlockFigure(new System.Drawing.Point[]
                {
                    /// ##
                    /// ##

                    new System.Drawing.Point(0, 0),
                    new System.Drawing.Point(0, 1),
                    new System.Drawing.Point(1, 0),
                    new System.Drawing.Point(1, 1),
                }
            ),
            new BlockFigure(new System.Drawing.Point[]
                {
                    /// ###
                    /// #..

                    new System.Drawing.Point(0, 0),
                    new System.Drawing.Point(1, 0),
                    new System.Drawing.Point(2, 0),
                    new System.Drawing.Point(0, 1),
                }
            ),
            new BlockFigure(new System.Drawing.Point[]
                {
                    /// #..
                    /// ###

                    new System.Drawing.Point(0, 0),
                    new System.Drawing.Point(0, 1),
                    new System.Drawing.Point(1, 1),
                    new System.Drawing.Point(2, 1),
                }
            ),
            new BlockFigure(new System.Drawing.Point[]
                {
                    /// .#.
                    /// ###

                    new System.Drawing.Point(1, 0),
                    new System.Drawing.Point(0, 1),
                    new System.Drawing.Point(1, 1),
                    new System.Drawing.Point(2, 1),
                }
            ),
        };
    }
}
