using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Splines;
namespace Emptybraces
{
	public class Sample : MonoBehaviour
	{
		SplineContainer _container;
		SplineAnimate _splineAnimate;
		MeshFilter _mesh;
		Transform _pinParent;
		void Awake()
		{
			_container = GetComponentInChildren<SplineContainer>();
			_splineAnimate = GetComponentInChildren<SplineAnimate>();
			_mesh = _splineAnimate.GetComponentInChildren<MeshFilter>();
			GetComponentInChildren<TextMesh>().text = (1 < _container.Splines.Count ? "multi, " : "single, ") + _splineAnimate.Loop.ToString();
			var pin_prefab = transform.GetChild(transform.childCount - 1).GetChild(0);
			_pinParent = pin_prefab.parent;
			GetComponentInChildren<SplineAnimateOnReached>().OnReachedKnot.AddListener(OnReachedKnot);
			for (int i = 0, cnt = 1; i < _container.Splines.Count; ++i)
			{
				for (int j = 0; j < _container.Splines[i].Knots.Count(); ++j, ++cnt)
				{
					var pin = Instantiate(pin_prefab, pin_prefab.parent);
					pin.name += cnt.ToString();
					pin.position = _container.transform.TransformPoint(_container.Splines[i].Knots.ElementAt(j).Position);
				}
			}
			Destroy(pin_prefab.gameObject);
		}
		void Update()
		{
			if (Time.frameCount % 5 == 0)
			{
				var color = Color.HSVToRGB(Time.time * 2 % 1, 1f, .3f);
				color.a = 0.5f;
				GizmoHelper.DrawMesh(_mesh.sharedMesh, 0, _mesh.transform.position, _mesh.transform.rotation, _mesh.transform.lossyScale, color, .2f);
			}
			if (Input.GetKey(KeyCode.Space))
			{
				_splineAnimate.Restart(true);
				_splineAnimate.GetComponent<SplineAnimateOnReached>().Reset();
				GizmoHelper.RemoveAllGizmos();
			}
		}

		public void OnReachedKnot(SplineContainer container, BezierKnot knot, int knotIdx)
		{
			// Debug.Log($"OnReachedKnot: {knotIdx}");
			// StartCoroutine(_Animate(_pinParent.GetChild(knotIdx), knotIdx));
			GizmoHelper.DrawSphere(container.transform.TransformPoint(knot.Position), 1, Color.red, .5f);
		}

		IEnumerator _Animate(Transform pin, int idx)
		{
			GizmoHelper.DrawSphere(pin.position, 1, Color.red, .5f);
			// var st = Time.time;
			// var et = Time.time + .3f;
			// var p = pin.position;
			// while (Time.time <= et)
			// {
			// 	var t = Mathf.InverseLerp(st, et, Time.time);
			// 	t = Mathf.Sin(t * Mathf.PI);
			// 	// t = Mathf.PingPong(t * 2, 1);
			// 	pin.position = Vector3.Lerp(p, p + Vector3.up * 3, t);
			// 	yield return null;
			// }
			// pin.position = p;
			yield break;
		}
	}
}
