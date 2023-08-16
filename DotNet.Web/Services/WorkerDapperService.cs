using Dapper;
using DotNet.Web.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Web.Services
{
    public class WorkerDapperService : IWorkerMaster
    {
        private SqlConnection _Connection;

        public WorkerDapperService(IConfiguration configuration)
        {
            // SqlConnection 클래스 를 이용한 데이터 베이스 접속 경로 설정 . 
            _Connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        #region < 작업자 정보 가져오기 > 
        // Async await 를 이용한 비동기 식 데이터베이스 호출 
        public async Task<List<WorkerMaster>> GetWorkerMastersAsync()
        {
            string SelectSql = @"   SELECT WorkerId,     -- 작업자 정보
                                           SortNo,       -- 정렬순서
                                    	   FirstName,    -- 성
                                    	   LastName,     -- 이름
                                    	   DeptName,     -- 부서명
                                    	   Age,          -- 나이
                                    	   InDate,       -- 입사일자
                                    	   Salary,       -- 급여
                                    	   MakeDate,     -- 생성일시
                                    	   Maker,        -- 생성자 
                                    	   EditDate,     -- 수정일시
                                    	   Editor        -- 수정자
                                      FROM TB_WorkerMaster
                                  ORDER BY MakeDate ";

            // dapper 를 이용하여 데이터 베이스 에서 작업자 정보 가져오기
            IEnumerable<WorkerMaster> workermasters = await _Connection.QueryAsync<WorkerMaster>(SelectSql);
            return workermasters.ToList();
        }
        #endregion
    }
}




