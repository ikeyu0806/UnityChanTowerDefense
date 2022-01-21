using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int life = 10;
    private int maxLife = 15;
    private float generatePlayerUnitTimeOut = 1f;
    private float generateEnemyUnitTimeOut = 1f;
    private float generatePlayerUnitTime;
    private float generateEnemyUnitTime;
    public GameObject attackerPlayerUnit;
    public GameObject tankerPlayerUnit;
    public GameObject healerPlayerUnit;
    private GameObject selectedPlayerUnit;
    public GameObject enemyUnit;
    public GameObject castle;
    public GameObject lifeHeart;
    public Button attackerButton;
    public Button tankerButton;
    public Button healerButton;

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
        attackerButton.image.color = Color.green;
        tankerButton.image.color = Color.white;
        healerButton.image.color = Color.white;

    }

    public void selectTankerPlayerUnit()
    {
        selectedPlayerUnit = tankerPlayerUnit;
        attackerButton.image.color = Color.white;
        tankerButton.image.color = Color.green;
        healerButton.image.color = Color.white;
    }

    public void selectHealerPlayerUnit()
    {
        selectedPlayerUnit = healerPlayerUnit;
        attackerButton.image.color = Color.white;
        tankerButton.image.color = Color.white;
        healerButton.image.color = Color.green;
    }

    public void healLife()
    {
        if (maxLife > life)
        {
            life++;
            GameObject cloneLifeHeart = Instantiate(lifeHeart, new Vector3(-9 - -life, 4f, 0f), Quaternion.identity);
            cloneLifeHeart.name = "cloneLifeHeart" + life.ToString();
        }
    }
}
