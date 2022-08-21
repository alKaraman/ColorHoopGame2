using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    GameObject SelectedObj;
    GameObject SelectedStand;
    Circle _Circle;
    public bool HasMoved;
    
    
    // B R B
    public int TargetStandNumber;
    int FullFilledStandNum;
    
    void Update()
    {
     
        if(Input.GetMouseButtonDown(0))
        {

            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit,100))
            {

                if(hit.collider!=null && hit.collider.CompareTag("Stand"))
                {

                    if(SelectedObj!=null && SelectedStand!=hit.collider.gameObject)
                    {

                        Stand _Stand = hit.collider.GetComponent<Stand>();
                        SelectedStand.GetComponent<Stand>().RelocateOfThePlugs(SelectedObj);

                        _Circle.Move("Relocate",hit.collider.gameObject,_Stand.AvailablePlug(),_Stand.MovePos);//


                        _Stand.EmptyPlug++;
                        _Stand._Circles.Add(SelectedObj);


                        SelectedObj = null;
                        SelectedStand = null;
                    }
                    else
                    {
                        Stand _Stand = hit.collider.GetComponent<Stand>();
                        SelectedObj = _Stand.TopEndCircle();
                        _Circle = SelectedObj.GetComponent<Circle>();
                        HasMoved = true;


                        if(_Circle.CanItMove)
                        {

                            _Circle.Move("Select", _Circle._CirclesStand, null, _Circle._CirclesStand.GetComponent<Stand>().MovePos);


                            SelectedStand = _Circle._CirclesStand;
                        }
                    }
                }



            }




        }




    }
}
