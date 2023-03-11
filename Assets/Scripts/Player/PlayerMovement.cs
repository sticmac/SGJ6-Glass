using UnityEngine;

/// <summary>
/// Manages the player character's movement in scene.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Rigidbody _rb;

    [Header("Parameters")]
    [SerializeField] float _movementRotationYOffset = 45;
    [SerializeField] float _speed = 1f;

    private Vector3 _movement;
    private Quaternion _movementRotationOffset;

    private void Awake()
    {
        _movementRotationOffset = Quaternion.AngleAxis(_movementRotationYOffset, Vector3.up);
    }

    private void OnDisable() {
        _rb.velocity = Vector3.zero;
    }

    /// <summary>
    /// Manages the player horizontal movement
    /// </summary>
    /// <param name="input">The player's input for moving</param>
    public void Move(Vector2 input)
    {
        _movement = _movementRotationOffset * new Vector3(input.x, _movement.y, input.y) * _speed;
    }

    private void FixedUpdate()
    {
        _rb.velocity = _movement;
        _rb.transform.LookAt(transform.position + _movement, Vector3.up); // Make character face direction they're moving towards
    }
}
