using Spline;
using UnityEngine;

namespace MovementAlongSpline
{
    public class Engine : MonoBehaviour
    {
        public ISpline Spline => _spline;
        public Transform SelectedObject => _selectedObject;
        
        [SerializeField, Range(1, 500)] private float _speedMovement;
        [SerializeField, Range(1, 100)] private float _speedRotation;
        [SerializeField, Range(0, 1)] private float _spacing;
        [SerializeField] private Spline.Spline _spline;
        [SerializeField] private Transform _selectedObject;

        private IRoute _route;
        private IMovement _movement;
        
        private void Start()
        {
            CreateRoute();
            CreateMovement();
            ToRun();
        }

        private void CreateRoute()
        {
            _route = new Route(_spline);
            _route.Spacing = _spacing;
            _route.Build();
        }

        private void CreateMovement()
        {
            _movement = new Movement(_selectedObject, _route.Points);
            _movement.SpeedMovement = _speedMovement;
            _movement.SpeedRotation = _speedRotation;
        }

        private void ToRun()
        {
            StartCoroutine(_movement.Drive());
        }
        
    }
}