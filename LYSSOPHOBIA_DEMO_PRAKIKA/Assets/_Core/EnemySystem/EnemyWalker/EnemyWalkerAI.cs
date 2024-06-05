using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyWalker
{
    public class EnemyWalkerAI : MonoBehaviour
    {
        [SerializeField] public float moveSpeed;
        [SerializeField] public float RadiusView;
        [SerializeField] public LayerMask playerLayer;
        [SerializeField] private Rigidbody2D rb;

        private Vector2 moveDirection;
        private Vector2 initialPosition;

        void Start()
        {
            moveDirection = Vector2.right;
            initialPosition = transform.position;
        }

        void Update()
        {
            RaycastHit2D hitPlayer = Physics2D.Raycast(transform.position, moveDirection, RadiusView, playerLayer);

            if (hitPlayer.collider != null)
            {
                AttackMode(hitPlayer);
            }
            else
            {
                WanderMode();
            }
        }

        private void WanderMode()
        {
            if (Vector2.Distance(transform.position, initialPosition) < 0.1f)
            {
                moveDirection = new Vector2(Mathf.Sign(moveDirection.x) * -1, 0);
            }
        }


        private void AttackMode(RaycastHit2D hitPlayer)
        {
            moveDirection = (hitPlayer.point - (Vector2)transform.position).normalized;
            initialPosition = transform.position;
        }

        void FixedUpdate()
        {
            rb.velocity = moveDirection * moveSpeed;
        }
    }
}