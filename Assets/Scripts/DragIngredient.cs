using UnityEngine;

public class DragIngredient : MonoBehaviour
{
  public bool isDragging;

  void OnMouseDown()
  { if (Input.GetMouseButtonDown(0) )
    {  isDragging = true;
     
    
     
                                   
    }
    
  }
  void OnMouseUp()
  {
     
    if (Input.GetMouseButtonUp(0))
    {
      isDragging = false;
    }
  }
  void Update()
  {
     
      
      
    if (isDragging)
    {
      Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      transform.position = mousePos;
        
    }
      
  }
}
