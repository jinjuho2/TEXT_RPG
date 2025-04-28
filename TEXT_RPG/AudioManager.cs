using System;
using System.IO;
using NAudio.Wave;

namespace TEXT_RPG
{
    internal class AudioManager
    {
        private IWavePlayer waveOut;
        private AudioFileReader audioFile;

        private static AudioManager instance;
        public static AudioManager Instance()
        {
            if (instance == null)
                instance = new AudioManager();
            return instance;
        }



        public void InitBgm()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "bgm.wav");

            if (File.Exists(filePath))
            {
                waveOut = new WaveOutEvent();
                audioFile = new AudioFileReader(filePath);

                // 재생이 끝날 때 이벤트를 감지하여 무한 반복
                waveOut.PlaybackStopped += (sender, args) =>
                {
                    audioFile.Position = 0; // 파일의 시작 위치로 되돌림
                    waveOut.Play();
                };

                waveOut.Init(audioFile);
                waveOut.Play();
            }
            else
            {
                Console.WriteLine("배경음악 파일이 없습니다.");
                Console.WriteLine(filePath);
                System.Threading.Thread.Sleep(1000);
            }
        }

        public void StopBgm()
        {
            waveOut?.Stop();
            waveOut?.Dispose();
            audioFile?.Dispose();
        }
    }
}
