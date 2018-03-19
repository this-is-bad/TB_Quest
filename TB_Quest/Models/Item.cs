using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest
{
    public class Item : GameObject
    {
        public override string Description { get; set; }
        public override int LocationID { get; set; }
        public override string Name { get; set; }
        public override int ObjectID { get; set; }
        public override int ExperiencePoints { get; set; }
    }
}
