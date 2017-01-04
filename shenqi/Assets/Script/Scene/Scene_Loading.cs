using UnityEngine;
using System.Collections;
using CG_Manage;
using CG_Public;
using LitJson;
public class Scene_Loading : Scene_Manage
{
    #region   废弃
    //UISlider Bar = null;
    //UILabel BarLabel = null;
    ////读取场景的进度，它的取值范围在0 - 1 之间。
    //float progressMax = 13;
    //float progress = 0;
    //string progressName = "";
    //bool on_off = false;
    //JsonData LOADINGRES = null;
    //void Start()
    //{
    //    LOADINGRES = CG_Config.LOADINGRES[SceneName];

    //    initUI();
    //    //进入loadScene方法。
    //    StartCoroutine(loadScene());
    //}
    //void initUI() {
    //    GameObject bar = transform.Find("Progress Bar").gameObject;
    //    GameObject label = transform.Find("Label").gameObject;
    //    Bar = bar.GetComponent<UISlider>();
    //    BarLabel = label.GetComponent<UILabel>();
    //} 
    //IEnumerator loadScene()
    //{
    //     IDictionary infoValue = LOADINGRES as IDictionary;
    //     foreach (string key in infoValue.Keys) {
    //        switch (key) {
    //            case "UI":
    //                on_off = true;
    //                for (int i = 0; i < LOADINGRES[key].Count; i++)
    //                {
    //                    Debug.Log(CG_Config.RESPath["UI"].ToString() + LOADINGRES[key][i]);
    //                    CG_Games.LoadObject((string)CG_Config.RESPath["UI"] + LOADINGRES[key][i]);
    //                    progress++;
    //                    yield return 0;
    //                }
    //                break;
    //            case "model":
    //                for (int i = 0; i < LOADINGRES[key].Count; i++)
    //                {
    //                    Debug.Log((string)CG_Config.RESPath["UI"] + LOADINGRES[key][i]);
    //                    string path = (string)CG_Config.MODEL[LOADINGRES[key][i].ToString()]["path"]+ CG_Config.MODEL[LOADINGRES[key][i].ToString()]["model"];
    //                    CG_Games.LoadObject(path);
    //                    progress++;
    //                    yield return 0;
    //                }
    //                break;
    //        }
            
    //    }

    //    on_off = false;
    //   yield return 0;

    //}
    //void Update()
    //{
    //    if (on_off) {           
    //       Bar.value =  progress / progressMax;
    //        BarLabel.text = (progress / progressMax *100f).ToString();
    //    }
    //}    
    #endregion
    UISlider Bar = null;
    UILabel BarLabel = null;
    //读取场景的进度，它的取值范围在0 - 1 之间。
    float progressMax = 10.0f;
    float progress = 0;
    string progressName = "";
    bool on_off = false;
    JsonData LOADINGRES = null;

    //异步对象
    AsyncOperation async;

    void Start()
    {
        LOADINGRES = CG_Config.LOADINGRES[SceneName];

        initUI();
        //进入loadScene方法。
        StartCoroutine(loadScene());
    }
    void initUI()
    {
        GameObject bar = transform.Find("Progress Bar").gameObject;
        GameObject label = transform.Find("Label").gameObject;
        Bar = bar.GetComponent<UISlider>();
        BarLabel = label.GetComponent<UILabel>();
    }
    IEnumerator loadScene()
    {
        #region
        //IDictionary infoValue = LOADINGRES as IDictionary;
        //foreach (string key in infoValue.Keys)
        //{
        //    switch (key)
        //    {
        //        case "UI":
        //            on_off = true;
        //            for (int i = 0; i < LOADINGRES[key].Count; i++)
        //            {
        //                Debug.Log(CG_Config.RESPath["UI"].ToString() + LOADINGRES[key][i]);
        //                CG_Games.LoadObject((string)CG_Config.RESPath["UI"] + LOADINGRES[key][i]);
        //                progress++;
        //                yield return 0;
        //            }
        //            break;
        //        case "model":
        //            for (int i = 0; i < LOADINGRES[key].Count; i++)
        //            {
        //                Debug.Log((string)CG_Config.RESPath["UI"] + LOADINGRES[key][i]);
        //                string path = (string)CG_Config.MODEL[LOADINGRES[key][i].ToString()]["path"] + CG_Config.MODEL[LOADINGRES[key][i].ToString()]["model"];
        //                CG_Games.LoadObject(path);
        //                progress++;
        //                yield return 0;
        //            }
        //            break;
        //    }

        //}

        //on_off = false;
        //yield return 0;
        #endregion
        async = Application.LoadLevelAsync("Scene_Game");
        async.allowSceneActivation = false;
        yield return async;
    }
    void Update()
    {
        if (async == null)
        { return; }
        uint toProcess;
        if (async.progress < 0.9f)
        {
            toProcess = (uint)async.progress * 100;
        }
        else
        {
            toProcess = 100;
        }
        if (progress < toProcess)
        {
            progress++;
        }
        Bar.value = progress / 100f;
        BarLabel.text = progress.ToString();
        if (progress == 100)
        {
            async.allowSceneActivation = true;
        }
    }    
}
