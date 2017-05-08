//https://github.com/3dorange/PEffectsPool
using UnityEngine;

namespace Peffects
{
	public class Spawner : MonoBehaviour
	{
		private const float SpawnRadius = 20;
		private const float WaitForPoolTime = 2;
		private float _startTime;

		private const float RedTimer = 0.5f;
		private const float BlueTimer = 0.75f;
		private const float GreenTimer = 0.5f;
		private const float PurpleTimer = 0.25f;
		private const float YellowTimer = 0.5f;

		private float _currentRedTimer;
		private float _currentBlueTimer;
		private float _currentGreenTimer;
		private float _currentPurpleTimer;
		private float _currentYellowTimer;

		private void Start()
		{
			_startTime = Time.time;

			_currentRedTimer = RedTimer;
			_currentBlueTimer = BlueTimer;
			_currentGreenTimer = GreenTimer;
			_currentPurpleTimer = PurpleTimer;
			_currentYellowTimer = YellowTimer;

			LoadEffects();
		}

		private void Update()
		{
			if (Time.time - _startTime > WaitForPoolTime)
			{
				_currentRedTimer -= Time.deltaTime;
				_currentBlueTimer -= Time.deltaTime;
				_currentGreenTimer -= Time.deltaTime;
				_currentPurpleTimer -= Time.deltaTime;
				_currentYellowTimer -= Time.deltaTime;

				if (_currentRedTimer <= 0)
				{
					PEffectsPool.Instance.Spawn("red", GetRandomPos(), Quaternion.identity, transform, 1.5f);
					_currentRedTimer = RedTimer;
				}

				if (_currentBlueTimer <= 0)
				{
					PEffectsPool.Instance.Spawn("green", GetRandomPos(), Quaternion.identity, transform, 1.5f);
					_currentBlueTimer = BlueTimer;
				}

				if (_currentGreenTimer <= 0)
				{
					PEffectsPool.Instance.Spawn("blue", GetRandomPos(), Quaternion.identity, transform, 1.5f);
					_currentGreenTimer = GreenTimer;
				}

				if (_currentPurpleTimer <= 0)
				{
					PEffectsPool.Instance.Spawn("purple", GetRandomPos(), Quaternion.identity, transform, 1.5f);
					_currentPurpleTimer = PurpleTimer;
				}

				if (_currentYellowTimer <= 0)
				{
					PEffectsPool.Instance.Spawn("yellow", GetRandomPos(), Quaternion.identity, transform, 1.5f);
					_currentYellowTimer = YellowTimer;
				}
			}
		}

		private Vector3 GetRandomPos()
		{
			return transform.position + new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)) * SpawnRadius;
		}

		private void LoadEffects()
		{
			PEffectsPool.Instance.AddParticleSystemType("Red", "red");
			PEffectsPool.Instance.AddParticleSystemType("Green", "green");
			PEffectsPool.Instance.AddParticleSystemType("Blue", "blue");
			PEffectsPool.Instance.AddParticleSystemType("Purple", "purple");
			PEffectsPool.Instance.AddParticleSystemType("Yellow", "yellow");
		}
	}
}
