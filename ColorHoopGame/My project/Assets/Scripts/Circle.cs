using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public GameObject _CirclesStand;
    public GameObject _CirclesPlug;
    public bool CanItMove;
    public string Color;
    public GameManager _GameManager;


    GameObject MovePos;
    GameObject CirclesStand;


    bool Selected, Relocated, PlugIn, PlugOut;


    public void Move(string execute, GameObject Stand = null , GameObject Plug = null , GameObject TargetObj = null)
    {
        
        switch(execute)
        {
            case "Select":

                MovePos = TargetObj;
                Selected = true;

                break;

            case "Relocate":

                CirclesStand = Stand;
                _CirclesPlug = Plug;
                MovePos = TargetObj;
                Relocated = true;

                break;

            case "PlugIn":

                break;

            case "PlugOut":

                break;
                
        }



    }

    // Update is called once per frame
    void Update()
    {
        
        if(Selected)
        {

            transform.position = Vector3.Lerp(transform.position,MovePos.transform.position,.2f);

            if(Vector3.Distance(transform.position,MovePos.transform.position)<.10)
            {
                Selected = false;

            }


        }

        if (Relocated)
        {

            transform.position = Vector3.Lerp(transform.position, MovePos.transform.position, .2f);

            if (Vector3.Distance(transform.position, MovePos.transform.position) < .10)
            {
                Relocated = false;
                PlugIn = true;
            }


        }

        if (PlugIn)
        {

            transform.position = Vector3.Lerp(transform.position, _CirclesPlug.transform.position, .2f);

            if (Vector3.Distance(transform.position, _CirclesPlug.transform.position) < .10)
            {

                transform.position = _CirclesPlug.transform.position;
                
                PlugIn = false;


                _CirclesStand = CirclesStand;

                if(CirclesStand.GetComponent<Stand>()._Circles.Count>1)
                {
                    _CirclesStand.GetComponent<Stand>()._Circles[^2].GetComponent<Circle>().CanItMove = false;
                }


                _GameManager.HasMoved = false;

            }


        }


    }
}
