using UnityEngine;
using System.Collections;
using CG_Public;
using CG_Manage;
public class UI_libao : UI_Manage, interface_UI
{
    string ClassID = "UI_libao";
    GameObject me;
    public UI_libao()
    {
        initUI();
    }
   public void initUI()
    {
        me = CloneUI(ClassID);
        AddUI(ClassID,me);
        Debug.Log("进来了。。。。。。。。。。。。。。");
    }
   public void initBtns() { }
   public void Callback(GameObject Obj) { }
}
