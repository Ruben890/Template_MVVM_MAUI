namespace UI.Shared.Utils
{
    public class PathHelper
    {
        private readonly IDeviceInfo _deviceInfo;

        public PathHelper(IDeviceInfo deviceInfo)
        {
            _deviceInfo = deviceInfo ?? throw new ArgumentNullException(nameof(deviceInfo));
        }

        public string GetLynxFolder()
        {
            string lynxFolder;

            if (_deviceInfo.Platform == DevicePlatform.Android)
            {
#if ANDROID
                var filesPath = Android.App.Application.Context?.FilesDir?.AbsolutePath;
                if (string.IsNullOrEmpty(filesPath))
                    throw new InvalidOperationException("FilesDir is not available on this Android device.");

                lynxFolder = Path.Combine(filesPath, "Lynx");
#else
                throw new PlatformNotSupportedException("Android code executed on non-Android platform.");
#endif
            }
            else if (_deviceInfo.Platform == DevicePlatform.iOS ||
                     _deviceInfo.Platform == DevicePlatform.MacCatalyst)
            {
                var docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var libPath = Path.Combine(docsPath, "..", "Library");
                lynxFolder = Path.Combine(libPath, "Lynx");
            }
            else if (_deviceInfo.Platform == DevicePlatform.WinUI)
            {
                var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                lynxFolder = Path.Combine(localAppData, "Lynx");
            }
            else
            {
                var homePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                lynxFolder = Path.Combine(homePath, ".lynx");
            }

            // Solo crea la carpeta si no existe
            if (!Directory.Exists(lynxFolder))
            {
                Directory.CreateDirectory(lynxFolder);
            }

            return lynxFolder;
        }
    }
}
