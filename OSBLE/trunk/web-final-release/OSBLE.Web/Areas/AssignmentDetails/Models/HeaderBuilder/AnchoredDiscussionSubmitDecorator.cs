﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OSBLE.Resources;
using OSBLE.Models.Assignments;
using OSBLE.Models.Courses;
using System.Runtime.Caching;
using OSBLE.Utility;
using OSBLE.Controllers;

namespace OSBLE.Areas.AssignmentDetails.Models.HeaderBuilder
{
    //TODO: DMO: check basic controller for details
    public class AnchoredDiscussionSubmitDecorator : HeaderDecorator
    {
        public CourseUser Student { get; set; }

        public AnchoredDiscussionSubmitDecorator(IHeaderBuilder builder, CourseUser student)
            : base(builder)
        {
            Student = student;
        }

        public override DynamicDictionary BuildHeader(Assignment assignment)
        {
            //TODO:clear out the un-needed actions here

            dynamic header = Builder.BuildHeader(assignment);
            header.CRSubmission = new DynamicDictionary();
            header.Assignment = assignment;

            // get the assignment team ( team doing the review )
            AssignmentTeam assignmentTeam = null;
            foreach (AssignmentTeam at in assignment.AssignmentTeams)
            {
                foreach (TeamMember tm in at.Team.TeamMembers)
                {
                    if (tm.CourseUser.UserProfileID == Student.UserProfileID )
                    {
                        assignmentTeam = at;
                    }
                }
            }         

            header.CRSubmission.hasSubmitted = false;
            

            if (assignmentTeam != null)
            {
                List<ReviewTeam> authorTeams = new List<ReviewTeam>();
                authorTeams = (from rt in assignment.ReviewTeams
                               where rt.ReviewTeamID == assignmentTeam.TeamID
                               select rt).ToList();
                header.CRSubmission.authorTeams = authorTeams;
                header.CRSubmission.assignmentId = assignment.ID;

                List<DateTime?> submissionTimes = new List<DateTime?>();  

                //pass submission times to view
                header.CRSubmission.submissionTimes = submissionTimes;
                //header.CRSubmission.authorSubmissionTimes = authorSubmissionTimes;

                if (assignment.HasTeams)
                {
                    header.CRSubmission.hasTeams = true;
                }
                else
                {
                    header.CRSubmission.hasTeams = false;
                }
            }

            FileCache Cache = FileCacheHelper.GetCacheInstance(OsbleAuthentication.CurrentUser);
            //Same functionality as in the other controller. Note: These values are set in SubmissionController/Create[POST]
            //did the user just submit something?  If so, set up view to notify user
            if (Cache["SubmissionReceived"] != null && Convert.ToBoolean(Cache["SubmissionReceived"]) == true)
            {
                header.CRSubmission.SubmissionReceived = true;
                header.CRSubmission.AuthorTeamId = (int)Cache["SubmissionForAuthorTeamID"];
                Cache["SubmissionReceived"] = false;
            }
            else
            {
                header.CRSubmission.SubmissionReceived = false;
                Cache["SubmissionReceived"] = false;
            }

            //rubric stuff:
            header.CRSubmission.hasStudentRubric = assignment.HasStudentRubric;
            header.CRSubmission.studentRubricID = assignment.StudentRubricID;
           
            return header;
        }
    }
}
