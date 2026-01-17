using System;
using System.Drawing;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;


// Тут последние ответы показывают как взаимодействовать с бэкендом отправляя фото как байты
// https://chat.deepseek.com/share/b9wyjobsbobbe5djx1

namespace CameraCom
{
    public partial class CameraForm : Form
    {
        private VideoCaptureDevice _camera;
        private Bitmap _currentFrame;
        public string SavedFilePath { get; private set; }
        public CameraForm()
        {
            InitializeComponent();
            LoadCameras();
        }

        private void LoadCameras()
        {
            var devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in devices)
                cmbCameras.Items.Add(device);

            if (cmbCameras.Items.Count > 0)
                cmbCameras.SelectedIndex = 0;
        }

        private void LoadResolutions()
        {
            cmbResolution.Items.Clear();
            foreach (var cap in _camera.VideoCapabilities)
                cmbResolution.Items.Add($"{cap.FrameSize.Width}x{cap.FrameSize.Height}");

            cmbResolution.SelectedIndex = 0;
        }

        private void Camera_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            _currentFrame?.Dispose();
            _currentFrame = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = (Bitmap)_currentFrame.Clone();
        }

        private void cmbCameras_SelectedIndexChanged(object sender, EventArgs e)
        {
            var device = (FilterInfo)cmbCameras.SelectedItem;
            _camera = new VideoCaptureDevice(device.MonikerString);
            LoadResolutions();
        }

        //private void btnPhoto_Click(object sender, EventArgs e)
        //{
        //    if (_currentFrame == null)
        //        return;

        //    using (var dlg = new SaveFileDialog
        //    {
        //        Filter = "JPEG (*.jpg)|*.jpg|PNG (*.png)|*.png"
        //    })
        //    {
        //        if (dlg.ShowDialog() == DialogResult.OK)
        //        {
        //            _currentFrame.Save(dlg.FileName);
        //            SavedFilePath = dlg.FileName;
        //            DialogResult = DialogResult.OK;
        //            Close();
        //        }
        //    }
        //}
        private async void btnPhoto_Click(object sender, EventArgs e)
        {
            if (_currentFrame == null)
                return;

            try
            {
                btnPhoto.Enabled = false;

                string json = await UploadPhotoAsync(_currentFrame);

                SavedFilePath = json; // теперь тут JSON
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки: " + ex.Message);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_camera != null && _camera.IsRunning)
            {
                _camera.SignalToStop();
                _camera.WaitForStop();
            }
            base.OnFormClosing(e);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            StartCamera();
        }
        private void StartCamera()
        {
            var devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (devices.Count == 0)
                throw new Exception("Камера не найдена");

            _camera = new VideoCaptureDevice(devices[0].MonikerString);
            _camera.NewFrame += Camera_NewFrame;
            _camera.Start();
        }

        private async Task<string> UploadPhotoAsync(Bitmap bitmap)
        {
            using (var client = new HttpClient())
            using (var ms = new System.IO.MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                ms.Position = 0;

                var content = new MultipartFormDataContent();

                var imageContent = new ByteArrayContent(ms.ToArray());
                imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");

                content.Add(imageContent, "file", "photo.jpg");

                var response = await client.PostAsync(
                    "http://192.168.30.171:8010/api/v1/upload",
                    content
                );

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
