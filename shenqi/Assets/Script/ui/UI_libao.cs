using UnityEngine;
using System.Collections;
using CG_Public;
using CG_Manage;
public class UI_libao : UI_Manage, interface_UI
{
    string ClassID = "UI_libao";
    GameObject me = null;
    public Transform GetMe
    {
        get
        {
            return me.transform;
        }
    }
    public UI_libao()
    {
        initUI();
    }
   public void initUI()
    {
        me = initUI(ClassID);
        Debug.Log("进来了。。。。。。。。。。。。。。");
    }
   public void initBtns() { }
   public void Callback(GameObject Obj) { }
}
