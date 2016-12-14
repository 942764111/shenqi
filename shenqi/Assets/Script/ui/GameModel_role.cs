using UnityEngine;
using System.Collections;
using LitJson;
using usermanage;
public class GameModel_role : GameModel
{
    JsonData ModelData;
    GameObject Model;
    UserManage userdata;
    void Awake() {
        ModelData = null;
        Model = null;
        userdata = null;
    }
    void Start()
    {
        userdata = new UserManage();

        LoadData(StaticGame.GetUserInfo["Model"]);

        CreateModel((string)ModelData["path"], (string)ModelData["model"]);

        AddInfo(ModelData["info"]);
    }
    public override void LoadData(string ModelID)
    {
        ModelData = Config.MODEL[ModelID];
        Debug.Log(Windows.Format((string)Config.LABEL["JZMXSJ"], ModelData.ToJson()));
    }
    protected override void CreateModel(string ModelPath, string ModelName) {
        GameObject Modelres = Games.LoadObject(ModelPath+ ModelName);
        Model = Instantiate(Modelres);
        transform.parent = Model.transform;
        Model.transform.localPosition = new Vector3(0, 0, 0); 
    }
    protected override void AddInfo(JsonData info){
        int index = 0;
        IDictionary infoValue = info as IDictionary;
        Debug.Log(Windows.Format((string)Config.LABEL["BROKEN"], (string)Config.LABEL["ZRJSSX"]));
        Debug.Log(Windows.Format((string)Config.LABEL["BROKEN"], (string)Config.LABEL["Begin"]));
        foreach (var obj in infoValue.Values)
        {
            userdata.SetInfo(StaticGame.GetUserInfo["id"], userdata.GetModelKeys[index], obj.ToString());
            index++;
        }
        Debug.Log(Windows.Format((string)Config.LABEL["BROKEN"], (string)Config.LABEL["END"]));
    }
}
