using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int life = 10;
    private float generatePlayerUnitTimeOut = 3f;
    private float generateEnemyUnitTimeOut = 1f;
    private float generatePlayerUnitTime;
    private float generateEnemyUnitTime;
    public GameObject attackerPlayerUnit;
    public GameObject tankerPlayerUnit;
    private GameObject selectedPlayerUnit;
    public GameObject enemyUnit;
    public GameObject castle;
    public GameObject lifeHeart;

    // Start is called before the first frame update
    void Start()
    {
        selectAttackerPlayerUnit();
        int lifeCount = life;
        while(0 < lifeCount)
        {
            GameObject cloneLifeHeart = Instantiate(lifeHeart, new Vector3(-9 - -lifeCount, 4f, 0f), Quaternion.identity);
            cloneLifeHeart.name = "cloneLifeHeart" + lifeCount.ToString();
            lifeCount--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        generatePlayerUnitTime += Time.deltaTime;

        if (generatePlayerUnitTime >= generatePlayerUnitTimeOut)
        {
            Instantiate(selectedPlayerUnit, new Vector3(castle.transform.position.x, castle.transform.position.y, castle.transform.position.z), Quaternion.identity);

            generatePlayerUnitTime = 0.0f;
        }

        generateEnemyUnitTime += Time.deltaTime;

        if (generateEnemyUnitTime >= generateEnemyUnitTimeOut)
        {
            int y = Random.Range(-4, 4);
            Instantiate(enemyUnit, new Vector3(10f, y, 0), Quaternion.identity);

            generateEnemyUnitTime = 0.0f;
        }

        if (life <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    public void reduceLife()
    {
        GameObject deleteLifeHeart = GameObject.Find("cloneLifeHeart" + life.ToString());
        Destroy(deleteLifeHeart);
        life--;
    }

    public void selectAttackerPlayerUnit()
    {
        selectedPlayerUnit = attackerPlayerUnit;
    }

    public void selectTankerPlayerUnit()
    {
        selectedPlayerUnit = tankerPlayerUnit;
    }
}
