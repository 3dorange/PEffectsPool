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
		private ParticleSystem.ColorOverLifetimeModule _rootColorOverLife;

		private Action _deSpawnCallback;
		private float _deSpawnTime;
		private float _spawnTime;
		private PEffectsPool _pool;
		private int _id;

		private bool _needToRemove;
		private float _deSpawnWaitTime;
		private const float WaitTime = 0.5f;

		public void Init(PEffectsPool pool)
		{
			if (_inited) return;
			_pool = pool;
			_cachedTransform = transform;

			_inited = true;

			AddRootParticleSystem();
		}

		public void Spawn(int id, PeffectData data, Vector3 position, Quaternion rotation, Transform parent = null, float deSpawnTime = 0, Action deSpawnCallback = null)
		{
			if (_currentDummyState == DummyState.Spawened)
			{
				Debug.Log(string.Concat("Cant spawn, already have it id ", id));
				return;
			}

			_id = id;

			UseEffectData(data);

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

		private void RemoveFromUsed()
		{
			_pool.RemoveFromUsed(this);
			_needToRemove = false;
		}

		private void UseEffectData(PeffectData data)
		{
			UpdateMain(data.GetMain());
			UpdateRender(data.GetRender());
			UpdateShape(data.GetShape());
			UpdateEmission(data.GetEmission());
			UpdateColorOverLife(data.GetColorOverLife());
		}

		private void UpdateMain(PeffectData.PeMain peMain)
		{
			_rootMain.customSimulationSpace = peMain.CustomSimulationSpace;
			_rootMain.duration = peMain.Duration;
			_rootMain.gravityModifier = peMain.GravityModifier;
			_rootMain.gravityModifierMultiplier = peMain.GravityModifierMultiplier;
			_rootMain.loop = peMain.Loop;
			_rootMain.maxParticles = peMain.MaxParticles;
			_rootMain.prewarm = peMain.Prewarm;
			_rootMain.randomizeRotationDirection = peMain.RandomizeRotationDirection;
			_rootMain.scalingMode = peMain.ScalingMode;
			_rootMain.simulationSpace = peMain.SimulationSpace;
			_rootMain.simulationSpeed = peMain.SimulationSpeed;
			_rootMain.startColor = peMain.StartColor;
			_rootMain.startDelay = peMain.StartDelay;
			_rootMain.startDelayMultiplier = peMain.StartDelayMultiplier;
			_rootMain.startLifetime = peMain.StartLifetime;
			_rootMain.startLifetimeMultiplier = peMain.StartLifetimeMultiplier;
			_rootMain.startRotation = peMain.StartRotation;
			_rootMain.startRotation3D = peMain.StartRotation3D;
			_rootMain.startRotationMultiplier = peMain.StartRotationMultiplier;
			_rootMain.startRotationX = peMain.StartRotationX;
			_rootMain.startRotationXMultiplier = peMain.StartRotationXMultiplier;
			_rootMain.startRotationY = peMain.StartRotationY;
			_rootMain.startRotationYMultiplier = peMain.StartRotationYMultiplier;
			_rootMain.startRotationZ = peMain.StartRotationZ;
			_rootMain.startRotationZMultiplier = peMain.StartRotationZMultiplier;
			_rootMain.startSize = peMain.StartSize;
			_rootMain.startSize3D = peMain.StartSize3D;
			_rootMain.startSizeMultiplier = peMain.StartSizeMultiplier;
			_rootMain.startSizeX = peMain.StartSizeX;
			_rootMain.startSizeXMultiplier = peMain.StartSizeXMultiplier;
			_rootMain.startSizeY = peMain.StartSizeY;
			_rootMain.startSizeYMultiplier = peMain.StartSizeYMultiplier;
			_rootMain.startSizeZ = peMain.StartSizeZ;
			_rootMain.startSizeZMultiplier = peMain.StartSizeZMultiplier;
			_rootMain.startSpeed = peMain.StartSpeed;
			_rootMain.startSpeedMultiplier = peMain.StartSpeedMultiplier;
		}

		private void UpdateRender(PeffectData.PeRender peRender)
		{
			_rootPsRender.enabled = false;

			_rootPsRender.alignment = peRender.Alignment;
			_rootPsRender.cameraVelocityScale = peRender.CameraVelocityScale;
			_rootPsRender.lengthScale = peRender.LengthScale;
			_rootPsRender.maxParticleSize = peRender.MaxParticleSize;
			_rootPsRender.mesh = peRender.PeMesh;
			_rootPsRender.minParticleSize = peRender.MinParticleSize;
			_rootPsRender.normalDirection = peRender.NormalDirection;
			_rootPsRender.pivot = peRender.Pivot;
			_rootPsRender.renderMode = peRender.RenderMode;
			_rootPsRender.sortingFudge = peRender.SortingFudge;
			_rootPsRender.sortMode = peRender.SortMode;
			_rootPsRender.trailMaterial = peRender.TrailMaterial;
			_rootPsRender.velocityScale = peRender.VelocityScale;
			_rootPsRender.sharedMaterial = peRender.SharedMaterial;
			_rootPsRender.sharedMaterials = peRender.SharedMaterials;
			_rootPsRender.motionVectorGenerationMode = peRender.MotionVectorGenerationMode;
			_rootPsRender.receiveShadows = peRender.ReceiveShadows;
			_rootPsRender.reflectionProbeUsage = peRender.ReflectionProbeUsage;
			_rootPsRender.sortingLayerID = peRender.SortingLayerId;
			_rootPsRender.sortingLayerName = peRender.SortingLayerName;
			_rootPsRender.sortingOrder = peRender.SortingOrder;

			_rootPsRender.enabled = true;
		}

		private void UpdateShape(PeffectData.PeShape peShape)
		{
			_rootShape.enabled = false;
			if (!peShape.Enabled) return;

			_rootShape.alignToDirection = peShape.AlignToDirection;
			_rootShape.mesh = peShape.PeMesh;
			_rootShape.meshRenderer = peShape.PeMeshRenderer;
			_rootShape.skinnedMeshRenderer = peShape.PeSkinnedMeshRenderer;
			_rootShape.useMeshColors = peShape.UseMeshColors;
			_rootShape.useMeshMaterialIndex = peShape.UseMeshMaterialIndex;
			_rootShape.angle = peShape.Angle;
			_rootShape.arc = peShape.Arc;
			_rootShape.box = peShape.Box;
			_rootShape.length = peShape.Length;
			_rootShape.meshMaterialIndex = peShape.MeshMaterialIndex;
			_rootShape.meshScale = peShape.MeshScale;
			_rootShape.meshShapeType = peShape.MeshShapeType;
			_rootShape.normalOffset = peShape.NormalOffset;
			_rootShape.radius = peShape.Radius;
			_rootShape.randomDirectionAmount = peShape.RandomDirectionAmount;
			_rootShape.shapeType = peShape.ShapeType;
			_rootShape.sphericalDirectionAmount = peShape.SphericalDirectionAmount;

			_rootShape.enabled = peShape.Enabled;
		}

		private void UpdateEmission(PeffectData.PeEmission peEmission)
		{
			_rootEmission.enabled = false;
			if (!peEmission.Enabled) return;

			_rootEmission.SetBursts(peEmission.Bursts);
			_rootEmission.rateOverDistance = peEmission.RateOverDistance;
			_rootEmission.rateOverDistanceMultiplier = peEmission.RateOverDistanceMultiplier;
			_rootEmission.rateOverTime = peEmission.RateOverTime;
			_rootEmission.rateOverTimeMultiplier = peEmission.RateOverTimeMultiplier;

			_rootEmission.enabled = peEmission.Enabled;
		}

		private void UpdateColorOverLife(PeffectData.PeColorOverLife peColorOverLife)
		{
			_rootColorOverLife.enabled = false;
			if (!peColorOverLife.Enabled) return;

			_rootColorOverLife.color = peColorOverLife.Color;
			_rootColorOverLife.enabled = peColorOverLife.Enabled;
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
			_rootPs.Stop(false);
			_rootEmission.enabled = false;
			_cachedTransform.parent = _pool.transform;
//			_cachedTransform.localPosition = Vector3.zero;
			ChangeChildrenState(false);
			_currentDummyState = DummyState.DeSpawned;

			_needToRemove = true;
			_deSpawnWaitTime = Time.time;
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

			if (_needToRemove && Time.time - _deSpawnWaitTime > WaitTime)
			{
				RemoveFromUsed();
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
			_rootColorOverLife = _rootPs.colorOverLifetime;

			_rootMain.playOnAwake = false;
			_rootEmission.enabled = false;
			_rootMain.loop = false;
			_rootShape.shapeType = ParticleSystemShapeType.Sphere;

			_rootPs.Stop();
		}
	}
}
