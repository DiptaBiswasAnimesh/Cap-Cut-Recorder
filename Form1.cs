using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.FFMPEG;
using NAudio.Wave;

namespace Cap_Cut_Recorder
{
    public partial class Form1 : Form
    {
        private int videoCount = 0; // To track the number of recorded videos
        private VideoFileWriter writer;
        private ScreenCaptureStream screenCapture;
        private WaveInEvent waveIn;
        private MemoryStream audioStream;
        private bool isRecording = false;
        private string audioOutputPath;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isRecording)
            {
                StartRecording();
            }
            else
            {
                StopRecording();
            }
        }

        private void StartRecording()
        {
            videoCount++; // Increment video count

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string videoFileName = $"output{videoCount}.mp4"; // Use incremental file name for video
            string videoOutputPath = Path.Combine(desktopPath, videoFileName);
            string audioTempPath = Path.Combine(desktopPath, $"temp{videoCount}.aac"); // Temporary audio path

            Rectangle screenBounds = Screen.PrimaryScreen.Bounds;

            writer = new VideoFileWriter();
            writer.Open(videoOutputPath, screenBounds.Width, screenBounds.Height, 15, VideoCodec.MPEG4);

            screenCapture = new ScreenCaptureStream(screenBounds);
            screenCapture.NewFrame += ScreenCapture_NewFrame;
            screenCapture.Start();

            waveIn = new WaveInEvent();
            waveIn.DataAvailable += WaveIn_DataAvailable;
            waveIn.WaveFormat = new WaveFormat(44100, 1); // Adjust audio settings (44100 Hz, mono)
            audioStream = new MemoryStream();
            waveIn.StartRecording();

            audioOutputPath = audioTempPath;

            isRecording = true;
            button1.Text = "";
            lblRecordingStatus.Text = "Recording In Progress";
        }

        private void StopRecording()
        {
            if (isRecording)
            {
                screenCapture.SignalToStop();
                screenCapture.WaitForStop();
                writer.Close();

                waveIn.DataAvailable -= WaveIn_DataAvailable;
                waveIn.StopRecording();
                waveIn.Dispose();

                audioStream.Seek(0, SeekOrigin.Begin);

                using (FileStream fs = new FileStream(audioOutputPath, FileMode.Create))
                {
                    audioStream.CopyTo(fs);
                }

                audioStream.Dispose();

                // Use FFmpeg to merge audio and video
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string videoFileName = $"output{videoCount}.mp4";
                string audioFileName = $"temp{videoCount}.aac";
                string mergedFileName = $"merged{videoCount}.mp4";
                string mergedOutputPath = Path.Combine(desktopPath, mergedFileName);

                string ffmpegArgs = $"-i \"{videoFileName}\" -i \"{audioFileName}\" -c:v copy -c:a aac \"{mergedOutputPath}\"";
                RunFFmpegProcess(ffmpegArgs);

                // Delete temporary audio file
                File.Delete(audioOutputPath);

                isRecording = false;
                button1.Text = "";
                lblRecordingStatus.Text = "";
            }
        }
        private void RunFFmpegProcess(string arguments)
        {
            using (System.Diagnostics.Process process = new System.Diagnostics.Process())
            {
                process.StartInfo.FileName = "ffmpeg.exe";
                process.StartInfo.Arguments = arguments;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.Start();
                process.WaitForExit();
            }
        }

        private void ScreenCapture_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            writer.WriteVideoFrame(eventArgs.Frame);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CaptureScreenshot();
        }
        private void WaveIn_DataAvailable(object sender, WaveInEventArgs eventArgs)
        {
            audioStream.Write(eventArgs.Buffer, 0, eventArgs.BytesRecorded);
        }
        private void CaptureScreenshot()
        {
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string fileName = $"Screenshot_{DateTime.Now:yyyyMMddHHmmss}.png";
                string filePath = System.IO.Path.Combine(desktopPath, fileName);

                using (Bitmap screenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
                {
                    using (Graphics graphics = Graphics.FromImage(screenshot))
                    {
                        graphics.CopyFromScreen(0, 0, 0, 0, screenshot.Size);
                    }

                    screenshot.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                }

                MessageBox.Show($"Screenshot saved to:\n{filePath}", "Screenshot Captured", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error capturing screenshot: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
