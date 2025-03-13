using UnityEngine;
using UnityEngine.EventSystems;

namespace SimpleInputNamespace
{
    public class BreakInput : MonoBehaviour, ISimpleInputDraggable
    {
        public SimpleInput.ButtonInput brakeButton = new SimpleInput.ButtonInput("Brake");

#pragma warning disable 0649
        [Tooltip("Radius of the deadzone at the center of the arrows that will yield no input")]
        [SerializeField]
        private float deadzoneRadius;
        private float deadzoneRadiusSqr;
#pragma warning restore 0649

        private RectTransform rectTransform;

        private void Awake()
        {
            rectTransform = (RectTransform)transform;
            gameObject.AddComponent<SimpleInputDragListener>().Listener = this;

            deadzoneRadiusSqr = deadzoneRadius * deadzoneRadius;
        }

        private void OnEnable()
        {
            brakeButton.StartTracking();
        }

        private void OnDisable()
        {
            brakeButton.StopTracking();
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            deadzoneRadiusSqr = deadzoneRadius * deadzoneRadius;
        }
#endif

        public void OnPointerDown(PointerEventData eventData)
        {
            CalculateInput(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            CalculateInput(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            brakeButton.value = false;
        }

        private void CalculateInput(PointerEventData eventData)
        {
            Vector2 pointerPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out pointerPos);

            // Check if the brake button should be pressed
            brakeButton.value = (pointerPos.y < 0f && Mathf.Abs(pointerPos.x) < deadzoneRadius);
        }
    }
}