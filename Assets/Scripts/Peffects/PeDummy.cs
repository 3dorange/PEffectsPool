//https://github.com/3dorange/PEffectsPool
using System;
using UnityEngine;

namespace Peffects
{
	public class PeDummy : MonoBehaviour
	{
		public enum DummyState : byte
		{
			DeSpawned = 0,
			Spawened = 1
		}

		private DummyState _currentDummyState;
		private bool _inited;
		private Transform _cachedTransform;
		private ParticleSystem _rootPs;
		private ParticleSystemRenderer _rootPsRender;

		private ParticleSystem.MainModule _rootMain;
		private ParticleSystem.EmissionModule _rootEmission;
		private ParticleSystem.ShapeModule _rootShape;

		private Action _deSpawnCallback;
		private float _deSpawnTime;
		private float _spawnTime;
		private PEffectsPool _pool;
		private int _id;

		public void Init(PEffectsPool pool)
		{
			if (_inited) return;
			_pool = pool;
			_cachedTransform = transform;

			_inited = true;

			AddRootParticleSystem();
		}

		public void Spawn(int id,Vector3 position, Quaternion rotation, Transform parent = null, float deSpawnTime = 0, Action deSpawnCallback = null)
		{
			if (_currentDummyState == DummyState.Spawened)
			{
				Debug.Log(string.Concat("Cant spawn, already have it id ", id));
				return;
			}

			_id = id;

			_cachedTransform.position = position;
			_cachedTransform.rotation = rotation;
			_cachedTransform.parent = parent;

			_deSpawnTime = deSpawnTime;
			_deSpawnCallback = deSpawnCallback;
			_spawnTime = Time.time;

			Activate();
		}

		public int GetId()
		{
			return _id;
		}

		public void DeSpawn()
		{
			if (_currentDummyState == DummyState.DeSpawned)
			{
				return;
			}

			Deactivate();
			if (_deSpawnCallback != null)
			{
				_deSpawnCallback();
				_deSpawnCallback = null;
			}

			_deSpawnTime = 0;
			_spawnTime = 0;
		}

		private void Activate()
		{
			_rootEmission.enabled = true;
			_rootPs.Play();
			ChangeChildrenState(true);
			_currentDummyState = DummyState.Spawened;
		}

		private void Deactivate()
		{
			_rootEmission.enabled = false;
			_rootPs.Stop();
			_cachedTransform.parent = _pool.transform;
			_cachedTransform.localPosition = Vector3.zero;
			ChangeChildrenState(false);
			_currentDummyState = DummyState.DeSpawned;
		}

		private void ChangeChildrenState(bool state)
		{

		}

		private void Update()
		{
			if (_deSpawnTime > 0)
			{
				if (Time.time - _spawnTime >= _deSpawnTime)
				{
					DeSpawnByTime();
				}
			}
		}

		private void DeSpawnByTime()
		{
			if (_currentDummyState == DummyState.DeSpawned)
			{
				return;
			}

			Deactivate();
			_pool.DeSpawn(this);

			if (_deSpawnCallback != null)
			{
				_deSpawnCallback();
				_deSpawnCallback = null;
			}

			_deSpawnTime = 0;
			_spawnTime = 0;
		}

		private void AddRootParticleSystem()
		{
			_rootPs = _cachedTransform.gameObject.AddComponent<ParticleSystem>();
			_rootPsRender = _rootPs.GetComponent<ParticleSystemRenderer>();

			_rootMain = _rootPs.main;
			_rootEmission = _rootPs.emission;
			_rootShape =_rootPs.shape;

			_rootMain.playOnAwake = false;
			_rootEmission.enabled = false;
			_rootMain.loop = false;
			_rootShape.shapeType = ParticleSystemShapeType.Sphere;
		}

	}
}
