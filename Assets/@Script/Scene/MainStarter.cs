using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStarter : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;
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
            PlayerController pc = pa.GetOrAddComponent<PlayerController>();
            Manager.Instance.GetPlayer(pc);
            pa.transform.position = startPos;
            DontDestroyOnLoad(pa);
        }
        // 인벤토리 초기화
        GameObject inven = GameObject.Find("InvenCanvas");
        if(inven == null)
        {
            InvenCanvas inventory = Manager.Ui.CreateUI<InvenCanvas>("InvenCanvas");
            inven = inventory.gameObject;
            DontDestroyOnLoad (inven);
        }
        //카메라 생성
        GameObject mainCam = GameObject.Find("Main Camera");
        if(mainCam == null)
        {
            mainCam = Instantiate(cam);
            mainCam.name = cam.name;
            mainCam.transform.position = new Vector3(0, 0, -10);
            CameraController camCon = mainCam.GetOrAddComponent<CameraController>();
            camCon.player = Manager.Instance.player;
            DontDestroyOnLoad(mainCam);
        }
    }
}
