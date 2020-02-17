using UnityEngine;

namespace Library.Data
{
    public class SpawnPattern : MonoBehaviour
    {
        [SerializeField] private Transform endPoint;
        [SerializeField] private int patternNumber;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            SelectRoom();
            SpawnNextPatternManager.Instance.SpawnNextRoom(endPoint,patternNumber);
        }

        private void SelectRoom()
        {
            var level = SpawnNextPatternManager.Instance.levelNumber;
            if (SpawnNextPatternManager.Instance.levelNumber > 100) level = (SpawnNextPatternManager.Instance.levelNumber - 100);
            switch (level)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 10:
                    patternNumber = 0;
                    break;
                case 2:
                case 6:
                case 9:
                    patternNumber = 1;
                    break;
                case 4:
                case 8:
                    patternNumber = 2;
                    break;
                case 11:
                    patternNumber = 3;
                    break;
                case 12:
                case 22:
                case 32:
                case 42:
                case 52:
                case 62:
                case 72:
                case 82:
                case 92:
                    patternNumber = 4;
                    break;
                case 13:
                case 16:
                case 19:
                case 23:
                case 26:
                case 29:
                case 33:
                case 36:
                case 39:
                case 43:
                case 46:
                case 49:
                case 53:
                case 56:
                case 59:
                case 63:
                case 66:
                case 69:
                case 73:
                case 76:
                case 79:
                case 83:
                case 86:
                case 89:
                case 93:
                case 96:
                case 99:
                    patternNumber = 5;
                    break;
                case 14:
                case 18:
                case 24:
                case 28:
                case 34:
                case 38:
                case 44:
                case 48:
                case 54:
                case 58:
                case 64:
                case 68:
                case 74:
                case 78:
                case 84:
                case 88:
                case 94:
                case 98:
                    patternNumber = 6;
                    break;
                case 15:
                case 17:
                case 25:
                case 27:
                case 35:
                case 37:
                case 45:
                case 47:
                case 55:
                case 57:
                case 65:
                case 67:
                case 75:
                case 77:
                case 85:
                case 87:
                case 95:
                case 97:
                    patternNumber = 7;
                    break;
                case 20:
                case 30:
                case 40:
                case 60:
                case 70:
                case 80:
                case 90:
                    patternNumber = 8;
                    break;
                case 21:
                case 31:
                case 41:
                case 51:
                case 61:
                case 71:
                case 81:
                case 91:
                    patternNumber = 9;
                    break;
                case 50:
                case 100:
                    patternNumber = 10;
                    break;
                default:
                    break;
            }
        }
    }
}