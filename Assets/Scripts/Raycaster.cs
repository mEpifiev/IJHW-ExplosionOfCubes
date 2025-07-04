using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    [SerializeField] private float _maxDistance; 

    public event Action<Cube> Hited;

    private void OnEnable()
    {
        _inputReader.LeftMouseClicked += HandleInput;
    }

    private void OnDisable()
    {
        _inputReader.LeftMouseClicked -= HandleInput;
    }

    private void HandleInput()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, _maxDistance))
            if(hit.collider.TryGetComponent(out Cube cube))
                    Hited?.Invoke(cube);
    }
}
