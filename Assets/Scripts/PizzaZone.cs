using UnityEngine;

public class PizzaZone : MonoBehaviour
{
    public Sprite pizza;
    public SpriteRenderer pizzaRenderer;
    public SpriteRenderer SpriteRenderer;
    public GameObject pizzaPrefab;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        
            Debug.Log("Pizza!");
            other.transform.SetParent(transform);
            if (other.GetComponent("Grabtools"))
            {
                Debug.Log("changer");
                pizzaRenderer.sprite = pizza;
            }
        
    }
}
