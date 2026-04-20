using System.Collections.Generic;
using UnityEngine;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public class Spell : Card
    {
        public void Resolve()
        {
            foreach(Effect effect in effects)
            {
                effect.ActivateEffect(this.rank, new List<GameObject> { this.gameObject });
            }
        }

        public override void RankUp(EnumLibrary.Ranks newRank, List<Effect> newEffects, 
            List<Trigger> newTriggers)
        {
            base.RankUp(newRank, newEffects, newTriggers);
        }
    }
}
