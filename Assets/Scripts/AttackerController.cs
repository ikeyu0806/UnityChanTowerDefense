using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerController : MonoBehaviour
{
    int unitHP = 5;
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
            transform.position += new Vector3(2f, 0, 0) * Time.deltaTime;
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

    public void TakeHit(float damage)
    {
        unitHP = (int)Mathf.Clamp(unitHP - damage, 0, unitHP);

        if (unitHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
