using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerController : MonoBehaviour
{
    bool isCollision = false;
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        SearchTarget();
    }

    // Update is called once per frame
    void Update()
    {
        SearchTarget();
        if (!isCollision)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.08f);
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

    void SearchTarget()
    {
        float tmpDis = 0;
        float nearDis = 0;
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("EnemyUnit"))
        {
            tmpDis = Vector3.Distance(transform.position, obj.transform.position);
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                target = obj;
            }
        }
    }
}
