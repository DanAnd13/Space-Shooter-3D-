using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform PlayerShip;

    private EnemyParam _parameters;
    private EnemyScriptableObjects _enemyScriptableObjects;
    private float _alignmentThreshold = 0.1f;

    private void Awake()
    {
        _parameters = GetComponentInChildren<EnemyParam>();
        _enemyScriptableObjects = _parameters.EnemyScriptableObjectByType;
    }

    private void FixedUpdate()
    {
        //Vector3 direction = PlayerShip.position - transform.position;
        /*Vector3 direction = new Vector3(0, 0, PlayerShip.position.z - transform.position.z);
        Vector3 velocity = direction.normalized * _enemyScriptableObjects.MovementSpeed * Time.deltaTime;
        transform.position = transform.position + velocity;*/
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = PlayerShip.position;

        // �������� �� ����������� �� X � Y � ��������� �������
        bool xAligned = Mathf.Abs(currentPosition.x - targetPosition.x) < _alignmentThreshold;
        bool yAligned = Mathf.Abs(currentPosition.y - targetPosition.y) < _alignmentThreshold;

        // ���� X ��� Y �� ����������, �������� �� ��� ����
        if (!xAligned || !yAligned)
        {
            Vector3 moveDirection = new Vector3(targetPosition.x - currentPosition.x, targetPosition.y - currentPosition.y, 0);
            Vector3 velocity = moveDirection.normalized * _enemyScriptableObjects.MovementSpeed * Time.deltaTime;

            // ��������� ������ �� X � Y
            transform.position = currentPosition + velocity;
        }
        // ���� X � Y �������, ������ ������ �� �� Z
        else
        {
            Vector3 zDirection = new Vector3(0, 0, targetPosition.z - currentPosition.z);
            Vector3 zVelocity = zDirection.normalized * _enemyScriptableObjects.MovementSpeed * Time.deltaTime;

            // ��������� ������ �� Z
            transform.position = currentPosition + zVelocity;
        }
    }
}
