using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainStarter : MonoBehaviour
{
    public GameObject player;
    public GameObject shopChr;
    public GameObject cam;
    public Transform shoptrans;


    public GameObject[] testItem;


    private Vector3 startPos = new Vector3(-24f, -7.5f);
    private Vector3 shopPos = new Vector3(9f, 1f);

    private void Start()
    {
        CheatAngine.instance.curID = 0;
        InitStart();
    }

    private void InitStart()
    {
        // �÷��̾� �ʱ�ȭ
        if (Manager.Instance.player == null)
        {
            GameObject pa = Instantiate(player);
            pa.name = player.name;
            PlayerController pc = pa.GetOrAddComponent<PlayerController>();
            Manager.Instance.GetPlayer(pc); // Manager�� �÷��̾� ����
            pa.transform.position = startPos;
            DontDestroyOnLoad(pa);
        }
        Manager.Instance.player.transform.position = startPos;
        Manager.Instance.player.CurrentBreath = Manager.Instance.player.MaxBreath;
        Manager.Instance.player.CurrentHp = Manager.Instance.player.Hp;
        // �κ��丮 �ʱ�ȭ

        if (Manager.Ui.InvenCanvas == null)
        {
            InvenCanvas inventory = Manager.Ui.CreateUI<InvenCanvas>("InvenCanvas");
            Manager.Ui.InvenCanvas = inventory;
            DontDestroyOnLoad (inventory.gameObject);
        }
        //ī�޶� ����
        if (Camera.main == null) // ���� ���� ī�޶� Ȯ��
        {
            GameObject mainCam = Instantiate(cam);
            mainCam.name = cam.name;
            mainCam.transform.position = new Vector3(0, 0, -10);
            CameraController camCon = mainCam.GetOrAddComponent<CameraController>();
            camCon.player = Manager.Instance.player;
            DontDestroyOnLoad(mainCam);
        }
        //���� ����
        GameObject shoper = GameObject.Find("ShopChracter");
        if(shoper == null)
        {
            shoper = Instantiate(shopChr, shoptrans);
            shoper.name = shopChr.name;
            shoper.transform.localPosition = shopPos;
        }
        //���� ����
        for(int i =0; i< 25; i++)
        {
            int rand = Random.Range(0, testItem.Length);
            GameObject potion = Instantiate(testItem[rand]);
            potion.name = testItem[rand].name;
            potion.transform.position = new Vector3(Random.Range(-3,7), Random.Range(-3, 7), 0);

        }

        //���� ����
        if(Manager.Ui.Shop == null)
        {
            ShopCanvas shopCanvas = Manager.Ui.CreateUI<ShopCanvas>("Shop_UI/ShopCanvas");
            Manager.Ui.Shop = shopCanvas;
            DontDestroyOnLoad (shopCanvas.gameObject);
        }

        //�̴ϸ� ����
        if(Manager.Ui.MiniMapCanvas == null)
        {
            MiniMapCanvas mini = Manager.Ui.CreateUI<MiniMapCanvas>("MiniMapCanvas");
            Manager.Ui.MiniMapCanvas = mini;
            DontDestroyOnLoad(mini.gameObject);
        }
        //�״� �� ĵ�ٽ� ����
        if(Manager.Ui.Die == null)
        {
            DieCanvas die = Manager.Ui.CreateUI<DieCanvas>("DieCanvas");
            Manager.Ui.Die = die;
            DontDestroyOnLoad(die.gameObject);
        }
        //������ �Ǹ�â ����
        if(Manager.Ui.ItemSell == null)
        {
            ItemSellCanvas sell = Manager.Ui.CreateUI<ItemSellCanvas>("ItemSellCanvas");
            Manager.Ui.ItemSell = sell;
            DontDestroyOnLoad(sell.gameObject);
        }
        else
        {
            Manager.Ui.ItemSell.SellItem();
        }

    }
}
