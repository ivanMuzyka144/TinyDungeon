using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMaker : MonoBehaviour
{
    [SerializeField] private DominoSelector dominoSelector;
    [Space(10)]
    [SerializeField] private float dragVelocity;

    private bool canDrag;
    private bool isDragged;

    public void Enable() => canDrag = true;

    private void Update()
    {
        if (canDrag)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)
                && dominoSelector.IsSelected()
                && !dominoSelector.IsBlocked()
                && isDragged == false)
            {
                isDragged = true;
                dominoSelector.Block();
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0) && isDragged == true)
            {
                dominoSelector.MakeReturnAction();
                isDragged = false;
            }

            if (isDragged)
            {
                OnDrag();
            }
        }
    }

    private void OnDrag()
    {
        float dz = Camera.main.transform.InverseTransformPoint(transform.position).z;

        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dz);
        Vector3 point = Camera.main.ScreenToWorldPoint(mousePosition);
        point.z = gameObject.transform.position.z;

        gameObject.transform.position = point;
        //gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,
                                         //                   point, dragVelocity * Time.deltaTime);
    }


    //    [SerializeField] private DominoSelector dominoSelector;
    //    [Space(10)]
    //    [SerializeField] private float dragVelocity;

    //    private bool canDrag;
    //    private bool isDragged;

    //    public void SetDrag(bool canDrag) => this.canDrag = canDrag;

    //    private void Update()
    //    {
    //        if (canDrag)
    //        {
    //            if (Input.GetKeyDown(KeyCode.Mouse0) 
    //                && dominoSelector.IsActive()
    //                && dominoSelector.IsSelected()
    //                && isDragged == false)
    //            {
    //                isDragged = true;
    //            }
    //            else if (Input.GetKeyUp(KeyCode.Mouse0) && isDragged == true)
    //            {
    //                isDragged = false;
    //                dominoSelector.Activate();
    //            }

    //            if (isDragged)
    //            {
    //                OnDrag();
    //            }
    //        }
    //    }

    //    private void OnDrag()
    //    {
    //        dominoSelector.Disable();
    //        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
    //        Vector3 point = Camera.main.ScreenToWorldPoint(mousePosition);
    //        point.z = gameObject.transform.position.z;

    //        //gameObject.transform.position = point;
    //        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,
    //                                                            point, dragVelocity * Time.deltaTime);
    //    }
    //}
}