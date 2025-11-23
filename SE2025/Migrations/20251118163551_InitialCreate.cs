using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SE2025.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Gender_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Gender_ID);
                });

            migrationBuilder.CreateTable(
                name: "User_Types",
                columns: table => new
                {
                    User_Type_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Types", x => x.User_Type_ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Type_ID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password_Hash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Is_Activated = table.Column<bool>(type: "bit", nullable: false),
                    Activation_Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_ID);
                    table.ForeignKey(
                        name: "FK_Users_User_Types_User_Type_ID",
                        column: x => x.User_Type_ID,
                        principalTable: "User_Types",
                        principalColumn: "User_Type_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carers",
                columns: table => new
                {
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    Availability_Schedule = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carers", x => x.User_ID);
                    table.ForeignKey(
                        name: "FK_Carers_Users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "Users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    Gender_ID = table.Column<int>(type: "int", nullable: false),
                    Date_of_Birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.User_ID);
                    table.ForeignKey(
                        name: "FK_Patients_Genders_Gender_ID",
                        column: x => x.Gender_ID,
                        principalTable: "Genders",
                        principalColumn: "Gender_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patients_Users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "Users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carer_Accesses",
                columns: table => new
                {
                    Access_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Carer_User_ID = table.Column<int>(type: "int", nullable: false),
                    Patient_User_ID = table.Column<int>(type: "int", nullable: false),
                    Permission_Level = table.Column<int>(type: "int", nullable: false),
                    Granted_By_User_ID = table.Column<int>(type: "int", nullable: false),
                    Revoked_By_User_ID = table.Column<int>(type: "int", nullable: false),
                    Granted_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Revoked_At = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carer_Accesses", x => x.Access_ID);
                    table.ForeignKey(
                        name: "FK_Carer_Accesses_Carers_Carer_User_ID",
                        column: x => x.Carer_User_ID,
                        principalTable: "Carers",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Carer_Accesses_Patients_Patient_User_ID",
                        column: x => x.Patient_User_ID,
                        principalTable: "Patients",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Gender_ID", "Name" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" },
                    { 3, "Other" }
                });

            migrationBuilder.InsertData(
                table: "User_Types",
                columns: new[] { "User_Type_ID", "Description", "Type_Name" },
                values: new object[,]
                {
                    { 1, "N/A", "Admin" },
                    { 2, "N/A", "Clinician" },
                    { 3, "N/A", "Patient" },
                    { 4, "N/A", "Carer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "User_ID", "Activation_Code", "Created_At", "Email", "First_Name", "Is_Activated", "Last_Name", "Password_Hash", "Status", "Title", "User_Type_ID" },
                values: new object[,]
                {
                    { 1, "ABC123", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.smith@example.com", "John", true, "Smith", "hash123", "Active", "Mr", 4 },
                    { 2, "DEF456", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "sarah.j@example.com", "Sarah", true, "Johnson", "hash456", "Active", "Ms", 4 },
                    { 3, "GHI789", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "emma.w@example.com", "Emma", true, "Williams", "hash789", "Active", "Mrs", 3 },
                    { 4, "JKL101", new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael.b@example.com", "Michael", true, "Brown", "hash101", "Active", "Mr", 3 },
                    { 5, "MNO202", new DateTime(2024, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "dr.anderson@example.com", "Lisa", true, "Anderson", "hash202", "Active", "Dr", 2 }
                });

            migrationBuilder.InsertData(
                table: "Carers",
                columns: new[] { "User_ID", "Availability_Schedule" },
                values: new object[,]
                {
                    { 1, "Mon-Fri 9am-5pm" },
                    { 2, "Tue-Thu 10am-4pm" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "User_ID", "Date_of_Birth", "Gender_ID", "Notes" },
                values: new object[,]
                {
                    { 3, new DateTime(1985, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "N/A" },
                    { 4, new DateTime(1992, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "N/A" }
                });

            migrationBuilder.InsertData(
                table: "Carer_Accesses",
                columns: new[] { "Access_ID", "Carer_User_ID", "Granted_At", "Granted_By_User_ID", "Patient_User_ID", "Permission_Level", "Revoked_At", "Revoked_By_User_ID" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 3, 2, null, 0 },
                    { 2, 1, new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 4, 3, null, 0 },
                    { 3, 2, new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 3, 1, null, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carer_Accesses_Carer_User_ID",
                table: "Carer_Accesses",
                column: "Carer_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Carer_Accesses_Patient_User_ID",
                table: "Carer_Accesses",
                column: "Patient_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Gender_ID",
                table: "Patients",
                column: "Gender_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_User_Type_ID",
                table: "Users",
                column: "User_Type_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carer_Accesses");

            migrationBuilder.DropTable(
                name: "Carers");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "User_Types");
        }
    }
}
