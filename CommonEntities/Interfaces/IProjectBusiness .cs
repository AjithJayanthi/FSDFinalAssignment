using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonEntities.Interfaces
{
    public interface IProjectBusiness
    {
        bool AddProject(ProjectModel project);
        List<ProjectModel> GetProject(string sortParameter);

        bool DeleteProject(ProjectModel project);
    }
}
