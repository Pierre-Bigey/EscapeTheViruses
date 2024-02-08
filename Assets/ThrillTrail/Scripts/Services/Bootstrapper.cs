using UnityEngine;
using UnityEngine.SceneManagement;

namespace ThrillTrail.Services
{
    public static class Bootstrapper
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        public static void Initiailze()
        {
            // Initialize default service locator.
            ServiceLocator.Initiailze();

            // Register all your services next.
            ServiceLocator.Instance.Register(new SceneLoaderService());
            /*ServiceLocator.Instance.Register<IMyGameServiceB>(new MyGameServiceB());
            ServiceLocator.Instance.Register<IMyGameServiceC>(new MyGameServiceC());*/

            // Application is ready to start, load your main scene.
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        }
    }
}