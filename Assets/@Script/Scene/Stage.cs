using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    private const float breathDamage = 3f;
    public float breathSpeed;
    public bool isFrist;
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
            StartCoroutine(PlayerBrath());
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
            Debug.Log("ºê·¡½º");
        }
    }

    public void Clear()
    {

    }
}
