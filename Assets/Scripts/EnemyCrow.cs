using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCrow : MonoBehaviour
{
    bool isCollision = false;
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Castle");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCollision)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.1f);
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
