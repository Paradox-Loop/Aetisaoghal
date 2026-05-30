using UnityEngine;
using UnityEngine.EventSystems;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public class DraggingControl : MonoBehaviour, IDragHandler
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        [SerializeField] private bool isDragging = false;
        [SerializeField] private Card parent;
        MatchController matchController;

        // Update is called once per frame
        private void Start()
        {
            parent = GetComponentInParent<Card>();
            matchController.GetComponent<MatchController>();
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
            if (matchController.GetZone(parent) is Hand)
            {
                isDragging = true;
                //play hand drag anim

            }
            else if (matchController.GetZone(parent) is FrontLine || matchController.GetZone(parent) is BackLine)
            {
                isDragging = true;
                //play attack drag anim
            }
        }

        public void OnDragEnd()
        {
            isDragging = false;
            //remove drag anim
        }
    }
}
