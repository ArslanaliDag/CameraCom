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
            this.btnPhoto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(784, 496);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // cmbCameras
            // 
            this.cmbCameras.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbCameras.Location = new System.Drawing.Point(0, 0);
            this.cmbCameras.Name = "cmbCameras";
            this.cmbCameras.Size = new System.Drawing.Size(784, 21);
            this.cmbCameras.TabIndex = 3;
            // 
            // cmbResolution
            // 
            this.cmbResolution.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbResolution.Location = new System.Drawing.Point(0, 21);
            this.cmbResolution.Name = "cmbResolution";
            this.cmbResolution.Size = new System.Drawing.Size(784, 21);
            this.cmbResolution.TabIndex = 2;
            // 
            // btnPhoto
            // 
            this.btnPhoto.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnPhoto.Location = new System.Drawing.Point(0, 538);
            this.btnPhoto.Name = "btnPhoto";
            this.btnPhoto.Size = new System.Drawing.Size(784, 23);
            this.btnPhoto.TabIndex = 1;
            this.btnPhoto.Text = "Найти товар";
            this.btnPhoto.Click += new System.EventHandler(this.btnPhoto_Click);
            // 
            // CameraForm
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnPhoto);
            this.Controls.Add(this.cmbResolution);
            this.Controls.Add(this.cmbCameras);
            this.Name = "CameraForm";
            this.Text = "Камера";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}