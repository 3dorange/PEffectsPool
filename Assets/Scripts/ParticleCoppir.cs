using Peffects;
using UnityEngine;

public class ParticleCoppir : MonoBehaviour
{

	public ParticleSystem OriginalParticle;
	public ParticleSystem CopyParticle;

	// Use this for initialization
	void Start()
	{
//		GameObject particle = Instantiate(Resources.Load("Origin", typeof(GameObject))) as GameObject;

		var particle = Resources.Load("Origin") as GameObject;
		var pS = particle.GetComponent<ParticleSystem>();

		Debug.Log("color " + pS.main.startColor.color);
	}

	// Update is called once per frame
	void Update()
	{
		var copyParticleColorOverLifetime = CopyParticle.colorOverLifetime;
		copyParticleColorOverLifetime.color = OriginalParticle.colorOverLifetime.color;
		copyParticleColorOverLifetime.enabled = OriginalParticle.colorOverLifetime.enabled;

		var copyParticleMain = CopyParticle.main;
		copyParticleMain.startColor = OriginalParticle.main.startColor;
		copyParticleMain.startDelay = OriginalParticle.main.startDelay;
		copyParticleMain.startLifetime = OriginalParticle.main.startLifetime;
		copyParticleMain.startSpeed = OriginalParticle.main.startSpeed;

//		ParticleSystemRenderer идет отдельным куском
//		CopyParticle.startColor = OriginalParticle.main.startColor.color;
	}
}