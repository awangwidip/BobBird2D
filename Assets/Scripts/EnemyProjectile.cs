using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public Animator bulletAnim;
    private float bulletSpeed = 5.0f;
    private int damage = 1;

    // Start is called before the first frame update
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * bulletSpeed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            bulletSpeed = 0.0f;
            bulletAnim.SetBool("OnHit", true);
            other.GetComponent<PlayerController>().health -= damage;
            Debug.Log(other.GetComponent<PlayerController>().health);
            Invoke("destroyBullet", 0.35f);
        }
    }

    private void destroyBullet()
    {
        Destroy(gameObject);
    }
}
