using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStarter : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;
    public Collider2D graph;
    private Vector3 startPos = new Vector3(-24f, -7.5f);

    private void Start()
    {
        InitStart();
    }

    private void InitStart()
    {
        // 플레이어 초기화
        GameObject pa = GameObject.Find("Player");
        if(pa == null)
        {
            pa = Instantiate(player);
            pa.name = player.name;
            pa.GetOrAddComponent<PlayerController>();
            pa.transform.position = startPos;
            DontDestroyOnLoad(pa);
        }
        // 인벤토리 초기화
        GameObject inven = GameObject.Find("InvenCanvas");
        if(inven == null)
        {
            Debug.Log(Manager.Ui);
            InvenCanvas inventory = Manager.Ui.CreateUI<InvenCanvas>("InvenCanvas");
            inven = inventory.gameObject;
            DontDestroyOnLoad (inven);
        }

        // 카메라 초기화
        GameObject virualCam = GameObject.Find("PlayerCam");
        if(virualCam == null)
        {
            virualCam = Instantiate(cam);
            virualCam.transform.position = new Vector3(0,0,-10);
            DontDestroyOnLoad (virualCam);
        }
        CinemachineVirtualCamera cinema = virualCam.GetComponent<CinemachineVirtualCamera>();
        cinema.Follow = pa.transform;
        cinema.m_Lens.OrthographicSize = 10;

        CinemachineConfiner2D confiner = virualCam.gameObject.GetOrAddComponent<CinemachineConfiner2D>();
        confiner.m_BoundingShape2D = graph;
    }
}
