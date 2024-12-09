namespace KR.Hanyang.Mindwatch.Domain.MlService
{
    public interface IMlService
    {
        Task<MlServiceOutput> PredictAsync(MlServiceInput input);
    }
}
