using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompalintsSystem.EF.Migrations
{
    public partial class newc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fd9b8c0-353d-432b-b675-3ea5aa3cd5ed");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91792a90-d2a1-4c26-96fa-7dedd90d89cb");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97909c23-fa13-432c-8127-f4ec7644e6d9");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac1b8714-af11-427c-a96f-76ed3aa52777");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6a3325f-4b52-45c3-9058-410554952374");

            migrationBuilder.AddColumn<string>(
                name: "UserRoleName",
                schema: "Identity",
                table: "UploadsComplaintes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetRoles",
                columns: new[] { "Id", "ApplicationUserId", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "34a77758-8402-4104-ae1a-14e854d90f38", null, "f1565658-2aea-47ef-9949-49b4303fff6b", "AdminGeneralFederation", "ADMINGENERALFEDERATION" },
                    { "9b5dd56a-1501-4ac2-bc37-2e390ed3febd", null, "019cb24e-adba-4d33-9efb-a15ddcdff40f", "AdminGovernorate", "ADMINGOVERNORATE" },
                    { "0b0fc9d2-3783-4c3b-a0b8-0c80c773dfa4", null, "ad2550b8-7990-4eb3-abcb-dc064181181f", "AdminDirectorate", "ADMINDIRECTORATE" },
                    { "fb18d034-2618-466c-a8a1-203e4b85e120", null, "32b6a1a3-d9bd-4a5d-86e1-6025bd7076de", "AdminSubDirectorate", "ADMINSUBDIRECTORATE" },
                    { "5fd906ab-a068-4439-8568-654ad2a7c27c", null, "45bc40a9-7f6d-47ce-9923-d6a67d02414f", "Beneficiarie", "BENEFICIARIE" }
                });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeCommunications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 4, 23, 59, 35, 494, DateTimeKind.Local).AddTicks(4500));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeCommunications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 4, 23, 59, 35, 494, DateTimeKind.Local).AddTicks(4547));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 4, 23, 59, 35, 497, DateTimeKind.Local).AddTicks(9748));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 4, 23, 59, 35, 498, DateTimeKind.Local).AddTicks(1674));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b0fc9d2-3783-4c3b-a0b8-0c80c773dfa4");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34a77758-8402-4104-ae1a-14e854d90f38");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fd906ab-a068-4439-8568-654ad2a7c27c");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b5dd56a-1501-4ac2-bc37-2e390ed3febd");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb18d034-2618-466c-a8a1-203e4b85e120");

            migrationBuilder.DropColumn(
                name: "UserRoleName",
                schema: "Identity",
                table: "UploadsComplaintes");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetRoles",
                columns: new[] { "Id", "ApplicationUserId", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "91792a90-d2a1-4c26-96fa-7dedd90d89cb", null, "a0e6b9cd-0b6d-4abc-81cd-71b3168a1a2b", "AdminGeneralFederation", "ADMINGENERALFEDERATION" },
                    { "97909c23-fa13-432c-8127-f4ec7644e6d9", null, "429269d1-d1c4-4985-97a0-27b99fee5861", "AdminGovernorate", "ADMINGOVERNORATE" },
                    { "4fd9b8c0-353d-432b-b675-3ea5aa3cd5ed", null, "6c9d3274-edb5-4140-880e-d7dc08ebd6dc", "AdminDirectorate", "ADMINDIRECTORATE" },
                    { "ac1b8714-af11-427c-a96f-76ed3aa52777", null, "298567ce-0f9a-4a30-a750-e9698abaa91e", "AdminSubDirectorate", "ADMINSUBDIRECTORATE" },
                    { "f6a3325f-4b52-45c3-9058-410554952374", null, "4089713f-0e29-49e5-bf9c-88e1a0d7c8bc", "Beneficiarie", "BENEFICIARIE" }
                });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeCommunications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 3, 22, 51, 28, 811, DateTimeKind.Local).AddTicks(3587));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeCommunications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 3, 22, 51, 28, 811, DateTimeKind.Local).AddTicks(3638));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 3, 22, 51, 28, 812, DateTimeKind.Local).AddTicks(6314));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 3, 22, 51, 28, 812, DateTimeKind.Local).AddTicks(7031));
        }
    }
}
