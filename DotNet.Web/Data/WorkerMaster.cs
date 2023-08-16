using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace DotNet.Web.Data
{
    public class WorkerMaster
    {
        [Required]
        public int SortNo { get; set; }

        [Key]
        public string WorkerId { get; set; } = Guid.NewGuid().ToString(); // 기본값 GUID 값으로 설정

        [Required(ErrorMessage ="이름 을 입력 하세요")]
        [Display(Name ="이름")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "성 을 입력 하세요")]
        [Display(Name = "성")]
        public string LastName { get; set; }

        [NotMapped] // 데이터 베이스의 컬럼 모델로 인식하지 않음
        public string UserName => LastName + " " + FirstName;

        [Required(ErrorMessage = "부서 를 입력하세요")]
        [Display(Name = "부서")]
        public string DeptName { get; set; }

        [Display(Name ="나이")]
        public int? Age { get; set; }

        [Required(ErrorMessage ="입사일자 를 입력하세요")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name ="입사 일자")]
        public DateTime InDate { get; set; } = DateTime.Now;

        [NotMapped] // 입사 일자 를 일자 문자열로 사용함. (데이터베이스 컬럼 미처리)
        public string InDateString => InDate.ToShortDateString();

        [Required(ErrorMessage = "급여를 입력하세요")]
        [DataType(DataType.Currency)] // 통화 
        [Display(Name = "급여")]
        public int Salary { set; get; } = 0;

        [NotMapped]
        public string SalaryString => Salary.ToString("###,###,###") + " ￦";

        [DataType(DataType.Date)]
        public DateTime? MakeDate { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        public string? Maker { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EditDate { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        public string? Editor { get; set; } 
    }
}


