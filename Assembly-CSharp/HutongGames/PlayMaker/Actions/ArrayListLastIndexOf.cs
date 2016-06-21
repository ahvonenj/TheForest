using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("ArrayMaker/ArrayList"), HutongGames.PlayMaker.Tooltip("Return the Last index occurence of an item from a PlayMaker Array List Proxy component. Can search within a range")]
	public class ArrayListLastIndexOf : ArrayListActions
	{
		[ActionSection("Set up"), CheckForComponent(typeof(PlayMakerArrayListProxy)), RequiredField, HutongGames.PlayMaker.Tooltip("The gameObject with the PlayMaker ArrayList Proxy component")]
		public FsmOwnerDefault gameObject;

		[HutongGames.PlayMaker.Tooltip("Author defined Reference of the PlayMaker ArrayList Proxy component (necessary if several component coexists on the same GameObject)"), UIHint(UIHint.FsmString)]
		public FsmString reference;

		[HutongGames.PlayMaker.Tooltip("Optional start index to search from: set to 0 to ignore"), UIHint(UIHint.FsmInt)]
		public FsmInt startIndex;

		[HutongGames.PlayMaker.Tooltip("Optional amount of elements to search within: set to 0 to ignore"), UIHint(UIHint.FsmInt)]
		public FsmInt count;

		[ActionSection("Data"), RequiredField, HutongGames.PlayMaker.Tooltip("The variable to get the index of.")]
		public FsmVar variable;

		[ActionSection("Result"), RequiredField, HutongGames.PlayMaker.Tooltip("The index of the last item described below"), UIHint(UIHint.Variable)]
		public FsmInt lastIndexOf;

		[HutongGames.PlayMaker.Tooltip("Event sent if this arraList contains that element ( described below)"), UIHint(UIHint.FsmEvent)]
		public FsmEvent itemFound;

		[HutongGames.PlayMaker.Tooltip("Event sent if this arraList does not contains that element ( described below)"), UIHint(UIHint.FsmEvent)]
		public FsmEvent itemNotFound;

		[HutongGames.PlayMaker.Tooltip("Optional Event to trigger if the action fails ( likely an out of range exception when using wrong values for index and/or count)"), UIHint(UIHint.FsmEvent)]
		public FsmEvent failureEvent;

		public override void Reset()
		{
			this.gameObject = null;
			this.reference = null;
			this.startIndex = null;
			this.count = null;
			this.lastIndexOf = null;
			this.itemFound = null;
			this.itemNotFound = null;
			this.failureEvent = null;
		}

		public override void OnEnter()
		{
			if (base.SetUpArrayListProxyPointer(base.Fsm.GetOwnerDefaultTarget(this.gameObject), this.reference.Value))
			{
				this.DoArrayListLastIndex();
			}
			base.Finish();
		}

		public void DoArrayListLastIndex()
		{
			if (!base.isProxyValid())
			{
				return;
			}
			object valueFromFsmVar = PlayMakerUtils.GetValueFromFsmVar(base.Fsm, this.variable);
			int num = -1;
			try
			{
				if (this.startIndex.Value == 0 && this.count.Value == 0)
				{
					num = this.proxy.arrayList.LastIndexOf(valueFromFsmVar);
				}
				else if (this.count.Value == 0)
				{
					if (this.startIndex.Value < 0 || this.startIndex.Value >= this.proxy.arrayList.Count)
					{
						Debug.LogError("start index out of range");
						return;
					}
					num = this.proxy.arrayList.LastIndexOf(valueFromFsmVar, this.startIndex.Value);
				}
				else
				{
					if (this.startIndex.Value < 0 || this.startIndex.Value >= this.proxy.arrayList.Count - this.count.Value)
					{
						Debug.LogError("start index and count out of range");
						return;
					}
					num = this.proxy.arrayList.LastIndexOf(valueFromFsmVar, this.startIndex.Value, this.count.Value);
				}
			}
			catch (Exception ex)
			{
				Debug.LogError(ex.Message);
				base.Fsm.Event(this.failureEvent);
				return;
			}
			this.lastIndexOf.Value = num;
			if (num == -1)
			{
				base.Fsm.Event(this.itemNotFound);
			}
			else
			{
				base.Fsm.Event(this.itemFound);
			}
		}
	}
}
