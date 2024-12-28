using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _positionOne;
    [SerializeField] private Transform _positionTwo;

    private float _speed = 5f;
    private Vector3 _target;

    private void Update()
    {
        Moves();
    }

    private void Moves()
    {
        Vector2 offsetPositionOne = _positionOne.position - transform.position;
        Vector2 offsetPositionTwo = _positionTwo.position - transform.position;
        float minDistance = .1f;

        if (offsetPositionOne.sqrMagnitude < minDistance * minDistance && offsetPositionTwo.sqrMagnitude > minDistance * minDistance)
            _target = _positionTwo.position;
        else if(offsetPositionTwo.sqrMagnitude < minDistance * minDistance && offsetPositionOne.sqrMagnitude > minDistance * minDistance)
            _target = _positionOne.position;

        transform.position = Vector2.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }
}
