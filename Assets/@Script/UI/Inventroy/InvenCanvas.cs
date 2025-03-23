using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenCanvas : UI_Base
{
    enum Images
    {
        InvenBackground,
        BackImage,
        Bg_Back,
        Hp_Slider,
        Breath_Slider,
        Weight_Slider,
    }
    enum Objects
    {
        InvenBackground,
    }
   
    enum Texts
    {
        AllText,
        Hp_Txt,
        Br_Txt,
        Weight_Txt,
    }

    public GameObject backObj;
    public Image hp_S;
    public Image br_S;
    public Image weight_S;

    Text hp_T;
    Text br_T;
    Text we_T;

    Text allTxt;
    Coroutine _cor;

    private int maxPanelCount = 6;
    public override bool Init()
    {
        base.Init();

        Bind<Image>(typeof(Images));
        Bind<GameObject>(typeof(Objects));
        Bind<Text>(typeof(Texts));

        hp_S = GetImage((int)Images.Hp_Slider);
        br_S = GetImage((int)Images.Breath_Slider);
        weight_S = GetImage((int)Images.Weight_Slider);
        //text
        allTxt = GetText((int)Texts.AllText);
        hp_T = GetText((int)Texts.Hp_Txt);
        br_T = GetText((int)Texts.Br_Txt);
        we_T = GetText((int)Texts.Weight_Txt);


        allTxt.gameObject.SetActive(false);

        //Action
        player.hpAction = Hp_UI;
        player.breathAction = Breath_UI;
        Manager.Game.backpackWeightAction = Weight_UI;

        backObj = GetImage((int)Images.BackImage).gameObject;

        //ReBack(); // 처음 가방 설정
        for (int i = 0; i < maxPanelCount; i++)
        {
            Manager.Ui.soletClickUIs.Add(Manager.Ui.CreateUI<SoletClickUI>("Bg_panel", GetObject((int)Objects.InvenBackground).transform));
            //Instantiate(ui_Panel, GetObject((int)Objects.InvenBackground).transform);
        }

        // 플레이어 start 아이템 설정

        return true;
    }

    #region 플레이어 슬라이더 관리
    public void Hp_UI(float cur, float max)
    {
        float sliderValue = Mathf.Max(cur, 0);
        hp_T.text = $"{cur}/{max}";
        hp_S.fillAmount = sliderValue / max;
    }

    public void Breath_UI(float cur, float max)
    {
        float sliderValue = Mathf.Max(cur, 0);
        br_T.text = $"{cur}/{max}";
        br_S.fillAmount = sliderValue / max;
    }
    public void Weight_UI(int cur, int max)
    {
        if ((float)cur / max >= 0.9)
        {
            Manager.Ui.InvenCanvas.GetAllTxt("가방이 너무 무겁습니다");
            weight_S.color = Color.red;
            player.Speed = player.maxSpeed * 0.5f;
        }
        else if((float)cur / max >= 0.7)
        {
            Manager.Ui.InvenCanvas.GetAllTxt("가방이 너무 무겁습니다");
            weight_S.color = new Color(1f, 0.5f, 0f, 1f);
            player.Speed = player.maxSpeed * 0.8f;
        }
        else
        {
            weight_S.color = Color.yellow;
            if(player.maxSpeed > 0f)
                player.Speed = player.maxSpeed;
        }

        float sliderValue = Mathf.Max(cur, 0);
        we_T.text = $"{cur} / {max}";
        weight_S.fillAmount = sliderValue / max;
    }
    #endregion

    #region 플레이어 가방 관련
    public void OpenOrCloseBag()
    {
        if (Manager.Ui.Backpack.gameObject.activeSelf == true)
        {
            Manager.Ui.Backpack.gameObject.SetActive(false);
        }
        else
        {
            Manager.Ui.Backpack.gameObject.SetActive(true);
        }
    }

    public void ReBack()
    {
        //매니저에서 관리하는 가방 칸수 초기화
        //Destroy(backpack.gameObject);
        if (Manager.Ui.Backpack != null)
            Destroy(Manager.Ui.Backpack.gameObject);

        Manager.Ui.backpackSolet.Clear();
        Manager.Game.CurrentBackCount = 0;

        if (gameObject.FindChild<BackpackCanvas>("BackpackCanvas") == null)
        {
            Manager.Ui.Backpack = Manager.Ui.CreateUI<BackpackCanvas>("Backpack_UI/Bg_Back", transform);
            Manager.Ui.Backpack.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            Manager.Ui.Backpack.name = "BackpackCanvas";
            Manager.Ui.Backpack.gameObject.SetActive(false);
        }

        allTxt.transform.SetAsLastSibling(); //외워
        backObj.gameObject.BindingBtn(OpenOrCloseBag);
    }
    #endregion

    public void GetAllTxt(string txt)
    {
        allTxt.text = txt;

        if (_cor != null)
            StopCoroutine(_cor);

        _cor = StartCoroutine(waitTxt());
    }

    private IEnumerator waitTxt()
    {
        allTxt.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        allTxt.gameObject.SetActive(false);
    }
}
