using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public float velocidadeObjeto;

    private Truck truck;

    public List<Comando> comandos = new List<Comando>();

    public Text comandosText;

    public TemTerreno temTerreno;

	// Use this for initialization
	void Start () {
        truck = FindObjectOfType<Truck>();
        temTerreno = FindObjectOfType<TemTerreno>();
	}
	
	// Update is called once per frame
	void Update () {
		


	}

    public void addComando(Comando comando)
    {
        comandos.Add(comando);
        comandosText.text = comandosText.text + comando.Name + " ";
        print(comandosText.text);
    }

    public void start()
    {
        StartCoroutine(rodarComandos());
    }

    IEnumerator rodarComandos()
    {
        foreach (Comando comando in comandos)
        {
            yield return new WaitUntil(() => truck.isGrounded);
            if (temTerreno.temTerreno)
            {
                yield return comando.run();
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
