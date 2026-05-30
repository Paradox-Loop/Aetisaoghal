using UnityEngine;
using UnityEngine.UI;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public class LayoutModif : MonoBehaviour
    {
        private RectTransform parentRT;
        private GridLayoutGroup layoutGroup;
        public float lenght;
        public float height;
        public float xPos;
        public float yPos;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            parentRT = GetComponentInParent<RectTransform>();
            layoutGroup = GetComponentInParent<GridLayoutGroup>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void Resize()
        {
            GridLayoutGroup.
        }
    }
}
