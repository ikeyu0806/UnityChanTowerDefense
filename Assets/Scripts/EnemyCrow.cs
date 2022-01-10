using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCrow : MonoBehaviour
{
    bool isCollision = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isCollision)
        {
            transform.position += new Vector3(-3f, 0, 0) * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isCollision = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isCollision = false;
    }

}
