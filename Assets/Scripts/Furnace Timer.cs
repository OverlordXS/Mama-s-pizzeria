using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FurnaceTimer : MonoBehaviour, IPointerClickHandler
{
    private int cookingTime = 0;
    private float timer = 0f;

    public bool isCooked;
    public bool isVeryCooked;
    public bool isBurned;
    public bool stopCooking;

    [SerializeField] private Image uiImage;

    public Sprite raw;
    public Sprite cooked;
    public Sprite overCooked;
    public Sprite burned;
    private Animator animator;
    public string triggerShrinkName;
    public string triggerGrowName;

    private void Awake()
    {
            uiImage = GetComponent<Image>();
            animator = GetComponent<Animator>();
    }

    private void Start()
    {
            uiImage.sprite = raw;
    }

    void Update()
    {
        if (isBurned) return;
        if (stopCooking) return;

        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            timer -= 1f;
            cookingTime++;

            if (cookingTime == 10)
            {
                Cook();
            }
            else if (cookingTime == 20)
            {
                VeryCooked();
            }
            else if (cookingTime == 30)
            {
                Burned();
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("La pizza a été cliquée !");
        stopCooking = true;
        animator.SetTrigger(triggerShrinkName);
    }

    void Cook()
    {
        isCooked = true;
            uiImage.sprite = cooked;
    }

    void VeryCooked()
    {
        isCooked = false;
        isVeryCooked = true;
            uiImage.sprite = overCooked;
    }

    void Burned()
    {
        isCooked = false;
        isVeryCooked = false;
        isBurned = true;
            uiImage.sprite = burned;
    }
}