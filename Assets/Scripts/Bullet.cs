using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    private GameManager gameManager;

    private Vector3 targetPosition;
    private Vector3 initialPosition;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        Destroy(gameObject, 5);
        initialPosition = transform.position;
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;

        Vector3 direction = (targetPosition - initialPosition).normalized;
        transform.up = direction; // Make the bullet face the target direction
    }

    private void Update() // Use Update instead of FixedUpdate for better collision accuracy
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (Vector3.Distance(initialPosition, transform.position) >= Vector3.Distance(initialPosition, targetPosition))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            gameManager.score += 100;
        }
    }
}
