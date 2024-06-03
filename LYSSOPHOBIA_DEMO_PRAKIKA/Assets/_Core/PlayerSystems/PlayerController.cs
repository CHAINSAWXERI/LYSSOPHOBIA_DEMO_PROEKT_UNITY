using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystems
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        public float moveSpeed { private get; set; }

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

        public void SpeedUpdate(float newSpeed)
        {
            moveSpeed = newSpeed;
        }
    }
}