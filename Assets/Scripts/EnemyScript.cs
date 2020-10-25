using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody2D rd2d; 
    float speed = 3f;
    float height = 1.5f;

    Vector3 pos;

    void Start()
    {
         rd2d = GetComponent<Rigidbody2D>();
         pos = transform.position;
    }
void Update()
{

//calculate what the new Y position will be
float newY = Mathf.Sin(Time.time * speed) * height + pos.y;
//set the object's Y to the new calculated Y
transform.position = new Vector3(transform.position.x, newY, transform.position.z) ;
}
}