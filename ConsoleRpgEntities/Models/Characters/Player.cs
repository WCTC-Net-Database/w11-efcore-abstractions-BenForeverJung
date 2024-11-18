using System.ComponentModel.Design;
using ConsoleRpgEntities.Models.Abilities.PlayerAbilities;
using ConsoleRpgEntities.Models.Attributes;

namespace ConsoleRpgEntities.Models.Characters
{
    public class Player : ITargetable, IPlayer
    {
        public int Experience { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public virtual ICollection<Ability> Abilities { get; set; }

        public virtual Equipment? Equipment { get; set; }
        // public virtual ICollection<Equipment> Equipments { get; set; }


        public void Attack(ITargetable target)
        {
            // Player-specific attack logic
            if (Equipment.Weapon is not null)
            {
                Console.WriteLine($"{Name} attacks {target.Name} with a {Equipment?.Weapon.Name}, dealing {Equipment.Weapon.Attack} damage!");
                target.Health -= Equipment.Weapon.Attack;
                Console.WriteLine($"{target.Name} has {target.Health} health remaining.");
            }
            else
            {
                Console.WriteLine($"{Name} does not have a weapon to attack with!");
                UseAbility(Abilities.First(), target);
            }
        }

        public void UseAbility(IAbility ability, ITargetable target)
        {
            if (Abilities.Contains(ability))
            {
                ability.Activate(this, target);
            }
            else
            {
                Console.WriteLine($"{Name} does not have the ability {ability.Name}!");

            }
        }
    }
}
