﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest
{
    /// <summary>
    /// static class sets the layout of the game screen
    /// </summary>
    public static class ConsoleLayout
    {
        //
        // console window configuration
        //
        public static int WindowWidth = 160;
        public static int WindowHeight = 40;
        public static int WindowPositionLeft = 0;
        public static int WindowPositionTop = 0;

        //
        // header configuration
        //
        // Note: The header height is the sum of lines of text and 2 blank lines.
        //       The top positions of other elements should be adjusted accordingly and
        //       the number of lines of text displayed by the header should not change.
        public static int HeaderWidth = 158;
        public static int HeaderPositionLeft = 0;
        public static int HeaderPositionTop = 0;

        //
        // footer configuration
        //
        // Note: The footer height is the sum of lines of text and 2 blank lines.
        //       The heights of other elements should be adjusted accordingly and
        //       the number of lines of text displayed by the footer should not change.
        public static int FooterWidth = 158;
        public static int FooterPositionLeft = 0;
        public static int FooterPositionTop = 37;

        //
        // menu box configuration
        //
        public static int MenuBoxWidth = 37;
        public static int MenuBoxHeight = 20;
        public static int MenuBoxPositionLeft = 120;
        public static int MenuBoxPositionTop = 3;

        //
        // message box configuration
        //
        public static int MessageBoxWidth = 118;
        public static int MessageBoxHeight = 30;
        public static int MessageBoxPositionLeft = 1;
        public static int MessageBoxPositionTop = 3;

        //
        // input box configuration
        //
        public static int InputBoxWidth = 118;
        public static int InputBoxHeight = 4;
        public static int InputBoxPositionLeft = 1;
        public static int InputBoxPositionTop = 33;

        //
        // status box configuration
        //
        public static int StatusBoxWidth = 37;
        public static int StatusBoxHeight = 14;
        public static int StatusBoxPositionLeft = 120;
        public static int StatusBoxPositionTop = 23;
    }
}
