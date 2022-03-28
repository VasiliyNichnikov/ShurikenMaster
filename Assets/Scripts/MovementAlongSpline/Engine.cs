using System.Collections;
using Spline;
using UnityEngine;

namespace MovementAlongSpline
{
    public class Engine : MonoBehaviour, IEngine
    {
        public ISpline Spline => _spline;
        public Transform SelectedObject => _selectedObject;

        [SerializeField, Header("Отключение двигателя")]
        private bool _disableEngine;
        [SerializeField, Header("Расстояние между точками при движение"), Range(0, 1)] private float _spacing;
        [SerializeField] private Spline.Spline _spline;
        [SerializeField] private Transform _selectedObject;

        private IRoute _route;
        private IMovement _movement;
        private IEnumerator _currentDrive;
        
        private void Start()
        {
            CreateRoute();
            _movement = new Movement(_selectedObject, _route.Points);
        }

        private void CreateRoute()
        {
            _route = new Route(_spline);
            _route.Spacing = _spacing;
            _route.Build();
        }

        public void ToRun()
        {
            if(_disableEngine)
                return;

            if (_currentDrive == null)
            {
                _currentDrive = _movement.Drive();
                StartCoroutine(_currentDrive);
            }
            else
                _movement.Pause = false;
        }

        public void ToRun(float speedMovement, float speedRotation)
        {
            _movement.SpeedMovement = speedMovement;
            _movement.SpeedRotation = speedRotation;
            ToRun();
        }

        public void Stop()
        {
            _movement.Pause = true;
        }
        
    }
}