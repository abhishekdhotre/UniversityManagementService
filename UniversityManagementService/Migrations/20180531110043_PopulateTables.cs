using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityManagementService.Migrations
{
    public partial class PopulateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Universities"
                , new string[] { "Id", "Description", "ImagePath", "Name" }
                , new object[] { 1
                , "The University of Texas at Arlington is a growing Carnegie Research-1 highest research activity powerhouse committed to life-enhancing discovery, innovative instruction, and caring community engagement. An educational leader in the heart of the thriving North Texas region, UTA nurtures minds within an environment that values excellence, ingenuity, and diversity."
                , "https://www.uta.edu/ucomm/identity/pix/UTA_A-logo.jpg"
                , "University of Texas at Arlington" });

            migrationBuilder.InsertData("Universities"
                , new string[] { "Id", "Description", "ImagePath", "Name" }
                , new object[] { 2
                , "Established by Eugene McDermott, J. Erik Jonsson and Cecil Green, the founders of Texas Instruments, UT Dallas is a young institution driven by the entrepreneurial spirit of its founders and their commitment to academic excellence. In 1969, the public research institution joined The University of Texas System and became The University of Texas at Dallas."
                , "http://www.freelogovectors.net/wp-content/uploads/2018/03/ut-dallas-logo02.png"
                , "University of Texas at Dallas" });

            migrationBuilder.InsertData("Universities"
                , new string[] { "Id", "Description", "ImagePath", "Name" }
                , new object[] { 3
                , "Like the state it calls home, The University of Texas at Austin is a bold, ambitious leader. Ranked among the biggest and best research universities in the country, UT Austin is home to more than 51,000 students and 3,000 teaching faculty."
                , "https://upload.wikimedia.org/wikipedia/en/thumb/e/e1/University_of_Texas_at_Austin_seal.svg/1200px-University_of_Texas_at_Austin_seal.svg.png"
                , "University of Texas at Austin" });

            migrationBuilder.InsertData("Schools",
                new string[] { "Id", "Name", "UniversityId" },
                new object[] { 1, "College Of Engineering", 1 });

            migrationBuilder.InsertData("Schools",
                new string[] { "Id", "Name", "UniversityId" },
                new object[] { 2, "College Of Education", 1 });

            migrationBuilder.InsertData("Schools",
                new string[] { "Id", "Name", "UniversityId" },
                new object[] { 3, "Erik Jonsson School of Engineering and Computer Science", 2 });

            migrationBuilder.InsertData("Schools",
                new string[] { "Id", "Name", "UniversityId" },
                new object[] { 4, "Naveen Jindal School of Management", 2 });

            migrationBuilder.InsertData("Schools",
                new string[] { "Id", "Name", "UniversityId" },
                new object[] { 5, "Cockrell School of Engineering", 3 });

            migrationBuilder.InsertData("Schools",
                new string[] { "Id", "Name", "UniversityId" },
                new object[] { 6, "Dell Medical School", 3 });

            migrationBuilder.InsertData("Departments",
                new string[] { "Id", "Name", "SchoolId" },
                new object[] { 1, "Department of Computer Science", 1 });

            migrationBuilder.InsertData("Departments",
                new string[] { "Id", "Name", "SchoolId" },
                new object[] { 2, "Department of Mechanical Engineering", 1 });

            migrationBuilder.InsertData("Departments",
                new string[] { "Id", "Name", "SchoolId" },
                new object[] { 3, "Department of Software Engineering", 3 });

            migrationBuilder.InsertData("Departments",
                new string[] { "Id", "Name", "SchoolId" },
                new object[] { 4, "Department of Industrial Engineering", 3 });

            migrationBuilder.InsertData("Departments",
                new string[] { "Id", "Name", "SchoolId" },
                new object[] { 5, "Management in Information Science Department", 4 });

            migrationBuilder.InsertData("Departments",
                new string[] { "Id", "Name", "SchoolId" },
                new object[] { 6, "Aerospace Engineering", 5 });

            migrationBuilder.InsertData("Departments",
                new string[] { "Id", "Name", "SchoolId" },
                new object[] { 7, "Department of Nursing", 6 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
