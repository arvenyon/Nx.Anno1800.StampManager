namespace WinClient.Utils.Extensions.ExtensionModels
{
    public class ViewState
    {
        public ViewState(double posX, double posY, double width, double height, bool isMaximized = true)
        {
            PosX=posX;
            PosY=posY;
            Width=width;
            Height=height;
            IsMaximized=isMaximized;
        }

        public double PosX { get; set; }
        public double PosY { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public bool IsMaximized { get; set; }
    }
}
