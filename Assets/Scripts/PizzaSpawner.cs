using UnityEngine;
using System.Collections.Generic;

public class PizzaSpawner : MonoBehaviour
{
    [Header("Références")]
    [SerializeField] private GameObject pizzaUIPrefab; 
    [SerializeField] private RectTransform[] spawnPoints; 
    [SerializeField] private Transform canvasTransform;

    [Header("Paramètres")]
    [SerializeField] private float spawnInterval = 3f;

    private GameObject[] currentPizzas;

    private void Start()
    {
        currentPizzas = new GameObject[spawnPoints.Length];

        InvokeRepeating("TrySpawnPizza", 1f, spawnInterval);
    }

    void TrySpawnPizza()
    {
        List<int> availableIndices = new List<int>();

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (currentPizzas[i] == null)
            {
                availableIndices.Add(i);
            }
        }

        if (availableIndices.Count == 0)
        {
            return;
        }

        int randomIndex = availableIndices[Random.Range(0, availableIndices.Count)];

        GameObject newPizza = Instantiate(pizzaUIPrefab, canvasTransform);

        RectTransform pizzaRect = newPizza.GetComponent<RectTransform>();
        pizzaRect.anchoredPosition = spawnPoints[randomIndex].anchoredPosition;

        currentPizzas[randomIndex] = newPizza;
    }
}