using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour {
    public GameObject[] itemsArray = new GameObject[6];
    public int itemsLevel = 1;
    public Vector3[] spawnPoints;
    public int score;
    public GameObject scoreGUI;
    public GameObject highScore;
    public GameObject panel;
    public GameObject defeatMessageLabel;

    public int nextLevel;
    // Use this for initialization
    void Start() {
        nextLevel = 10;
        StartCoroutine("Spawner");
    }

    void Update()
    {
        if (score >= nextLevel)
        {
            nextLevel = nextLevel + 20;
            GameObject Enemy = GameObject.FindGameObjectWithTag("EnemyPool");
            Debug.Log(Enemy);
            Vector3 newpos = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Enemy.transform.position = newpos;
            Enemy.tag = "Enemy";
        }
    }
    public void InventoryInsert(GameObject obj)
    {
        for (int i = 0; i <= 5; i++) {
            Debug.Log(obj.name);
           if (itemsArray[i] == null)
            {
                obj.transform.position = new Vector3(1000, 8000, 0);
                itemsArray[i] = obj;
                i = 7;
            }
        }
    }
    public void InventoryDrop(GameObject obj) {
        for (int i = 0; i <= 5; i++)
        {
            if (!(itemsArray[i] == null))
            {
                score = score + 10;
                scoreGUI.GetComponent<Text>().text = score.ToString();
                obj.gameObject.tag = "ItemPool";
                itemsArray[i] = null;
            }
        }
    }
    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            Vector3 newpos = spawnPoints[Random.Range(0, spawnPoints.Length)];
            ItemsSpawn(newpos);
        }
        
    }
    void ItemsSpawn(Vector3 pos)
    {
        GameObject item = GameObject.FindGameObjectWithTag("ItemPool");
        item.GetComponent<ItemController>().ItemSpawn();
        item.transform.position = pos;
        item.tag = "Item";
    }
    
    public void PlayerDefeated (string message)
    {
        Time.timeScale = 0;
        defeatMessageLabel.GetComponent<Text>().text = message;
        panel.SetActive(true);

            int oldHighscore = PlayerPrefs.GetInt("highscore", 0);
            if (score > oldHighscore)
                PlayerPrefs.SetInt("highscore", score);

        highScore.GetComponent<Text>().text = PlayerPrefs.GetInt("highscore").ToString();
    } 
}