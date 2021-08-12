/*
Student Name: Muhammad Murtaza
Student ID: K00223470 
Desc: Class which implements eevent handlers to detect when the FireButton is pressed or released.
*/


using UnityEngine;
using UnityEngine.EventSystems;

public class FireButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    public bool isPressed;
        
	// Implementing IPointerUpHandler interface of handling event when fire button is not pressed
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }

    // Implementing IPointerDownHandler interface of handling event when fire button is pressed
	public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

}
