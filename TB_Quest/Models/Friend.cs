using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest
{
    public class Friend : NPC, IModify, ISpeak
    {

        #region PROPERTIES

        /// <summary>
        /// the Friend ID
        /// </summary>
        public override int Id { get; set; }

        /// <summary>
        /// description of the Friend
        /// </summary>
        public override string Description { get; set; }

        /// <summary>
        /// the ISpeak dialog options
        /// </summary>
        public List<string> Messages { get; set; }

        /// <summary>
        /// the IModify health modifier
        /// </summary>
        public int HealthModifier { get; set; }
        #endregion

        #region METHODS

        /// <summary>
        /// generate a message or use a default
        /// </summary>
        /// <returns>string</returns>
        public string Speak()
        {
            if (this.Messages != null)
            {
                return GetMessage();
            }
            else
            {
                return $"My name is {base.Name} and I am a {base.Race}";
            }
        }

        /// <summary>
        /// randomly select a message from the list of messages
        /// </summary>
        /// <returns>string</returns>
        private string GetMessage()
        {
            Random r = new Random();
            int messageIndex = r.Next(0, Messages.Count());
            return Messages[messageIndex];
        }

        /// <summary>
        /// returns an integer to be applied to the player's health
        /// </summary>
        /// <returns>int</returns>
        public int ReturnHealthModifier()
        {

            return this.HealthModifier;
        }

        #endregion
    }
}