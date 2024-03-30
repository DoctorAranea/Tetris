﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TETRIS.TetrisGameProject
{
    public static class Figures
    {
        public static List<BlockFigure> FigureTypes { get; } = new List<BlockFigure>
        {
            new BlockFigure(new System.Drawing.Point[]
                {
                    /// #.
                    /// ##
                    /// .#
                    
                    new System.Drawing.Point(0, 0),
                    new System.Drawing.Point(0, 1),
                    new System.Drawing.Point(1, 1),
                    new System.Drawing.Point(1, 2),
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
                    /// ..#
                    /// ###

                    new System.Drawing.Point(2, 0),
                    new System.Drawing.Point(0, 1),
                    new System.Drawing.Point(1, 1),
                    new System.Drawing.Point(2, 1),
                }
            ),
        };
    }
}