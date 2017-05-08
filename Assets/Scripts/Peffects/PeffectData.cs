//https://github.com/3dorange/PEffectsPool
using UnityEngine;
using UnityEngine.Rendering;

namespace Peffects
{
	public class PeffectData
	{
		private PeMain _peMain;
		private PeRender _peRender;
		private PeColorOverLife _peColorOverLife;
		private PeShape _peShape;
		private PeEmission _peEmission;

		private ParticleSystem.VelocityOverLifetimeModule _velocityOverLifetime;
		private ParticleSystem.LimitVelocityOverLifetimeModule _limitVelocityOverLifetime;
		private ParticleSystem.InheritVelocityModule _inheritVelocity;
		private ParticleSystem.ForceOverLifetimeModule _forceOverLifetime;
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

		public PeMain GetMain()
		{
			return _peMain;
		}

		public PeRender GetRender()
		{
			return _peRender;
		}

		public PeColorOverLife GetColorOverLife()
		{
			return _peColorOverLife;
		}

		public PeShape GetShape()
		{
			return _peShape;
		}

		public PeEmission GetEmission()
		{
			return _peEmission;
		}

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
			#region ColorOverLife
			_peColorOverLife = new PeColorOverLife
			{
				Enabled = particleSystem.colorOverLifetime.enabled,
				Color = particleSystem.colorOverLifetime.color
			};

			#endregion
			#region Shape
			_peShape = new PeShape
			{
				AlignToDirection = particleSystem.shape.alignToDirection,
				Enabled = particleSystem.shape.enabled,
				PeMesh = particleSystem.shape.mesh,
				PeMeshRenderer = particleSystem.shape.meshRenderer,
				PeSkinnedMeshRenderer = particleSystem.shape.skinnedMeshRenderer,
				UseMeshColors = particleSystem.shape.useMeshColors,
				UseMeshMaterialIndex = particleSystem.shape.useMeshMaterialIndex,
				Angle = particleSystem.shape.angle,
				Arc = particleSystem.shape.arc,
				Box = particleSystem.shape.box,
				Length = particleSystem.shape.length,
				MeshMaterialIndex = particleSystem.shape.meshMaterialIndex,
				MeshScale = particleSystem.shape.meshScale,
				MeshShapeType = particleSystem.shape.meshShapeType,
				NormalOffset = particleSystem.shape.normalOffset,
				Radius = particleSystem.shape.radius,
				RandomDirectionAmount = particleSystem.shape.randomDirectionAmount,
				ShapeType = particleSystem.shape.shapeType,
				SphericalDirectionAmount = particleSystem.shape.sphericalDirectionAmount
			};
			#endregion
			#region Emission

			_peEmission = new PeEmission
			{
				BurstCount = particleSystem.emission.burstCount,
				Enabled = particleSystem.emission.enabled,
				RateOverDistance = particleSystem.emission.rateOverDistance,
				RateOverDistanceMultiplier = particleSystem.emission.rateOverDistanceMultiplier,
				RateOverTime = particleSystem.emission.rateOverTime,
				RateOverTimeMultiplier = particleSystem.emission.rateOverTimeMultiplier,
				Bursts = new ParticleSystem.Burst[particleSystem.emission.burstCount]
			};
			particleSystem.emission.GetBursts(_peEmission.Bursts);
			#endregion
		}

		public class PeShape
		{
			public bool AlignToDirection;
			public bool Enabled;
			public Mesh PeMesh;
			public MeshRenderer PeMeshRenderer;
			public SkinnedMeshRenderer PeSkinnedMeshRenderer;
			public bool UseMeshColors;
			public bool UseMeshMaterialIndex;
			public float Angle;
			public float Arc;
			public Vector3 Box;
			public float Length;
			public int MeshMaterialIndex;
			public float MeshScale;
			public ParticleSystemMeshShapeType MeshShapeType;
			public float NormalOffset;
			public float Radius;
			public float RandomDirectionAmount;
			public ParticleSystemShapeType ShapeType;
			public float SphericalDirectionAmount;
		}

		public class PeEmission
		{
			public int BurstCount;
			public bool Enabled;
			public ParticleSystem.MinMaxCurve RateOverDistance;
			public float RateOverDistanceMultiplier;
			public ParticleSystem.MinMaxCurve RateOverTime;
			public float RateOverTimeMultiplier;
			public ParticleSystem.Burst[] Bursts;
		}

		public class PeColorOverLife
		{
			public bool Enabled;
			public ParticleSystem.MinMaxGradient Color;
		}

		public class PeMain
		{
			public Transform CustomSimulationSpace;
			public float Duration;
			public ParticleSystem.MinMaxCurve GravityModifier;
			public float GravityModifierMultiplier;
			public bool Loop;
			public int MaxParticles;
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
