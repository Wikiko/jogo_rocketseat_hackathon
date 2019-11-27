using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemTerreno : MonoBehaviour {

    public bool temTerreno;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Terreno":
                temTerreno = true;
                break;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Terreno":
                temTerreno = false;
                break;
        }
    }
}
