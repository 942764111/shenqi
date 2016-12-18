using UnityEngine;
using System.Collections.Generic;
using CG_Manage;
using CG_Public;
public class UI_Login : UI_Manage, interface_UI
{
    string ClassID = "UI_Login";
    User_Manage userdata;
    GameObject me;
    public UI_Login() {
        initUI();
    }
    public void initUI()
    {
        userdata = User_Manage.CreateInstance();
        me =  CloneUI(ClassID);
        AddUI(ClassID, me);
        initBtns();
    }

    public void initBtns()
    {
        string[] arr = { "kaishi", "guanbi" };
        for (int i = 0; i < arr.Length; i++)
        {
            Transform obj = me.transform.Find(arr[i]);
            UIEventListener.Get(obj.gameObject).onClick = Callback;
        }
    }
    public void Callback(GameObject Obj)
    {
        switch (Obj.name)
        {
            case "kaishi":
                BtnZC_zc(Obj);
                break;
            case "guanbi":
                Remove(Obj);
                break;
            default:
                break;
        }
    }
    //注册
    void BtnZC_zc(GameObject A)
    {
        string state = "";
        string[] str = { "namobj/name","zh","mima" };
        List<string> text = new List<string>();
        UILabel label;
        for (int i = 0; i < str.Length; i++)
        {
            label = GameObject.Find("shurukuang/" + str[i]).GetComponent<UILabel>();
            text.Add(label.text);
        }
        state = userdata.GetZhuce(text[0], text[1], text[2]);
        switch (state)
        {
            case "1":
                removeUI(me, ClassID);
                break;
            case "2":

                break;
            case "3":

                break;
            case "4":

                break;
            case "5":

                break;
        }
    }
    void Remove(GameObject A)
    {
        removeUI(me, ClassID);
    }

}
