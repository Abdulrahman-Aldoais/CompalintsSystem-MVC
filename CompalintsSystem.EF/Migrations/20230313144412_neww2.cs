using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompalintsSystem.EF.Migrations
{
    public partial class neww2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
