using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Search;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public GameManager gameManager;

    private Vector3 initialPosition;

    public GameOverPanel show;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        initialPosition = transform.position;
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;

        Vector3 direction = (targetPosition - initialPosition).normalized;
        transform.up = direction; // Make the bullet face the target direction
    }

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (IsOutsideScreen())
        {
            this.gameObject.SetActive(false);
        }
    }

    private bool IsOutsideScreen()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.x < 0 || screenPosition.x > Screen.width || screenPosition.y < 0 || screenPosition.y > Screen.height)
        {
            return true;
        }
        return false;
    }

    public void SetTarget(Vector3 target)
    {
        Vector3 targetPosition = target;
        targetPosition.z = transform.position.z;

        Vector3 direction = (targetPosition - initialPosition).normalized;
        transform.up = direction; // Make the bullet face the target direction
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().gameObject.SetActive(false);
            this.gameObject.SetActive(false);
            gameManager.score += 100;
        }
    }

    public void Stop()
    {
        StopAllCoroutines();
    }
}
