using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class StarfieldManager : MonoBehaviour
{
    [FormerlySerializedAs("pooledPrefab")] [SerializeField] GameObject starPrefab;
    [FormerlySerializedAs("size")] [SerializeField] private int NumberOfStars = 10;
    [FormerlySerializedAs("MinMaxPosX")] public Vector2 SpawnRangeX = new Vector2(0.5f, 1.5f);

    public float BottomYPosition = 0f;
    
    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        for (var i = 0; i < NumberOfStars; i++)
        {
            var obj = Instantiate(starPrefab, transform, true);
            obj.GetComponent<StarBehaviour>().Initialize(this);
            obj.transform.position = new Vector3(Random.Range(SpawnRangeX.x, SpawnRangeX.y), Random.Range(transform.position.y, BottomYPosition), 0f);
        }
    }
    
}
