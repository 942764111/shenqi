using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using usermanage;
public class SelectRole : MonoBehaviour {
    Animation Animobj;
    ArrayList Action = new ArrayList();
    JsonData json;
    UserManage userdata;
    string job = "";
    string sex = "";
    string Model = "1";
    //// Use this for initialization
    void Start()
    {
        userdata = new UserManage();

        json = Config.SELECTROLE;

        initAddAction();

        initBtns();

        StartState();
    }
    //----------------------------------------初始化选择角色界面按钮
    void StartState()
    {
        JsonData jobs = json["job"];
        UIButton btn = GameObject.Find("btns/job/" + (string)jobs[0]["name"]).GetComponent<UIButton>();
        Transform obj = transform.Find("ui/hero/" + (string)jobs[0]["name"]);
        TheRunState(btn, obj, jobs[0]["jobPath"], jobs[0]["sexPath"]);
        otherOnClickState("sj");
        job = (string)jobs[0]["job"];
        sex = (string)jobs[0]["sex"];
    }

    void initBtns() {
        //职业按钮
        JsonData jobs = json["job"];
        GameObject objbtn;
        for (int i = 0; i < jobs.Count; i++) {
            objbtn = GameObject.Find("btns/job/" + (string)jobs[i]["name"]);
            UIEventListener.Get(objbtn.gameObject).onClick = jobsOnClick;
        }

        //其它按钮
        string[] otherarr = { "sj", "ks" };
        GameObject otherbtn;
        for (int i = 0; i < otherarr.Length; i++)
        {
            otherbtn = GameObject.Find("btns/other/" + otherarr[i]);
            UIEventListener.Get(otherbtn.gameObject).onClick = otherOnClick;
        }
    }
    //----------------------------------------职业按钮
    public void jobsOnClick(GameObject obj)
    {
        jobsOnClickState(obj.name);
    }
    void jobsOnClickState(string objname) {
        JsonData jobs = json["job"];
        UIButton btn;
        Transform obj;
        for (int i = 0; i < jobs.Count; i++)
        {
            btn = GameObject.Find("btns/job/" + (string)jobs[i]["name"]).GetComponent<UIButton>();
            obj = transform.Find("ui/hero/" + (string)jobs[i]["name"]);
            if ((string)jobs[i]["name"] == objname)
            {
                TheRunState(btn, obj,jobs[i]["jobPath"], jobs[i]["sexPath"]);
                job = (string)jobs[i]["job"];
                sex = (string)jobs[i]["sex"];
                Model = (string)jobs[i]["model"];
            }
            else
            {
                btn.isEnabled = true;
                obj.gameObject.SetActive(false);
            }
        }
    }
    void TheRunState(UIButton btn, Transform obj, JsonData jobPath, JsonData sexPath)
    {
        btn.isEnabled = false;
        obj.gameObject.SetActive(true);
        Animobj = obj.GetComponent<Animation>();
        Games.AddClips(Animobj, Action, (string)jobPath, (string)sexPath);
        PlayOrder(Action);
    }
    //----------------------------------初始化添加动作
    void initAddAction()
    {

        for (int i = 0; i < json["Action"].Count; i++)
        {
            Action.Add(json["Action"][i]);
        }
    }

    //----------------------------------执行动画
    void PlayOrder(ArrayList arr)
    {
        foreach (var index in arr)
        {
            Animobj.PlayQueued(index.ToString());
        }
    }

    //----------------------------------------其它按钮
    public void otherOnClick(GameObject obj)
    {
       otherOnClickState(obj.name);
    }
    void otherOnClickState(string objname) {
        Transform Getname = transform.Find("ui/name/Label");
        UILabel name = Getname.GetComponent<UILabel>();
        switch (objname) {
             case "sj": 
                 string Setname = "";
                 int rand;
                 for (int i = 0; i < 3; i++)
                 {
                     rand = Windows.Random(0, Config._FIRSTNAME.Length);
                     Setname += Config._FIRSTNAME[rand].ToString();
                 }
                 name.text = Setname;
                 
                break;
            case "ks":
                bool same = userdata.isSame(userdata.GetKey_Name, name.text);
                if (same)
                {
                    Debug.LogError(Windows.Format((string)Config.LABEL["JZJSONCG"]));
                }
                else {
                    userdata.SetInfo(StaticGame.GetUserInfo["id"], userdata.GetKey_Name, name.text);
                    userdata.SetInfo(StaticGame.GetUserInfo["id"], userdata.GetKey_Role, job);
                    userdata.SetInfo(StaticGame.GetUserInfo["id"], userdata.GetKey_Sex, sex);
                    userdata.SetInfo(StaticGame.GetUserInfo["id"], userdata.GetKey_Model, Model);
                    GameModel_role role = new GameModel_role();
                    Games.LoadLevel("Game");
                }
                break;
        }
    }
}
