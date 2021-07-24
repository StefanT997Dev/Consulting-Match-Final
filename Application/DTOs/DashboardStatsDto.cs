using System.Collections.Generic;

namespace Application.DTOs
{
    public class DashboardStatsDto
    {
        public ICollection<DashboardUserDto> Followers { get; set; }=new List<DashboardUserDto>();
        public ICollection<DashboardUserDto> Following { get; set; }=new List<DashboardUserDto>();
    }
}