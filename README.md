# Unity Slider-Based Player Movement 🎮✨

## Project Overview

This experimental Unity project introduces an innovative control scheme that leverages sliders for player movement and rotation. By reimagining traditional input methods, this project explores a unique approach to game controls that offers precise and intuitive player manipulation.

### 🚀 Motivation

In a world of conventional game controls, I challenged myself to create something different. When I couldn't find existing resources or tutorials about using sliders for player movement, I saw an opportunity to innovate and push the boundaries of interactive design.

## 🌟 Key Features

- **Dynamic Slider Control**: 
  - Forward and backward movement controlled by a single slider
  - Rotation achieved through a separate slider
  - Neutral slider positions ensure precise player control
  - Smooth speed and rotation adjustments for seamless gameplay

## Technical Implementation

### Movement Mechanics

The project consists of two primary scripts that handle player movement and rotation:

1. **PlayerMovementController**
   - Manages forward and backward translation based on slider position
   - Neutral position (slider value 0.5) stops player movement
   - Slider values map directly to movement speed and direction

2. **PlayerRotationController**
   - Controls player rotation using a dedicated slider
   - Enables clockwise and counter-clockwise rotation
   - Neutral position prevents rotation

### Script Breakdown

#### PlayerMovementController

```csharp
public class PlayerMovementController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Movement speed configurable in Unity Inspector
    [SerializeField] private float moveSpeed = 5f;
    
    // Tracks slider press state
    private bool isPressed = false;
    private Slider slider;
    
    // Reference to player transform for movement
    [SerializeField] private Transform playerTransform;

    void Start()
    {
        // Automatically find player if not manually assigned
        if (playerTransform == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            playerTransform = player?.transform;
        }
    }

    void Update()
    {
        // Automatically center slider when not pressed
        if (!isPressed)
        {
            slider.value = 0.5f;
            return;
        }

        // Calculate and apply movement based on slider position
        float movement = CalculateMovement(slider.value);
        playerTransform?.Translate(Vector3.forward * movement * Time.deltaTime);
    }

    // Converts slider value to precise movement
    private float CalculateMovement(float sliderValue)
    {
        return (0.5f - sliderValue) * 2f * moveSpeed;
    }
}
```

#### PlayerRotationController

```csharp
public class PlayerRotationController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Rotation speed configurable in Unity Inspector
    [SerializeField] private float rotationSpeed = 180f;
    
    // Tracks slider press state
    private bool isPressed = false;
    private Slider slider;
    
    // Reference to player transform for rotation
    [SerializeField] private Transform playerTransform;

    void Update()
    {
        // Automatically center slider when not pressed
        if (!isPressed)
        {
            slider.value = 0.5f;
            return;
        }

        // Calculate and apply rotation based on slider position
        float rotationAmount = CalculateRotation(slider.value);
        playerTransform?.Rotate(Vector3.up * rotationAmount * Time.deltaTime);
    }

    // Converts slider value to precise rotation
    private float CalculateRotation(float sliderValue)
    {
        return (sliderValue - 0.5f) * 2f * rotationSpeed;
    }
}
```

## 💡 Design Philosophy

The core idea behind this project was to challenge traditional input paradigms. By mapping movement and rotation to slider interactions, we create:
- More granular control
- Intuitive input mechanics
- A unique gameplay experience

## Potential Applications

This control scheme could be particularly interesting for:
- Puzzle games requiring precision movement
- Educational simulations
- Accessibility-focused game design
- Experimental game mechanics

## 🔍 Lessons Learned

Throughout this project, I discovered:
- The importance of flexible input design
- How small UI/UX changes can dramatically alter gameplay
- Creative problem-solving in game development

## Getting Started

### Prerequisites
- Unity (recommended version: 2022.3 LTS or later)
- Basic understanding of Unity UI and C# scripting

### Installation
1. Clone the repository
2. Open the project in Unity
3. Ensure you have sliders set up with the `PlayerMovementController` and `PlayerRotationController` scripts
4. Configure player references in the Inspector

## Future Improvements
- Add acceleration and deceleration curves
- Implement more complex slider interaction patterns
- Create configurable sensitivity settings

## 🌈 Conclusion

This project is a testament to thinking outside the box in game design. By reimagining something as fundamental as player movement, we open doors to innovative gameplay experiences.

## License
[Insert appropriate license here]

## Acknowledgments
- Unity Technologies
- The game development community

---

**Happy Developing!** 🎮🚀
