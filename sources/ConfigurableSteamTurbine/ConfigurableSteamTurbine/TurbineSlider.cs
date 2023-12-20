using KSerialization;

namespace ConfigurableSteamTurbine
{
    [SerializationConfig(MemberSerialization.OptIn)]
    public class TurbineSlider : KMonoBehaviour, ISingleSliderControl, ISliderControl
    {

        public const float SLIDER_MAX = 100f;
        public const float SLIDER_MIN = 0f;

        private static readonly EventSystem.IntraObjectHandler<TurbineSlider> OnCopySettingsDelegate = new EventSystem.IntraObjectHandler<TurbineSlider>(OnCopySettings);

        private static void OnCopySettings(TurbineSlider comp, object data)
        {
            comp.OnCopySettings(data);
        }

        public const string KEY = "STRINGS.UI.UISIDESCREENS.STEAMTURBINE2SLIDER";

        [MyCmpReq]
        public SteamTurbine steamTurbine;

        [MyCmpAdd]
        public CopyBuildingSettings copyBuildingSettings;

        [Serialize]
        public float SLIDER = int.MaxValue;

        public int SliderDecimalPlaces(int i)
        {
            return 1;
        }

        public float GetSliderMin(int i)
        {
            return SLIDER_MIN;
        }

        public float GetSliderMax(int i)
        {
            return SLIDER_MAX;
        }

        public float GetSliderValue(int i)
        {
            return SLIDER;
        }

        public string GetSliderTooltipKey(int i)
        {
            return KEY + ".TOOLTIP";
        }

        public string GetSliderTooltip(int index)
        {
            return "Set Output Temperature";
        }

        public string SliderTitleKey => KEY + ".TITLE";
        public string SliderUnits => GameUtil.GetTemperatureUnitSuffix();

        public void SetSliderValue(float val, int i)
        {
            SLIDER = val;
            Update();
        }

        protected override void OnPrefabInit()
        {
            base.OnPrefabInit();
            Subscribe<TurbineSlider>((int)GameHashes.CopySettings, OnCopySettingsDelegate);
        }

        protected override void OnSpawn()
        {
            if (SLIDER == int.MaxValue)
            {
                SLIDER = Config.Instance.outputTempC;
            }
            Update();
        }

        internal void OnCopySettings(object data)
        {
            TurbineSlider comp = ((UnityEngine.GameObject)data).GetComponent<TurbineSlider>();
            if (comp != null)
            {
                this.SLIDER = comp.SLIDER;
            }
        }

        internal void Update()
        {
            steamTurbine.outputElementTemperature = SLIDER + 273.15f;
            steamTurbine.maxBuildingTemperature = SLIDER + 273.15f + Config.Instance.tempDiff;
        }
    }
}
