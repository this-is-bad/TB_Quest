﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest
{
    interface ISpeak
    {
        /// <summary>
        /// list of dialog options
        /// </summary>
        List<string> Messages { get; set; }

        /// <summary>
        /// speech
        /// </summary>
        /// <returns>string</returns>
        string Speak();
    }
}
