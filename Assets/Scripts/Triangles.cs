using UnityEngine;

public class Triangles : MonoBehaviour
{

    [SerializeField] float speed;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    private void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed);
        DestroyThis();
    }

    private void DestroyThis()
    {
        if (transform.position.x >= 13)
        {
            Destroy(gameObject);
        }
    }
}
