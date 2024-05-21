-- Person View
CREATE OR ALTER VIEW view_Person AS
SELECT 
    P.Id, 
    P.[Name], 
    P.FirstLastName, 
    P.SecondLastName, 
    CONCAT( P.[Name], ' ', P.FirstLastName, ' ', P.SecondLastName) FullName,
    JSON_QUERY((
        SELECT 
            C.Data ContactData,
            C.[State] [State],
            CT.Detail ContactType
        FROM Contact C
        JOIN catalog_ContactType CT ON C.ContactType_Id = CT.Id
        WHERE C.Person_Id = P.Id
        FOR JSON AUTO
    )) AS Contacts
FROM Person P
GO
-- User View
CREATE OR ALTER VIEW view_User AS
SELECT 
    U.[Name], 
    U.Password, 
    U.UserType_Id, 
    U.Person_Id, 
    U.[Date], 
    U.UpdateDate, 
    U.[State],
    JSON_QUERY((
        SELECT 
            *
        FROM view_Person P
        WHERE P.Id = U.Person_Id
        FOR JSON AUTO
    )) AS Person,
    JSON_QUERY((
        SELECT 
            SS.Detail SoftSkill,
            UHSS.[State] [State]
        FROM User_has_SoftSkills UHSS
        JOIN catalog_SoftSkills SS ON UHSS.SoftSkills_Id = SS.Id
        WHERE UHSS.User_Name = U.[Name]
        FOR JSON AUTO
    )) AS SoftSkills
FROM [User] U
GO

SELECT * FROM view_User;