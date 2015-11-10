namespace Platform.Core.Layout
{
    public class AppLayout
    {
        public string SetTitle
        {
            set {
                _Title = value + " - " + _Title;
            }
        }

        public string _Title { get; set; }

        public string _Descript { get; set; }

        public string _Keywords { get; set; }
    }
}
