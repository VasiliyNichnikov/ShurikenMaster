using UnityEditor;
using UnityEngine;

namespace Spline.Editor
{
    [CustomEditor(typeof(Spline))]
    public class SplineEditor : UnityEditor.Editor
    {
        private static Color[] _modeColors =
        {
            Color.white,
            Color.yellow,
            Color.cyan
        };

        private Spline _spline;
        private Transform _handleTransform;
        private Quaternion _handleRotation;
        private int _selectedIndex;
        private const float _handleSize = 0.15f;

        private void OnEnable()
        {
            _spline = (Spline) target;
        }

        private void OnSceneGUI()
        {
            _handleTransform = _spline.transform;
            _handleRotation = Tools.pivotRotation == PivotRotation.Local
                ? _handleTransform.rotation
                : Quaternion.identity;

            ShowPoints();
        }

        public override void OnInspectorGUI()
        {
            _handleTransform = _spline.transform;
            _handleRotation = Tools.pivotRotation == PivotRotation.Local
                ? _handleTransform.rotation
                : Quaternion.identity;

            DrawPointInspector();
            _spline.IsActiveHandles = EditorGUILayout.ToggleLeft("Включить отображение опорных точек и лепестков",
                _spline.IsActiveHandles);
            SaveChanges("IsActiveHandles change");

            ButtonAddCurve();
            ButtonRemoveCurve();
        }

        private void DrawPointInspector()
        {
            if (_selectedIndex >= 0 && _selectedIndex < _spline.LengthPoints)
            {
                DrawSelectedPointInspector();
                GUILayout.Space(10);
            }
        }

        private void SaveChanges(string nameChange)
        {
            if (GUI.changed)
            {
                Undo.RecordObject(_spline, nameChange);
                EditorUtility.SetDirty(_spline);
            }
        }

        private void ButtonAddCurve()
        {
            if (GUILayout.Button("Добавить кривую в конец"))
            {
                Undo.RecordObject(_spline, "Add Curve");
                _spline.AddCurve();
                EditorUtility.SetDirty(_spline);
            }
        }

        private void ButtonRemoveCurve()
        {
            if (GUILayout.Button("Удалить кривую в конце"))
            {
                Undo.RecordObject(_spline, "Remove Curve");
                _selectedIndex = 0;
                _spline.RemoveCurve();
                EditorUtility.SetDirty(_spline);
            }
        }

        private void DrawSelectedPointInspector()
        {
            EditorGUILayout.BeginVertical("box");
            GUILayout.Label("Выбранная точка");
            EditorGUI.BeginChangeCheck();
            Vector3 point = EditorGUILayout.Vector3Field("Позиция", _spline[_selectedIndex]);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(_spline, "Move point");
                EditorUtility.SetDirty(_spline);
                _spline[_selectedIndex] = point;
            }

            EditorGUI.BeginChangeCheck();
            BezierControlPointMode mode =
                (BezierControlPointMode) EditorGUILayout.EnumPopup("Mode", _spline.GetControlPointMode(_selectedIndex));
            _spline.SetControlPointMode(_selectedIndex, mode);
            // if (EditorGUI.EndChangeCheck())
            // {
            //     Undo.RecordObject(_spline, "Change Point Mode");
            //     _spline.SetControlPointMode(_selectedIndex, mode);
            //     EditorUtility.SetDirty(_spline);
            // }

            EditorGUILayout.EndVertical();
        }

        private void ShowPoints()
        {
            Vector3 p0 = GetAndDrawPoint(0);
            for (int i = 1; i < _spline.LengthPoints; i += 3)
            {
                Vector3 p1 = GetAndDrawPoint(i);
                Vector3 p2 = GetAndDrawPoint(i + 1);
                Vector3 p3 = GetAndDrawPoint(i + 2);

                if (_spline.IsActiveHandles)
                {
                    Handles.color = Color.red;
                    Handles.DrawDottedLine(p0, p1, 4.0f);
                    Handles.DrawDottedLine(p2, p3, 4.0f);
                }

                Handles.DrawBezier(p0, p3, p1, p2, Color.cyan, null, 4f);
                p0 = p3;
            }
        }

        private Vector3 GetAndDrawPoint(int index)
        {
            Vector3 point = _spline[index];
            float size = HandleUtility.GetHandleSize(point);
            // SelectColorHandles(index);
            Handles.color = _modeColors[(int) _spline.GetControlPointMode(index)];
            if (_spline.IsActiveHandles &&
                Handles.Button(point, _handleRotation, size * _handleSize, size * _handleSize, Handles.DotHandleCap))
            {
                _selectedIndex = index;
                Repaint();
            }

            if (_spline.IsActiveHandles && _selectedIndex == index)
            {
                EditorGUI.BeginChangeCheck();
                point = Handles.DoPositionHandle(point, _handleRotation);

                if (EditorGUI.EndChangeCheck())
                {
                    Undo.RecordObject(_spline, "Move point");
                    EditorUtility.SetDirty(_spline);
                    _spline[index] = point;
                }
            }

            return point;
        }

        // private void SelectColorHandles(int index)
        // {
        //     Handles.color = Color.yellow;
        //     if (_selectedIndex == index)
        //         Handles.color = Color.white;
        //     else if (index == _spline.LengthPoints - 1)
        //         Handles.color = Color.blue;
        // }
    }
}