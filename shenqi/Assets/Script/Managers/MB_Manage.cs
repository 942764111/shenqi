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
    /// 销毁。
    /// 1个参数：立即销毁。
    /// </summary>
    public void MB_Destroy(GameObject obj) {
        Destroy(obj);
    }
    /// <summary>
    /// 销毁。
    /// 2个参数：延时销毁（2参：时间）。
    /// </summary>
    public void MB_Destroy(GameObject obj,float time)
    {
        Destroy(obj, time);
    }

    /// <summary>
    /// 实例化
    /// </summary>
    public GameObject MB_Instantiate(GameObject res) {
        GameObject obj = Instantiate(res);
        return obj;
    }
}
