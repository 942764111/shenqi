using UnityEngine;
using System.Collections;

public class MB_Manage : MonoBehaviour {

    private static MB_Manage _instance = null;
    protected MB_Manage() { }
    public static MB_Manage CreateInstance()
    {
        if (_instance == null)
        {
            _instance = new MB_Manage();
        }
        return _instance;
    }
    /// <summary>
    /// 销毁
    /// </summary>
    /// <param name="obj">销毁对象</param>
    public void MB_Destroy(GameObject obj) {
        Destroy(obj);
    }
    /// <summary>
    /// 销毁
    /// </summary>
    /// <param name="obj">销毁对象</param>
    /// <param name="time">时间</param>
    public void MB_Destroy(GameObject obj,float time)
    {
        Destroy(obj, time);
    }

    /// <summary>
    /// 实例化
    /// </summary>
    /// <param name="res">对象</param>
    /// <returns></returns>
    public GameObject MB_Instantiate(GameObject res) {
        GameObject obj = Instantiate(res);
        return obj;
    }
}
