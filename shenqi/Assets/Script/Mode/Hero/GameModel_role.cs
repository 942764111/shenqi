using UnityEngine;
using System.Collections;
using LitJson;
using CG_Manage;
using CG_Public;
public class GameModel_role : Hero_Manage, interface_Model
{
    string ClassID = "GameModel_role";
    JsonData ModelData;
    User_Manage userdata = null;
    string ModelID = "1";
    private GameObject me = null;

    public Transform GetMe
    {
        get
        {
            return me.transform;
        }
    }

    public GameModel_role(string ModelID) {
        this.ModelID = ModelID;
        ModelData = CG_Config.MODEL[this.ModelID];
        init();
    }
    void init()
    {
        userdata = User_Manage.CreateInstance();

        LoadData();

        CreateModel((string)ModelData["path"], (string)ModelData["model"]);

        AddInfo(ModelData["info"]);
    }
    public void LoadData()
    {
        Debug.Log(CG_Windows.Format((string)CG_Config.LABEL["JZMXSJ"], ModelData.ToJson()));
    }
    public void CreateModel(string path,string model) {
        GameObject obj = CloneModel(path+model);
        Vector3 size = new Vector3(0.6f, 0.6f,0.6f);//待定  最后走配置
        obj.transform.localScale = size;
        me = obj;
    }
    public void AddInfo(JsonData info){
        int index = 0;
        IDictionary infoValue = info as IDictionary;
        Debug.Log(CG_Windows.Format((string)CG_Config.LABEL["BROKEN"], (string)CG_Config.LABEL["ZRJSSX"]));
        Debug.Log(CG_Windows.Format((string)CG_Config.LABEL["BROKEN"], (string)CG_Config.LABEL["Begin"]));
        foreach (var obj in infoValue.Values)
        {
            userdata.SetInfo(User_Manage.GetUserInfo[userdata.GetKey_ID], userdata.GetModelKeys[index], obj.ToString());
            index++;
        }
        Debug.Log(CG_Windows.Format((string)CG_Config.LABEL["BROKEN"], (string)CG_Config.LABEL["END"]));
    }
}
