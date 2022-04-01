using UnityEngine;
using UnityEngine.EventSystems;

namespace Relanima
{
    public class DragUI : EventTrigger
    {
        private bool isDragging;

        // Update is called once per frame
        private void Update()
        {
            if (isDragging)
            {
                transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            }
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            isDragging = true;
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            isDragging = false;
        }
    }
}
