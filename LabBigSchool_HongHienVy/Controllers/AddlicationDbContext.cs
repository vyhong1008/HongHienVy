using LabBigSchool_HongHienVy.Models;
using System;

namespace LabBigSchool_HongHienVy.Controllers
{
    internal class AddlicationDbContext
    {
        public object Courses { get; internal set; }

        public static implicit operator AddlicationDbContext(ApplicationDbContext v)
        {
            throw new NotImplementedException();
        }
    }
}