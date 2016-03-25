namespace Platform.Core
{
    public class ResponseItem<T>
    {
        public ResponseItem()
        {
            error = 0;
            status = "OK";
            able = new Able();
        }

        public T data { get; set; }

        public int error { get; set; }

        public string status { get; set; }

        public Able able { get; set; }
    }

    public class ResponseList<Ts>
    {
        public ResponseList()
        {
            error = 0;
            status = "OK";
        }

        public Ts  data {get; set;}

        public int error { get; set; }

        public string status { get; set; }
    }

    public class Paging
    {
        public Paging()
        {
            total = 0;
            page= 0;
            start = 0;
            limit = 0;
            page = 0;
            active = false;
        }

        public int total { get; set; }

        public int pages { get; set; }

        public int start { get; set; }

        public int limit { get; set; }

        public int page { get; set; }

        public bool active { get; set; }
    }

    public class Summary
    {
        public Summary()
        {
            total = 0;
        }

        public int total { get; set; }
    }

    public class DOB
    {
        public int Day { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }
    }

    public class Able
    {
        public Able()
        {
            IsEdit = false;

            IsView = false;
            IsDelete = false;
            IsCreate = false;
            IsClone = false;
        }

        public bool IsEdit { get; set; }

        public bool IsView { get; set; }

        public bool IsDelete { get; set; }

        public bool IsCreate { get; set; }

        public bool IsClone { get; set; }
    }
}
