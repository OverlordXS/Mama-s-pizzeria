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
    [SerializeField] private RectTransform needleTransform;

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

    void FixedUpdate()
    {
        if (isBurned) return;
        if (stopCooking) return;

        timer += Time.deltaTime;

        if (needleTransform != null)
        {
            float totalProgress = (cookingTime + timer) / 30f;
            float currentAngle = -totalProgress * 360f;
            needleTransform.localRotation = Quaternion.Euler(0, 0, currentAngle);
        }

        if (timer >= 1f)
        {
            timer -= 1f;
            cookingTime++;

            if (cookingTime == 11)
            {
                Cook();
            }
            else if (cookingTime == 18)
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