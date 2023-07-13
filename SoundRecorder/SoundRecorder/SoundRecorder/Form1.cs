using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Data;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Channels;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Speech.V1;
using Grpc.Auth;
using System;
using System.Speech;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using NAudio.Wave;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ClientInformationServices.Services.Impl;
using ClientInformationServices.Services;

namespace SoundRecorder
{
    public partial class Form1 : Form
    {
        int s = 0;
        SpeechSynthesizer speechSynthesizerObj;
        public WaveIn _waveIn = null;
        public WaveFileWriter fileToWrite = null;
        ImageToText _imageToText = new ImageToText();
        PdfToText _pdfToText = new PdfToText();
        public Form1()
        {
            InitializeComponent();
            speechSynthesizerObj = new SpeechSynthesizer();

        }

        //[DllImport(@"C:\Users\yy23\source\repos\SoundRecorder\SoundRecorder\bin\Debug\net6.0-windows\winmm.dll", EntryPoint = "mciSendStringA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int record(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);


        private void button3_Click(object sender, EventArgs e)
        {
            s = 0;
            timer1.Enabled = false;
            if (saveFileDialog1.FileName != "")
            {
                (new Microsoft.VisualBasic.Devices.Audio()).Play(saveFileDialog1.FileName);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            s++;
            textBox1.Text = s.ToString();
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            (new Microsoft.VisualBasic.Devices.Audio()).Stop();
            record("close recsound", "", 0, 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";

            openFileDialog1.Filter = "wav (*.wav)|*.wav|All files (*.*)|*.*";
            openFileDialog1.Title = "Select audio file";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                textBox2.Text = "<Processing Audio Sample>";
                string processfile = openFileDialog1.FileName;

                GoogleCredential googleCredential;
                StringBuilder sb1 = new StringBuilder();
                using (Stream m = new FileStream(@"sidproject-2102-2360d6244d15.json", FileMode.Open))
                    googleCredential = GoogleCredential.FromStream(m);
                var client = new SpeechClientBuilder { ChannelCredentials = googleCredential.ToChannelCredentials() }.Build();

                var response = client.Recognize(new RecognitionConfig()
                {
                    Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                    //SampleRateHertz = 16000,
                    LanguageCode = "hu",
                }, RecognitionAudio.FromFile(processfile));
                foreach (var result in response.Results)
                {
                    foreach (var alternative in result.Alternatives)
                    {
                        sb1.Append((alternative.Transcript));
                    }
                }

                textBox2.Text = sb1.ToString();
            }
        }



        private void _waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (fileToWrite != null)
            {
                fileToWrite.Write(e.Buffer, 0, e.BytesRecorded); // writes bytes to the wav file
                fileToWrite.Flush();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Enabled = false;
            s = 0;
            _waveIn.StopRecording();
            fileToWrite.Dispose();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "Image files | *.png"; // file types, that will be allowed to upload
            openFileDialog1.Multiselect = false; // allow/deny user to upload more than one file at a time
            if (openFileDialog1.ShowDialog() == DialogResult.OK) // if user clicked OK
            {
                String path = openFileDialog1.FileName; // get name of file

                var txt = _imageToText.call(path);
                textBox2.Text = txt;
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            _waveIn = new WaveIn();
            _waveIn.WaveFormat = new WaveFormat(44100, 1);
            _waveIn.DataAvailable += _waveIn_DataAvailable; // event that keep listening mic

            saveFileDialog1.Filter = "wav (*.wav)|*.wav|All files (*.*)|*.*";
            saveFileDialog1.Title = "Save audio";
            saveFileDialog1.ShowDialog();
            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                s = 0;
                timer1.Enabled = true;
                timer1.Start();
                fileToWrite = new WaveFileWriter(saveFileDialog1.FileName, _waveIn.WaveFormat);
                _waveIn.StartRecording();
            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "PDF files | *.pdf"; // file types, that will be allowed to upload
            openFileDialog1.Multiselect = false; // allow/deny user to upload more than one file at a time
            if (openFileDialog1.ShowDialog() == DialogResult.OK) // if user clicked OK
            {
                String path = openFileDialog1.FileName; // get name of file

                var txt = _pdfToText.call(path);
                textBox2.Text = txt;
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Enabled = false;
            s = 0;
            _waveIn.StopRecording();
            fileToWrite.Dispose();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "";

            openFileDialog1.Filter = "wav (*.wav)|*.wav|All files (*.*)|*.*";
            openFileDialog1.Title = "Select audio file";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                textBox2.Text = "<Processing Audio Sample>";
                string processfile = openFileDialog1.FileName;

                GoogleCredential googleCredential;
                StringBuilder sb1 = new StringBuilder();
                using (Stream m = new FileStream(@"sidproject-2102-2360d6244d15.json", FileMode.Open))
                    googleCredential = GoogleCredential.FromStream(m);
                var client = new SpeechClientBuilder { ChannelCredentials = googleCredential.ToChannelCredentials() }.Build();

                var response = client.Recognize(new RecognitionConfig()
                {
                    Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                    //SampleRateHertz = 16000,
                    LanguageCode = "hu",
                }, RecognitionAudio.FromFile(processfile));
                foreach (var result in response.Results)
                {
                    foreach (var alternative in result.Alternatives)
                    {
                        sb1.Append((alternative.Transcript));
                    }
                }

                textBox2.Text = sb1.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}