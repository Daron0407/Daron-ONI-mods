using KSerialization;

namespace AdvancedCoolers
{
    /*
    [SerializationConfig(MemberSerialization.OptIn)]
    public class AdjustableSlider : KMonoBehaviour, ISingleSliderControl, ISliderControl
    {

        public const float SLIDER_MAX = 100f;
        public const float SLIDER_MIN = -265f;

        private static readonly EventSystem.IntraObjectHandler<AdjustableSlider> OnCopySettingsDelegate = new EventSystem.IntraObjectHandler<AdjustableSlider>(OnCopySettings);

        private static void OnCopySettings(AdjustableSlider comp, object data)
        {
            comp.OnCopySettings(data);
        }

        public const string KEY = "STRINGS.UI.UISIDESCREENS.ADJUSTABLESLIDERSIDESCREEN";

        [MyCmpReq]
        public MinimumOperatingTemperature minimumOperatingTemperature;

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

        public string GetSliderTooltip()
        {
            return "Set Target Temperature";
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
            Subscribe((int)GameHashes.CopySettings, OnCopySettingsDelegate);
        }

        protected override void OnSpawn()
        {
            if (SLIDER == int.MaxValue)
            {
                SLIDER = 85f;
            }
            Update();
        }

        internal void OnCopySettings(object data)
        {
            AdjustableSlider comp = ((UnityEngine.GameObject)data).GetComponent<AdjustableSlider>();
            if (comp != null)
            {
                this.SLIDER = comp.SLIDER;
            }
        }

        internal void Update()
        {
            minimumOperatingTemperature.minimumTemperature = SLIDER + 273.15f;
        }

        string ISliderControl.GetSliderTooltip(int index)
        {
            return "Adjust target temperature";
        }
    }*/
}
