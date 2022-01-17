using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public int attackPower;
    public int unitHP;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DamageController>())
        {
            int damage = collision.gameObject.GetComponent<DamageController>().attackPower;
            Damage(damage);
        }
    }

    public void Damage(float damage)
    {
        unitHP = (int)Mathf.Clamp(unitHP - damage, 0, unitHP);

        if (unitHP <= 0)
        {
            Destroy(gameObject);
        }
    }

}
