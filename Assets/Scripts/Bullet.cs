using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Bullet : MonoBehaviour
{
    public float speed;
    public GameManager gameManager;

    private Vector3 initialPosition;


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

        if (collision.CompareTag("Planet"))
        {
            Vector3 vd = this.transform.up- new Vector3(0,0,0);
            float dum = Quaternion.FromToRotation(Vector3.up, vd).eulerAngles.z;
            vd = collision.transform.position-this.transform.position;
            float dum2 = Quaternion.FromToRotation(Vector3.up, vd).eulerAngles.z;
            float dum3 = (dum - dum2) * -1 + dum2-90;
            transform.up = new Vector3(Mathf.Cos(Mathf.Deg2Rad * dum3), Mathf.Sin(dum3 * Mathf.Deg2Rad),0).normalized;
        }
    }
}
