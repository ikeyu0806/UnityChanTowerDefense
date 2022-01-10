using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerController : MonoBehaviour
{
    int unitHP = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(1f, 0, 0) * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
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
