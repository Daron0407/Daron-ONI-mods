using KSerialization;

namespace ConfigurableSteamTurbine
{
    [SerializationConfig(MemberSerialization.OptIn)]
    class FreezePreventable : KMonoBehaviour
    {
        public static readonly float MIN_TEMP = 1f;
        private static readonly EventSystem.IntraObjectHandler<FreezePreventable> OnFreezeDelegate = new EventSystem.IntraObjectHandler<FreezePreventable>(OnTempChange);


        private static void OnTempChange(FreezePreventable comp, object data)
        {

        }
        protected override void OnPrefabInit()
        {
            base.OnPrefabInit();
            Subscribe<FreezePreventable>((int)GameHashes.TemperatureUnitChanged, OnFreezeDelegate);
        }
    }
}
