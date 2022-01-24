using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankerController : MonoBehaviour
{
    bool isCollision = false;
    float speed = 0.08f;
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        SearchTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCollision)
        {
            SearchTarget();
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
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
