# Screen Recording and Screenshot Capture App

This is a simple Windows application that allows you to record your screen and capture screenshots. It uses the AForge.Video and NAudio libraries for video and audio recording, and it utilizes FFmpeg for merging audio and video files. The application is built using C# and Windows Forms.

## Features

- Record your screen as a video.
- Capture screenshots of your screen.
- Record audio while capturing video.
- Merge audio and video files to create playable video recordings.

## Prerequisites

- Visual Studio (or any other C# IDE)
- FFmpeg executable (added to system PATH)

## Installation and Usage

1. Clone or download this repository.

2. Install the required NuGet packages:
   - AForge.Video
   - NAudio

3. Download FFmpeg from the official website (https://ffmpeg.org/download.html) and add the folder containing `ffmpeg.exe` to your system's PATH environment variable.

4. Open the solution in Visual Studio.

5. Build and run the application.

6. Click the "REC" button to start recording your screen.
   - Click the "Stop Recording" button to stop the recording.
   - The recorded video will be saved on your Desktop with an incremental filename (e.g., output1.mp4).

7. Click the "Capture Screenshot" button to capture a screenshot of your screen.
   - The screenshot will be saved on your Desktop with a timestamped filename (e.g., Screenshot_20230819123456.png).

8. You can adjust the video and audio settings within the code to suit your preferences.

## Credits

- AForge.NET Framework: https://github.com/andrewkirillov/AForge.NET
- NAudio Library: https://github.com/naudio/NAudio
- FFmpeg: https://ffmpeg.org/

## License


Feel free to fork, modify, and use this project according to your needs.
