using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {
    bool haspouch;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerStay2D(Collider2D elephant)
    {
        haspouch = GameObject.Find("Elephant").GetComponent<ElephantState>().hasPouch;
        Debug.Log(elephant);
        if (elephant.name.Equals("Elephant") && haspouch)
        {
            SceneManager.LoadScene("level-2");
        }
    }
    
}
