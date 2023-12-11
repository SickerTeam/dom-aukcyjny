using backend.DTOs;
using backend.Models;

namespace backend.Services
{
    public interface IPictureService
    {
        Task<IList<PictureDTO>> GetPicturesAsync();
        Task<PictureDTO> GetPicturesByIdAsync(int id);
        Task AddPicturesAsync(PictureRegistrationDTO pictureDto);
        Task DeletePicturesAsync(int id);
    }

}
