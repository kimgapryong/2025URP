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

    private ItemManager _item = new ItemManager();
    public static ItemManager Item { get { return Instance._item; } }   

    private StageManager _stage = new StageManager();
    public static StageManager Stage { get { return Instance._stage; } }

    private GameManager _game = new GameManager();
    public static GameManager Game { get { return Instance._game; } }

    public PlayerController player { get; private set; }
    public RandomSpwanController RanomSpwan {  get; private set; }

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

    public void GetPlayer(PlayerController pa)
    {
        if (pa == null)
        {
            Debug.LogError("PlayerController가 null입니다!");
            return;
        }
        player = pa;
        RanomSpwan = player.GetComponent<RandomSpwanController>();
    }

    public void DieClear()
    {
        Destroy(player.gameObject);
        Destroy(Camera.main.gameObject);
        Destroy(Ui.InvenCanvas.gameObject);
        Destroy(Ui.Shop.gameObject);
        Destroy(Ui.ItemSell.gameObject);
        Destroy(gameObject);
    }

}
