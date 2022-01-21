using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerController : MonoBehaviour
{
    bool isCollision = false;
    float speed = 0.05f;
    float healTimeOut = 3f;
    float healTime;
    GameObject target;
    GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController");
        SearchTarget();
        healLife();
    }

    // Update is called once per frame
    void Update()
    {
        SearchTarget();
        if (!isCollision)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
        }

        healTime += Time.deltaTime;
        if (healTime >= healTimeOut)
        {
            healLife();
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

    void healLife()
    {
        gameController.GetComponent<GameController>().healLife();
    }
}
