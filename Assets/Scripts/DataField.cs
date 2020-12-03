using UnityEngine;

public class DataField : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject spherePrefab;

    [SerializeField]
    private bool TwoDimensions;
    [SerializeField]
    private bool ThreeDimensions;
    // Start is called before the first frame update
    void Start()
    {

        if (TwoDimensions)
        {
            for ( int x = 0; x < 100; x++)
            {
                for (int z = 0; z < 100; z++)
                {
                    var dataObject = GameObject.Instantiate(cubePrefab, new Vector3(x, 0, z), Quaternion.identity);
                    dataObject.transform.parent = transform;
                }
            }
        }
        else if (ThreeDimensions)
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    for (int z = 0; z < 10; z++)
                    {
                        var dataObject = GameObject.Instantiate(spherePrefab, new Vector3(x * 2, Random.Range(0,100), z * 2), Quaternion.identity);
                        dataObject.transform.parent = transform;
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
