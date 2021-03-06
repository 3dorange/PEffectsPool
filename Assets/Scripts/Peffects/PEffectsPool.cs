﻿//https://github.com/3dorange/PEffectsPool

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Peffects
{
	public class PEffectsPool : MonoBehaviour
	{
		public static PEffectsPool Instance;
		[Tooltip("Number of particle to create")]
		public int ParticlesToCreateNumber;
		[Tooltip("Time to create particles in sec")]
		public int TimeCreate;
		[Tooltip("Max count of children in particle")]
		public byte ParticleMaxChilds;
		[Tooltip("Can spawn more instances then settled on start")]
		public bool CanSpawnMore;

		private Transform _cachedTransform;

		private Dictionary<int,PeDummy> _dummies = new Dictionary<int, PeDummy>();						//particleSystem dummies
		private Dictionary<string,PeffectData> _effectsData = new Dictionary<string, PeffectData>();		//data and parameters from particles for dummies

		private Queue<int> _dummiesCanBeUsed = new Queue<int>();

		private int _dummiesCreated;
		private bool _needToCreateInUpdate;
		private float _createFactor;
		private float _lastCreateTime;

		public void AddParticleSystemType(string path, string keyCode)
		{
			if (string.IsNullOrEmpty(path))
			{
				Debug.LogError("AddParticleSystemType: Empty path");
				return;
			}

			if (string.IsNullOrEmpty(keyCode))
			{
				Debug.LogError("AddParticleSystemType: Empty keyCode");
				return;
			}

			if (_effectsData.ContainsKey(keyCode))
			{
				Debug.LogError(string.Concat("AddParticleSystemType: Already have keyCode ", keyCode));
				return;
			}

			var particleObject = Resources.Load(path) as GameObject;

			if (particleObject == null)
			{
				Debug.LogError(string.Concat("AddParticleSystemType: Nothing find on path ", path));
				return;
			}

			var pS = particleObject.GetComponent<ParticleSystem>();
			var pR = particleObject.GetComponent<ParticleSystemRenderer>();

			if (pR != null && pS != null)
			{
				var data = new PeffectData(pS, pR);
				_effectsData[keyCode] = data;
			}
			else
			{
				Debug.LogError(string.Concat("AddParticleSystemType: No particleSystem on path ", path));
			}
		}

		public PeDummy Spawn(string keyCode, Vector3 position, Quaternion rotation, Transform parent = null, float deSpawnTime = 0, Action deSpawnCallback = null)
		{
			if (string.IsNullOrEmpty(keyCode))
			{
				Debug.LogError("Spawn: Empty keyCode");
				return null;
			}

			if (_effectsData.ContainsKey(keyCode))
			{
				var id = GetFreeDummyId();

				if (id < 0)
				{
					Debug.LogError(string.Concat("Spawn: no free dummies for keyCode ", keyCode));
				}
				else
				{
					var dummy = _dummies[id];
					dummy.Spawn(id,_effectsData[keyCode], position, rotation, parent, deSpawnTime, deSpawnCallback);
				}
			}
			else
			{
				Debug.LogError(string.Concat("Spawn: no data for keyCode ", keyCode));
			}
			return null;
		}

		public void DeSpawn(PeDummy dummy)
		{
			dummy.DeSpawn();
		}

		public void RemoveFromUsed(PeDummy dummy)
		{
			_dummiesCanBeUsed.Enqueue(dummy.GetId());
		}

		private int GetFreeDummyId()
		{
			var n = -1;

			var count = _dummiesCanBeUsed.Count;
			if (count > 0)
			{
				n = _dummiesCanBeUsed.Dequeue();
			}

			if (CanSpawnMore && count < 3)
			{
				CreateDummy();
			}

			return n;
		}

		private void Awake()
		{
			InitIntance();
		}

		private void Start()
		{
			CreateDummys();
		}

		private void Update()
		{
			if (!_needToCreateInUpdate) return;
			if (!(Time.time - _lastCreateTime >= _createFactor)) return;

			if (_dummiesCreated < ParticlesToCreateNumber)
			{
				CreateDummy();
			}
			else
			{
				_needToCreateInUpdate = false;
			}
		}

		private void CreateDummys()
		{
			if (TimeCreate <= 0)
			{
				CreateAtOnce();
			}
			else
			{
				CreateInTime();
			}
		}

		private void CreateInTime()
		{
			CreateDummy();														//creating first element
			_needToCreateInUpdate = true;
			_createFactor = TimeCreate / (ParticlesToCreateNumber - 1.0f);
		}

		private void CreateAtOnce()
		{
			for (var i = 0; i < ParticlesToCreateNumber; i++)
			{
				CreateDummy();
			}
		}

		private void CreateDummy()
		{
			_dummiesCanBeUsed.Enqueue(_dummiesCreated);

			var pInstance = new GameObject();
			pInstance.transform.parent = _cachedTransform;
			pInstance.name = string.Concat("Dummy_", _dummiesCreated);
			_dummies[_dummiesCreated] = pInstance.AddComponent<PeDummy>();
			_dummies[_dummiesCreated].Init(this);

			_lastCreateTime = Time.time;
			_dummiesCreated++;
		}

		private void InitIntance()
		{
			if (Instance != null)
			{
				Destroy(this);
			}
			else
			{
				Instance = this;
			}

			_dummiesCreated = 0;
			_cachedTransform = transform;
		}
	}
}
