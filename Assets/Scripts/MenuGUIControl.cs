using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuGUIControl : MonoBehaviour {

    public GameObject panel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeScene(int i)
    {
        SceneManager.LoadScene(i);
        Time.timeScale = 1;
    }

    public void ShowPanel(bool i)
    {
        panel.SetActive(i);
    }
}
