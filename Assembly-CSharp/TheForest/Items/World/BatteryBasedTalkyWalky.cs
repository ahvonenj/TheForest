using Bolt;
using System;
using System.Collections;
using System.Diagnostics;
using TheForest.Items.Inventory;
using TheForest.Utils;
using UnityEngine;

namespace TheForest.Items.World
{
	[AddComponentMenu("Items/World/Battery Based Talky Walky")]
	public class BatteryBasedTalkyWalky : EntityBehaviour<IPlayerState>
	{
		public PlayerInventory _player;

		public float _batterieCostPerSecond = 0.2f;

		public float _delayBeforeStart = 0.5f;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void Update()
		{
			if (!BoltNetwork.isRunning || base.GetComponentInParent<BoltEntity>().IsOwner())
			{
				LocalPlayer.Stats.BatteryCharge -= this._batterieCostPerSecond * Time.deltaTime;
				if (LocalPlayer.Stats.BatteryCharge <= 0f)
				{
					this._player.StashLeftHand();
				}
			}
		}

		[DebuggerHidden]
		private IEnumerator DelayedStart()
		{
			BatteryBasedTalkyWalky.<DelayedStart>c__Iterator16F <DelayedStart>c__Iterator16F = new BatteryBasedTalkyWalky.<DelayedStart>c__Iterator16F();
			<DelayedStart>c__Iterator16F.<>f__this = this;
			return <DelayedStart>c__Iterator16F;
		}
	}
}
