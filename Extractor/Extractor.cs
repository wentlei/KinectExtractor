using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KinectXEFTools;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Threading;

namespace Extractor
{
    public partial class Extractor: Form
    {
        static bool videoFlag = false;
        static bool skeletonFlag = false;
        static bool audioFlag = false;
        static bool depthFlag = false;
        static bool resumeFlag = false;
        static bool stdinFlag = false;
        string fileSavedName;
        private delegate void delInfoList(string text);
        // public string objectNumberText;
        public Extractor()
        {
            InitializeComponent();
        }
        /// <summary>
        ///  开始提取按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStartExtract_Click(object sender, EventArgs e)
        {
            if (checkBoxDepth.Checked == false && checkBoxVideo.Checked == false && checkBoxSkeleton.Checked == false && allModalityCheck.Checked == false && checkBoxAudio.Checked ==false)
            {
                MessageBox.Show("Please select one modality!\n");  // 确定最少有一种数据流被选择
            }
            else
            {
                if (textBoxXefFolder.Text == "")
                {
                    MessageShowing("Check the input XEF file!\n");
                }
                else 
                {
                    if (objectNumber.Text == "")
                    {
                        MessageShowing("Please enter the object humber!\n");
                    }
                    else
                    {
                        string[] filename;
                        filename = new string[] { textBoxXefFolder.Text };
                        fileSavedName = textBoxSaveFolder.Text + "//" + objectNumber.Text; //objectNumber---实验对象编号
                        ModalityCheck(filename, fileSavedName);
                        MessageShowing("Done.\n");
                    }
                } 
            }
        }
        /// <summary>
        /// 选择打开文件夹中的.xef文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonXefBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Title = "Please select the xef files!";
            dialog.Filter = "Xef files(*.xef)|*.xef*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string file = dialog.FileName;
                textBoxXefFolder.Text = file;
            }
        }
        private void buttonFileSaved_Click(object sender, EventArgs e)
        {
            SavedExtractFile();
        }
        #region
        /// <summary>
        /// Use the radio button for fps setting;
        /// </summary>
        /// <returns></returns>
        public int FpsSetting()
        {
            int fps = 30;
            if (radioButton30fps.Checked) fps = 30;
            if (radioButton60fps.Checked) fps = 60;
            return fps;
        }
        /// <summary>
        /// 确认最少有一种模态被选择，且数据将被保存到所选文件夹中；
        /// </summary>
        /// <param name="xefFile"></param>
        public void ModalityCheck(string[] xefFile, string fileName)
        {
            if (checkBoxVideo.Checked)
            {
                videoFlag = true;
            }
            if (checkBoxSkeleton.Checked)
            {
                skeletonFlag = true;
            }
            if (checkBoxDepth.Checked)
            {
                depthFlag = true;
            }
            if (checkBoxAudio.Checked)
            {
                audioFlag = true;
            }
            if (allModalityCheck.Checked)
            {
                videoFlag = true;
                skeletonFlag = true;
                depthFlag = true;
                audioFlag = true;
            }
            // xef file path
            var path = xefFile[xefFile.Length - 1];
            if (path.StartsWith("-"))
            {
                MessageShowing("No input file/directory provided.\n");
            }
            else if (stdinFlag)
            {
                using (XEFDataConverter xdc = new XEFDataConverter()
                {
                    UseVideo = videoFlag,
                    UseSkeleton = skeletonFlag,
                    UseDepth = depthFlag,
                    UseAudio = audioFlag,
                    ResumeConversion = resumeFlag
                })
                {
                    using (Stream stdin = Console.OpenStandardInput())
                    {
                        Thread newExt = new Thread(() => xdc.ConvertFile(path, fileName, stdin));
                        newExt.Start();
                        // xdc.ConvertFile(path, fileName,stdin);
                    }
                }
            }
            else if (Directory.Exists(@path))
            {
                DirectoryInfo di = new DirectoryInfo(path);
                ParseDirectory(di);
            }
            else if (File.Exists(@path))
            {
                FileInfo file = new FileInfo(@path);
                if (file.Extension != ".xef")
                {
                    MessageShowing("File " + path + " is not a .xef file.\n");
                    return;
                }
                MessageShowing("Processing " + file.Name + "\n");
                // Convert the file
                using (XEFDataConverter xdc = new XEFDataConverter()
                {
                    UseVideo = videoFlag,
                    UseSkeleton = skeletonFlag,
                    UseDepth = depthFlag,
                    UseAudio = audioFlag,
                    ResumeConversion = resumeFlag
                })
                {
                    Thread newExt = new Thread(() => xdc.ConvertFile(file.FullName, fileName));
                    newExt.Start();
                    // xdc.ConvertFile(file.FullName, fileName);  // start processing
                }
                // MessageShowing("Done.\n");
            }
            else
            {
                MessageShowing("Input " + path + " Does not Exist.\n");
            }
        }
        public string SavedExtractFile() 
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.Description = "Please select the folder.\n";
            if(folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string extractPath = folderBrowser.SelectedPath;
                textBoxSaveFolder.Text = extractPath;
            }
            return textBoxSaveFolder.Text;
        }
        /// <summary>
        /// Processing message showing
        /// </summary>
        /// <param name="mess"></param>
        public void MessageShowing(string mess)
        {
            if (richTextBoxMessage.InvokeRequired)
            {
                delInfoList delInfo = new delInfoList(MessageShowing);
                richTextBoxMessage.Invoke(delInfo, mess);
            }
            else
            {
                if (richTextBoxMessage.Lines.Length > 300) // >300 messages, clean
                {
                    richTextBoxMessage.Clear();
                }
                richTextBoxMessage.Focus();
                richTextBoxMessage.Select(richTextBoxMessage.TextLength, 0);
                richTextBoxMessage.ScrollToCaret();
                richTextBoxMessage.AppendText(mess);
            }
        }
        /// <summary>
        /// XEF files processing method
        /// </summary>
        /// <param name="di"></param>
        public void ParseDirectory(DirectoryInfo di)
        {
            MessageShowing("Parsing Directory " + di.Name + ".\n");
            var files = from f in di.EnumerateFiles()
                        where f.Extension == ".xef"
                        select f;

            foreach (FileInfo f in files)
            {
                MessageShowing("Processing " + f.Name + ".\n");
                // Convert the file
                using (XEFDataConverter xdc = new XEFDataConverter()
                {
                    UseVideo = videoFlag,
                    UseSkeleton = skeletonFlag,
                    UseDepth = depthFlag,
                    UseAudio = audioFlag,
                    ResumeConversion = resumeFlag
                })
                {
                    fileSavedName = textBoxSaveFolder.Text + "//" + objectNumber.Text;
                    Thread newExt = new Thread(() => xdc.ConvertFile(f.FullName, fileSavedName));
                    newExt.Start();
                    //xdc.ConvertFile(f.FullName, fileSavedName);
                }
                MessageShowing("Done!\n");
            }

            foreach (DirectoryInfo d in di.EnumerateDirectories())
            {
                ParseDirectory(d);
            }
        }
        /// <summary>
        /// int totalFrames为总的视频帧数
        /// </summary>
        /// <param name="totalFrames"></param>
        private void ExtractingBar(int totalFrames)
        {
            processingBar.Visible = true;
            processingBar.Minimum = 1;
            processingBar.Maximum = totalFrames;  // 定义视频总的帧数
            processingBar.Value = 1; // 设定初始处理值
            for (int i =1; i <= totalFrames; i++)
            {

                processingBar.PerformStep();
            }
        }
        #endregion
    }
    /// <summary>
    /// 当某种数据流被选择后，所要执行的数据提取过程
    /// </summary>
    public class XEFDataConverter : IDisposable
    {
        //
        //  Properties
        //
        public bool UseVideo { get; set; }
        public bool UseSkeleton { get; set; }
        public bool UseDepth { get; set; }
        public bool ResumeConversion { get; set; }
        public bool UseAudio { get; set; }
        public int frameIndex { get; set; }
        //
        //  Constructor
        //
        public XEFDataConverter()
        {
        }
        ~XEFDataConverter()
        {
            Dispose(false);
        }
        Extractor ext = new Extractor();   // refer Extract  class for radioButton value return.
        //
        //	IDisposable
        //
        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources
                }
                disposed = true;
            }
        }
        //
        //  Methods
        //
        public void ConvertFile(string path, string savedPath, Stream input = null)
        {
            //
            //  Set up filenames
            //
            // string baseXefPath = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path));
            string basePath = savedPath;
            string rgbVideoPath = basePath + "_RGB.mp4";
            string wavAudioPath = basePath + "_Audio.wav";
            // string fulVideoPath = basePath + "_Video.avi"; // remove the .avi video file output;
            string skeletonPath = basePath + "_Skeleton.csv";
            string depthDatPath = basePath + "_Depth.dat";  // .dat file for depth sensor file output;

            bool videoFlag = UseVideo;
            bool skeletonFlag = UseSkeleton;
            bool depthFlag = UseDepth;
            bool audioFlag = UseAudio;
            // Check if files exist (disable flags if found)
            if (ResumeConversion)
            {
                if (File.Exists(rgbVideoPath)) videoFlag = false;
                if (File.Exists(skeletonPath)) skeletonFlag = false;
                if (File.Exists(depthDatPath)) depthFlag = false;
                if (File.Exists(wavAudioPath)) audioFlag = false;
            }
            // Start parsing events
            try
            {
                //
                //  Set up XEF data converters/writers
                //
                List<IXEFDataWriter> dataWriters = new List<IXEFDataWriter>();

                if (videoFlag)
                {
                    
                    int fpsValue;
                    fpsValue = ext.FpsSetting();
                    dataWriters.Add(new XEFColorWriter(rgbVideoPath, fpsValue));
                }
                if (audioFlag)
                {
                    dataWriters.Add(new XEFAudioWriter(wavAudioPath));
                }
                if (skeletonFlag)
                {
                    dataWriters.Add(new XEFBodyWriter(skeletonPath));
                }
                if (depthFlag)
                {
                    dataWriters.Add(new XEFDepthWriter(depthDatPath));
                }
                if (dataWriters.Count == 0)
                {
                    ext.MessageShowing("Skipped: " + basePath + ".\n");
                    return;
                }

                //
                //  Process events
                //

                using (IEventReader reader = (input == null) ? new XEFEventReader(path) : new XEFEventStreamReader(input) as IEventReader)
                {
                    XEFEvent ev;
                    while ((ev = reader.GetNextEvent()) != null)
                    {
                        foreach (IXEFDataWriter dataWriter in dataWriters)
                        {
                            dataWriter.ProcessEvent(ev);
                        }
                    }
                }
                //
                //  Finalization
                //
                foreach (IXEFDataWriter dataWriter in dataWriters)
                {
                    dataWriter.Close();
                }

                if (videoFlag)  // 当开始提取视频格式的时候，将会执行FFMPEG command
                {
                    // First determine if there were any audio events processed
                    bool containsAudio = false;
                    foreach (IXEFDataWriter dataWriter in dataWriters)
                    {
                        if (dataWriter.GetType() == typeof(XEFAudioWriter))
                        {
                            containsAudio = dataWriter.EventCount > 0;
                        }
                    }
                    // Mux color and audio files into one video file
                    using (Process ffmpegProc = new Process())
                    {
                        ffmpegProc.StartInfo = new ProcessStartInfo()
                        {
                            // CreateNoWindow = false,
                            FileName = "ffmpeg",
                            Arguments =
                                $"-v quiet " +
                                $"-i \"{rgbVideoPath}\" " +
                                (containsAudio ? $"-i \"{wavAudioPath}\" " : "") +
                                $"-codec copy " +
                                $"-shortest " +
                                $"-y ",
                            UseShellExecute = false,
                            CreateNoWindow = false,
                        };
                        ffmpegProc.Start();
                        ffmpegProc.WaitForExit();
                    }
                }
            }
            catch (Exception)
            {
                ext.MessageShowing("Error processing file!");
                ext.MessageShowing("Exception thrown!");
                return;
            }
        }
    }
}
