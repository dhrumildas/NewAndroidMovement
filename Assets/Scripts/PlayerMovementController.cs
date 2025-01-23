using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMovementController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float moveSpeed = 5f; // Units per second
    private bool isPressed = false;
    private Slider slider;
    
    // Reference to the player object that will move
    [SerializeField] private Transform playerTransform;

    void Start()
    {
        // Get the Slider component
        slider = GetComponent<Slider>();
        
        // Set initial slider value to 0.5 (neutral position)
        slider.value = 0.5f;

        // If player reference is not set, try to find it
        if (playerTransform == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                playerTransform = player.transform;
            }
        }
    }

    void Update()
    {
        // If slider is not being pressed, return to neutral position (0.5)
        if (!isPressed)
        {
            slider.value = 0.5f;
            return;
        }

        // Calculate movement based on slider value
        float movement = CalculateMovement(slider.value);
        
        // Apply movement to the player
        if (playerTransform != null)
        {
            // Move the player forward or backward based on their current facing direction
            playerTransform.Translate(Vector3.forward * movement * Time.deltaTime);
        }
    }

    private float CalculateMovement(float sliderValue)
    {
        // Convert slider value to movement:
        // 0.0 -> +moveSpeed (forward)
        // 0.5 -> 0 (no movement)
        // 1.0 -> -moveSpeed (backward)
        return (0.5f - sliderValue) * 2f * moveSpeed;
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