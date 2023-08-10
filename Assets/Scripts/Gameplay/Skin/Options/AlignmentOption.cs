// <auto-generated> to shut up linter
using ArcCreate.Utility;
using ArcCreate.Utility.ExternalAssets;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ArcCreate.Gameplay.Skin
{
    [CreateAssetMenu(fileName = "Alignment", menuName = "Skin Option/Alignment")]
    public class AlignmentOption : ScriptableObject
    {
        public string Name;
        public NoteSkinOption DefaultNoteOption;
        public ParticleSkinOption DefaultParticleOption;
        public TrackSkinOption DefaultTrackOption;
        public SingleLineOption DefaultSingleLineOption;
        public AccentOption DefaultAccentOption;
        [SerializeField] public Sprite defaultBackground;
        [SerializeField] public Sprite infoPanelSprite;
        [SerializeField] public Sprite pauseButtonSprite;

        public ExternalSprite DefaultBackground { get; private set; }

        public ExternalSprite InfoPanelSprite { get; private set; }

        public ExternalSprite PauseButtonSprite { get; private set; }

        internal void RegisterExternalSkin()
        {
            DefaultBackground = new ExternalSprite(defaultBackground, "DefaultBackgrounds");
            InfoPanelSprite = new ExternalSprite(infoPanelSprite, "HUD");
            PauseButtonSprite = new ExternalSprite(pauseButtonSprite, "HUD");
        }

        internal async UniTask LoadExternalSkin()
        {
            await DefaultBackground.Load();
            await InfoPanelSprite.Load();
            await PauseButtonSprite.Load();
        }

        internal void UnloadExternalSkin()
        {
            DefaultBackground.Unload();
            InfoPanelSprite.Unload();
            PauseButtonSprite.Unload();
        }
    }
}