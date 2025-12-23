using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CameraCom
{
    [ComVisible(true)]
    [Guid("A2F5C8E1-6E77-4F6C-9A11-998877665544")]
    [ProgId("CameraCom.PhotoCamera")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class PhotoCamera
    {
        public string ShowCameraAndTakePhoto()
        {
            string result = string.Empty;

            var thread = new System.Threading.Thread(() =>
            {
                using (var form = new CameraForm())
                {
                    if (form.ShowDialog() == DialogResult.OK)
                        result = form.SavedFilePath;
                }
            });

            thread.SetApartmentState(System.Threading.ApartmentState.STA);
            thread.Start();
            thread.Join();

            return result;
        }
    }
}
