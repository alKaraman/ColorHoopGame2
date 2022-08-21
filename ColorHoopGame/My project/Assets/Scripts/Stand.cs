using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand : MonoBehaviour
{
    public GameObject MovePos;
    public GameObject[] Plugs;
    public int EmptyPlug;
    public List<GameObject> _Circles = new();
    [SerializeField] private GameManager _GameManager;



    public GameObject TopEndCircle()
    {
        return _Circles[^1];


    }

    public GameObject AvailablePlug()
    {
        return Plugs[EmptyPlug];//


    }


    public void RelocateOfThePlugs(GameObject RemovebleObj)
    {

        _Circles.Remove(RemovebleObj);
        

        if(_Circles.Count!= 0)
        {

            EmptyPlug--;
            _Circles[^1].GetComponent<Circle>().CanItMove = true;

        }
        else
        {

            EmptyPlug = 0;

        }


    }


}
