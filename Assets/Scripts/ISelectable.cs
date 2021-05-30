
using UnityEngine;

public interface ISelectable 
{
   void OnSelected();
   void OnDeselected();
   void OnStillSelected();
   bool IsSelected();
   void MakeSelectionAction();
   GameObject GetObject();
}
