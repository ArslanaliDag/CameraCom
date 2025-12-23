namespace CameraCom
{
    partial class CameraForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmbCameras;
        private System.Windows.Forms.ComboBox cmbResolution;
        //private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPhoto;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmbCameras = new System.Windows.Forms.ComboBox();
            this.cmbResolution = new System.Windows.Forms.ComboBox();
            //this.btnStart = new System.Windows.Forms.Button();
            this.btnPhoto = new System.Windows.Forms.Button();

            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.cmbCameras.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbCameras.SelectedIndexChanged += cmbCameras_SelectedIndexChanged;

            this.cmbResolution.Dock = System.Windows.Forms.DockStyle.Top;

            //this.btnStart.Text = "Запустить камеру";
            //this.btnStart.Dock = System.Windows.Forms.DockStyle.Top;
            //this.btnStart.Click += btnStart_Click;

            this.btnPhoto.Text = "Сфотографировать";
            this.btnPhoto.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnPhoto.Click += btnPhoto_Click;

            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnPhoto);
            //this.Controls.Add(this.btnStart);
            this.Controls.Add(this.cmbResolution);
            this.Controls.Add(this.cmbCameras);

            this.Text = "Камера";
            this.Width = 800;
            this.Height = 600;
        }

        #endregion
    }
}