using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;

namespace ClientInformationServices.Services.Impl
{
    public class AudioToTextService : IAudioToTextService
    {
        public void call(string filePath)
        {
            SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
            Grammar gr = new DictationGrammar();
            sre.LoadGrammar(gr);
            //sre.RecognizeAsync(RecognizeMode.Multiple);
            sre.SetInputToWaveFile("C:\\temp\\mic.wav");
            sre.BabbleTimeout = new TimeSpan(Int32.MaxValue);
            sre.InitialSilenceTimeout = new TimeSpan(Int32.MaxValue);
            sre.EndSilenceTimeout = new TimeSpan(1000000000);
            sre.EndSilenceTimeoutAmbiguous = new TimeSpan(1000000000);

            StringBuilder sb = new StringBuilder();
            while (true)
            {
                try
                {
                    var recText = sre.Recognize();
                    if (recText == null)
                    {
                        break;
                    }

                    sb.Append(recText.Text);

                    FileStream f = new FileStream("C:\\temp\\mic.wav", FileMode.Create);
                    BinaryWriter wr = new BinaryWriter(f);
                    wr.Write(System.Text.Encoding.ASCII.GetBytes("RIFF"));

                }
                catch (Exception ex)
                {
                    //handle exception      
                    //...

                    break;
                }
            }
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\j305\Documents\hereIam.txt"))
            {
                file.WriteLine(sb.ToString());
            }
        }
    }
}
