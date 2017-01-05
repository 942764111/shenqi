using UnityEngine;
using System.Collections;
using LitJson;
using CG_Public;
using CG_Manage;
public class UI_libao : UI_Manage, interface_UI
{
    string ClassID = "UI_libao";
    GameObject me = null;
    JsonData json;
    int JB = 1;
    public Transform GetMe
    {
        get
        {
            return me.transform;
        }
    }
    public UI_libao()
    {
        json = CG_Config.Libao;
        initUI();
    }
    public void initUI()
    {
        me = initUI(ClassID);
        initBtns();
    }
    public void initBtns()
    {
        me.SetActive(false);
        JsonData jsda = json["Requirement"];
        UILabel[] dJYQ_ZT = new UILabel[3];
        string[] str=new string [jsda.Count];
        string[] str1 = new string[jsda.Count];
        for (int j = 0; j < jsda.Count; j++)
        {
            str[j] = jsda[j]["Grade"].ToString();
        }
        for (int i = 0; i < dJYQ_ZT.Length; i++)
        {
            dJYQ_ZT[i] = me.transform.Find("Mao Dian/BG/DJ_" + i + "/ZT_" + i).GetComponent<UILabel>();
            dJYQ_ZT[i].text = CG_Windows.Format(CG_Config.LABEL["Libao"].ToString(), str[i]);
        }
        Transform obj = me.transform.parent.FindChild("Camera/R_C/L_B");
        UIEventListener.Get(obj.gameObject).onClick = Callback;
    }
    public void Callback(GameObject Obj)
    {
        if (JB == 1)
        {
            me.SetActive(true);
            JB = 0;
        }
        else
        {
            me.SetActive(false);
            JB = 1;
        }
    }
}
