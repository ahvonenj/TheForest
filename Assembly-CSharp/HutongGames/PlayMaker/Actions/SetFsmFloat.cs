using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.StateMachine), HutongGames.PlayMaker.Tooltip("Set the value of a Float Variable in another FSM.")]
	public class SetFsmFloat : FsmStateAction
	{
		[RequiredField, HutongGames.PlayMaker.Tooltip("The GameObject that owns the FSM.")]
		public FsmOwnerDefault gameObject;

		[HutongGames.PlayMaker.Tooltip("Optional name of FSM on Game Object"), UIHint(UIHint.FsmName)]
		public FsmString fsmName;

		[RequiredField, HutongGames.PlayMaker.Tooltip("The name of the FSM variable."), UIHint(UIHint.FsmFloat)]
		public FsmString variableName;

		[RequiredField, HutongGames.PlayMaker.Tooltip("Set the value of the variable.")]
		public FsmFloat setValue;

		[HutongGames.PlayMaker.Tooltip("Repeat every frame. Useful if the value is changing.")]
		public bool everyFrame;

		private GameObject goLastFrame;

		private PlayMakerFSM fsm;

		public override void Reset()
		{
			this.gameObject = null;
			this.fsmName = string.Empty;
			this.setValue = null;
		}

		public override void OnEnter()
		{
			this.DoSetFsmFloat();
			if (!this.everyFrame)
			{
				base.Finish();
			}
		}

		private void DoSetFsmFloat()
		{
			if (this.setValue == null)
			{
				return;
			}
			GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
			if (ownerDefaultTarget == null)
			{
				return;
			}
			if (ownerDefaultTarget != this.goLastFrame)
			{
				this.goLastFrame = ownerDefaultTarget;
				this.fsm = ActionHelpers.GetGameObjectFsm(ownerDefaultTarget, this.fsmName.Value);
			}
			if (this.fsm == null)
			{
				this.LogWarning("Could not find FSM: " + this.fsmName.Value);
				return;
			}
			FsmFloat fsmFloat = this.fsm.FsmVariables.GetFsmFloat(this.variableName.Value);
			if (fsmFloat != null)
			{
				fsmFloat.Value = this.setValue.Value;
			}
			else
			{
				this.LogWarning("Could not find variable: " + this.variableName.Value);
			}
		}

		public override void OnUpdate()
		{
			this.DoSetFsmFloat();
		}
	}
}
