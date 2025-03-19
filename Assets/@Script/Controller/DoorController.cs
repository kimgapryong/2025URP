using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : BaseContoller
{
    public Sprite sprite;
    public string animalString;
    public float sizeCell;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            Time.timeScale = 0;
            QuizCanvas quizCanvas = Manager.Ui.CreateUI<QuizCanvas>("QuizCanvas");
            quizCanvas.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            quizCanvas.myDoor = gameObject;
            quizCanvas.animalSprite = sprite;
            quizCanvas.quizAnimal = animalString;
            quizCanvas.SetSize = sizeCell;

            quizCanvas.StrInit();
        }
    }
}
