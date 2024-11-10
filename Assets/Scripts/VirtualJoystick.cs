using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private RectTransform joystickBackground;
    private RectTransform joystickHandle;

    public Vector3 InputDirection { get; private set; } = Vector3.zero; // 3D input direction

    void Start()
    {
        joystickBackground = GetComponent<RectTransform>();
        joystickHandle = transform.GetChild(0).GetComponent<RectTransform>(); // Handle is the first child of joystick
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBackground, eventData.position, eventData.pressEventCamera, out position))
        {
            position.x = (position.x / joystickBackground.sizeDelta.x) * 2;
            position.y = (position.y / joystickBackground.sizeDelta.y) * 2;

            // Convert to 3D input direction on XZ plane for movement
            InputDirection = new Vector3(position.x, 0, position.y);
            InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;

            joystickHandle.anchoredPosition = new Vector2(
                InputDirection.x * (joystickBackground.sizeDelta.x / 2),
                InputDirection.z * (joystickBackground.sizeDelta.y / 2));
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        InputDirection = Vector3.zero;
        joystickHandle.anchoredPosition = Vector2.zero;
    }

    public float Horizontal => InputDirection.x;
    public float Vertical => InputDirection.z;
}
