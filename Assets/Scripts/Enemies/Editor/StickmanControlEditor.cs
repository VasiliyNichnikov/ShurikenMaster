using Enemies.Stickman;
using UnityEditor;
using UnityEngine;

namespace Enemies.Editor
{
    [CustomEditor(typeof(StickmanContol))]
    public class StickmanControlEditor : UnityEditor.Editor
    {
        private StickmanContol _control;
        private Transform _handleTransform;
        private Quaternion _handleRotation;
        private const float _handleSize = 0.1f;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            ResetPoint();
        }

        private void OnEnable()
        {
            _control = (StickmanContol) target;
        }

        private void OnSceneGUI()
        {
            _handleTransform = _control.transform;
            _handleRotation = Tools.pivotRotation == PivotRotation.Local
                ? _handleTransform.rotation
                : Quaternion.identity;
            DrawEndPoint();
        }

        private void ResetPoint()
        {
            if (GUILayout.Button("Сбросить EndPoint"))
            {
                Undo.RecordObject(_control, "Remove end point");
                _control.EndPoint = _handleTransform.position;
                EditorUtility.SetDirty(_control);
            }
        }
        
        private void DrawEndPoint()
        {
            Handles.color = Color.magenta;
            
            EditorGUI.BeginChangeCheck();
            _control.EndPoint = Handles.DoPositionHandle(_control.EndPoint, _handleRotation);
            Handles.DrawLine(_control.EndPoint, _handleTransform.position);

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(_control, "Move point");
                EditorUtility.SetDirty(_control);
            }
        }
    }
}