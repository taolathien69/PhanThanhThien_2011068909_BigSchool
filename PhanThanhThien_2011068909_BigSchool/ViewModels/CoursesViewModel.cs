using PhanThanhThien_2011068909_BigSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhanThanhThien_2011068909_BigSchool.ViewModels
{
    public class CoursesViewModel
    {
        public IEnumerable<Course> UpcommingCourse { get; set; }
        public bool ShowAction { get; set; }
    }
}