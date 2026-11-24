BEGIN IMMEDIATE;

INSERT INTO "Students" ("Id", "Name")
VALUES
    (9001, 'Sample Student One'),
    (9002, 'Sample Student Two')
ON CONFLICT ("Id") DO UPDATE SET
    "Name" = excluded."Name";

INSERT INTO "SwimClasses" ("Id", "Name", "Capacity")
VALUES
    (9001, 'Sample Class - No Enrollments', 2),
    (9002, 'Sample Class - One Enrollment', 2),
    (9003, 'Sample Class - Two Enrollments', 2)
ON CONFLICT ("Id") DO UPDATE SET
    "Name" = excluded."Name",
    "Capacity" = excluded."Capacity";

INSERT INTO "Enrollments" ("Id", "StudentId", "SwimClassId")
VALUES
    (9001, 9001, 9002),
    (9002, 9001, 9003),
    (9003, 9002, 9003)
ON CONFLICT ("Id") DO UPDATE SET
    "StudentId" = excluded."StudentId",
    "SwimClassId" = excluded."SwimClassId";

COMMIT;
