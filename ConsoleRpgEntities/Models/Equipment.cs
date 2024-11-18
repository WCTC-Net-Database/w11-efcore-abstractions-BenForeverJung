

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRpgEntities.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public int? WeaponId { get; set; }
        public int? ArmorId { get; set; }



        //  Navigation Properties
        public virtual Item Weapon { get; set; }
        public virtual Item Armor { get; set; }

    }

    // public class Weapon : Equipment { }
    // public class Armor : Equipment { }


    public class Item
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
    

    }
}
