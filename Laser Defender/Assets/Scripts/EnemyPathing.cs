using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{

    [SerializeField] List<Transform> waypoints = default;
    [SerializeField] float moveSpeed = default;

    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
            transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
   
        if (waypointIndex < waypoints.Count)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if ((transform.position.x == targetPosition.x) && (transform.position.y == targetPosition.y))
            {
                waypointIndex++;
            }

            else
            {
                Destroy(gameObject);
            }
        }
    }
}
