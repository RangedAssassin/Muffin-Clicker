using UnityEngine;
using UnityEngine.UI; // Required for accessing the Image component
using System.Collections.Generic;

public class SweetsRain : MonoBehaviour
{
    [SerializeField] private GameObject _fallingSweetsPrefab; // Prefab with Image component
    [SerializeField] private Sprite[] sweetSprites; // Array of sprites to assign
    [SerializeField] private float maxX = -10f;
    [SerializeField] private float minX = 870;
    [SerializeField] private float yPosition = 520;
    [SerializeField] private float spawnInterval = 0.5f;
    [SerializeField] private float fallSpeed = 100f;
    [SerializeField] private Transform parentTransform; // Reference to the parent GameObject

    private float timer;
    private List<GameObject> clones = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f; // Initialize timer
    }

    // Update is called once per frame
    void Update()
    {
        CreateRandomSpriteAtRandomX();

        MakeRainFall();
    }
    private void CreateRandomSpriteAtRandomX()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            // Generate a random x position within the specified range
            float randomX = Random.Range(minX, maxX);
            Vector2 localPosition2D = new Vector2(randomX, yPosition);

            // Convert Vector2 to Vector3 for instantiation
            Vector3 spawnPosition = new Vector3(localPosition2D.x, localPosition2D.y, 0f);
            GameObject clone = Instantiate(_fallingSweetsPrefab, spawnPosition, Quaternion.identity, parentTransform);

            // Randomize the sprite of the clone if it's an Image component
            Image imageComponent = clone.GetComponent<Image>();
            if (imageComponent != null && sweetSprites.Length > 0)
            {
                int randomIndex = Random.Range(0, sweetSprites.Length);
                imageComponent.sprite = sweetSprites[randomIndex];
            }

            clones.Add(clone);

            timer = 0f;
        }
    }

    private void MakeRainFall()
    {
        // Move clones using Vector2 for calculations
        for (int i = clones.Count - 1; i >= 0; i--)
        {
            GameObject clone = clones[i];
            if (clone != null)
            {
                // Convert the current position to Vector2
                Vector2 position2D = new Vector2(clone.transform.position.x, clone.transform.position.y);

                // Update the y position based on fallSpeed
                position2D.y -= fallSpeed * Time.deltaTime;

                // Convert Vector2 back to Vector3 and apply the new position
                clone.transform.position = new Vector3(position2D.x, position2D.y, clone.transform.position.z);

                // Optional: Destroy clone if it falls below a certain y position
                if (position2D.y < -30f) // Adjust this value as needed
                {
                    Destroy(clone);
                    clones.RemoveAt(i); // Remove the clone from the list
                }
            }
        }
    }


}
