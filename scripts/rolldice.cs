using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class rolldice : MonoBehaviourPunCallbacks
{
    public Text score;
    public Transform diceplace;
    public GameObject diceobj;
    public GameObject rule;
    public GameObject scview;
    public Transform gridlayout;
    public GameObject sctable;
    public Text newsc;

    public void roll()
    {
        int[] sct = new int[6];
        System.Random rd = new System.Random();

        for (int i = 0; i < 6; i++)
        {
            int sc = rd.Next(1, 7);

            creatdice(sc);

            sct[i] = sc;
        }
        diceplace.position = diceplace.position + Vector3.left * 600;
        sortsct(sct);
        string kg = checkpoint(sct);
        //GameObject newsc = PhotonNetwork.Instantiate("scview",gridlayout.position,Quaternion.identity);
        //newsc.GetComponent<Text>().text = showsct(sct, kg);
        //newsc.transform.SetParent(gridlayout);
        newsc.text = kg;
        showsct(sct, kg);
        Invoke("cleansc", 5);

    }
    public void creatdice(int sc)
    {
        diceplace.position = diceplace.position + Vector3.right * 100;
        //GameObject newdice = PhotonNetwork.Instantiate("dice", diceplace.position, diceplace.rotation);
        GameObject newdice = Instantiate(diceobj, diceplace.position, diceplace.rotation);
        newdice.transform.parent = this.transform;
        newdice.GetComponent<dice>().setnumber(sc);
    }
    public void sortsct(int[] sct)
    {
        Array.Sort(sct);
        Array.Reverse(sct);
    }
    public string checkpoint(int[] sct)
    {
        string kg = "";
        string name = "";
        int[] total = new int[6];
        for (int i = 0; i < sct.Length; i++)
            total[sct[i] - 1]++;
        if (total[1] == 4)
        {
            kg = "JinShi";
            name = "SiJin";
        }
        else if (total[3] == 4 && total[0] == 2)
        {
            kg = "ZhuangYuan";
            name = "ZhuangYuanChaJinHua";
        }
        else if (total[3] == 6)
        {
            kg = "ZhuangYuan";
            name = "LiuBeiHong";
        }
        else if (total[5] == 6)
        {
            kg = "ZhuangYuan";
            name = "LiuBeiHei";
        }
        else if (total[3] == 5)
        {
            kg = "ZhuangYuan";
            name = "WuWang";
        }
        else if (total[5] == 5)
        {
            kg = "ZhuangYuan";
            name = "WuZiDengKe";
        }
        else if (total[3] == 4)
        {
            kg = "ZhuangYuan";
            name = "ZhuangYuan";
        }
        else if (total[3] == 3)
        {
            kg = "TanHua";
            name = "SanHong";
        }
        else if (total[3] == 2)
        {
            kg = "JuRen";
            name = "ErJu";
        }
        else if (total[3] == 1)
        {
            bool b = true;
            for (int i = 0; i < total.Length; i++)
            {
                if (total[i] != 1)
                {
                    b = false;
                    break;
                }
            }
            if (b == true)
            {
                kg = "BangYan";
                name = "DuiTang";
            }
            else
            {
                kg = "XiuCai";
                name = "YiJu";
            }
        }
        else
        {
            kg = "No Reward";
        }
        kg = string.Concat(kg, " ", name);
        return kg;
    }
    public string showsct(int[] sct, string kg)
    {

        string s = score.text;
        //string s = "";
        s = string.Concat(s, "|");
        for (int i = 0; i < sct.Length; i++)
        {
            s = string.Concat(s, sct[i].ToString(), "|");
        }
        s = string.Concat(s, kg, "\n");
        score.text = s;
        return s;
    }

    public void returnmeun()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        PhotonNetwork.LoadLevel(0);
    }
    public void claentable()
    {
        score.text = "";
    }
    public void showrule()
    {
        rule.SetActive(true);
    }
    public void closerule()
    {
        rule.SetActive(false);
    }
    public void showsctable()
    {
        sctable.SetActive(true);
    }
    public void closetable()
    {
        sctable.SetActive(false);
    }
    public void cleansc()
    {
        newsc.text = "";
    }
}
