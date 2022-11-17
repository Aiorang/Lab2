using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dice : MonoBehaviour
{
    public GameObject diceobj;
    public Animator ani;
    int number=6;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("getres", 1);
    }

    public void getres()
    {
        ani.SetInteger("point",number);
        Invoke("destorydice", 3);
    }
    public void destorydice()
    {
        Destroy(diceobj);
    }
    public void setnumber(int x)
    {
        number = x;
    }

}
