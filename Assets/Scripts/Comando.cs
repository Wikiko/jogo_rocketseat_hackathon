using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Comando {

    private Func<IEnumerator> action;

    private string name;

    public Comando(string name, Func<IEnumerator> action)
    {
        this.name = name;
        this.action = action;
    }

    public string Name
    {
        get
        {
            return name;
        }
    }

    public IEnumerator run()
    {
        yield return action.Invoke();
    }

}
