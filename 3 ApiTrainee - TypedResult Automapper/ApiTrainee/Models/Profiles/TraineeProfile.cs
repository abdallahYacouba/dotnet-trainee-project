using ApiTrainee.Models.Entities;
using ApiTrainee.Models.ModelWrapper;
using AutoMapper;

namespace ApiTrainee.Models.Profiles;

public class TraineeProfile : Profile
{
    public TraineeProfile()
    {
        CreateMap<Trainee, TraineeDto>();   
        CreateMap<TraineeForCreatingDto, Trainee>();   
        CreateMap<TraineeForUpdatingDto, Trainee>();   
        
    }
}
