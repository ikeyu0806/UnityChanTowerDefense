using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCrow : MonoBehaviour
{
    bool isCollision = false;
    GameObject target;
    GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Castle");
        gameController = GameObject.Find("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCollision)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.08f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Castle")
        {
            Destroy(gameObject);
            gameController.GetComponent<GameController>().reduceLife();
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
