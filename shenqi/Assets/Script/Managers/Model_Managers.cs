using UnityEngine;
using LitJson;
namespace CG_Manage
{
    public class Model_Managers : MB_Manage
    {
        private static Model_Managers _instance = null;
        protected Model_Managers() { }
        public static Model_Managers CreateInstance()
        {
            if (_instance == null)
            {
                _instance = new Model_Managers();
            }
            return _instance;
        }
    }
}
