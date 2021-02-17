using FlaxEngine;
using System;
using System.Threading.Tasks;

namespace Game
{
    public class PlayerController : Script
    {
        [Serialize] private Camera _camera;
        [Serialize, ShowInEditor] private Prefab _bulletPrefab;
        [Serialize, ShowInEditor] private Vector3 _bulletOffset = new Vector3(0, 75, 0);
        [Serialize, ShowInEditor] private float _bulletSpeed = 1000;
        private ObjectPool<BulletController> _bulletPool;
        public HpBar HpBar;
        public JsonAsset Defaults;
        public Player Player;
        public float Speed;

        public override void OnStart()
        {
            _camera = Camera.MainCamera;
            _bulletPool = new ObjectPool<BulletController>(SpawnBullet);
            Player = new Player((Defaults)Defaults.CreateInstance());
            HpBar.Init(Player.Hp);
        }

        private BulletController SpawnBullet()
        {
            var newActor = PrefabManager.SpawnPrefab(_bulletPrefab);
            var bullet = newActor.GetScript<BulletController>();
            return bullet;
        }

        public override void OnEnable()
        {
            // Here you can add code that needs to be called when script is enabled (eg. register for events)
        }

        public override void OnDisable()
        {
            // Here you can add code that needs to be called when script is disabled (eg. unregister from events)
        }

        public override void OnUpdate()
        {
            HandleFire();

            var cameraVector = new Vector3(_camera.Transform.Forward.X, 0, _camera.Transform.Forward.Z);

            var inputHorizontal = Input.GetAxis("Horizontal");
            var inputVertical = Input.GetAxis("Vertical");
            Vector3 inputVector = new Vector3(inputHorizontal, 0, inputVertical);
            var inputVectorDir = Vector3.Normalize(inputVector);

            var moveDir = Vector3.Normalize(_camera.Transform.TransformDirection(inputVectorDir) * new Vector3(1, 0, 1));

            Actor.Position += moveDir * Speed;
            TurnToMousePos();
        }

        private void HandleFire()
        {
            var fireInput = Input.GetAction("Fire");
            if(fireInput)
            {
                var bullet = _bulletPool.Rent();

                Action returnBullet = async () =>
                {
                    await Task.Delay(TimeSpan.FromSeconds(2));
                    _bulletPool.Return(bullet);
                };
                returnBullet();

                bullet.Actor.Position = Actor.Position + _bulletOffset;
                var rigidbody = bullet.Actor.As<RigidBody>();
                rigidbody.LinearVelocity = Actor.Direction * _bulletSpeed;
            }
        }

        private void TurnToMousePos()
        {
            var mousePos = Input.MousePosition;
            var ray = _camera.ConvertMouseToRay(mousePos);

            Plane plane = new Plane(Vector3.Zero, new Vector3(0, 1, 0));
            plane.Intersects(ref ray, out Vector3 point);

            var lookAtPoint = new Vector3(point.X, Actor.Position.Y, point.Z);
            Actor.LookAt(lookAtPoint);
        }

        public float AngleBetween(Vector3 vector1, Vector3 vector2)
        {
            float sin = vector1.X * vector2.Z - vector2.X * vector1.Z;
            float cos = vector1.X * vector2.X + vector1.Z * vector2.Z;

            return Mathf.Atan2(sin, cos) * (180 / Mathf.Pi);
        }
    }
}
