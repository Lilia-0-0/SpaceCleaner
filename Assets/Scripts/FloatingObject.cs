using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public int scoreValue = 1;        
    public bool isTrash = true;       
    private Vector3 targetPosition;   
    private float speed = 2f;

    void Start()
    {
        float x = Random.Range(-8f, 8f);
        float y = Random.Range(-4f, 4f);
        targetPosition = new Vector3(x, y, 0);

        transform.position = new Vector3(Random.Range(-9f, 9f), Random.Range(-5f, 5f), 0);
    }

    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            float x = Random.Range(-8f, 8f);
            float y = Random.Range(-4f, 4f);
            targetPosition = new Vector3(x, y, 0);
        }
    }


    void OnMouseDown()
    {

        GameManager gm = FindObjectOfType<GameManager>();
        if (gm != null)
        {
            gm.HandleClick(isTrash, scoreValue);
        }

        Destroy(gameObject);
    }
}