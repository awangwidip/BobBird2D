using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Animator bulletAnim;
    private float bulletSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * bulletSpeed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            bulletSpeed = 0.0f;
            bulletAnim.SetBool("OnHit", true);
            Invoke("destroyBullet", 0.35f);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Obstacle"))
        {
            bulletSpeed = 0.0f;
            bulletAnim.SetBool("OnHit", true);
            Invoke("destroyBullet", 0.35f);
        }
    }

    private void destroyBullet()
    {
        Destroy(gameObject);   
    }
    
}
