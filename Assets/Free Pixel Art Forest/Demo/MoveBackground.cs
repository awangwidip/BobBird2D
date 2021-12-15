using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour {



	public float speed;
	private float x;
	public float PontoDeDestino;
	public float PontoOriginal;

	private PlayerController playerController;


	// Use this for initialization
	void Start () {
		//PontoOriginal = transform.position.x;
		playerController = GameObject.Find("Player").GetComponent<PlayerController>();
	}

	// Update is called once per frame
	void Update () {

		x = transform.position.x;
		x += speed * Time.deltaTime;
		transform.position = new Vector3 (x, transform.position.y, transform.position.z);



		if (x <= PontoDeDestino){

			x = PontoOriginal;
			transform.position = new Vector3 (x, transform.position.y, transform.position.z);
		}

		if(playerController.health == 0)
        {
			speed = 0;
        }
	}
}
