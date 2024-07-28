using UnityEngine;
namespace Emptybraces
{
	public class ChangeFps : MonoBehaviour
	{
		[SerializeField] int fps = -1;
		void Update()
		{
			Application.targetFrameRate = fps;
		}
	}
}
