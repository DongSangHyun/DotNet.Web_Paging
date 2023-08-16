using DotNet.Web.Data;

namespace DotNet.Web.Services
{
    public interface IWorkerMaster
    {
        // 비동기 연결을 위한 Task 방식의 WorkerMaster 정보 조회 메서드
        Task<List<WorkerMaster>> GetWorkerMastersAsync();
    }
}


