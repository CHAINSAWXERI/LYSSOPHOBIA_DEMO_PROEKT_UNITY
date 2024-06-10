using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform exitPortal; // Другой портал, куда происходит телепортация

    private bool isPlayerOverlapping = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Проверяем, что объект, с которым столкнулся портал, имеет тег "Player"
        {
            isPlayerOverlapping = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOverlapping = false;
        }
    }

    private void Update()
    {
        if (isPlayerOverlapping && Input.GetKeyDown(KeyCode.E)) // Предположим, что для телепортации используется клавиша "E"
        {
            TeleportPlayer();
        }
    }

    private void TeleportPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player"); // Находим игрока по тегу
        player.transform.position = exitPortal.position; // Устанавливаем позицию игрока равной позиции другого портала
    }
}
