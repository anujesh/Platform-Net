namespace Platform.Core.Interface
{
    public interface IFixyRepo
    {
        bool FixById(int thisId, int correctId);
    }
}
