using UnityEngine;
using System.Collections;
using LitJson;
using CG_Manage;
using CG_Public;
public class UI_SelectRole : UI_Manage,interface_UI
{
    string ClassID = "UI_SelectRole";
    User_Manage userdata;
    GameObject me;
    Animation Animobj;
    ArrayList Action = new ArrayList();
    JsonData json;
    string job = "";
    string sex = "";
    string Model = "1";
    //// Use this for initialization

    public UI_SelectRole()
    {
        userdata = User_Manage.CreateInstance();

        json = CG_Config.SELECTROLE;

        initUI();
    }
    public void initUI()
    {
       userdata = User_Manage.CreateInstance();
       me = CloneUI(ClassID);

        GameModel_role role =  new GameModel_role();
      //  role.GetThis().localRotation = new Vector2(0f,-180f);
        initAddAction();

        initBtns();

        StartState();

        AddUI(ClassID, me);
    }
    public void initBtns()
    {
        //职业按钮
        JsonData jobs = json["job"];
        Transform objbtn;
        for (int i = 0; i < jobs.Count; i++)
        {
            objbtn = me.transform.Find("btns/job/" + (string)jobs[i]["name"]);
            UIEventListener.Get(objbtn.gameObject).onClick = jobsOnClick;
        }

        //其它按钮
        string[] otherarr = { "sj", "ks" };
        Transform otherbtn;
        for (int i = 0; i < otherarr.Length; i++)
        {
            otherbtn = me.transform.Find("btns/other/" + otherarr[i]);
            UIEventListener.Get(otherbtn.gameObject).onClick = Callback;
        }
    }
    //----------------------------------------初始化选择角色界面按钮
    void StartState()
    {
        JsonData jobs = json["job"];
        UIButton btn = me.transform.Find("btns/job/" + (string)jobs[0]["name"]).GetComponent<UIButton>();
        Transform obj = me.transform.Find("ui/hero/" + (string)jobs[0]["name"]);
        TheRunState(btn, obj, jobs[0]["jobPath"], jobs[0]["sexPath"]);
        otherOnClickState("sj");
        job = (string)jobs[0]["job"];
        sex = (string)jobs[0]["sex"];
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
            btn = me.transform.Find("btns/job/" + (string)jobs[i]["name"]).GetComponent<UIButton>();
            obj = me.transform.Find("ui/hero/" + (string)jobs[i]["name"]);
            if ((string)jobs[i]["name"] == objname)
            {
                TheRunState(btn, obj, jobs[i]["jobPath"], jobs[i]["sexPath"]);
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
    public void Callback(GameObject obj)
    {
       otherOnClickState(obj.name);
    }
    void otherOnClickState(string objname) {
        Transform Getname = me.transform.Find("ui/name/Label");
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
                    userdata.SetInfo(CG_variable.GetUserInfo[userdata.GetKey_ID], userdata.GetKey_Name, name.text);
                    userdata.SetInfo(CG_variable.GetUserInfo[userdata.GetKey_ID], userdata.GetKey_Role, job);
                    userdata.SetInfo(CG_variable.GetUserInfo[userdata.GetKey_ID], userdata.GetKey_Sex, sex);
                    userdata.SetInfo(CG_variable.GetUserInfo[userdata.GetKey_ID], userdata.GetKey_Model, Model);
                //    GameModel_role role = new GameModel_role();
                }
                break;
        }
    }
}
