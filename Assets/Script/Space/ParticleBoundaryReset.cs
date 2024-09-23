using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBoundaryReset : MonoBehaviour
{
    public List<GameObject> Particles; // Список систем частинок
    public Transform PlayerShip; // Трансформ корабля

    private Vector3 _basePosition; // Початкова позиція корабля
    private int _currentIndex; // Поточний індекс активної системи частинок

    private void Start()
    {
        _basePosition = PlayerShip.position; // Зберігаємо початкову позицію
        _currentIndex = 0; // Починаємо з першої системи частинок
    }

    private void Update()
    {
        CheckPosition(); // Перевіряємо позицію корабля
    }

    private void CheckPosition()
    {
        // Перевірка на рух по осі X
        if (PlayerShip.position.x > _basePosition.x)
        {
            ActivateNextParticleSystem(new Vector3(500, 0, 0));
        }
        else if (PlayerShip.position.x < _basePosition.x)
        {
            ActivateNextParticleSystem(new Vector3(-500, 0, 0));
        }

        // Перевірка на рух по осі Y
        if (PlayerShip.position.y > _basePosition.y)
        {
            ActivateNextParticleSystem(new Vector3(0, 500, 0));
        }
        else if (PlayerShip.position.y < _basePosition.y)
        {
            ActivateNextParticleSystem(new Vector3(0, -500, 0));
        }
    }

    private void ActivateNextParticleSystem(Vector3 offset)
    {
        // Обчислюємо наступний індекс
        int nextIndex = (_currentIndex + 1) % Particles.Count;

        // Встановлюємо позицію нової системи частинок
        Particles[nextIndex].transform.position = Particles[_currentIndex].transform.position + offset;
        Particles[nextIndex].gameObject.SetActive(true);

        // Оновлюємо базову позицію
        _basePosition = Particles[nextIndex].transform.position;

        // Оновлюємо поточний індекс
        _currentIndex = nextIndex;
    }
}
