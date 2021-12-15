using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    [SerializeField] GameObject gameOver;

    private Rigidbody2D birdRb;
    //public float gravityModifier = 1.0f;
    public float jumpForce = 10.0f;

    private float verticalInput;

    public GameObject birdShoot;
    private float delay;

    public int health = 3;

    // Start is called before the first frame update
    void Start()
    {
        birdRb = GetComponent<Rigidbody2D>();
        //Physics2D.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && delay < Time.time && health > 0)
        {
            delay = Time.time + 1.0f;
            Instantiate(birdShoot, transform.position, birdShoot.transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            birdRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); 

        }
        verticalInput = Input.GetAxis("Vertical");
        animator.SetFloat("Speed", Mathf.Abs(verticalInput));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("1Up") && health < 3)
        {
            health += 1;
            Destroy(other.gameObject);
        }

        if(health == 0)
        {
            gameOver.SetActive(true);
        }
    }
}
