using UnityEngine;
using System.Collections;

public class GameBeginBtn : MonoBehaviour {
    Transform begin;
    // Use this for initialization
    void Start () {
        begin = transform.Find("bgein");
        UIEventListener.Get(begin.gameObject).onClick = BeginBtn;
    }
    void BeginBtn(GameObject a) {
        Debug.Log("进入游戏");
    }
    // Update is called once per frame
    void Update () {
	
	}
}
