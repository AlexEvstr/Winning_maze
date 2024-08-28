using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneJoystickController : MonoBehaviour
{
    [SerializeField] private FixedJoystick _fixedJoystick;
    [SerializeField] private Transform _plane;
    private float speed = 0.5f;

    public void Update()
    {
        Vector3 direction = new Vector3(_fixedJoystick.Horizontal, _fixedJoystick.Vertical, 0);

        direction = direction.normalized;

        _plane.position += direction * speed * Time.deltaTime;

        if (direction != Vector3.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

            _plane.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}
