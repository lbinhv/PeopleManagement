
namespace PeopleManagement.Service.CommonViewModels
{
    public class ErrorModel
    {
        public bool IsError { get; set; }
        public string ErrorContent { get; set; }
        public string Element { get; set; }

        public ErrorModel()
        {
            IsError = false;
        }
    }
}
