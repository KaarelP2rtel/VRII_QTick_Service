using BL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Interfaces
{
    public interface IPerformanceService
    {
        List<PerformanceDTO> GetPerformances();
        List<PerformanceDTO> GetPerformancesWithPerformers();
        PerformanceDTO GetPerformanceById(int id);
        PerformanceDTO GetPerformanceByIdWithPerformer(int id);
        PerformanceDTO AddNewPerformance(PerformanceDTO newPerformance);
        PerformanceDTO AddPerformerToPerformance(PerformancePerformerDTO dto);
        bool DeletePerformance(int id);
        PerformanceDTO UpdatePerformance(PerformanceDTO performance);
        bool RemovePerformerFromPerformance(int performanceId, int performerId);
        List<PerformanceDTO> GetPerformancesForEvent(int id);
    }
}
