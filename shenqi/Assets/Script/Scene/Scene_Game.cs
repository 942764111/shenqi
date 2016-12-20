using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CG_Manage;
using CG_Public;
public class Scene_Game : Scene_Manage,interface_Scene {
    string ClassID = "Scene_Game";
    User_Manage userdata;
    void Start()
    {

        userdata = User_Manage.CreateInstance();

        initUI();
    }
    //----------------初始化开始界面
    public void initUI()
    {
        new UI_libao();
        initBtns();
    }

    public void initBtns()
    {
    }
    public void Callback(GameObject Obj)
    {  
    }
}
