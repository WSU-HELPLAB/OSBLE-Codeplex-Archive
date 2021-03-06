﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OSBLE.Areas.AssignmentWizard.Models;
using OSBLE.Models.Assignments;
using OSBLE.Models.Courses;
using OSBLE.Models.Assessments;

namespace OSBLE.Areas.AssessmentWizard.Controllers
{
    public class ReviewOfStudentWorkController : AssessmentBaseController
    {

        public override string PrettyName
        {
            get { return "Review Of Student Work"; }
        }

        public override string ControllerName
        {
            get { return "ReviewOfStudentWork"; }
        }

        public override string ControllerDescription
        {
            get
            {
                return "More detailed information about a student work review.";
            }
        }

        public override IWizardBaseController Prerequisite
        {
            get
            {
                return new AssessmentBasicsController();
            }
        }

        public override ICollection<AssessmentType> ValidAssessmentTypes
        {
            get
            {
                List<AssessmentType> Assessments = new List<AssessmentType>();
                Assessments.Add(AssessmentType.ReviewOfStudentWork);
                return Assessments;
            }
        }

        public override bool IsRequired
        {
            get
            {
                return true;
            }
        }

        public override ActionResult Index()
        {
            base.Index();
            Assessment.Type = manager.ActiveAssessmentType;
            return View(Assessment);
        }

        [HttpPost]
        public ActionResult Index(Assessment model)
        {
            Assessment = db.Assessments.Find(model.ID);
            return base.PostBack(model);
        }
    }
}
