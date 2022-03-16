using NameMicroservice.DTO;
using NameMicroservice.DTO.DTO;

namespace NameMicroservice.DAL.Repository.Interfaces
{
    public interface INameRepository
    {
        public string InsertNameData(NameData nameData);
        public List<NameData> GetAllNameData();
        public NameData GetNameData(int personID);
    }
}
