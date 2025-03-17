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

    public BackpackCanvas backpack;

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

        ReBack(); // ó�� ���� ����

        allTxt.transform.SetAsLastSibling(); //�ܿ�
        backObj.gameObject.BindingBtn(OpenOrCloseBag);

        for (int i = 0; i < maxPanelCount; i++)
        {
            Manager.Ui.soletClickUIs.Add(Manager.Ui.CreateUI<SoletClickUI>("Bg_panel", GetObject((int)Objects.InvenBackground).transform));
            //Instantiate(ui_Panel, GetObject((int)Objects.InvenBackground).transform);
        }

        // �÷��̾� start ������ ����

        return true;
    }

    #region �÷��̾� �����̴� ����
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

    #region �÷��̾� ���� ����
    public void OpenOrCloseBag()
    {
        if (backpack.gameObject.activeSelf == true)
        {
            backpack.gameObject.SetActive(false);
        }
        else
        {
            backpack.gameObject.SetActive(true);
        }
    }

    public void ReBack()
    {
        //�Ŵ������� �����ϴ� ���� ĭ�� �ʱ�ȭ
        //Destroy(backpack.gameObject);
        Manager.Ui.backpackSolet.Clear();
        if (backpack != null)
            backpack.items.Clear();
        Manager.Game.CurrentBackCount = 0;
        if (gameObject.FindChild<BackpackCanvas>("BackpackCanvas") == null)
        {
            backpack = Manager.Ui.CreateUI<BackpackCanvas>("Backpack_UI/Bg_Back", transform);
            backpack.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            backpack.name = "BackpackCanvas";
            backpack.gameObject.SetActive(false);
        }

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
