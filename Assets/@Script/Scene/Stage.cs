using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    private const float breathDamage = 3f;
    public float breathSpeed;
    public bool isFrist;

    public int myStageID;   
    public GameObject door;
    public GameObject onePiece;
    public Dfine.StageScene MyStage { get; set; }
    private void Start()
    {
        Init();
    }
    private void Update()
    {
        UpdateMethod();
    }

    public virtual bool Init()
    {
        if (!isFrist)
        {
            isFrist = true;
            if(MyStage != Dfine.StageScene.Lobby)
                StartCoroutine(PlayerBrath());

            //보물 초기화
            onePiece = GameObject.FindGameObjectWithTag("OnePiece");
            foreach(var item in Manager.Instance.player.itemHole.GetComponentsInChildren<MapItem>())
            {
                item.SetOnePiece(onePiece);
            }

            Manager.Instance.player.PlayerClear();
            if (Manager.Stage.CheckTrager(myStageID))
                Destroy(onePiece);

            if (Manager.Stage.CheckStage(myStageID))
                Destroy(door);
            return true;
        }
        return false;
    }

    public virtual void UpdateMethod() { }

    IEnumerator PlayerBrath()
    {
        while (true && Manager.Instance.player.CurrentHp > 0)
        {
            yield return new WaitForSeconds(breathSpeed);
            Manager.Instance.player.CurrentBreath -= breathDamage;
        }
    }

    public void Clear()
    {

    }
}
