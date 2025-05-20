using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] GameObject moneySystem;
    private MoneySystem m;
    private void Start()
    {
        m = moneySystem.GetComponent<MoneySystem>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Triangle")
        {
            m.AddMoney();
        }
    }
}
