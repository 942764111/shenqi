using UnityEngine;
using System.Collections;
using LitJson;
using CG_Manage;
using CG_Public;
public class GameModel_role : Model_Managers
{
    JsonData ModelData;
    GameObject Model;
    User_Manage userdata;
    void Awake() {
        ModelData = null;
        Model = null;
        userdata = null;
    }
    void Start()
    {
        userdata = User_Manage.CreateInstance();

        LoadData(CG_variable.GetUserInfo["Model"]);

        CreateModel((string)ModelData["path"], (string)ModelData["model"]);

        AddInfo(ModelData["info"]);
    }
    public override void LoadData(string ModelID)
    {
        ModelData = CG_Config.MODEL[ModelID];
        Debug.Log(CG_Windows.Format((string)CG_Config.LABEL["JZMXSJ"], ModelData.ToJson()));
    }
    protected override void CreateModel(string ModelPath, string ModelName) {
        GameObject Modelres = CG_Games.LoadObject(ModelPath+ ModelName);
        Model = Instantiate(Modelres);
        transform.parent = Model.transform;
        Model.transform.localPosition = new Vector3(0, 0, 0); 
    }
    protected override void AddInfo(JsonData info){
        int index = 0;
        IDictionary infoValue = info as IDictionary;
        Debug.Log(CG_Windows.Format((string)CG_Config.LABEL["BROKEN"], (string)CG_Config.LABEL["ZRJSSX"]));
        Debug.Log(CG_Windows.Format((string)CG_Config.LABEL["BROKEN"], (string)CG_Config.LABEL["Begin"]));
        foreach (var obj in infoValue.Values)
        {
            userdata.SetInfo(CG_variable.GetUserInfo["id"], userdata.GetModelKeys[index], obj.ToString());
            index++;
        }
        Debug.Log(CG_Windows.Format((string)CG_Config.LABEL["BROKEN"], (string)CG_Config.LABEL["END"]));
    }
}
