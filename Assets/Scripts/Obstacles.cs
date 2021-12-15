using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public int damage = 1;
    public float speed = 1.0f;
    private PlayerController playerController;


    // Start is called before the first frame update
    void Start()
    {
		playerController = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {

        if(playerController.health > 0)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        } else if(playerController.health <= 0)
        {
            speed = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().health -= damage;
            Debug.Log(other.GetComponent<PlayerController>().health);
            Destroy(gameObject);
        }
        
    }
}
