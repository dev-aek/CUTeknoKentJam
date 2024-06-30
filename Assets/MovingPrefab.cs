using UnityEngine;

public class MovingPrefab : MonoBehaviour
{
    public Transform target; 
    public float speed = 5f; 




    private void Update()
    {

        if (target != null)
        {

            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);


            Vector3 direction = (target.position - transform.position).normalized;
            if (direction != Vector3.zero)
            {
                transform.forward = direction;
            }

            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                gameObject.SetActive(false);
            }
        }


    }
}
