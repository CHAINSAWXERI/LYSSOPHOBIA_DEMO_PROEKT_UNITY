using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystems
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private Rigidbody2D rb;

        private Vector2 movement;

        void Update()
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }

        void FixedUpdate()
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}