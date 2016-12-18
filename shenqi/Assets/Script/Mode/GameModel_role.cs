using UnityEngine;
using System.Collections;
using LitJson;
using CG_Manage;
using CG_Public;
public class GameModel_role : Model_Managers,interface_Model
{
    string ClassID = "GameModel_role";
    JsonData ModelData;
    User_Manage userdata;
    string ModelID = "1";
    Transform me = null;
    void Start()
    {
        this.ModelID = ModelID;
        ModelData = CG_Config.MODEL[this.ModelID];
        userdata = null;
        init();
    }
    void init()
    {
        userdata = User_Manage.CreateInstance();

        LoadData();

        CreateModel((string)ModelData["path"], (string)ModelData["model"]);

        //  AddInfo(ModelData["info"]);
    }
    public Transform GetThis() {
        return me;
    }
    public void LoadData()
    {
        Debug.Log(CG_Windows.Format((string)CG_Config.LABEL["JZMXSJ"], ModelData.ToJson()));
    }
    public void CreateModel(string ModelPath, string ModelName) {
        GameObject Modelres = CG_Games.LoadObject(ModelPath + ModelName);
        GameObject obj = Instantiate(Modelres);
        obj.transform.localPosition = new Vector3(0, 0, 0);
        Vector2 size = new Vector2(0.6f, 0.6f);
        obj.transform.localScale = size;
        me = obj.transform;
    }
    public void AddInfo(JsonData info){
        int index = 0;
        IDictionary infoValue = info as IDictionary;
        Debug.Log(CG_Windows.Format((string)CG_Config.LABEL["BROKEN"], (string)CG_Config.LABEL["ZRJSSX"]));
        Debug.Log(CG_Windows.Format((string)CG_Config.LABEL["BROKEN"], (string)CG_Config.LABEL["Begin"]));
        foreach (var obj in infoValue.Values)
        {
            userdata.SetInfo(CG_variable.GetUserInfo[userdata.GetKey_ID], userdata.GetModelKeys[index], obj.ToString());
            index++;
        }
        Debug.Log(CG_Windows.Format((string)CG_Config.LABEL["BROKEN"], (string)CG_Config.LABEL["END"]));
    }
}
