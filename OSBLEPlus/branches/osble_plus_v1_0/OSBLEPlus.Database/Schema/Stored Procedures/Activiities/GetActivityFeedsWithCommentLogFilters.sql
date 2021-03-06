﻿-------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------
-- sproc [GetActivityFeedsWithCommentLogFilters]
-------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[GetActivityFeedsWithCommentLogFilters] @DateReceivedMin DATETIME='01-01-2010',
                                                                     @DateReceivedMax DATETIME,
                                                                     @MinEventLogId   INT=-1,
                                                                     @MaxEventLogId   INT=2147483647,
                                                                     @CourseId        INT=-1,
                                                                     @RoleId          INT=99,
                                                                     @CommentFilter   NVARCHAR(max)='',
                                                                     @TopN            INT=20,
                                                                     @anyCourse       INT=-1
AS
  BEGIN
      SET NOCOUNT ON;

      INSERT INTO #events
      SELECT TOP(@TopN) EventLogId = s.Id,
                        s.EventTypeId,
                        s.EventDate,
                        s.SenderId,
                        s.CourseId,
                        1
      FROM   [dbo].[EventLogs] s WITH (NOLOCK)
             INNER JOIN #eventTypesFilter ef
                     ON ef.EventTypeId = s.EventTypeId
             INNER JOIN [dbo].[UserProfiles] u WITH (NOLOCK)
                     ON u.ID = s.SenderId
             INNER JOIN [dbo].[CourseUsers] cr WITH (NOLOCK)
                     ON cr.UserProfileID = s.SenderId
                        AND ( cr.AbstractCourseID = @CourseId
                               OR @CourseId = @anyCourse )
                        AND ( cr.AbstractRoleID = @RoleId
                               OR @RoleId = 99 )
             LEFT JOIN (SELECT buildErrors=Count(BuildErrorTypeId),
                               LogId
                        FROM   [dbo].[BuildErrors] WITH (NOLOCK)
                        GROUP  BY LogId) be
                    ON s.Id = be.LogId
                       AND ef.EventTypeId = 2
                       AND be.buildErrors > 0
             INNER JOIN #eventLogIdFilter eif
                     ON eif.Id = s.Id
             LEFT JOIN [dbo].[FeedPostEvents] fp
                    ON fp.EventLogId = s.Id
                       AND fp.Comment LIKE @CommentFilter
                       AND ef.EventTypeId = 7
                       AND fp.Id > 0
			 LEFT JOIN [dbo].[AskForHelpEvents] afh
				    ON afh.EventLogId = s.Id
					   AND afh.UserComment LIKE @CommentFilter
					   AND ef.EventTypeId = 1
					   AND fp.Id > 0
      WHERE  s.[DateReceived] BETWEEN @DateReceivedMin AND @DateReceivedMax
             AND s.[Id] BETWEEN @MinEventLogId AND @MaxEventLogId
			 AND (s.[IsDeleted] IS NULL OR s.[IsDeleted] = 0)
			 AND (s.[CourseId] = @CourseId
				 OR s.[CourseId] IS NULL
				 OR @CourseId = @anyCourse)
		     AND s.EventTypeId != 8
	  GROUP BY s.Id, s.EventTypeId, s.EventDate, s.SenderId, s.CourseId
      ORDER  BY s.EventDate DESC

  END 
