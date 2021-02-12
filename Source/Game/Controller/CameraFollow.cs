using FlaxEngine;

namespace Game
{
    public class CameraFollow : Script
    {
        public Actor Target;
        public float Speed;
        private Vector3 _offset;

        public override void OnStart()
        {
            _offset = Actor.Position - Target.Position;
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
            Actor.Position = Vector3.SmoothStep(Actor.Position, Target.Position + _offset, Speed);
        }
    }
}
