using UnityEngine;
using System.Collections;
using CG_Manage;
using CG_Public;
using LitJson;
public class Scene_Loading :MB_Manage{

    //异步对象
    AsyncOperation async = null;
    public string SceneName = "";
    UIProgressBar Bar = null;
    UILabel BarLabel = null;
    //读取场景的进度，它的取值范围在0 - 1 之间。
    int progress = 0;
    string progressName = "";
    void Start()
    {
        initUI();
        //进入loadScene方法。
        StartCoroutine(loadScene());
    }
    void initUI() {
        GameObject bar = transform.Find("Progress Bar").gameObject;
        GameObject label = transform.Find("Label").gameObject;
        Bar = bar.GetComponent<UIProgressBar>();
        BarLabel = label.GetComponent<UILabel>();
    } 
    IEnumerator loadScene()
    {
        
        foreach (string scene in CG_Config.LOADINGRES[Scene_Manage.SceneName])
        {
            Debug.Log("78898" + scene);
        }
        ////便利所有游戏对象
        //foreach (string scene in CG_Config.LOADINGRES[Scene_Manage.SceneName])
        //{
        //    foreach (var obj in CG_Config.LOADINGRES[Scene_Manage.SceneName][scene])
        //    {

        //        Debug.Log(obj);
        //        progress++;
        //        yield return 0;
        //    }
        //}
        //async = Application.LoadLevelAsync(Scene_Manage.SceneName);
        yield return 0;

    }
    void Update()
    {
      //  progress = (int)(async.progress * 100);
      //  Bar.value = progress;
      //  BarLabel.text = progress.ToString();
    }

}
