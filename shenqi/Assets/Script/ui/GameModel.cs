using UnityEngine;
using System.Collections;
using LitJson;
public abstract class GameModel : MonoBehaviour {
    public abstract void LoadData(string ModelID);
    protected abstract void CreateModel(string ModelPath,string ModelName);
    protected abstract void AddInfo(JsonData info);
}
