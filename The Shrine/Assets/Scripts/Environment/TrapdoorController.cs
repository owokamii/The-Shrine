using UnityEngine;

public class TrapdoorController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public BoxCollider2D boxCollider;
    public bool isOpen;
    //public Animator animator;

    public void OpenTrapdoor()
    {
        if(!isOpen)
        {
            isOpen = true;
            Debug.Log("Trapdoor is now open ...");
            spriteRenderer.sprite = newSprite;
            boxCollider.enabled = false;
        }    
    }
}
