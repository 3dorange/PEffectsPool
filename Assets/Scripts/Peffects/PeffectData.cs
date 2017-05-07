//https://github.com/3dorange/PEffectsPool
using UnityEngine;
using UnityEngine.Rendering;

namespace Peffects
{
	public class PeffectData
	{
		private PeMain _peMain;
		private PeRender _peRender;

		private ParticleSystem.EmissionModule _emission;
		private ParticleSystem.ShapeModule _shape;
		private ParticleSystem.VelocityOverLifetimeModule _velocityOverLifetime;
		private ParticleSystem.LimitVelocityOverLifetimeModule _limitVelocityOverLifetime;
		private ParticleSystem.InheritVelocityModule _inheritVelocity;
		private ParticleSystem.ForceOverLifetimeModule _forceOverLifetime;
		private ParticleSystem.ColorOverLifetimeModule _colorOverLifetime;
		private ParticleSystem.ColorBySpeedModule _colorBySpeed;
		private ParticleSystem.SizeOverLifetimeModule _sizeOverLifetime;
		private ParticleSystem.SizeBySpeedModule _sizeBySpeed;
		private ParticleSystem.RotationOverLifetimeModule _rotationOverLifetime;
		private ParticleSystem.RotationBySpeedModule _rotationBySpeed;
		private ParticleSystem.ExternalForcesModule _externalForces;
		private ParticleSystem.NoiseModule _noise;
		//private ParticleSystem.CollisionModule _collision;
		//private ParticleSystem.TriggerModule _trigger;
		//private ParticleSystem.SubEmittersModule _subEmitters;
		private ParticleSystem.TextureSheetAnimationModule _textureSheetAnimation;
		//private ParticleSystem.LightsModule _lights;
		//private ParticleSystem.TrailModule _trails;

		public PeffectData(ParticleSystem particleSystem, ParticleSystemRenderer particleSystemRenderer)
		{
			#region Main
			_peMain = new PeMain
			{
				CustomSimulationSpace = particleSystem.main.customSimulationSpace,
				Duration = particleSystem.main.duration,
				GravityModifier = particleSystem.main.gravityModifier,
				GravityModifierMultiplier = particleSystem.main.gravityModifierMultiplier,
				Loop = particleSystem.main.loop,
				MaxParticles = particleSystem.main.maxParticles,
				PlayOnAwake = particleSystem.main.playOnAwake,
				Prewarm = particleSystem.main.prewarm,
				RandomizeRotationDirection = particleSystem.main.randomizeRotationDirection,
				ScalingMode = particleSystem.main.scalingMode,
				SimulationSpace = particleSystem.main.simulationSpace,
				SimulationSpeed = particleSystem.main.simulationSpeed,
				StartColor = particleSystem.main.startColor,
				StartDelay = particleSystem.main.startDelay,
				StartDelayMultiplier = particleSystem.main.startDelayMultiplier,
				StartLifetime = particleSystem.main.startLifetime,
				StartLifetimeMultiplier = particleSystem.main.startLifetimeMultiplier,
				StartRotation = particleSystem.main.startRotation,
				StartRotation3D = particleSystem.main.startRotation3D,
				StartRotationMultiplier = particleSystem.main.startRotationMultiplier,
				StartRotationX = particleSystem.main.startRotationX,
				StartRotationXMultiplier = particleSystem.main.startRotationXMultiplier,
				StartRotationY = particleSystem.main.startRotationY,
				StartRotationYMultiplier = particleSystem.main.startRotationYMultiplier,
				StartRotationZ = particleSystem.main.startRotationZ,
				StartRotationZMultiplier = particleSystem.main.startRotationZMultiplier,
				StartSize = particleSystem.main.startSize,
				StartSize3D = particleSystem.main.startSize3D,
				StartSizeMultiplier = particleSystem.main.startSizeMultiplier,
				StartSizeX = particleSystem.main.startSizeX,
				StartSizeXMultiplier = particleSystem.main.startSizeXMultiplier,
				StartSizeY = particleSystem.main.startSizeY,
				StartSizeYMultiplier = particleSystem.main.startSizeYMultiplier,
				StartSizeZ = particleSystem.main.startSizeZ,
				StartSizeZMultiplier = particleSystem.main.startSizeZMultiplier,
				StartSpeed = particleSystem.main.startSpeed,
				StartSpeedMultiplier = particleSystem.main.startSpeedMultiplier
			};
			#endregion
			#region Render
			_peRender = new PeRender
			{
				Alignment = particleSystemRenderer.alignment,
				CameraVelocityScale = particleSystemRenderer.cameraVelocityScale,
				LengthScale = particleSystemRenderer.lengthScale,
				MaxParticleSize = particleSystemRenderer.maxParticleSize,
				PeMesh = particleSystemRenderer.mesh,
				MeshCount = particleSystemRenderer.meshCount,
				MinParticleSize = particleSystemRenderer.minParticleSize,
				NormalDirection = particleSystemRenderer.normalDirection,
				Pivot = particleSystemRenderer.pivot,
				RenderMode = particleSystemRenderer.renderMode,
				SortingFudge = particleSystemRenderer.sortingFudge,
				SortMode = particleSystemRenderer.sortMode,
				TrailMaterial = particleSystemRenderer.trailMaterial,
				VelocityScale = particleSystemRenderer.velocityScale,
				SharedMaterial = particleSystemRenderer.sharedMaterial,
				SharedMaterials = particleSystemRenderer.sharedMaterials,
				MotionVectorGenerationMode = particleSystemRenderer.motionVectorGenerationMode,
				ReceiveShadows = particleSystemRenderer.receiveShadows,
				ReflectionProbeUsage = particleSystemRenderer.reflectionProbeUsage,
				SortingLayerId = particleSystemRenderer.sortingLayerID,
				SortingLayerName = particleSystemRenderer.sortingLayerName,
				SortingOrder = particleSystemRenderer.sortingOrder
			};
			#endregion
		}

		public class PeMain
		{
			public Transform CustomSimulationSpace;
			public float Duration;
			public ParticleSystem.MinMaxCurve GravityModifier;
			public float GravityModifierMultiplier;
			public bool Loop;
			public float MaxParticles;
			public bool PlayOnAwake;
			public bool Prewarm;
			public float RandomizeRotationDirection;
			public ParticleSystemScalingMode ScalingMode;
			public ParticleSystemSimulationSpace SimulationSpace;
			public float SimulationSpeed;
			public ParticleSystem.MinMaxGradient StartColor;
			public ParticleSystem.MinMaxCurve StartDelay;
			public float StartDelayMultiplier;
			public ParticleSystem.MinMaxCurve StartLifetime;
			public float StartLifetimeMultiplier;
			public ParticleSystem.MinMaxCurve StartRotation;
			public bool StartRotation3D;
			public float StartRotationMultiplier;
			public ParticleSystem.MinMaxCurve StartRotationX;
			public float StartRotationXMultiplier;
			public ParticleSystem.MinMaxCurve StartRotationY;
			public float StartRotationYMultiplier;
			public ParticleSystem.MinMaxCurve StartRotationZ;
			public float StartRotationZMultiplier;
			public ParticleSystem.MinMaxCurve StartSize;
			public bool StartSize3D;
			public float StartSizeMultiplier;
			public ParticleSystem.MinMaxCurve StartSizeX;
			public float StartSizeXMultiplier;
			public ParticleSystem.MinMaxCurve StartSizeY;
			public float StartSizeYMultiplier;
			public ParticleSystem.MinMaxCurve StartSizeZ;
			public float StartSizeZMultiplier;
			public ParticleSystem.MinMaxCurve StartSpeed;
			public float StartSpeedMultiplier;
		}

		public class PeRender
		{
			public ParticleSystemRenderSpace Alignment;
			public float CameraVelocityScale;
			public float LengthScale;
			public float MaxParticleSize;
			public Mesh PeMesh;
			public float MeshCount;
			public float MinParticleSize;
			public float NormalDirection;
			public Vector3 Pivot;
			public ParticleSystemRenderMode RenderMode;
			public float SortingFudge;
			public ParticleSystemSortMode SortMode;
			public Material TrailMaterial;
			public float VelocityScale;
			public Material SharedMaterial;
			public Material[] SharedMaterials;
			public MotionVectorGenerationMode MotionVectorGenerationMode;
			public bool ReceiveShadows;
			public ReflectionProbeUsage ReflectionProbeUsage;
			public int SortingLayerId;
			public string SortingLayerName;
			public int SortingOrder;
		}
	}
}
