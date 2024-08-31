CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE activities (
    "Id" uuid NOT NULL,
    "Name" character varying(128) NOT NULL,
    "Admin" character varying(128) NOT NULL,
    "Start" timestamp with time zone NOT NULL,
    "Finish" timestamp with time zone NOT NULL,
    "Preview" uuid NOT NULL,
    "Link" character varying(128) NOT NULL,
    CONSTRAINT "PK_activities" PRIMARY KEY ("Id")
);

CREATE TABLE users_info (
    "EmailAddress" character varying(128) NOT NULL,
    "AvatarImgLink" character varying(32),
    "Nickname" character varying(32),
    "FirstName" character varying(32),
    "LastName" character varying(32),
    "MiddleName" character varying(32),
    "Course" character varying(32),
    "BannedBy" character varying(128),
    CONSTRAINT "PK_users_info" PRIMARY KEY ("EmailAddress")
);

CREATE TABLE verification_requests (
    "Id" uuid NOT NULL,
    "Student" character varying(128) NOT NULL,
    "EventName" character varying(128) NOT NULL,
    "Description" character varying(512) NOT NULL,
    "CreatedAt" timestamp with time zone NOT NULL,
    "Status" text NOT NULL,
    CONSTRAINT "PK_verification_requests" PRIMARY KEY ("Id")
);

CREATE TABLE achievements (
    "Id" uuid NOT NULL,
    "Admin" character varying(128) NOT NULL,
    "Score" real NOT NULL,
    "requestId" uuid NOT NULL,
    CONSTRAINT "PK_achievements" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_achievements_verification_requests_requestId" FOREIGN KEY ("requestId") REFERENCES verification_requests ("Id") ON DELETE CASCADE
);

CREATE TABLE comments (
    "Id" uuid NOT NULL,
    "Admin" character varying(128) NOT NULL,
    "Message" character varying(512) NOT NULL,
    "requestId" uuid NOT NULL,
    CONSTRAINT "PK_comments" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_comments_verification_requests_requestId" FOREIGN KEY ("requestId") REFERENCES verification_requests ("Id") ON DELETE CASCADE
);

CREATE TABLE images (
    "Guid" uuid NOT NULL,
    "RequestId" uuid NOT NULL,
    CONSTRAINT "PK_images" PRIMARY KEY ("Guid"),
    CONSTRAINT "FK_images_verification_requests_RequestId" FOREIGN KEY ("RequestId") REFERENCES verification_requests ("Id") ON DELETE CASCADE
);

CREATE UNIQUE INDEX "IX_achievements_requestId" ON achievements ("requestId");

CREATE UNIQUE INDEX "IX_comments_requestId" ON comments ("requestId");

CREATE INDEX "IX_images_RequestId" ON images ("RequestId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240827103001_Init', '8.0.4');

COMMIT;

