using UnityEngine;

/// <summary>
/// Manages the player character's movement in scene.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] CharacterController _characterController;

    [Header("Parameters")]
    [SerializeField] float _speed = 1f;

    private Vector3 _movement;

    /// <summary>
    /// Manages the player horizontal movement
    /// </summary>
    /// <param name="input">The player's input for moving</param>
    public void Move(Vector2 input)
    {
        _movement = new Vector3(input.x, _movement.y, input.y) * _speed;
    }

    private void Update() {
        _characterController.Move(_movement * Time.deltaTime);
    }
}
