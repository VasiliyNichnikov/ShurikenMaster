using UnityEditor;
using UnityEngine;

namespace MovementAlongSpline.Editor
{
    [CustomEditor(typeof(Engine))]
    public class EngineEditor : UnityEditor.Editor
    {
        private Engine _engine;
        private float _progress;
        private bool _isRoute;
        
        private void OnEnable()
        {
            _engine = (Engine) target;
        }
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
# if UNITY_EDITOR
            if (Application.isPlaying == false)
            {
                EnablingRealTimeRoute();
            }
# endif
        }

        private void EnablingRealTimeRoute()
        {
            _isRoute = EditorGUILayout.ToggleLeft("Включить построение маршрута в Editor", _isRoute);

            if (_isRoute)
            {
                _progress = EditorGUILayout.Slider(nameof(_progress), _progress, 0, 1);
                Vector3 position = _engine.Spline.GetPoint(_progress);
                _engine.SelectedObject.position = position;
                _engine.SelectedObject.LookAt(position + _engine.Spline.GetDirection(_progress));
            }
            else
            {
                ButtonMoveToFirstPoint();
            }
        }
        
        private void ButtonMoveToFirstPoint()
        {
            if (GUILayout.Button("Переместить выбранный объект к первой точке линии"))
            {
                if (_engine.Spline != null && _engine.SelectedObject != null)
                {
                    Undo.RecordObject(_engine, "Update position selected object");
                    _engine.SelectedObject.position = _engine.Spline[0];
                    EditorUtility.SetDirty(_engine);
                }
            }
        }
    }
}