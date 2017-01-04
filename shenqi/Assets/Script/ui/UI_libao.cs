using UnityEngine;
using System.Collections;
using CG_Public;
using CG_Manage;
using LitJson;
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
        JsonData jsda=json["Requirement"];
        UILabel [] Labels = new UILabel[3];
        for (int j = 0; j < jsda.Count; j++)
       {
            for (int i = 0; i < Labels.Length; i++)
            {
                Labels[i] = me.transform.Find("Mao Dian/BG/DJXSK_" + (i + 1) + "/ZT_" + (i + 1)).GetComponent<UILabel>();
                Labels[i].text = CG_Windows.Format(CG_Config.LABEL["Libao"].ToString(),jsda[j]["jb"] );
            }
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
