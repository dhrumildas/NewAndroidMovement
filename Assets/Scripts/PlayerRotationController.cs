using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerRotationController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float rotationSpeed = 180f; // Degrees per second
    private bool isPressed = false;
    private Slider slider;
    
    // Reference to the player object that will rotate
    [SerializeField] private Transform playerTransform;

    void Start()
    {
        // Get the Slider component
        slider = GetComponent<Slider>();
        
        // Set initial slider value to 0.5 (neutral position)
        slider.value = 0.5f;
    }

    void Update()
    {
        // If slider is not being pressed, return to neutral position (0.5)
        if (!isPressed)
        {
            slider.value = 0.5f;
            return;
        }

        // Calculate rotation based on slider value
        float rotationAmount = CalculateRotation(slider.value);
        
        // Apply rotation to the player
        if (playerTransform != null)
        {
            playerTransform.Rotate(Vector3.up * rotationAmount * Time.deltaTime);
        }
    }

    private float CalculateRotation(float sliderValue)
    {
        // Convert slider value to rotation:
        // 0.0 -> -rotationSpeed (full speed anti-clockwise)
        // 0.5 -> 0 (no rotation)
        // 1.0 -> rotationSpeed (full speed clockwise)
        return (sliderValue - 0.5f) * 2f * rotationSpeed;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
}