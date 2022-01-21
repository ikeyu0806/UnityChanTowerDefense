using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float timeOut;
    private float generatePlayerUnitTime;
    private float generateEnemyUnitTime;
    public GameObject playerUnit;
    public GameObject enemyUnit;
    public GameObject castle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        generatePlayerUnitTime += Time.deltaTime;

        if (generatePlayerUnitTime >= timeOut)
        {
            Instantiate(playerUnit, new Vector3(castle.transform.position.x, castle.transform.position.y, castle.transform.position.z), Quaternion.identity);

            generatePlayerUnitTime = 0.0f;
        }

        generateEnemyUnitTime += Time.deltaTime;

        if (generateEnemyUnitTime >= timeOut)
        {
            int y = Random.Range(-4, 4);
            Instantiate(enemyUnit, new Vector3(10f, y, 0), Quaternion.identity);

            generateEnemyUnitTime = 0.0f;
        }
    }
}
