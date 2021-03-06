﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17626
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OSBLE.UnitTests.OsbleService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="", ConfigurationName="OsbleService.OsbleService")]
    public interface OsbleService {
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:OsbleService/GetCourses", ReplyAction="urn:OsbleService/GetCoursesResponse")]
        OSBLE.Models.Courses.Course[] GetCourses(string authToken);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:OsbleService/GetCourseAssignments", ReplyAction="urn:OsbleService/GetCourseAssignmentsResponse")]
        OSBLE.Models.Assignments.Assignment[] GetCourseAssignments(int courseId, string authToken);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:OsbleService/GetMergedReviewDocument", ReplyAction="urn:OsbleService/GetMergedReviewDocumentResponse")]
        byte[] GetMergedReviewDocument(int criticalReviewAssignmentId, string authToken);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:OsbleService/GetReviewItems", ReplyAction="urn:OsbleService/GetReviewItemsResponse")]
        byte[] GetReviewItems(int assignmentId, string authToken);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:OsbleService/SubmitReview", ReplyAction="urn:OsbleService/SubmitReviewResponse")]
        bool SubmitReview(int authorId, int assignmentId, byte[] zippedReviewData, string authToken);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:OsbleService/GetAssignmentSubmission", ReplyAction="urn:OsbleService/GetAssignmentSubmissionResponse")]
        byte[] GetAssignmentSubmission(int assignmentId, string authToken);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:OsbleService/GetCourseRole", ReplyAction="urn:OsbleService/GetCourseRoleResponse")]
        OSBLE.Models.Courses.CourseRole GetCourseRole(int courseId, string authToken);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:OsbleService/SubmitAssignment", ReplyAction="urn:OsbleService/SubmitAssignmentResponse")]
        bool SubmitAssignment(int assignmentId, byte[] zipData, string authToken);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface OsbleServiceChannel : OSBLE.UnitTests.OsbleService.OsbleService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OsbleServiceClient : System.ServiceModel.ClientBase<OSBLE.UnitTests.OsbleService.OsbleService>, OSBLE.UnitTests.OsbleService.OsbleService {
        
        public OsbleServiceClient() {
        }
        
        public OsbleServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OsbleServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OsbleServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OsbleServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public OSBLE.Models.Courses.Course[] GetCourses(string authToken) {
            return base.Channel.GetCourses(authToken);
        }
        
        public OSBLE.Models.Assignments.Assignment[] GetCourseAssignments(int courseId, string authToken) {
            return base.Channel.GetCourseAssignments(courseId, authToken);
        }
        
        public byte[] GetMergedReviewDocument(int criticalReviewAssignmentId, string authToken) {
            return base.Channel.GetMergedReviewDocument(criticalReviewAssignmentId, authToken);
        }
        
        public byte[] GetReviewItems(int assignmentId, string authToken) {
            return base.Channel.GetReviewItems(assignmentId, authToken);
        }
        
        public bool SubmitReview(int authorId, int assignmentId, byte[] zippedReviewData, string authToken) {
            return base.Channel.SubmitReview(authorId, assignmentId, zippedReviewData, authToken);
        }
        
        public byte[] GetAssignmentSubmission(int assignmentId, string authToken) {
            return base.Channel.GetAssignmentSubmission(assignmentId, authToken);
        }
        
        public OSBLE.Models.Courses.CourseRole GetCourseRole(int courseId, string authToken) {
            return base.Channel.GetCourseRole(courseId, authToken);
        }
        
        public bool SubmitAssignment(int assignmentId, byte[] zipData, string authToken) {
            return base.Channel.SubmitAssignment(assignmentId, zipData, authToken);
        }
    }
}
