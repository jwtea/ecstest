using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class MoverSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation translation, ref MoveSpeedComponent moveSpeedComponent) =>
        {
            translation.Value.y += moveSpeedComponent.moveSpeed * UnityEngine.Time.deltaTime;

            if (translation.Value.y > 5f)
            {
                moveSpeedComponent.moveSpeed = -math.abs(moveSpeedComponent.moveSpeed);
            }

            if (translation.Value.y < -5f)
            {
                moveSpeedComponent.moveSpeed = +math.abs(moveSpeedComponent.moveSpeed);
            }
        });
    }
}