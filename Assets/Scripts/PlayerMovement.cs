using UnityEngine;
using UnityEngine.InputSystem;

namespace LastEmber.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        private const float InputThreshold = 0.01f;

        [Header("Input")]
        [SerializeField] private InputActionReference _moveAction;

        [Header("Movement")]
        [SerializeField, Min(0f)] private float _moveSpeed = 5f;
        [SerializeField, Min(0f)] private float _acceleration = 60f;
        [SerializeField, Min(0f)] private float _deceleration = 80f;

        [Header("Visuals")]
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private Rigidbody2D _rigidbody;
        private Vector2 _moveInput;

        /// <summary>Last non-zero direction. Use it to aim attacks and the lantern throw.</summary>
        public Vector2 FacingDirection { get; private set; } = Vector2.down;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();

            if (_moveAction == null)
            {
                Debug.LogError("PlayerMovement: assign the Move action in the Inspector.", this);
                enabled = false;
            }
        }

        private void OnEnable()
        {
            if (_moveAction != null)
            {
                _moveAction.action.Enable();
            }
        }

        private void OnDisable()
        {
            _moveInput = Vector2.zero;

            if (_rigidbody != null)
            {
                _rigidbody.linearVelocity = Vector2.zero;
            }

            if (_moveAction != null)
            {
                _moveAction.action.Disable();
            }
        }

        private void Update()
        {
            _moveInput = Vector2.ClampMagnitude(_moveAction.action.ReadValue<Vector2>(), 1f);

            if (_moveInput.sqrMagnitude > InputThreshold * InputThreshold)
            {
                FacingDirection = _moveInput.normalized;
            }

            UpdateSpriteFlip();
        }

        private void FixedUpdate()
        {
            Vector2 targetVelocity = _moveInput * _moveSpeed;
            bool hasInput = _moveInput.sqrMagnitude > InputThreshold * InputThreshold;
            float rate = hasInput ? _acceleration : _deceleration;

            _rigidbody.linearVelocity = Vector2.MoveTowards(
                _rigidbody.linearVelocity,
                targetVelocity,
                rate * Time.fixedDeltaTime);
        }

        private void UpdateSpriteFlip()
        {
            if (_spriteRenderer == null || Mathf.Abs(_moveInput.x) <= InputThreshold)
            {
                return;
            }

            _spriteRenderer.flipX = _moveInput.x < 0f;
        }
    }
}