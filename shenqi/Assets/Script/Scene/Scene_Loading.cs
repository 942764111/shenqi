using UnityEngine;
using System.Collections;
using CG_Manage;
using CG_Public;
using LitJson;
public class Scene_Loading :MB_Manage
{
    UISlider Bar = null;
    UILabel BarLabel = null;
    //读取场景的进度，它的取值范围在0 - 1 之间。
    float progress = 0;
    string progressName = "";
    bool on_off = false;
    JsonData LOADINGRES = null;
    void Start()
    {
        LOADINGRES = CG_Config.LOADINGRES[Scene_Manage.SceneName];

        initUI();
        //进入loadScene方法。
        StartCoroutine(loadScene());
    }
    void initUI() {
        GameObject bar = transform.Find("Progress Bar").gameObject;
        GameObject label = transform.Find("Label").gameObject;
        Bar = bar.GetComponent<UISlider>();
        BarLabel = label.GetComponent<UILabel>();
    } 
    IEnumerator loadScene()
    {
         IDictionary infoValue = LOADINGRES as IDictionary;
         foreach (string key in infoValue.Keys) {
            switch (key) {
                case "UI":
                    on_off = true;
                    for (var i = 0; i < LOADINGRES[key].Count; i++)
                    {
                        Debug.Log((string)CG_Config.RESPath["UI"] + LOADINGRES[key][i]);
                        CG_Games.LoadObject((string)CG_Config.RESPath["UI"] + LOADINGRES[key][i]);
                        progress++;
                        yield return 0;
                    }
                    break;
                case "model":
                    for (var i = 0; i < LOADINGRES[key].Count; i++)
                    {
                        Debug.Log((string)CG_Config.RESPath["UI"] + LOADINGRES[key][i]);
                        string path = (string)CG_Config.MODEL[LOADINGRES[key][i].ToString()]["path"]+ CG_Config.MODEL[LOADINGRES[key][i].ToString()]["model"];
                        CG_Games.LoadObject(path);
                        progress++;
                        yield return 0;
                    }
                    break;
            }
            
        }

        on_off = false;
       yield return 0;

    }
    void Update()
    {
        if (on_off) {
            Bar.value = Mathf.Lerp(progress, 1, Time.time);
            Debug.Log(Bar.value);
            BarLabel.text = progress.ToString();
        }
    }    
}
