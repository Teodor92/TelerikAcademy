using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Ninja : Character, IGatherer, IFighter
    {
        private int currentAttackPoints = 0;

        public Ninja(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = 1;
        }

        public int AttackPoints
        {
            get { return this.currentAttackPoints; }
        }

        public int DefensePoints
        {
            get { return int.MaxValue; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner
                    && availableTargets[i].Owner != 0
                    && availableTargets[i].HitPoints == availableTargets.Max(x => x.HitPoints))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                this.currentAttackPoints = this.currentAttackPoints + (resource.Quantity * 2);
                return true;
            }

            if (resource.Type == ResourceType.Lumber)
            {
                this.currentAttackPoints = this.currentAttackPoints + resource.Quantity;
                return true;
            }

            return false;
        }
    }
}
