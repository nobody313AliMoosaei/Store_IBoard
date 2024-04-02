
-- where  Id={cmd.StudentId}   order by [TimeYearTypeId] desc ,[GradeTypeId] desc ,[TimeDoreTypeId] desc
-- where  Id={studentId}        and [TimeYearTypeId] =1402              and studentStateTypeId in (1,3,5)   order by [GradeTypeId] desc ,[TimeDoreTypeId]
-- where  Id ={studentId}       and [TimeYearTypeId] = {year}           and [timeDoreTypeId] ={dore}        order by [GradeTypeId] desc
-- where  Id ={studentId}       and [TimeYearTypeId] = {year}           and [timeDoreTypeId] ={dore}        order by [GradeTypeId] desc
-- where  Id={studentId}        and [TimeYearTypeId]= 1401              and [timeDoreTypeId] = 1            order by [GradeTypeId] desc
-- where  Id={studentId}        and [TimeYearTypeId]= 1401              and BirthDate={birthDate}           order by [GradeTypeId] desc
-- where  Id={studentId}        and [TimeYearTypeId]= 1401              and BirthDate={birthDate}           order by [GradeTypeId] desc
-- where  Id={studentId}        and [TimeYearTypeId]= {timeYearTypeId}  and [timeDoreTypeId] ={timeDoreTypeId}  and  StudentStateTypeId in (1,3,5) order by [GradeTypeId] desc
-- where  Id={studentId}        and [TimeYearTypeId]= {timeYearTypeId}  and [timeDoreTypeId] ={timeDoreTypeId}  and  StudentStateTypeId in (1,3,5) order by [GradeTypeId] desc
-- where  Id={studentId}        and [TimeYearTypeId]= {timeYearTypeId}  and [timeDoreTypeId] ={timeDoreTypeId}  and  StudentStateTypeId in (1,3,5) order by [GradeTypeId] desc

/*

*/

-- ABCDEF
/*
ABCDEF
ABCDE
FBCDE

*/
CREATE OR ALTER [dbo].[USP_Student]

--  DECLARE 
        @StudentId NVARCHAR(50) = 125,
        @TimeYearTypeId NVARCHAR(50) = NULL,
        @TimeDoreTypeId NVARCHAR(50) = NULL,
        @BirthDate NVARCHAR(50) = NULL,
        @StudentStateTypeId NVARCHAR(50)= NULL,
        @StudentStateTypeId2 NVARCHAR(50)= NULL,
        @StudentStateTypeId3 NVARCHAR(50)= NULL,
        @OrderBy_TimeYearTypeId BIT = NULL,
        @OrderBy_TimeYearTypeId_DESC BIT = NULL,
        @OrderBy_GradeTypeId BIT = 1,
        @OrderBy_GradeTypeId_DESC BIT = NULL,
        @OrderBy_TimeDoreTypeId BIT = 1,
        @OrderBy_TimeDoreTypeId_DESC BIT = NULL;

AS 
BEGIN

DECLARE @SqlQuery NVARCHAR(MAX) = N'
SELECT 
sc.Tel,
sc.Address, 
sc.SchoolModelType_Id AS SchoolModelTypeId,
sc.OrganizationType_Id AS OrganizationTypeId, 
h.Id AS HistoryId,
s.Id,
s.DanaStudentCode,
s.NationalCode,
s.FirstName,
s.FatherName,
s.LastName, 
s.IDno, 
s.IssuePlace, 
s.SabtPlaceCode, 
s.BirthDate, 
s.BirthPlace, 
s.SexType_Id AS SexTypeId, 
s.SerialID, 
s.SeriType_Id AS SeriTypeId,
s.RadifID,
s.EntranceTimeYearType_Id AS EntranceTimeYearTypeId,
h.State_Id AS StateId, 
h.Region_Id AS RegionId,
h.School_Id AS SchoolId,
h.StageType_Id AS StageTypeId,
h.GradeType_Id AS GradeTypeId, 
h.Major_Id AS MajorId,
h.ClassRoom_Id AS ClassRoomId,
h.TimeYearType_Id AS TimeYearTypeId,
h.TimeDoreType_Id AS TimeDoreTypeId, 
s.StudentType_Id AS StudentTypeId,
h.StudentStateType_Id AS StudentStateTypeId,
s.JaheshiRahnamaee,
s.ReligionType_Id AS ReligionTypeId,
s.NationalityType_Id AS NationalityTypeId,
s.MazhabType_Id AS MazhabTypeId,
s.FamilyStateType_Id AS FamilyStateTypeId, 
s.FatherMadrakType_Id AS FatherMadrakTypeId,
s.FatherJobType_Id AS FatherJobTypeId,
s.MotherMadrakType_Id AS MotherMadrakTypeId,
s.MotherJobType_Id AS MotherJobTypeId, 
s.BodyStateType_Id AS BodyStateTypeId, 
s.LeftHand,
s.SeekType_Id AS SeekTypeId,
s.SoldierStateType_Id AS SoldierStateTypeId,
s.MarriageStateType_Id AS MarriageStateTypeId, 
s.HouseStateType_Id AS HouseStateTypeId,
s.HomeAddress, 
s.HomePostalCode, 
s.OtherNationalCode, 
s.MotherLastName ,
s.MotherName, 
s.HomeTelephone, 
s.FatherMobileNumber, 
s.MotherMobileNumber, 
s.FatherNationalCode,
s.MotherNationalCode,
s.StudentMobileNumber, 
s.StudentEmailAddress,
r.Title AS RegionTitle, 
st.Title AS StateTitle, 
sc.Title AS SchoolTitle, 
m.Title AS MajorTitle,
s.Sarparast as Sarparast,
FatherIDno,
FatherIssuePlace,
[FatherBirthDate],
[MotherBirthDate],
[OtherBirthDate],
[StudentMobileGoverment],
FatherWorkAddress,
MotherWorkAddress,
FatherInsuranceNumber,
MotherInsuranceNumber
FROM                     dbo.History AS h WITH (NOLOCK) INNER JOIN
                         dbo.Student AS s WITH (NOLOCK) ON h.Student_Id = s.Id INNER JOIN 
                         dbo.Region AS r WITH (NOLOCK) ON h.Region_Id = r.Id INNER JOIN
                         dbo.State AS st WITH (NOLOCK) ON h.State_Id = st.Id LEFT OUTER JOIN
                         dbo.Major AS m WITH (NOLOCK) ON h.Major_Id = m.Id INNER JOIN
                         dbo.School AS sc WITH (NOLOCK) ON h.School_Id = sc.Id
                         WHERE 1=1 ';

IF @StudentId IS NOT NULL
    SET @SqlQuery = @SqlQuery + 'AND s.Id = ' + @StudentId;

IF @TimeYearTypeId IS NOT NULL
    SET @SqlQuery = @SqlQuery + ' AND h.TimeYearType_Id = ' + @TimeYearTypeId;

IF @TimeDoreTypeId IS NOT NULL
    SET @SqlQuery = @SqlQuery + ' AND h.TimeDoreType_Id = '+@TimeDoreTypeId;

IF @BirthDate IS NOT NULL
    SET @SqlQuery =@SqlQuery + ' AND s.BirthDate = ' + @BirthDate;

IF @StudentStateTypeId IS NOT NULL AND @StudentStateTypeId2 IS NOT NULL AND @StudentStateTypeId3 IS NOT NULL
    SET @SqlQuery = @SqlQuery + ' AND h.StudentStateType_Id IN (' + @StudentStateTypeId + ' , ' + @StudentStateTypeId2 + ' , ' + @StudentStateTypeId3 + ')';
ELSE IF @StudentStateTypeId IS NOT NULL AND @StudentStateTypeId2 IS NOT NULL
    SET @SqlQuery = @SqlQuery + ' AND h.StudentStateType_Id IN (' + @StudentStateTypeId + ' , ' + @StudentStateTypeId2 + ')';
ELSE IF @StudentStateTypeId IS NOT NULL AND @StudentStateTypeId3 IS NOT NULL
    SET @SqlQuery = @SqlQuery + ' AND h.StudentStateType_Id IN (' + @StudentStateTypeId + ' , ' + @StudentStateTypeId3 + ')';
ELSE IF @StudentStateTypeId3 IS NOT NULL AND @StudentStateTypeId2 IS NOT NULL
    SET @SqlQuery = @SqlQuery + ' AND h.StudentStateType_Id IN (' + @StudentStateTypeId3 + ' , ' + @StudentStateTypeId2 + ')';
ELSE IF @StudentStateTypeId IS NOT NULL
    SET @SqlQuery = @SqlQuery + ' AND h.StudentStateType_Id  = ' + @StudentStateTypeId;
ELSE IF @StudentStateTypeId2 IS NOT NULL
    SET @SqlQuery = @SqlQuery + ' AND h.StudentStateType_Id  = ' + @StudentStateTypeId2;
ELSE IF @StudentStateTypeId3 IS NOT NULL
    SET @SqlQuery = @SqlQuery + ' AND h.StudentStateType_Id  = ' + @StudentStateTypeId3;


-- Order by
IF @OrderBy_GradeTypeId IS NOT NULL OR @OrderBy_GradeTypeId_DESC IS NOT NULL
    OR @OrderBy_TimeDoreTypeId IS NOT NULL OR @OrderBy_TimeDoreTypeId_DESC IS NOT NULL
    OR @OrderBy_TimeYearTypeId IS NOT NULL OR @OrderBy_TimeYearTypeId_DESC IS NOT NULL
BEGIN
    SET @SqlQuery = @SqlQuery + ' ORDER BY ';
    DECLARE @Flag BIT = 0;
    IF @OrderBy_TimeYearTypeId IS NOT NULL
        BEGIN
            IF @Flag = 0
                BEGIN
                    SET @SqlQuery = @SqlQuery + ' h.TimeYearType_Id ';
                    SET @Flag = 1;
                END
            ELSE
                SET @SqlQuery = @SqlQuery +  ' , h.TimeYearType_Id ';
        END;

    IF @OrderBy_TimeYearTypeId_DESC IS NOT NULL
        BEGIN
            IF @Flag = 0
                BEGIN
                    SET @SqlQuery = @SqlQuery + ' h.TimeYearType_Id DESC ';
                    SET @Flag = 1;
                END
            ELSE
                SET @SqlQuery = @SqlQuery +  ' , h.TimeYearType_Id DESC ';
        END;


    IF @OrderBy_GradeTypeId IS NOT NULL
        BEGIN
            IF @Flag = 0
                BEGIN
                    SET @SqlQuery = @SqlQuery + ' h.GradeType_Id ';
                    SET @Flag = 1;
                END;

            ELSE
                SET @SqlQuery = @SqlQuery +  ' , h.GradeType_Id ';
        END;


    IF @OrderBy_GradeTypeId_DESC IS NOT NULL
        BEGIN
            IF @Flag = 0
                BEGIN
                    SET @SqlQuery = @SqlQuery + ' h.GradeType_Id DESC ';
                    SET @Flag = 1;
                END;

            ELSE
                SET @SqlQuery = @SqlQuery +  ' , h.GradeType_Id DESC ';
        END;


    IF @OrderBy_TimeDoreTypeId IS NOT NULL
        BEGIN
            IF @Flag = 0
                BEGIN
                    SET @SqlQuery = @SqlQuery + ' h.TimeDoreType_Id ';
                    SET @Flag = 1;
                END;

            ELSE
                SET @SqlQuery = @SqlQuery +  ' , h.TimeDoreType_Id ';
        END;


    IF @OrderBy_TimeDoreTypeId_DESC IS NOT NULL
        BEGIN
            IF @Flag = 0
                BEGIN
                    SET @SqlQuery = @SqlQuery + ' h.TimeDoreType_Id DESC ';
                    SET @Flag = 1;
                END;

            ELSE
                SET @SqlQuery = @SqlQuery +  ' , h.TimeDoreType_Id DESC ';
        END;
END
-- PRINT @SqlQuery;

EXEC @SqlQuery;

END;