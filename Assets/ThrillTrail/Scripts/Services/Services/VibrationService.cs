namespace ThrillTrail.Services
{
    //Will be used to vibrate the device via the Vibration class
    public class VibrationService : IGameService
    {
        PlayerPrefService _playerPrefService;
        
        public VibrationService(PlayerPrefService playerPrefService)
        {
            _playerPrefService = playerPrefService;
        }
        
        public void Vibrate(float milliseconds)
        {
            //Check if the vibration is enable in playerpref and vibrate the device
            if (_playerPrefService.GetBool("Vibration", out bool vibrationEnabled) && vibrationEnabled)
            {
                Vibration.Vibrate((long) milliseconds);
            }
        }

        public void Vibrate(long[] pattern, int repeat)
        {
            Vibration.Vibrate(pattern, repeat);
        }

        public bool HasVibrator()
        {
            return Vibration.HasVibrator();
        }

        public void Cancel()
        {
            Vibration.Cancel();
        }
    }
}