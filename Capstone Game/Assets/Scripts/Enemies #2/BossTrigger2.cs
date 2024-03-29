using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger2 : MonoBehaviour
{
    public Transform entrance;
    public float yPosition = -9.95f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            entrance.transform.position = new Vector2(entrance.transform.position.x, yPosition);
        }
    }
}
