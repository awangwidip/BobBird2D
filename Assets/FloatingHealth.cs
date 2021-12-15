using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingHealth : MonoBehaviour
{
    public float speed = -1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(speed * Time.deltaTime, Mathf.Sin(Time.time) * Time.deltaTime * speed, 0.0f);
    }
}
