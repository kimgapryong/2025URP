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
    }
    enum Objects
    {
        InvenBackground,
    }
    enum Sliders
    {
        Hp_Slider,
        Breath_Slider,
    }
    enum Texts
    {
        AllText,
    }

    public GameObject backObj;
    Slider hpSlider;
    Slider brSlider;
    Text allTxt;
    Coroutine _cor;

    private int maxPanelCount = 6;
    public override bool Init()
    {
        base.Init();

        Bind<Image>(typeof(Images));
        Bind<GameObject>(typeof(Objects));
        Bind<Slider>(typeof(Sliders));
        Bind<Text>(typeof(Texts));

        hpSlider = GetSlider((int)Sliders.Hp_Slider);
        brSlider = GetSlider((int)Sliders.Breath_Slider);
        allTxt = GetText((int)Texts.AllText);
        allTxt.gameObject.SetActive(false);

        player.hpAction = Hp_UI;
        player.breathAction = Breath_UI;

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
        hpSlider.value = sliderValue / max;
    }

    public void Breath_UI(float cur, float max)
    {
        Debug.Log(max);
        float sliderValue = Mathf.Max(cur, 0);
        brSlider.value = sliderValue / max;
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
