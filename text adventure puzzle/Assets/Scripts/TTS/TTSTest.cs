using UnityEngine;

namespace TTS
{
    // Use this component to test if TTS works
    public class TTSTest : MonoBehaviour
    {       
        public static TTSTest Instance;

        [Header("This will be spoken on Start()")]
        public string TextToSpeak = "Text to speech works correctly on this computer.";

        void Start()
        {
            if(Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
            TTSWrapper.Speak(TextToSpeak);
        }

        public void GetMessage(string message)
        {
            TTSWrapper.Speak(message);
        }
    }
}
