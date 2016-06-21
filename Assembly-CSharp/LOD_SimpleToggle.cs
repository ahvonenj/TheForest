using System;
using UnityEngine;

public class LOD_SimpleToggle : MonoBehaviour
{
	public Renderer[] Renderers = new Renderer[0];

	public Component[] Components = new Component[0];

	[Range(1f, 1000f)]
	public float VisibleDistance = 75f;

	private int wsToken;

	private bool currentVisibility = true;

	private void Awake()
	{
	}

	private void Start()
	{
		this.wsToken = WorkScheduler.Register(new WorkScheduler.Task(this.RefreshVisibilityWork), base.transform.position, false);
		this.RefreshVisibility(true);
	}

	private void OnDestroy()
	{
		try
		{
			WorkScheduler.Unregister(new WorkScheduler.Task(this.RefreshVisibilityWork), this.wsToken);
		}
		catch
		{
		}
	}

	private void OnEnable()
	{
		this.RefreshVisibility(true);
	}

	private void RefreshVisibilityWork()
	{
		if (base.enabled && base.gameObject.activeInHierarchy)
		{
			this.RefreshVisibility(false);
		}
	}

	private void RefreshVisibility(bool force)
	{
		Vector3 position = base.transform.position;
		position.y = PlayerCamLocation.PlayerLoc.y;
		float sqrMagnitude = (position - PlayerCamLocation.PlayerLoc).sqrMagnitude;
		bool flag = sqrMagnitude < this.VisibleDistance * this.VisibleDistance;
		if (flag != this.currentVisibility || force)
		{
			for (int i = 0; i < this.Renderers.Length; i++)
			{
				this.Renderers[i].enabled = flag;
				if (flag)
				{
					this.Renderers[i].SendMessage("OnSpawned", SendMessageOptions.DontRequireReceiver);
				}
			}
			for (int j = 0; j < this.Components.Length; j++)
			{
				Component component = this.Components[j];
				Transform transform = component as Transform;
				if (transform != null)
				{
					transform.gameObject.SetActive(flag);
				}
				else
				{
					MonoBehaviour monoBehaviour = component as MonoBehaviour;
					if (monoBehaviour != null)
					{
						monoBehaviour.enabled = flag;
					}
					else
					{
						Collider collider = component as Collider;
						if (collider != null)
						{
							collider.enabled = flag;
						}
						else
						{
							ParticleEmitter particleEmitter = component as ParticleEmitter;
							if (particleEmitter != null)
							{
								particleEmitter.enabled = flag;
							}
							else
							{
								ParticleSystem particleSystem = component as ParticleSystem;
								if (particleSystem != null)
								{
									particleSystem.enableEmission = flag;
								}
								else
								{
									AudioSource audioSource = component as AudioSource;
									if (audioSource != null)
									{
										audioSource.enabled = flag;
									}
									else
									{
										Light light = component as Light;
										if (light)
										{
											light.enabled = flag;
										}
									}
								}
							}
						}
					}
				}
			}
			this.currentVisibility = flag;
		}
	}
}
