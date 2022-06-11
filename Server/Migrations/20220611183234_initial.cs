using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneBookv1.Server.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "e",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Department = table.Column<string>(nullable: false),
                    JobTitle = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    MobilePhoneNumber = table.Column<string>(nullable: false),
                    PhoneExtension = table.Column<string>(nullable: false),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_e", x => x.Id);
                });

            //migrationBuilder.InsertData(table: "MyTable",
            //    columns: 
            //    "EmployeeId", 
            //    "FirstName", 
            //    "LastName",
            //    "Department",



            //    value: 123,
            //    column: "FirstName",
            //    value: 123,
            //    column: "LastName",
            //    value: 123,
            //    column: "Department",
            //    value: 123,
            //    column: "JobTitle",
            //    value: 123,
            //    column: "Email",
            //    value: 123,
            //    column: "PhoneNumber",
            //    value: 123,
            //    column: "MobilePhoneNumber",
            //    value: 123,
            //    column: "PhoneExtension",
            //    value: 123,
            //    column: "Comments",
            //    value: 123);


            /////////////////////////////////////////////////
            //string InitializeData = "Insert into e" +
            //    "(" +
            //    "EmployeeId," +
            //    "FirstName," +
            //    "LastName," +
            //    "Department," +
            //    "JobTitle," +
            //    "Email," +
            //    "PhoneNumber," +
            //    "MobilePhoneNumber," +
            //    "PhoneExtension," +
            //    "Comments)" +
            //    "VALUES (" +
            //    "12345," +
            //    "5," +
            //    "5," +
            //    "5," +
            //    "5," +
            //    "5," +
            //    "5," +
            //    "5," +
            //    "5," +
            //    "5" +
            //    ")";
            //migrationBuilder.Sql(InitializeData);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "e");
        }
    }
}
