using UnityEngine;

namespace Library.Data
{
    public static class MathParabola {
        public static Vector3 Parabola(Vector3 start, Vector3 end, float height, float t) {
            var mid = Vector3.Lerp(start, end, t);
            return new Vector3(mid.x, f(t, height) + Mathf.Lerp(start.y, end.y, t), mid.z);
        }

        public static Vector2 Parabola(Vector2 start, Vector2 end, float height, float t) {
            var mid = Vector2.Lerp(start, end, t);
            return new Vector2(mid.x, f(t, height) + Mathf.Lerp(start.y, end.y, t));
        }

        private static float f(float x, float height) {
            return -4 * height * x * x + 4 * height * x;
        }
    }
}