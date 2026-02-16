using System.Collections.Generic;
using UnityEngine;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public class BackLine : Zone
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            validCardTypes = new List<EnumLibrary.CardTypes> { EnumLibrary.CardTypes.Unit, EnumLibrary.CardTypes.Leader };
        }

        //// Update is called once per frame
        //void Update()
        //{

        //}

        public override List<Card> GetCardsInZone()
        {
            return cardsInZone;
        }
        
    }
}
