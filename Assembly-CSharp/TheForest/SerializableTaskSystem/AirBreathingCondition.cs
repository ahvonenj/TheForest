using System;
using System.Collections;
using System.Diagnostics;
using TheForest.Utils;
using UnityEngine;

namespace TheForest.SerializableTaskSystem
{
	[Serializable]
	public class AirBreathingCondition : ACondition
	{
		[Header("AirBreathing")]
		public float _threshold;

		private Coroutine _routine;

		public override void Init()
		{
			this._routine = Scene.ActiveMB.StartCoroutine(this.CheckProximityRoutine());
		}

		public override void Clear()
		{
			if (this._routine != null)
			{
				Scene.ActiveMB.StopCoroutine(this._routine);
			}
			base.Clear();
		}

		[DebuggerHidden]
		public IEnumerator CheckProximityRoutine()
		{
			AirBreathingCondition.<CheckProximityRoutine>c__Iterator18B <CheckProximityRoutine>c__Iterator18B = new AirBreathingCondition.<CheckProximityRoutine>c__Iterator18B();
			<CheckProximityRoutine>c__Iterator18B.<>f__this = this;
			return <CheckProximityRoutine>c__Iterator18B;
		}

		private bool IsAirBellowThreshold()
		{
			return LocalPlayer.Stats.AirBreathing.CurrentAirPercent < this._threshold;
		}
	}
}
