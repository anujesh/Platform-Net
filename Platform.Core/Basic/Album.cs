namespace Platform.Core.Basic
{
    // item
    public class Album : AlonModel
    {
        public string Descript { get; set; }
    }

    // List
    public class Albums : CoreList<Album>
    {
    }

    // Response
    public class rpAlbum : ResponseItem<Album>
    {
    }

    public class rpAlbums : ResponseItem<Albums>
    {
    }
}
