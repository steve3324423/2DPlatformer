using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] _positions;

    private Vector3 _firstPosition;
    private Vector3 _secondPosition;
    private Vector3 _target;
    private float _speed = 5f;

    private void Awake()
    {
        _firstPosition  = _positions[0].position;
        _secondPosition = _positions[1].position;
    }

    private void Update()
    {
        Moves();
    }

    private void Moves()
    {
        Vector2 offsetPositionOne = _firstPosition - transform.position;
        Vector2 offsetPositionTwo = _secondPosition - transform.position;
        float minDistance = .1f;

        if (offsetPositionOne.sqrMagnitude < minDistance * minDistance && offsetPositionTwo.sqrMagnitude > minDistance * minDistance)
            _target = _secondPosition;
        else if(offsetPositionTwo.sqrMagnitude < minDistance * minDistance && offsetPositionOne.sqrMagnitude > minDistance * minDistance)
            _target = _firstPosition;

        transform.position = Vector2.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }
}
