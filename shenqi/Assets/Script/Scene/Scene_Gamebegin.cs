using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CG_Manage;
using CG_Public;
using LitJson;

public class Scene_Gamebegin : Scene_Manage, interface_Scene
{
    string ClassID = "Scene_Gamebegin";
    User_Manage userdata;
    void Start()
    {
        userdata = User_Manage.CreateInstance();
        initUI();
    }
    //----------------初始化开始界面
    public void initUI()
    {
        userdata = User_Manage.CreateInstance();
        initBtns();
    }

    public void initBtns()
    {
        string[] arr = { "bgein", "zc" };
        foreach (var obj in arr)
        {
            Transform button = this.transform.Find("Begin/" + obj);
            UIEventListener.Get(button.gameObject).onClick = Callback;
        }
    }
    public void Callback(GameObject Obj)
    {
        switch (Obj.name)
        {
            case "bgein":
                BtnStart_dl(Obj);
                break;
            case "zc":
                BtnStart_zc(Obj);
                break;
        }
    }
    //登录按钮
    void BtnStart_dl(GameObject obj)
    {
        UILabel zh = GameObject.Find("zh").GetComponent<UILabel>();
        UILabel mm = GameObject.Find("mima").GetComponent<UILabel>();
        string on_off = userdata.GetLogin(zh.text, mm.text);

        switch (on_off)
        {
            case "1":
                LoadLevel("Scene_Game");
                break;
            case "2":
                Transform me = transform.Find("Begin");
                me.gameObject.SetActive(false);
                new UI_SelectRole();
                break;
            default:
                break;
        }
    }
    //注册按钮  初始化注册界面
    void BtnStart_zc(GameObject obj)
    {
        UI_Manage login = new UI_Login();
    }

}
