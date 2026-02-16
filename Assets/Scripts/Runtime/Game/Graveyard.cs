using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public abstract class Graveyard : Zone, UnityEditor.Experimental.GraphView.ISelectable
    {
        void Start()
        {
            validCardTypes = new List<EnumLibrary.CardTypes> { EnumLibrary.CardTypes.Spell, EnumLibrary.CardTypes.Unit };
        }
        public bool HitTest(Vector2 localPoint)
        {
            throw new System.NotImplementedException();
        }

        public override List<Card> GetCardsInZone()
        {
            return cardsInZone;
        }

        public bool IsSelectable()
        {
            if(cardsInZone.Count == 0)
            {
                return false;
            }
            return true;
        }

        public bool IsSelected(VisualElement selectionContainer)
        {
            throw new System.NotImplementedException();
        }

        public bool Overlaps(Rect rectangle)
        {
            throw new System.NotImplementedException();
        }

        public void Select(VisualElement selectionContainer, bool additive)
        {
            throw new System.NotImplementedException();
        }

        public void Unselect(VisualElement selectionContainer)
        {
            throw new System.NotImplementedException();
        }
    }
}
