using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    private int Dinosaure;
    public int Life;
    public TMP_Text parler;
    private void OnMouseEnter()
    {
        Debug.Log("DINOSAURE?DINOSAURE?DINOSAURE?DINOSAURE?DINOSAURE?DINOSAURE?DINOSAURE?DINOSAURE");


    }
    void Start()
    {
        Dinosaure = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Life++;
            Debug.Log(Dinosaure);
        }
        if (Input.GetKey(KeyCode.P))
        {
            parler.text = "Hello World";
        }
        else
        {
            parler.text = "";
        }
    }

    void lifeupdate(int Damage)
    {
        Life -= Damage;
        if(Life <= 0) 
        {
            Destroy(this.gameObject);
        }
    }

}
