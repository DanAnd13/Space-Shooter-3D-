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
            StartCoroutine(StartPowerUp());  // Викликаємо корутину з об'єктом стрільби
        }
    }

    private void GetPowerUp()
    {
        _baseShootInterval = _gun.ShootInterval;  // Зберігаємо базовий інтервал
        _gun.ShootInterval = _shootInterval;      // Встановлюємо новий інтервал
    }

    private void EndPowerUp()
    {
        _gun.ShootInterval = _baseShootInterval;  // Повертаємо базовий інтервал
    }

    private IEnumerator StartPowerUp()
    {
        GetPowerUp();                         // Активуємо бонус
        yield return new WaitForSeconds(_powerUpTime);  // Чекаємо часу дії бонуса
        EndPowerUp();                         // Повертаємо інтервал назад
    }
}
