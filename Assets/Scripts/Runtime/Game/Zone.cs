using System.Collections.Generic;
using Unity.Netcode;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    
    public abstract class Zone : NetworkBehaviour
    {
        protected List<Card> cardsInZone;

        //returns the list of Cards in this zone in the order they appear (used only in public information zones
        //Method must be overrided in zones where information is hidden
        public virtual List<Card> GetCardsInZone()
        {
            return cardsInZone;
        }
    }

}
