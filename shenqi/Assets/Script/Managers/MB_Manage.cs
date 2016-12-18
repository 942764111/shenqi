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
    public void MB_Destroy(GameObject obj) {
        Destroy(obj);
    }
    public void MB_Destroy(GameObject obj,float time)
    {
        Destroy(obj, time);
    }

    public GameObject MB_Instantiate(GameObject res) {
        GameObject obj = Instantiate(res);
        return obj;
    }
}
