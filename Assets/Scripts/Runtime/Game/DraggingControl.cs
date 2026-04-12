using UnityEngine;
using UnityEngine.EventSystems;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public class DraggingControl : MonoBehaviour, IDragHandler
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        [SerializeField] private bool isDragging = false;
        [SerializeField] private Card parent;

        // Update is called once per frame
        private void Start()
        {
            parent = GetComponentInParent<Card>();
        }
        void Update()
        {
            if (isDragging)
            {
                transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }

        private void OnMouseDown()
        {
            isDragging = !isDragging;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if(parent.currentZone == Hand)

        }
    }
}
