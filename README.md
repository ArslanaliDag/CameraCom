### Зарегистрировать библиотеку:
_C:\Windows\Microsoft.NET\Framework64\v4.0.30319\regasm.exe CameraCom.dll /codebase /tlb_

### Снять с регистрации библиотеку:
_C:\Windows\Microsoft.NET\Framework64\v4.0.30319\regasm.exe /unregister CameraCom.dll_

### В 1С:
_Камера = Новый COMОбъект("CameraCom.PhotoCamera");_
_Путь = Камера.ShowCameraAndTakePhoto();_