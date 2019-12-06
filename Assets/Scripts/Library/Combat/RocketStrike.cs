using System.Collections;
using System.Collections.Generic;
using Library.Combat.Enemy;
using Library.Data;
using Library.UI;
using UnityEngine;

namespace Library.Combat
{
    public class RocketStrike : MonoBehaviour {
        private const float MISSILE_LAUNCHER_OPEN_TIME = 0.75f;
        private static bool firingRockets;
    
        
        [SerializeField]
        private float acceleration;

        
        [SerializeField]
        private float distanceShot;

        
        [SerializeField]
        private float maxSpeed;

       
        [SerializeField]
        private Vector3 boxHalfExtents;

        [SerializeField]
        private LayerMask damageToLayers;

        [SerializeField] private int explosionDamage;
    
        [SerializeField]
        private float timeBetweenMissiles = 0.1f;
        
        [SerializeField]
        private float coolDownTime = 3f;
    
        [SerializeField]
        private Transform playerTransform;
    
        [SerializeField]
        private Transform[] rocketSlotsLeft;
    
        [SerializeField]
        private Transform[] rocketSlotsRight;

        [SerializeField]
        private GameObject rocketPrefab;
    
        [SerializeField]
        private GameObject explosionPrefab;
        
        public float currentDooldown;
        private bool lastButtonOneState;
        public List<EnemyHealth> rocketStrikeTargets = new List<EnemyHealth>();
        [SerializeField] private int maxMissileTargets = 16;

        public GunMovement aim;

        private void Start() {
            currentDooldown = coolDownTime;
        }

        private void Update() {
            foreach (var x in rocketStrikeTargets)
            {
                if(x != null) continue;
            }
            if(!firingRockets && currentDooldown < coolDownTime) {
                currentDooldown += Time.deltaTime;
            }

            if (currentDooldown < coolDownTime) return;
            RocketStrikeUI.ResetRocketIndicator();
            var mouseButtonDown = Input.GetMouseButton(1);
            aim = FindObjectOfType<GunMovement>();

            if (mouseButtonDown == lastButtonOneState) return;
            if (!mouseButtonDown) {
                aim.EnemyInVisor.RemoveListener(RocketStrikeTargetAdd);
                TriggerRocketStrike();
            } else {
                aim.EnemyInVisor.AddListener(RocketStrikeTargetAdd);
            }
            
            lastButtonOneState = mouseButtonDown;
        }

        private void TriggerRocketStrike() {
            if (rocketSlotsRight.Length != rocketSlotsLeft.Length || rocketStrikeTargets.Count == 0) return;
            
            currentDooldown = 0;
            var height = distanceShot/4f;
            var aimPoints = new Transform[rocketStrikeTargets.Count];
            //var endPoints = new Vector3[rocketStrikeTargets.Count];
            for (var i = 0; i < rocketStrikeTargets.Count; i++)
            {
                aimPoints[i] =rocketStrikeTargets[i] == null ? FindObjectOfType<EnemyHealth>().transform : rocketStrikeTargets[i].transform;
//            endPoints[i] = Physics.Raycast(new Ray(aimPoints[i] + (Vector3.up * height), Vector3.down), out var hit, 500f, LayerMask.GetMask("Ground")) ? hit.point : aimPoints[i];
            }

            var slotArray = rocketSlotsLeft;

            firingRockets = true;
        
            for (var rocketIndex = 0; rocketIndex < rocketSlotsLeft.Length * 2; rocketIndex++) {
                var rocketSlot = slotArray[rocketIndex / 2];
                slotArray = slotArray == rocketSlotsLeft ? rocketSlotsRight : rocketSlotsLeft;
                FireMissile(rocketSlot, aimPoints[rocketIndex % aimPoints.Length], height, MISSILE_LAUNCHER_OPEN_TIME + rocketIndex * timeBetweenMissiles, rocketIndex == rocketSlotsLeft.Length * 2 - 1);
            }

            rocketStrikeTargets.Clear();
            RocketStrikeUI.ResetTargets();
        }

        private void RocketStrikeTargetAdd(EnemyHealth enemy) {
            if (rocketStrikeTargets.Count < maxMissileTargets && !rocketStrikeTargets.Contains(enemy)) {
                RocketStrikeUI.AddRocketTarget(enemy);
                rocketStrikeTargets.Add(enemy);
            }
        }

        private void FireMissile(Transform startPoint, Transform aimPoint, float height, float delay, bool lastMissile) {
            var rocket = Instantiate(rocketPrefab);
            var rocketTransform = rocket.GetComponent<Transform>();
            Debug.Log("Fired Missile");
        
            if (rocketTransform == null) return;

            var position = aimPoint.position;
            var endPoint = Physics.Raycast(new Ray(position + Vector3.up * height, Vector3.down), out var hit, 500f, LayerMask.GetMask("Ground")) ? hit.point : position;
            StartCoroutine(MissileHandle(rocketTransform, startPoint, aimPoint, height, delay, lastMissile));
        }

        private IEnumerator MissileHandle(Transform rocketTransform, Transform startPoint, Transform endPoint, float height, float delay, bool lastMissile = false) {
            yield return new WaitForSeconds(delay);

            float progress;
            var bygoneTime = 0f;
            var target = endPoint.position;
            
            RocketStrikeUI.ReduceRocketIndicator();

            do {
                bygoneTime += Time.deltaTime;
                progress = acceleration * bygoneTime * Mathf.Min(bygoneTime, maxSpeed);

                var position = startPoint.position;
                target = endPoint == null ? target : endPoint.position;
                rocketTransform.position = MathParabola.Parabola(position, target, height, progress);
                rocketTransform.LookAt(MathParabola.Parabola(position, target, height, Mathf.Clamp01(progress + 0.05f)));
                yield return new WaitForEndOfFrame();
            } while (progress < 1f);

            if (explosionPrefab != null) {
                Destroy(Instantiate(explosionPrefab, rocketTransform.position, rocketTransform.rotation), 2f);
               // ScreenShakeManager.Instance.Shake(4,0.1f);
            }

            Destroy(rocketTransform.gameObject);

            var enemies = Physics.OverlapBox(target, boxHalfExtents, Quaternion.LookRotation(target - startPoint.position), damageToLayers);
            foreach (var enemy in enemies) {
                var e = enemy.GetComponent<EnemyHealth>();
                if (e == null) continue;
                e.curHealth -= explosionDamage;
            }

            if (lastMissile) firingRockets = false;
        }
    }
}
