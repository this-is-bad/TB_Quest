using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest
{
    interface IModify
    {
        /// <summary>
        /// a value that changes health
        /// </summary>
        int HealthModifier { get; set; }

        /// <summary>
        /// adjust health
        /// </summary>
        /// <returns>int</returns>
        int ReturnHealthModifier();
    }
}
