using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompalintsSystem.EF.Migrations
{
    public partial class newsadf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38364aac-8443-4859-ac64-20aa469be6ac");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "573c553c-0b2d-4f33-b473-a9236f441f1b");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74bed645-9abf-45cc-ae2c-1a7058d9d0cf");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac14474e-25b0-42a8-8b0c-46008734c551");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e06f4aaa-96de-4ba4-940f-e48e0780ab85");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetRoles",
                columns: new[] { "Id", "ApplicationUserId", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "562f6123-9b88-4c8b-8f19-fe5c06965389", null, "d22d3299-e5e1-4710-ba11-6e58a9ef0138", "AdminGeneralFederation", "ADMINGENERALFEDERATION" },
                    { "c8e888e4-5329-4209-bc9f-f7a4e8beee8f", null, "41a6d381-b660-4983-bbff-2d055f09b329", "AdminGovernorate", "ADMINGOVERNORATE" },
                    { "ce91a16c-4cc4-4230-a468-c89825d32587", null, "afc12527-7c36-411e-9e31-4c9da3cde8a2", "AdminDirectorate", "ADMINDIRECTORATE" },
                    { "6418c02a-82fc-4b7a-b295-455447ce0f50", null, "314da243-7f42-47d8-a398-dbfc5172b0a2", "AdminSubDirectorate", "ADMINSUBDIRECTORATE" },
                    { "93e367ce-937d-4fc6-972b-4cd24cfd5f5b", null, "053effa8-be57-4998-bf8e-338adf49395f", "Beneficiarie", "BENEFICIARIE" }
                });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeCommunications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 20, 2, 49, 34, 845, DateTimeKind.Local).AddTicks(2679));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeCommunications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 20, 2, 49, 34, 845, DateTimeKind.Local).AddTicks(2698));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 20, 2, 49, 34, 845, DateTimeKind.Local).AddTicks(9644));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 20, 2, 49, 34, 846, DateTimeKind.Local).AddTicks(43));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "562f6123-9b88-4c8b-8f19-fe5c06965389");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6418c02a-82fc-4b7a-b295-455447ce0f50");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93e367ce-937d-4fc6-972b-4cd24cfd5f5b");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8e888e4-5329-4209-bc9f-f7a4e8beee8f");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce91a16c-4cc4-4230-a468-c89825d32587");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetRoles",
                columns: new[] { "Id", "ApplicationUserId", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e06f4aaa-96de-4ba4-940f-e48e0780ab85", null, "0df934f9-6207-43b3-88e5-9d6084a12664", "AdminGeneralFederation", "ADMINGENERALFEDERATION" },
                    { "38364aac-8443-4859-ac64-20aa469be6ac", null, "b451fd6f-9326-40b1-b818-0f48802149e2", "AdminGovernorate", "ADMINGOVERNORATE" },
                    { "74bed645-9abf-45cc-ae2c-1a7058d9d0cf", null, "63b66697-e7e2-4543-acf8-31388cb9bd0d", "AdminDirectorate", "ADMINDIRECTORATE" },
                    { "ac14474e-25b0-42a8-8b0c-46008734c551", null, "f3a87a94-2ea2-43d1-9d8e-2666a4f2e569", "AdminSubDirectorate", "ADMINSUBDIRECTORATE" },
                    { "573c553c-0b2d-4f33-b473-a9236f441f1b", null, "fffc1f96-3036-431d-993c-63ac23771d79", "Beneficiarie", "BENEFICIARIE" }
                });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeCommunications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 13, 17, 44, 10, 37, DateTimeKind.Local).AddTicks(6391));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeCommunications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 13, 17, 44, 10, 37, DateTimeKind.Local).AddTicks(6421));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 13, 17, 44, 10, 38, DateTimeKind.Local).AddTicks(7387));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 13, 17, 44, 10, 38, DateTimeKind.Local).AddTicks(8195));
        }
    }
}
