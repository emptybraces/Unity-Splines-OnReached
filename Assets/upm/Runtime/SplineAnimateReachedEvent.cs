using UnityEngine;
// using UnityEngine.Events;
// using UnityEngine.Splines;
namespace Emptybraces.Splines
{
	public class SplineAnimateReachedEvent : MonoBehaviour
	{
		// public UnityEvent<SplineContainer, BezierKnot, int> OnReachedKnot;
		// SplineAnimate _anim;
		int _knotIdxCur, _knotIdxPrev;
		// SplinePath<Spline> _splinePath;
		bool _isPlaying;
		bool _isReverse;
		float _prevT;
		// Spline LastSpline => _anim.Container.Splines[^1];
		// bool IsPingPongReverse => _anim.Loop == SplineAnimate.LoopMode.PingPong && _isReverse;

		void Awake()
		{
			// _anim = GetComponent<SplineAnimate>();
		}

		void Update()
		{
			// if (!_InitSplitePathIfNeeded())
			// 	return;

			// if (!_isPlaying && !_anim.IsPlaying)
			// 	return;
			// _isPlaying = true;

			// var t = SplineUtility.ConvertIndexUnit(_splinePath, _anim.NormalizedTime, PathIndexUnit.Knot);
			// var prev_is_reverse = _isReverse;
			// _isReverse = t < _prevT;
			// _prevT = t;

			// int nt = (int)(t + .000001f); // 精度調整
			// if (IsPingPongReverse)
			// 	++nt;
			// if (_knotIdxCur != nt)
			// {
			// 	_knotIdxPrev = _knotIdxCur;
			// 	_knotIdxCur = nt;
			// 	var knot_idx = _knotIdxPrev + 1;
			// 	if (_anim.Loop == SplineAnimate.LoopMode.PingPong)
			// 	{
			// 		// 最後まで行って折り返す時を除き逆走しているとき
			// 		if (_isReverse && prev_is_reverse)
			// 			knot_idx = _knotIdxPrev - 1;
			// 		// 最初に戻って、折り返すとき
			// 		else if (!_isReverse && prev_is_reverse)
			// 			knot_idx = _knotIdxPrev - 1;
			// 	}
			// 	// Debug.Log($"[SplineAnimateOnReached] _knotIdxPrev:{_knotIdxPrev}, _knotIdxCur:{_knotIdxCur}, ntime:{_anim.NormalizedTime}");
			// 	while (true)
			// 	{
			// 		_Invoke(knot_idx);
			// 		if (_knotIdxCur == knot_idx)
			// 			break;
			// 		if (IsPingPongReverse)
			// 			knot_idx = knot_idx == 0 ? _splinePath.Count - 1 : knot_idx - 1;
			// 		else
			// 			knot_idx = (knot_idx + 1) % _splinePath.Count;
			// 	}
			// }

			// if (!_anim.IsPlaying)
			// {
			// 	_isPlaying = false;
			// 	_knotIdxCur = 0;
			// }
		}

		public void Reset()
		{
			_knotIdxCur = _knotIdxPrev = 0;
			_isReverse = false;
			_prevT = 0;
		}

		void _Invoke(int idx)
		{
			// Debug.Log($"[SplineAnimateOnReached] Invoke {idx}");
			// OnReachedKnot.Invoke(_anim.Container, _splinePath[idx], idx);
		}

		// bool _InitSplitePathIfNeeded()
		// {
		// 	if (_splinePath == null)
		// 	{
		// 		if (_anim.Container == null)
		// 			return false;
		// 		if (_anim.Container.Splines.Count == 0)
		// 			return false;
		// 		_splinePath = new SplinePath<Spline>(_anim.Container.Splines);
		// 	}
		// 	return _splinePath != null;
		// }
	}
}
