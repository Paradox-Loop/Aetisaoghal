using System.Collections.Generic;
using Unity.Netcode;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public abstract class Zone : NetworkBehaviour
    {
        protected List<Card> cardsInZone;

        public abstract List<Card> GetCardsInZone();
    }
}