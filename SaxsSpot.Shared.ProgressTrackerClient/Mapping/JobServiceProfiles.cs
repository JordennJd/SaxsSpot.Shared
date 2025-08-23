using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using SaxsSpot.Shared.ProgressTrackerClient.Contracts.Models;
using System;

namespace SaxsSpot.Shared.ProgressTrackerClient.Mapping
{
    public class JobServiceProfiles : Profile
    {
        public JobServiceProfiles()
        {
            CreateMap<Timestamp, DateTime>().ConvertUsing(t => t.ToDateTime());
            CreateMap<DateTime, Timestamp>().ConvertUsing(d => Timestamp.FromDateTime(d));
            CreateMap<Timestamp, DateTime?>().ConvertUsing(t => t == null ? null : t.ToDateTime());
            CreateMap<DateTime?, Timestamp>().ConvertUsing(d => d == null ? null : Timestamp.FromDateTime(d.Value));

            // Result
            CreateMap<Result, JobCommandResult>()
                .ReverseMap();

            // GetJobQuery
            CreateMap<GetJobQuery, Contracts.Models.GetJobQuery>()
                .ReverseMap();

            // GetJobResult
            CreateMap<GetJobResult, Contracts.Models.GetJobResult>()
                .ForMember(dest => dest.Job, opt => opt.MapFrom(src => src.Job))
                .ReverseMap();

            CreateMap<GetJobsResult, Contracts.Models.GetJobsResult>()
                .ForMember(dest => dest.Jobs, opt => opt.MapFrom(src => src.Jobs))
                .ReverseMap();

            CreateMap<Job, Contracts.Models.Job>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.FinishedAt, opt => opt.MapFrom(src => 
                    src.FinishedAt != null ? src.FinishedAt.ToDateTime() : (DateTime?)null))
                .ReverseMap()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => 
                    Timestamp.FromDateTime(src.CreatedAt)))
                .ForMember(dest => dest.FinishedAt, opt => opt.MapFrom(src => 
                    src.FinishedAt.HasValue ? Timestamp.FromDateTime(src.FinishedAt.Value) : null));

            CreateMap<ChangeJobMessageQuery, Contracts.Models.ChangeJobMessageQuery>()
                .ReverseMap();
            
            CreateMap<CreateJobQuery, Contracts.Models.CreateJobQuery>()
                .ReverseMap();

            CreateMap<StartJobQuery, Contracts.Models.StartJobQuery>()
                .ReverseMap();

            CreateMap<CompleteJobQuery, Contracts.Models.CompleteJobQuery>()
                .ReverseMap();

            CreateMap<SetProgressQuery, Contracts.Models.SetProgressQuery>()
                .ReverseMap();

            CreateMap<GetNextJobRequest, Contracts.Models.GetNextJobRequest>()
                .ReverseMap();

            CreateMap<GetWorkingJobRequest, Contracts.Models.GetWorkingJobRequest>()
                .ReverseMap();
        }
    }
}