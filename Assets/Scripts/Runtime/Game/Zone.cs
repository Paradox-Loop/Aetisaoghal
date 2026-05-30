using System.Collections.Generic;
using Unity.Netcode;
using static Unity.Template.Multiplayer.NGO.Runtime.EnumLibrary;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public abstract class Zone : NetworkBehaviour
    {
        protected List<Card> cardsInZone;
        protected List<EnumLibrary.CardTypes> validCardTypes;

        public abstract List<Card> GetCardsInZone();

        public virtual void AddCardsToZone(List<Card> cardsToAdd)
        {
            foreach (Card card in cardsToAdd)
            {
                if(!IsCardValidInZone(card))
                {
                    cardsToAdd.Remove(card);
                    if(cardsToAdd.Count == 0 ) //exit if list is empty
                    { break; }
                }
                
            }
            cardsInZone.AddRange(cardsToAdd);
        }

        protected bool IsCardValidInZone(Card card)
        {
            bool valid = false;
            foreach (EnumLibrary.CardTypes type in validCardTypes)
            {
                if(type == card.cardType)
                {
                    valid = true; break;
                }
            }
            return valid;
        }

        
      
    }
}