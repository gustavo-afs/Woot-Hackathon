using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {
    SpriteRenderer itemSpriteRenderer;
    public Sprite[] itemsSprites;
    public GameObject gameControllerScript;
    // Use this for initialization
    void Start () {
        itemSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"){
            gameControllerScript.GetComponent<GameControllerScript>().InventoryInsert(gameObject);
        }
    }
    public void ItemSpawn()
    {
        int i = itemsSprites.Length;
        itemSpriteRenderer.sprite = itemsSprites[Random.Range(0,i)];
    }
}
