using UnityEngine;
using System.Collections;
using LitJson;
namespace CG_Manage
{
    public abstract class Model_Managers : MonoBehaviour
    {
        public abstract void LoadData(string ModelID);
        protected abstract void CreateModel(string ModelPath, string ModelName);
        protected abstract void AddInfo(JsonData info);
    }
}
