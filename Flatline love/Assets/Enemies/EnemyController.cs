using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject player;

    private Rigidbody2D rigBody2d;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
            throw new NullReferenceException("Player instance is not initialized. Check Enemy Inpector page");

        rigBody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        Vector2 playerPosition = player.transform.position;
        Vector2 movementVector = new Vector2(playerPosition.x - transform.position.x, playerPosition.y - transform.position.y);

        Debug.Log(movementVector.magnitude);

        if (movementVector.magnitude <= 1)
            movementVector = Vector2.zero;

        movementVector.Normalize();
        rigBody2d.velocity = movementVector * speed;
    }
}
