using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private static Manager _instance;
    public static Manager Instance { get { Init(); return _instance; } }

    private ResourcesManager _resources = new ResourcesManager();
    public static ResourcesManager Resources { get { return Instance._resources; } }

    private UIManager _ui = new UIManager();
    public static UIManager Ui { get { return Instance._ui; } }

    private void Awake()
    {
        Init();
    }

    public static void Init()
    {
        if (_instance != null) return;

        GameObject go = GameObject.Find("@Manager");
        if (go == null)
        {
            go = new GameObject("@Manager");
            _instance = go.AddComponent<Manager>();
           
        }
        _instance = go.GetComponent<Manager>();
        DontDestroyOnLoad(go);

    }
}
