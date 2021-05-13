using System.Diagnostics;
using System.IO;
using UnityEngine;

namespace TTS
{
    public static class TTSWrapper
    {
        private const string ExecutableName = "tts.exe";

        public static bool Speak(string text)
        {
            var path = Path.Combine(Application.streamingAssetsPath, "TTS/");
            var process = new Process();

            process.StartInfo = new ProcessStartInfo
            {
                Arguments = $"\"{text}\"",
                WorkingDirectory = path,
                FileName = ExecutableName,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            return process.Start();
        }
    }
}
