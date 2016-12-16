using UnityEngine;
using System.Collections;
using LitJson;
using CG_Manage;
using CG_Public;
public class SelectRole : MonoBehaviour {
    Animation Animobj;
    ArrayList Action = new ArrayList();
    JsonData json;
    User_Manage userdata;
    string job = "";
    string sex = "";
    string Model = "1";
    //// Use this for initialization
    void Start()
    {
        userdata = User_Manage.CreateInstance();

        json = CG_Config.SELECTROLE;

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
        CG_Games.AddClips(Animobj, Action, (string)jobPath, (string)sexPath);
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
                     rand = CG_Windows.Random(0, CG_Config._FIRSTNAME.Length);
                     Setname += CG_Config._FIRSTNAME[rand].ToString();
                 }
                 name.text = Setname;
                 
                break;
            case "ks":
                bool same = userdata.isSame(userdata.GetKey_Name, name.text);
                if (same)
                {
                    Debug.LogError(CG_Windows.Format((string)CG_Config.LABEL["JZJSONCG"]));
                }
                else {
                    userdata.SetInfo(CG_variable.GetUserInfo["id"], userdata.GetKey_Name, name.text);
                    userdata.SetInfo(CG_variable.GetUserInfo["id"], userdata.GetKey_Role, job);
                    userdata.SetInfo(CG_variable.GetUserInfo["id"], userdata.GetKey_Sex, sex);
                    userdata.SetInfo(CG_variable.GetUserInfo["id"], userdata.GetKey_Model, Model);
                    GameModel_role role = new GameModel_role();
                }
                break;
        }
    }
}
