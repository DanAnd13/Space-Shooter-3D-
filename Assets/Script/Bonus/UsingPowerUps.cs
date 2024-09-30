using System.Collections;
using UnityEngine;

public class UsingPowerUps : MonoBehaviour
{
    private TypeOfBonus _typeOfBonus;
    private Shooting _gun;
    private float _powerUpTime = 3f;
    private float _baseShootInterval;
    private float _shootInterval = 0.05f;

    private void Awake()
    {
        _gun = GetComponent<Shooting>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _typeOfBonus = other.GetComponent<TypeOfBonus>();
        if (_typeOfBonus != null)
        {
            StartCoroutine(StartPowerUp());
        }
    }

    private void GetPowerUp()
    {
        _baseShootInterval = _gun.ShootInterval;  
        _gun.ShootInterval = _shootInterval;      
    }

    private void EndPowerUp()
    {
        _gun.ShootInterval = _baseShootInterval;
    }

    private IEnumerator StartPowerUp()
    {
        GetPowerUp();         
        yield return new WaitForSeconds(_powerUpTime);
        EndPowerUp();
    }
}
