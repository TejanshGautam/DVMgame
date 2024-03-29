using UnityEngine;
using UnityEngine.EventSystems;

public class MovementJoystick : MonoBehaviour
{
    public GameObject joystick;
    public GameObject joystickBG;
    public Vector2 joystickVec;
    private Vector2 joystickOriginalPos;
    private float joystickRadius;

    // Start is called before the first frame update
    void Start()
    {
        joystickOriginalPos = joystickBG.transform.position;
        joystickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 2;
    }

    public void PointerDown()
    {
        UpdateJoystickPosition(Input.mousePosition);
    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        UpdateJoystickPosition(pointerEventData.position);
    }

    private void UpdateJoystickPosition(Vector2 touchPos)
    {
        joystickVec = (touchPos - joystickOriginalPos).normalized;
        float joystickDist = Vector2.Distance(touchPos, joystickOriginalPos);

        if (joystickDist < joystickRadius)
        {
            joystick.transform.position = touchPos;
        }
        else
        {
            joystick.transform.position = joystickOriginalPos + joystickVec * joystickRadius;
        }
    }

    public void PointerUp()
    {
        joystickVec = Vector2.zero;
        joystick.transform.position = joystickOriginalPos;
    }
}
