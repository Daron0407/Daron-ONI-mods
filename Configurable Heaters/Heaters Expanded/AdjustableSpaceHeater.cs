using KSerialization;

namespace Heaters_Expanded
{
    [SerializationConfig(MemberSerialization.OptIn)]
    public class AdjustableSpaceHeater : KMonoBehaviour, ISingleSliderControl, ISliderControl
    {

        public const float SLIDER_MAX = 1000f;
        public const float SLIDER_MIN = -200f;

        private static readonly EventSystem.IntraObjectHandler<AdjustableSpaceHeater> OnCopySettingsDelegate = new EventSystem.IntraObjectHandler<AdjustableSpaceHeater>(OnCopySettings);

        private static void OnCopySettings(AdjustableSpaceHeater comp, object data)
        {
            comp.OnCopySettings(data);
        }

        public const string KEY = "STRINGS.UI.UISIDESCREENS.SPACEHEATERTEMPERATURESIDESCREEN";

        [MyCmpReq]
        public SpaceHeater spaceHeater;
        
        [MyCmpReq]
        public MinimumOperatingTemperature minimumOperatingTemperature;

        [MyCmpReq]
        public EnergyConsumer energyConsumer;

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
            Subscribe<AdjustableSpaceHeater>((int)GameHashes.CopySettings, OnCopySettingsDelegate);
        }

        protected override void OnSpawn()
        {
            if (SLIDER == int.MaxValue)
            {
                SLIDER = 70f;
            }
            Update();
        }

        internal void OnCopySettings(object data)
        {
            AdjustableSpaceHeater comp = ((UnityEngine.GameObject)data).GetComponent<AdjustableSpaceHeater>();
            if (comp != null)
            {
                this.SLIDER = comp.SLIDER;
            }
        }

        internal void Update()
        {
            if (globals.SHheating())
            {
                minimumOperatingTemperature.minimumTemperature = globals.MIN_TEMP;
                spaceHeater.targetTemperature = SLIDER + globals.CELCIUS_TO_KELVIN;
            }
            else
            {
                minimumOperatingTemperature.minimumTemperature = SLIDER + globals.CELCIUS_TO_KELVIN;
                spaceHeater.targetTemperature = globals.MAX_TEMP;
            }
        }
    }
}
