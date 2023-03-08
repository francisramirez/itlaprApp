namespace itlapr.BLL.Core
{
    public interface  IBaseService
    {
        ServiceResult GetAll();
        ServiceResult GetById(int Id);
    }
}
