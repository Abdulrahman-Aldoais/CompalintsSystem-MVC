using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompalintsSystem.EF.Migrations
{
    public partial class dfsaf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01e3584f-f3fa-4061-bc4b-44ff60589945");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1aea39a7-c741-4311-9ca5-c2361d2d03a4");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3acc070b-bc07-46dd-b681-e454ff675991");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "604a0844-7d1d-43ca-80eb-4e3dcf6e319a");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e52b0c02-0a16-4bf1-a9b9-7e518abf4370");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetRoles",
                columns: new[] { "Id", "ApplicationUserId", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4692153f-df40-4b9b-9576-53d68f468116", null, "fcde1ff8-7a51-4a61-a59c-6d99d7443035", "AdminGeneralFederation", "ADMINGENERALFEDERATION" },
                    { "c11a2ffe-8423-4212-b3f2-0f0f3a408ff8", null, "c5887824-ed90-4078-ab55-b2808a54148f", "AdminGovernorate", "ADMINGOVERNORATE" },
                    { "39782e25-1052-412a-abb1-5f9ac0afe3cf", null, "3939fbcd-76f7-4eb9-9b72-c3bdbcd331dd", "AdminDirectorate", "ADMINDIRECTORATE" },
                    { "287e9837-6be4-4e40-80f9-eeabb942fc9f", null, "d4ff11b1-ae59-47df-b7d1-8855226cf116", "AdminSubDirectorate", "ADMINSUBDIRECTORATE" },
                    { "8fd22020-0ce6-4037-850c-3045e1183c38", null, "f06b4ceb-d628-4b29-9241-5769f44cbe74", "Beneficiarie", "BENEFICIARIE" }
                });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeCommunications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 24, 23, 45, 16, 384, DateTimeKind.Local).AddTicks(6716));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeCommunications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 24, 23, 45, 16, 384, DateTimeKind.Local).AddTicks(6742));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 24, 23, 45, 16, 385, DateTimeKind.Local).AddTicks(4708));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 24, 23, 45, 16, 385, DateTimeKind.Local).AddTicks(5128));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "287e9837-6be4-4e40-80f9-eeabb942fc9f");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39782e25-1052-412a-abb1-5f9ac0afe3cf");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4692153f-df40-4b9b-9576-53d68f468116");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fd22020-0ce6-4037-850c-3045e1183c38");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c11a2ffe-8423-4212-b3f2-0f0f3a408ff8");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetRoles",
                columns: new[] { "Id", "ApplicationUserId", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01e3584f-f3fa-4061-bc4b-44ff60589945", null, "c4773d4a-9cc2-47a3-af0b-084d3bc37c4f", "AdminGeneralFederation", "ADMINGENERALFEDERATION" },
                    { "1aea39a7-c741-4311-9ca5-c2361d2d03a4", null, "cff46487-ee5c-42a9-bf06-d25b44166d34", "AdminGovernorate", "ADMINGOVERNORATE" },
                    { "604a0844-7d1d-43ca-80eb-4e3dcf6e319a", null, "765ae1ba-6f7c-4382-865d-4d7cf7c4ffc3", "AdminDirectorate", "ADMINDIRECTORATE" },
                    { "e52b0c02-0a16-4bf1-a9b9-7e518abf4370", null, "ace48485-4e54-4b4c-893a-4eba3a2c05dd", "AdminSubDirectorate", "ADMINSUBDIRECTORATE" },
                    { "3acc070b-bc07-46dd-b681-e454ff675991", null, "c8b66d84-b2fe-4077-b346-f38c5fcaeabb", "Beneficiarie", "BENEFICIARIE" }
                });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeCommunications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 6, 0, 10, 29, 973, DateTimeKind.Local).AddTicks(3712));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeCommunications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 6, 0, 10, 29, 973, DateTimeKind.Local).AddTicks(3726));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 6, 0, 10, 29, 973, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 6, 0, 10, 29, 974, DateTimeKind.Local).AddTicks(175));
        }
    }
}
