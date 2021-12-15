using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilBirbShoot : MonoBehaviour
{
    public GameObject shooterProj;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("Shoot", 6, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController.health <= 0)
        {
            CancelInvoke("Shoot");
        }
    }

    public void Shoot()
    {
        Instantiate(shooterProj, transform.position, shooterProj.transform.rotation);
    }
}
