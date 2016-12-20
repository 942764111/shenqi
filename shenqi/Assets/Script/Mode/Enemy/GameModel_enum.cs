using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using CG_Manage;
using CG_Public;
public class GameModel_enum : Enemy_Manage, interface_Model
{
    string ClassID = "GameModel_enum";
    JsonData ModelData;
    User_Manage userdata = null;
    string ModelID = "1";
    
    public Dictionary<string, string> GetInfo = new Dictionary<string, string>();

    private GameObject me = null;
    public  Transform GetMe
    {
        get
        {
            return me.transform;
        }
    }

    public GameModel_enum(string ModelID)
    {
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
    public void CreateModel(string path, string model)
    {
        me = CloneModel(path + model);
    }
    public void AddInfo(JsonData info)
    {
        this.GetInfo = base.GetInfo(info);
    }
}
