using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health = 3;
    [SerializeField] private float _speed = 3f;
    private bool isInit = false;

    public void Init(Vector3 basePos)
    {
        if (isInit)
            return;

        transform.LookAt(basePos);
        isInit = true;
    }

    void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.GetComponent<Bullet>())
        {
            _health -= 1;
            Destroy(obj.gameObject);

            if (_health <= 0)
                Destroy(gameObject);
        }
    }
}
