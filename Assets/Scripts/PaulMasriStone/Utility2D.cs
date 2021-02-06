using UnityEngine;

namespace PaulMasriStone.Utility2D
{
	public static class Utility2D
	{
		public static bool IsPointWithinCollider2D(Vector2 targetPoint, Vector2 externalPoint, int layerMask = Physics2D.DefaultRaycastLayers)
		{
			var direction = (targetPoint - externalPoint).normalized;
			var tinyNudge = direction * 0.001f; // avoids Linecast hitting the same point over and over

			RaycastHit2D hit;
			int hitCount = 0;

			var rayStart = externalPoint;
			while (rayStart != targetPoint) {
				hit = Physics2D.Linecast(rayStart, targetPoint, layerMask);
				if (hit)
				{
					hitCount++;
					rayStart = hit.point + tinyNudge;
				}
				else
					break;
			}

			return hitCount % 2 != 0;
		}
	}
}
