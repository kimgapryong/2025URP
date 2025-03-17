using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class RandomSpwanController : BaseContoller
{
    Dfine.ItemRating itemRating;

    public GameObject[] common;
    public GameObject[] normal;
    public GameObject[] legend;

    public void RandomItemSpwan(Vector3 pos)
    {
        GameObject[] itemobjs = null;
        int rand = Random.Range(0, 101);

        if (rand <= 45)
            itemRating = Dfine.ItemRating.None;
        else if (rand <= 75)
            itemRating = Dfine.ItemRating.Common;
        else if (rand <= 98)
            itemRating = Dfine.ItemRating.Normal;
        else
            itemRating = Dfine.ItemRating.Legend;

        if (itemRating == Dfine.ItemRating.None)
            return;

        switch (itemRating)
        {
            case Dfine.ItemRating.Common:
                itemobjs = common;
                break;
            case Dfine.ItemRating.Normal:
                itemobjs = normal;
                break;
            case Dfine.ItemRating.Legend:
                itemobjs = legend;
                break;
        }

        int randomItem = Random.Range(0, itemobjs.Length);

        GameObject clone = Instantiate(itemobjs[randomItem]);
        clone.name = itemobjs[randomItem].name;
        clone.transform.position = pos;

        Item_Click itemclick = clone.GetComponent<Item_Click>();
        if(itemclick != null)
        {
            if (itemRating == Dfine.ItemRating.Normal)
            {
                itemclick.changeColor = () => itemclick.curImage.color = Color.yellow;
            }
            else if (itemRating < Dfine.ItemRating.Legend)
            {
                itemclick.changeColor = () => itemclick.curImage.color = Color.red;
            }
        }
      
    }
}
