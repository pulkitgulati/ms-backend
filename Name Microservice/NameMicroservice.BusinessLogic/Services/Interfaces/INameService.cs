using NameMicroservice.DTO.DTO;

namespace NameMicroservice.BusinessLogic.Services.Interfaces
{
    public interface INameService
    {
        public string InsertNameData(NameData nameData);
        public List<NameData> GetAllNameData();
        public NameData GetNameData(int personID);
    }
}
