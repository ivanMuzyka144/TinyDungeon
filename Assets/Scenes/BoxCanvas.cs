using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BoxCanvas : MonoBehaviour, ISelectable
{
    public Button button;
    public Toggle toggle;

    bool enableForEdit = true;

    public GameObject GetObject()
    {
        return gameObject;
    }

    public void InvokeUIElement()
    {
        if(button!=null)
            button.onClick.Invoke();
        if (toggle != null)
        {
            Debug.Log("ffff");
            if (toggle.isOn)
            {
                if (enableForEdit)
                {
                    toggle.isOn = false;
                    StartCoroutine(BlockingCoroutine());
                }
            }
            else
            {
                if (enableForEdit)
                {
                    toggle.isOn = true;
                    StartCoroutine(BlockingCoroutine());
                }

            }
        }
            
    }

    IEnumerator BlockingCoroutine()
    {

        enableForEdit = false;
        yield return new WaitForSeconds(0.5f);
        enableForEdit = true;
    }

    public bool IsSelected()
    {
        return true;
    }

    public void MakeSelectionAction()
    {
        
    }

    public void OnDeselected()
    {
        
    }

    public void OnSelected()
    {
       
    }

    public void OnStillSelected()
    {
        
    }
}
